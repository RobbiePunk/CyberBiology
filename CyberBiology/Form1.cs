using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics;

using static CyberBiology.Constants;
using static CyberBiology.Simulation;
using static CyberBiology.CellFunctions;
using static CyberBiology.CellAditionalFunctions;
using static CyberBiology.ServiceFunctions;
using MathNet.Numerics.Random;
using System.Runtime.Serialization.Formatters.Binary;
using static System.Windows.Forms.AxHost;

namespace CyberBiology
{
    public partial class Form1 : Form
    {
        

        Barrier saveBarrier = new Barrier(2, (bar) =>
        {

        });

        Bitmap bmp;
        Bitmap bmpSave;
        
        Thread t;
        Graphics GR;
        Graphics GR_save;
        SolidBrush BR = new SolidBrush(Color.White);
        String SaveFileName;
        
        bool GO = false;
        bool performanceTest = false;

        bool isDrawing = false;
        bool wantToDraw = true;
        int drawInterval = 100;

        bool saveWorld = false;
        bool saveImage = false;
        bool tryToSave = false;
        public int worldSaveStep = 1000;
        public int imageSaveStep = 100;
        public int imageSaveSize = 10;
        public int[] imageSaveViewMode = { 1, 0, 0, 0};

        int xDrawStartIndex = 0;
        int yDrawStartIndex = 0;
        int xScreenSize = 1200;
        int yScreenSize = 650;

        int SPF = 1;

        

        //Cells step locals
        int cyc;
        int lv;

        public unsafe Form1()
        {
            InitializeComponent();
            WORLD_WIDTH = 180 * WorldSizeScroll.Value;
            WORLD_HEIGHT = 96 * WorldSizeScroll.Value;
            MAX_CELLS = WORLD_HEIGHT * WORLD_WIDTH + 1;

            cells = new int[MAX_CELLS, CELL_SIZE];
            drawCells = new int[MAX_CELLS, CELL_SIZE];
            world = new int[WORLD_WIDTH, WORLD_HEIGHT + 2];
            drawWorld = new int[WORLD_WIDTH, WORLD_HEIGHT + 2];

            bmp = new Bitmap(WORLD_BOX.Width, WORLD_BOX.Height);
            bmpSave = new Bitmap(1920, 1080);

            GR = Graphics.FromImage(bmp);
            GR_save = Graphics.FromImage(bmpSave);

            int x = 0;
            while(x < WORLD_WIDTH)
            {
                world[x, 0] = WC_WALL;
                world[x, WORLD_HEIGHT + 1] = WC_WALL;
                x++;
            }

            seed = new Random().Next();
            rand = new StateRandom(seed);

            drawWorld = (int[,])world.Clone();
            FirstCell();
            ScreenUpdate();
            WORLD_BOX.Invalidate();
        }

        public void OneStep()
        {
            season = seasons[currentSeason];

            CELL = cells[0, NEXT];
            cell_count = 0;
            while (CELL != 0)
            {
                cell_count++;
                CELL = cell_step(CELL);
            }
                
            Print_cell_count = cell_count;
            age++;

            if (imageSaveStep != 0 && age % imageSaveStep == 0 && saveImage)
                SaveImagePng();

            if (worldSaveStep != 0 && age % worldSaveStep == 0 && saveWorld)
                SaveWorldFile();

            if (age % 10000 == 0)
            {
                currentSeason = (currentSeason + 1) % seasons.Length;

                if (currentSeason == 0)
                    season_str = "Summer";
                else if (currentSeason == 1)
                    season_str = "Autumn";
                else if (currentSeason == 2)
                    season_str = "Winter";
                else if (currentSeason == 3)
                    season_str = "Spring";

                season = seasons[currentSeason];
            }
                
        }

        public void MainFunction()
        {
            season = seasons[currentSeason];
            while(GO)
                OneStep();
        }

        int cell_step(int num)
        {
            lv = cells[num, LIVING];
            if (lv == LV_DEAD)
            {
                Fall(num);
                Pressure(num);
                if(cells[num,PUSH] > 31)
                {
                    int x = cells[num, X_COORD];
                    int y = cells[num, Y_COORD];
                    if(cells[world[x,y - 1],LIVING] == LV_DEAD)
                    {
                        delete_cell(world[x, y - 1]);
                    }
                    cells[num, LIVING] = LV_EARTH;
                }
                return (cells[num, NEXT]);
            }
            if(lv == LV_EARTH  || lv == LV_FALLING_EARTH)
            {
                if(lv == LV_EARTH)
                {
                    
                }
                else if (lv == LV_FALLING_EARTH)
                {
                    Fall(num);
                }
                Pressure(num);
                if(cells[num,PUSH] >= 63)
                {
                    int x = cells[num, X_COORD];
                    int y = cells[num, Y_COORD];
                    if (cells[world[x, y - 1], LIVING] == LV_DEAD)
                    {
                        delete_cell(world[x, y - 1]);
                    }
                    cells[num, LIVING] = LV_STONE;
                }
                return (cells[num, NEXT]);
            }
            if(lv == LV_STONE)
            {
                return (cells[num, NEXT]);
            }
            cyc = 0;
        ag:
            cyc++;
            if (cyc < 10)
            {
                int command = cells[num, cells[num, ADR]];
                if(command == 22)//Деление с абсолютной сменой команды
                {
                    cell_double(num);
                    inc_command_address(num, 1);
                    goto Out;
                }
                else if (command == 23)//смена направления относительно
                {
                    int newdrct = (cells[num, DIRECT] + get_param(num)) % 8;

                    cells[num, DIRECT] = newdrct;
                    inc_command_address(num, newdrct + 1);
                    goto ag;
                }
                else if (command == 24)//смена направления абсолютно
                {
                    cells[num, DIRECT] = get_param(num) % 8;
                    inc_command_address(num, 2);
                    goto ag;
                }
                else if (command == 25)//фотосинтез
                {
                    fotosintez(num);
                    inc_command_address(num, 1);
                    goto Out;
                }
                else if (command == 26)//движение относительно
                {
                    int a = isMulti(num);
                    if (a == 0)
                    {
                        int drct = get_param(num) % 8;
                        indirect_inc_cmd_address(num, cell_move(num, drct, 0));
                    }
                    else if(a < 5)
                    {
                        int drct = get_param(num) % 8;
                        indirect_inc_cmd_address(num, cell_multi_move(num, drct, 0));
                    }
                    else
                    {
                        inc_command_address(num, 1);
                    }

                    goto Out;
                }
                else if (command == 27)//движение абсолютно
                {
                    int a = isMulti(num);
                    if (a == 0)
                    {
                        int drct = get_param(num) % 8;
                        indirect_inc_cmd_address(num, cell_move(num, drct, 1));
                    }
                    else if (a < 5)
                    {
                        int drct = get_param(num) % 8;
                        indirect_inc_cmd_address(num, cell_multi_move(num, drct, 1));
                    }
                    else
                    {
                        inc_command_address(num, 1);
                    }
                    goto Out;
                }
                else if (command == 28)//съесть в относителном направлении
                {
                    int drct = get_param(num) % 8;
                    indirect_inc_cmd_address(num, cell_eat(num, drct, 0));
                    goto Out;
                }
                else if (command == 29)//съесть в абсолютном направлении
                {
                    int drct = get_param(num) % 8;
                    indirect_inc_cmd_address(num, cell_eat(num, drct, 1));
                    goto Out;
                }
                else if (command == 30)//посмотреть в относительном направлении
                {
                    int drct = get_param(num) % 8;
                    indirect_inc_cmd_address(num, cell_look(num, drct, 0));
                    goto ag;
                }
                else if (command == 31)//посмотреть в абсолютном направлении
                {
                    int drct = get_param(num) % 8;
                    indirect_inc_cmd_address(num, cell_look(num, drct, 1));
                    goto ag;
                }
                else if (command == 32)//поделиться лишними ресурсами в относительном направлении
                {
                    int drct = get_param(num) % 8;
                    indirect_inc_cmd_address(num, cell_care(num, drct, 0));
                    goto ag;
                }
                else if (command == 33)//поделиться лишними ресурсами в абсолютном направлении
                {
                    int drct = get_param(num) % 8;
                    indirect_inc_cmd_address(num, cell_care(num, drct, 1));
                    goto ag;
                }
                else if (command == 34)//отдать ресурсы в относительном направлении
                {
                    int drct = get_param(num) % 8;
                    indirect_inc_cmd_address(num, cell_give(num, drct, 0));
                    goto ag;
                }
                else if (command == 35)//отдать ресурсы в абсолютном направлении
                {
                    int drct = get_param(num) % 8;
                    indirect_inc_cmd_address(num, cell_give(num, drct, 1));
                    goto ag;
                }
                else if (command == 36)//выровняться по горизонтали
                {
                    if (rand.Next() % 2 == 0)
                    {
                        cells[num, DIRECT] = 3;
                    }
                    else
                    {
                        cells[num, DIRECT] = 7;
                    }
                    inc_command_address(num, 1);
                    goto ag;
                }
                else if (command == 37)//узнать высоту
                {
                    float param = get_param(num) * WORLD_HEIGHT / 64;
                    if (cells[num, Y_COORD]  < param)
                    {
                        indirect_inc_cmd_address(num, 2);
                    }
                    else
                    {
                        indirect_inc_cmd_address(num, 3);
                    }
                    goto ag;
                }
                else if (command == 38)//узнать количество энергии
                {
                    int param = get_param(num) * 15;
                    if (cells[num, ENERGY] < param)
                    {
                        indirect_inc_cmd_address(num, 2);
                    }
                    else
                    {
                        indirect_inc_cmd_address(num, 3);
                    }
                    goto ag;
                }
                else if (command == 39)//узнать количество минералов
                {
                    int param = get_param(num) * 15;
                    if (cells[num, MINERAL] < param)
                    {
                        indirect_inc_cmd_address(num, 2);
                    }
                    else
                    {
                        indirect_inc_cmd_address(num, 3);
                    }
                    goto ag;
                }
                else if (command == 40)//многоклеточное деление
                {
                    cell_multi(num);
                    inc_command_address(num, 1);
                    goto Out;
                }
                else if (command == 41)//свободное деление
                {
                    cell_double(num);
                    inc_command_address(num, 1);
                    goto Out;
                }
                else if (command == 43)//окружена ли клетка?
                {
                    indirect_inc_cmd_address(num, full_around(num));
                    goto ag;
                }
                else if (command == 44)//приход энергии есть?
                {
                    indirect_inc_cmd_address(num, is_energy_grow(num));
                    goto ag;
                }
                else if (command == 45)//минералы прибавляются?
                {
                    if (cells[num, Y_COORD] > WORLD_HEIGHT / 2)
                    {
                        indirect_inc_cmd_address(num, 1);
                    }
                    else
                    {
                        indirect_inc_cmd_address(num, 2);
                    }
                    goto ag;
                }
                else if (command == 46)//многоклеточный ли бот?
                {
                    int mu = isMulti(num);
                    if (mu == 0) { indirect_inc_cmd_address(num, 1); }
                    else if (mu == 8) { indirect_inc_cmd_address(num, 3); }
                    else { indirect_inc_cmd_address(num, 2); }
                    goto ag;
                }
                else if (command == 47)//преобразовать минералы в энергию
                {
                    cell_mineral2energy(num);
                    inc_command_address(num, 1);
                    goto Out;
                }
                else if (command == 48)//отобрать и поделить
                {
                    colonySharing(num);
                    inc_command_address(num, 1);
                    goto Out;
                }
                inc_command_address(num, command);
                goto ag;
            }
        Out:
            if (cells[num, LIVING] == LV_ALIVE)
            {
                int a = isMulti(num);

                if(a > 0)
                {
                    //colonySharing(num);
                }

                if(cells[num,ENERGY] > 999)
                {
                    if(a > 0) { cell_multi(num); }
                    else { cell_double(num); }
                }
                cells[num, ENERGY] -= ETL;
                if(cells[num,ENERGY] < 1)
                {
                    cell_die(num);
                    return (cells[num, NEXT]);
                }
                if(cells[num,Y_COORD] > WORLD_HEIGHT / 96 * 52)
                {
                    cells[num, MINERAL]++;
                    if(cells[num,Y_COORD] > WORLD_HEIGHT / 96 * 70 ) { cells[num, MINERAL]++; }
                    if (cells[num, Y_COORD] > WORLD_HEIGHT / 96 * 90) { cells[num, MINERAL]++; }
                    if(cells[num,MINERAL] > 499) { cells[num, MINERAL] = 499; }
                }

                cells[num, CELL_AGE]++;
            }
            return (cells[num, NEXT]);
        }

        #region Events

        void SetScrollers()
        {
            hScrollBar1.Maximum = WORLD_WIDTH < (xScreenSize / WORLD_SIZE) ? 0 : WORLD_WIDTH - (xScreenSize / WORLD_SIZE);
            hScrollBar1.Maximum /= 10;
            xDrawStartIndex = hScrollBar1.Value * 10;

            vScrollBar1.Maximum = WORLD_HEIGHT < (yScreenSize / WORLD_SIZE) ? 0 : WORLD_HEIGHT - (yScreenSize / WORLD_SIZE);
            vScrollBar1.Maximum /= 10;
            yDrawStartIndex = vScrollBar1.Value * 10;
        }

        private void SaveImagePng()
        {
            drawWorld = (int[,])world.Clone();
            drawCells = (int[,])cells.Clone();

            for (int i = 0; i < imageSaveViewMode.Length; i++)
                if (imageSaveViewMode[i] == 1)
                {
                    int mode = i + 1;
                    DrawWorld(GR_save, i + 1, imageSaveSize, xDrawStartIndex, yDrawStartIndex);

                    string catalogName = @"Images\" + mode.ToString();
                    string path;
                    if (SaveDirectory == null)
                        path = $"{Directory.GetCurrentDirectory()}/{catalogName}";
                    else
                        path = $"{SaveDirectory}/{catalogName}";

                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);

                    bmpSave.Save($"{path}/{age}.png");
                }

            tryToSave = false;
        }

        private void ScreenUpdate()
        {
            isDrawing = true;

            drawWorld = (int[,])world.Clone();
            drawCells = (int[,])cells.Clone();

            DrawWorld(GR, viewMode, WORLD_SIZE, xDrawStartIndex, yDrawStartIndex);

            WORLD_BOX.Image = bmp;

            isDrawing = false;
        }

        private void WORLD_BOX_Paint(object sender, PaintEventArgs e)
        {
            if (isDrawing || !wantToDraw || !GO)
                return;

            ScreenUpdate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Size_plus(object sender, EventArgs e)
        {
            if(WORLD_SIZE < 6)
            {
                WORLD_SIZE++;
                SetScrollers();
                ScreenUpdate();
                Refresh();
            }
        }

        private void size_minus(object sender, EventArgs e)
        {
            if (WORLD_SIZE > 1)
            {
                WORLD_SIZE--;
                SetScrollers();
                ScreenUpdate();
                Refresh();
            }
        }

        private void Save(object sender, EventArgs e)
        {

            bool t = GO;
            if(GO)
            {
                Stop_Play(sender, e);
            }

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                SaveFileName = saveFileDialog1.FileName;

                SaveWorldFile(SaveFileName);

            }
            GO = t;
        }

        private void Load_file(object sender, EventArgs e)
        {
            if (GO)
                Stop_Play(sender, e);

            if (age > 0)
                if (DialogResult.No == MessageBox.Show("YOU WILL LOSE UNSAVED WORLD!", "ARE YOU SHURE?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    return;


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                SaveFileName = openFileDialog1.FileName;
                String[] Str = File.ReadAllLines(SaveFileName);
                seed = int.Parse(Str[0]);

                UInt64 state = UInt64.Parse(Str[1]);
                rand = new StateRandom(seed, state);

                season_str = Str[2];
                viewMode = int.Parse(Str[3]);
                WORLD_SIZE = int.Parse(Str[4]);
                ETM = int.Parse(Str[5]);
                MTE = int.Parse(Str[6]);
                ETL = int.Parse(Str[7]);
                season = int.Parse(Str[8]);
                age = int.Parse(Str[9]);
                cell_count = int.Parse(Str[10]);
                Print_cell_count = int.Parse(Str[11]);
                WORLD_HEIGHT = int.Parse(Str[12]);
                WORLD_WIDTH = int.Parse(Str[13]);

                MAX_CELLS = WORLD_HEIGHT * WORLD_WIDTH + 1;
                cells = new int[MAX_CELLS, CELL_SIZE];
                world = new int[WORLD_WIDTH, WORLD_HEIGHT + 2];

                int Count = 14;

                for (int i = 0; i < seasons.Length; i++)
                    seasons[i] = int.Parse(Str[Count+i]);

                Count = 14 + seasons.Length;

                for (int x = 0; x < WORLD_WIDTH; x++)
                {
                    for (int y = 0; y < WORLD_HEIGHT + 2; y++)
                    {
                        world[x, y] = int.Parse(Str[Count]);
                            Count++;
                    }
                }
                for (int i = 0; i < MAX_CELLS; i++)
                {
                    for (int j = 0; j < CELL_SIZE; j++)
                    {
                        cells[i,j] = int.Parse(Str[Count]);
                            Count++;
                    }
                }
            }
            ScreenUpdate();
        }
        
        private void Stop_Play(object sender, EventArgs e)
        {
            GO = !GO;
            if (GO)
            {
                t = new System.Threading.Thread(MainFunction);
                t.Start();
                clock.Start();
                WORLD_BOX.Invalidate();
            }
            else
            {
                clock.Stop();
            }
        }

        private void ViewMode1(object sender, EventArgs e)
        {
            viewMode = 1;
            ScreenUpdate();
        }

        private void ViewMode2(object sender, EventArgs e)
        {
            viewMode = 2;
            ScreenUpdate();
        }

        private void ViewMode3(object sender, EventArgs e)
        {
            viewMode = 3;
            ScreenUpdate();
        }

        private void viewMode4_Click(object sender, EventArgs e)
        {
            viewMode = 4;
            ScreenUpdate();
        }

        private void ChangeFPS(object sender, EventArgs e)
        {
            drawInterval = FPS_Scroll.Value;
            textBox1.Text = $"Draw every {drawInterval} iteration";
        }

        private void WorldSizeChange(object sender, EventArgs e)
        {
            if (!GO && age == 0)
            {
                WORLD_WIDTH = 180 * WorldSizeScroll.Value;
                WORLD_HEIGHT = 96 * WorldSizeScroll.Value;
                MAX_CELLS = WORLD_HEIGHT * WORLD_WIDTH + 1;

                cells = new int[MAX_CELLS, CELL_SIZE];
                drawCells = new int[MAX_CELLS, CELL_SIZE];
                world = new int[WORLD_WIDTH, WORLD_HEIGHT + 2];
                drawWorld = new int[WORLD_WIDTH, WORLD_HEIGHT + 2];

                imageSaveSize = 1920 / (WORLD_WIDTH);


                int x = 0;
                while (x < WORLD_WIDTH)
                {
                    world[x, 0] = WC_WALL;
                    world[x, WORLD_HEIGHT + 1] = WC_WALL;
                    x++;
                }

                if (!performanceTest)
                {
                    MuteChance = 10;

                    seasons = new int[]{ 11, 10, 9, 10};
                    MTE = 2;

                    seed = new Random().Next();
                    rand = new StateRandom(seed);

                    FirstCell();
                }
                else
                {
                    MuteChance = 0;
                    seasons = new int[] { 33, 30, 27, 30 };
                    MTE = 3;

                    seed = 1;
                    rand = new StateRandom(1);

                    CreatePerformanceTestWorld();
                }
                currentSeason = 0;
                SetScrollers();
                ScreenUpdate();
                Refresh();
            }
        }

        private void NewSimulate(object sender, EventArgs e)
        {
            if (GO)
                Stop_Play(sender, e);

            if (!GO)
            { 
                if(age > 0)
                    if(DialogResult.No == MessageBox.Show("YOU WILL LOSE UNSAVED WORLD!", "ARE YOU SHURE?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                        return;

                age = 0;
                WorldSizeChange(sender, e);

                CELL = 0;
                cell_count = 0;
                Print_cell_count = 0;

                clock.Restart();
                clock.Stop();
                Refresh();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (GO)
            {
                GO = false;
                t.Join();    
            }
            System.Windows.Forms.Application.Exit();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            xDrawStartIndex = hScrollBar1.Value * 10;
            ScreenUpdate();
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            yDrawStartIndex = vScrollBar1.Value * 10;
            ScreenUpdate();
        }

        private void lacationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                SaveDirectory = folderBrowserDialog1.SelectedPath;
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            //button1.Location = new Point(this.Size.Width - 125, 34);
            //button2.Location = new Point(this.Size.Width - 250, 34);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            performanceTest = !performanceTest;
            toolStripMenuItem1.Checked = performanceTest;

            NewSimulate(sender, e);
        }

        private void saveImagesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            saveImage = !saveImage;
            saveImagesToolStripMenuItem1.Checked = saveImage;
        }

        private void saveParametresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageSaveParametresFrom imageSaveParametresFrom = new ImageSaveParametresFrom();
            
            imageSaveParametresFrom.mainForm = this;
            
            imageSaveParametresFrom.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            wantToDraw = !wantToDraw;

            if(wantToDraw)
            {
                button10.Text = "Turn Off Drawing";
                WORLD_BOX.Invalidate();
            }
            else
            {
                button10.Text = "Turn On Drawing";
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (GO)
            {
                Stop_Play(sender, e);
                t.Join();
            }
            
            OneStep();
            ScreenUpdate();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            //Кастомный размер поля
            //button11_Click(sender, e);
        }

        private void saveWorldsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveWorld = !saveWorld;
            saveWorldsToolStripMenuItem.Checked = saveWorld;
        }
    }
    #endregion
}
