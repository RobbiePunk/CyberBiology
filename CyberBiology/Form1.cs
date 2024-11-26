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
using System.Runtime.Serialization.Formatters.Binary;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.Security;

namespace CyberBiology
{
    public partial class Form1 : Form
    {

        Bitmap bmp;
        Bitmap bmpSave;
        
        Thread simulationThread;
        Graphics GR;
        Graphics GR_save;
        //SolidBrush BR = new SolidBrush(Color.White);
        String SaveFileName;
        
        bool GO = false;
        bool performanceTest = false;
        bool addWorld = false;
        bool saveDrawing = true;
        //bool keepWalls = false;
        int addType = WC_WALL;

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
        int xScreenSize = 1060;
        int yScreenSize = 560;

        public int customMuteChance = 10;

        public Form1()
        {
            InitializeComponent();

            bmp = new Bitmap(WORLD_BOX.Width, WORLD_BOX.Height);
            GR = Graphics.FromImage(bmp);

            SetWorldSize(180, 96);

            newSimulationBT.PerformClick();
        }

        public void OneStep()
        {
            season = seasons[currentSeason];

            CELL = cells[0, NEXT];
            cell_count = 0;
            while (CELL != 0)
            {
                cell_count++;
                CELL = CellStep(CELL);
            }
                
            print_cell_count = cell_count;
            age++;

            if (imageSaveStep != 0 && age % imageSaveStep == 0 && saveImage)
                SaveImagePng();

            if (worldSaveStep != 0 && age % worldSaveStep == 0 && saveWorld)
                SaveWorldFile();

            if (age % seasonTime == 0)
            {
                currentSeason = (currentSeason + 1) % seasons.Length;

                season_str = seasonsString[currentSeason];

                season = seasons[currentSeason];
            }
                
        }

        public void MainFunction()
        {
            season = seasons[currentSeason];

            while (GO)
                OneStep();
        }

        int CellStep(int num)
        {
            int lv = cells[num, LIVING];
            if (lv == LV_DEAD)
            {
                Fall(num);
                if (IsSolidBelow(num))
                {
                    if (isPressure)
                        Pressure(num);
                    if (cells[num, PUSH] > 31)
                    {
                        int x = cells[num, X_COORD];
                        int y = cells[num, Y_COORD];
                        if (cells[world[x, y - 1], LIVING] == LV_DEAD)
                        {
                            DeleteCell(world[x, y - 1]);
                        }
                        cells[num, LIVING] = LV_EARTH;
                    }
                }
                return (cells[num, NEXT]);
            }
            if(lv == LV_EARTH)
            {
                Fall(num);
                if (IsSolidBelow(num))
                {
                    Pressure(num);
                    if (cells[num, PUSH] >= 63)
                    {
                        int x = cells[num, X_COORD];
                        int y = cells[num, Y_COORD];
                        if (cells[world[x, y - 1], LIVING] == LV_DEAD)
                        {
                            DeleteCell(world[x, y - 1]);
                        }
                        cells[num, LIVING] = LV_STONE;
                    }
                }
                return (cells[num, NEXT]);
            }
            if(lv == LV_STONE)
            {
                Fall(num);
                return (cells[num, NEXT]);
            }
            if(cells[num, CELL_SLEEP] > 0)
            {
                cells[num, CELL_SLEEP]--;
                cells[num, ENERGY] -= ETL/2;
                if (cells[num, ENERGY] < 1)
                {
                    CellDie(num);
                    return (cells[num, NEXT]);
                }
                cells[num, CELL_AGE]++;
                return (cells[num, NEXT]);
            }
            int cyc = 0;
        ag:
            cyc++;
            if (cyc < 10)
            {
                int command = cells[num, cells[num, ADR]];
                if (command == 19)//сон
                {
                    cells[num, CELL_SLEEP] = GetParam(num);
                    IndirectIncCmdAddress(num, cells[num, CELL_SLEEP]);
                    goto Out;
                }
                else if (command == 20)//растворить в относителном направлении
                {
                    int drct = GetParam(num) % 8;
                    IndirectIncCmdAddress(num, AcidSplit(num, drct, 0));
                    goto Out;
                }
                else if (command == 21)//растворить в абсолютном направлении
                {
                    int drct = GetParam(num) % 8;
                    IndirectIncCmdAddress(num, AcidSplit(num, drct, 1));
                    goto Out;
                }
                else if (command == 22)//Деление с абсолютной сменой команды
                {
                    CellDouble(num);
                    IncCommandAddress(num, 1);
                    goto Out;
                }
                else if (command == 23)//смена направления относительно
                {
                    int newdrct = (cells[num, DIRECT] + GetParam(num)) % 8;

                    cells[num, DIRECT] = newdrct;
                    IncCommandAddress(num, 1);
                    goto ag;
                }
                else if (command == 24)//смена направления абсолютно
                {
                    cells[num, DIRECT] = GetParam(num) % 8;
                    IncCommandAddress(num, 1);
                    goto ag;
                }
                else if (command == 25)//фотосинтез
                {
                    Fotosintez(num);
                    IncCommandAddress(num, 1);
                    goto Out;
                }
                else if (command == 26)//движение относительно
                {
                    int a = IsMulti(num);
                    if (a == 0)
                    {
                        int drct = GetParam(num) % 8;
                        IndirectIncCmdAddress(num, CellMove(num, drct, 0));
                    }
                    else if(a < 5)
                    {
                        int drct = GetParam(num) % 8;
                        IndirectIncCmdAddress(num, CellMultiMove(num, drct, 0));
                    }
                    else
                    {
                        IncCommandAddress(num, 1);
                    }

                    goto Out;
                }
                else if (command == 27)//движение абсолютно
                {
                    int a = IsMulti(num);
                    if (a == 0)
                    {
                        int drct = GetParam(num) % 8;
                        IndirectIncCmdAddress(num, CellMove(num, drct, 1));
                    }
                    else if (a < 5)
                    {
                        int drct = GetParam(num) % 8;
                        IndirectIncCmdAddress(num, CellMultiMove(num, drct, 1));
                    }
                    else
                    {
                        IncCommandAddress(num, 1);
                    }
                    goto Out;
                }
                else if (command == 28)//съесть в относителном направлении
                {
                    int drct = GetParam(num) % 8;
                    IndirectIncCmdAddress(num, CellEat(num, drct, 0));
                    goto Out;
                }
                else if (command == 29)//съесть в абсолютном направлении
                {
                    int drct = GetParam(num) % 8;
                    IndirectIncCmdAddress(num, CellEat(num, drct, 1));
                    goto Out;
                }
                else if (command == 30)//посмотреть в относительном направлении
                {
                    int drct = GetParam(num) % 8;
                    IndirectIncCmdAddress(num, CellLook(num, drct, 0));
                    goto ag;
                }
                else if (command == 31)//посмотреть в абсолютном направлении
                {
                    int drct = GetParam(num) % 8;
                    IndirectIncCmdAddress(num, CellLook(num, drct, 1));
                    goto ag;
                }
                else if (command == 32)//поделиться лишними ресурсами в относительном направлении
                {
                    int drct = GetParam(num) % 8;
                    IndirectIncCmdAddress(num, CellCare(num, drct, 0));
                    goto ag;
                }
                else if (command == 33)//поделиться лишними ресурсами в абсолютном направлении
                {
                    int drct = GetParam(num) % 8;
                    IndirectIncCmdAddress(num, CellCare(num, drct, 1));
                    goto ag;
                }
                else if (command == 34)//отдать ресурсы в относительном направлении
                {
                    int drct = GetParam(num) % 8;
                    IndirectIncCmdAddress(num, CellGive(num, drct, 0));
                    goto ag;
                }
                else if (command == 35)//отдать ресурсы в абсолютном направлении
                {
                    int drct = GetParam(num) % 8;
                    IndirectIncCmdAddress(num, CellGive(num, drct, 1));
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
                    IncCommandAddress(num, 1);
                    goto ag;
                }
                else if (command == 37)//узнать высоту
                {
                    float param = GetParam(num) * WORLD_HEIGHT / 64;
                    if (cells[num, Y_COORD]  < param)
                    {
                        IndirectIncCmdAddress(num, 2);
                    }
                    else
                    {
                        IndirectIncCmdAddress(num, 3);
                    }
                    goto ag;
                }
                else if (command == 38)//узнать количество энергии
                {
                    int param = GetParam(num) * 15;
                    if (cells[num, ENERGY] < param)
                    {
                        IndirectIncCmdAddress(num, 2);
                    }
                    else
                    {
                        IndirectIncCmdAddress(num, 3);
                    }
                    goto ag;
                }
                else if (command == 39)//узнать количество минералов
                {
                    int param = GetParam(num) * 15;
                    if (cells[num, MINERAL] < param)
                    {
                        IndirectIncCmdAddress(num, 2);
                    }
                    else
                    {
                        IndirectIncCmdAddress(num, 3);
                    }
                    goto ag;
                }
                else if (command == 40)//многоклеточное деление
                {
                    CellMulti(num);
                    IncCommandAddress(num, 1);
                    goto Out;
                }
                else if (command == 41)//свободное деление
                {
                    CellDouble(num);
                    IncCommandAddress(num, 1);
                    goto Out;
                }
                else if (command == 43)//окружена ли клетка?
                {
                    IndirectIncCmdAddress(num, IsFullAround(num));
                    goto ag;
                }
                else if (command == 44)//приход энергии есть?
                {
                    IndirectIncCmdAddress(num, IsEnergyGrow(num));
                    goto ag;
                }
                else if (command == 45)//минералы прибавляются?
                {
                    if (cells[num, Y_COORD] > WORLD_HEIGHT / 2)
                    {
                        IndirectIncCmdAddress(num, 1);
                    }
                    else
                    {
                        IndirectIncCmdAddress(num, 2);
                    }
                    goto ag;
                }
                else if (command == 46)//многоклеточный ли бот?
                {
                    int mu = IsMulti(num);
                    if (mu == 0) { IndirectIncCmdAddress(num, 1); }
                    else if (mu == 8) { IndirectIncCmdAddress(num, 3); }
                    else { IndirectIncCmdAddress(num, 2); }
                    goto ag;
                }
                else if (command == 47)//преобразовать минералы в энергию
                {
                    CellMineralToEnergy(num);
                    IncCommandAddress(num, 1);
                    goto Out;
                }
                else if (command == 48)//отобрать и поделить
                {
                    ColonySharing(num);
                    IncCommandAddress(num, 1);
                    goto Out;
                }
                IncCommandAddress(num, command);
                goto ag;
            }
        Out:
            if (cells[num, LIVING] == LV_ALIVE)
            {
                int a = IsMulti(num);

                if(a > 0)
                {
                    //colonySharing(num);
                }

                if(cells[num,ENERGY] > 999 && isAutoDivide)
                {
                    if(a > 0) { CellMulti(num); }
                    else { CellDouble(num); }
                }
                cells[num, ENERGY] -= ETL;
                if(cells[num,ENERGY] < 1)
                {
                    CellDie(num);
                    return (cells[num, NEXT]);
                }
                if(cells[num,Y_COORD] > 56 * WORLD_HEIGHT / 96)
                {
                    cells[num, MINERAL]++;
                    if(cells[num,Y_COORD] > 72 * WORLD_HEIGHT / 96) { cells[num, MINERAL]++; }
                    if (cells[num, Y_COORD] > 90 * WORLD_HEIGHT / 96) { cells[num, MINERAL]++; }
                    if(cells[num,MINERAL] > 499) { cells[num, MINERAL] = 499; }
                }

                cells[num, CELL_AGE]++;
                if(!performanceTest && cells[num, CELL_AGE] % 10000 == 0)
                {
                    int vi = rand.Next();
                    if (vi % 100 < muteChance)
                    {
                        int ma = rand.Next() % MIND_SIZE;
                        int mc = rand.Next() % MIND_SIZE;
                        cells[num, ma] = mc;
                    }
                }
            }
            return (cells[num, NEXT]);
        }

        #region Service

        public void ChangeSaveBitmap()
        {
            if (drawInfo)
            {
                bmpSave = new Bitmap(imageSaveSize * WORLD_WIDTH + 80, imageSaveSize * WORLD_HEIGHT + 80);
                GR_save = Graphics.FromImage(bmpSave);
            }
            else
            {
                bmpSave = new Bitmap(imageSaveSize * WORLD_WIDTH, imageSaveSize * WORLD_HEIGHT);
                GR_save = Graphics.FromImage(bmpSave);
            }
        }

        void SetScrollers()
        {
            hScrollBar1.Maximum = WORLD_WIDTH < (xScreenSize / WORLD_SIZE) ? 0 : WORLD_WIDTH - (xScreenSize / WORLD_SIZE);
            hScrollBar1.Maximum /= 10;
            xDrawStartIndex = hScrollBar1.Value * 10;

            vScrollBar1.Maximum = (WORLD_HEIGHT + 2) < (yScreenSize / WORLD_SIZE) ? 0 : (WORLD_HEIGHT + 2) - (yScreenSize / WORLD_SIZE);
            vScrollBar1.Maximum /= 10;
            yDrawStartIndex = vScrollBar1.Value * 10;
        }

        private void SaveImagePng()
        {
            tryToSave = true;
            //Stopwatch time = new Stopwatch();
            //time.Start();

            drawWorld = (int[,])world.Clone();
            drawCells = (int[,])cells.Clone();

            float ips = IPS;

            for (int i = 0; i < imageSaveViewMode.Length; i++)
                if (imageSaveViewMode[i] == 1)
                {
                    int mode = i + 1;
                    DrawWorld(GR_save, i + 1, imageSaveSize, xDrawStartIndex, yDrawStartIndex, ips);

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

            //saveTime = string.Format("{0:00}:{1:00}", time.Elapsed.Seconds, time.Elapsed.Milliseconds);
            tryToSave = false;
            WORLD_BOX.Invalidate();
        }

        private void UpdateScreen()
        {
            isDrawing = true;

            drawWorld = (int[,])world.Clone();
            drawCells = (int[,])cells.Clone();

            DrawWorld(GR, viewMode, WORLD_SIZE, xDrawStartIndex, yDrawStartIndex);

            WORLD_BOX.Image = bmp;

            isDrawing = false;
        }

        public void SetWorldSettings(int s = 0)
        {
            if (!performanceTest)
            {
                muteChance = customMuteChance;

                if(s == 0)
                    seed = new Random().Next();
                else
                    seed = s;

                rand = new StateRandom(seed);

                FirstCell();
            }
            else
            {
                muteChance = 0;

                seed = 1;
                rand = new StateRandom(1);

                CreatePerformanceTestWorld();
            }
            print_cell_count = 1;
            currentSeason = 0;

            season_str = seasonsString[currentSeason];


            UpdateScreen();
            Refresh();
        }

        public void SetWorldSize(int w, int h)
        {
            if (!GO && age == 0)
            {
                WORLD_WIDTH = w;
                WORLD_HEIGHT = h;

                MAX_CELLS = WORLD_HEIGHT * WORLD_WIDTH + 1;

                cells = new int[MAX_CELLS, CELL_SIZE];
                drawCells = new int[MAX_CELLS, CELL_SIZE];
                world = new int[WORLD_WIDTH, WORLD_HEIGHT + 2];
                drawWorld = new int[WORLD_WIDTH, WORLD_HEIGHT + 2];

                if (saveSize == 0)
                {
                    imageSaveSize = 1000 / (WORLD_WIDTH);
                    if (imageSaveSize <= 0)
                        imageSaveSize = 1;
                }
                else
                {
                    imageSaveSize = saveSize;
                }

                ChangeSaveBitmap();

                int x = 0;
                while (x < WORLD_WIDTH)
                {
                    world[x, 0] = WC_WALL;
                    world[x, WORLD_HEIGHT + 1] = WC_WALL;
                    x++;
                }

                SetWorldSettings();

                SetScrollers();
                UpdateScreen();
                Refresh();
            }
        }

        #endregion

        #region Events

        private void WORLD_BOX_Paint(object sender, PaintEventArgs e)
        {
            if (isDrawing || !wantToDraw || !GO || tryToSave)
                return;

            UpdateScreen();
        }

        private void Size_plus(object sender, EventArgs e)
        {
            if(WORLD_SIZE < 10)
            {
                WORLD_SIZE++;
                SetScrollers();
                UpdateScreen();
                Refresh();
            }
        }

        private void Size_minus(object sender, EventArgs e)
        {
            if (WORLD_SIZE > 1)
            {
                WORLD_SIZE--;
                SetScrollers();
                UpdateScreen();
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
                label1.Text = saveTime;
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
                LoadWorldFile(SaveFileName);
            
                clock.Reset();

                imageSaveSize = 1920 / (WORLD_WIDTH);
                prev_milliseconds = 0;
                prev_age = age;

                label1.Text = saveTime;
            }
            UpdateScreen();
        }
        
        private void Stop_Play(object sender, EventArgs e)
        {
            GO = !GO;
            if (GO)
            {
                simulationThread = new System.Threading.Thread(MainFunction);
                simulationThread.Start();
                clock.Start();
                WORLD_BOX.Invalidate();

                worldSizeScroll.Enabled = false;
                perfomanceTestMenuItem.Enabled = false;
                worldSettingsToolStripMenuItem.Enabled = false;
            }
            else
            {
                simulationThread.Join();
                clock.Stop();
                if(age == 0)
                    worldSizeScroll.Enabled = true;

                UpdateScreen();
                WORLD_BOX.Invalidate();
            }
        }

        private void TurnViewMode1(object sender, EventArgs e)
        {
            viewMode = 1;
            UpdateScreen();
        }

        private void TurnViewMode2(object sender, EventArgs e)
        {
            viewMode = 2;
            UpdateScreen();
        }

        private void TurnViewMode3(object sender, EventArgs e)
        {
            viewMode = 3;
            UpdateScreen();
        }

        private void TurnViewMode4(object sender, EventArgs e)
        {
            viewMode = 4;
            UpdateScreen();
        }

        private void ChangeFPS(object sender, EventArgs e)
        {
            //временно скрыт
            drawInterval = FPS_Scroll.Value;
            fpsTB.Text = $"Draw every {drawInterval} iteration";
        }

        public void ChangeWorldSize(object sender, EventArgs e)
        {
            SetWorldSize(worldSizeScroll.Value * 180, worldSizeScroll.Value * 96);
        }

        public void NewSimulation(object sender, EventArgs e)
        {
            if (GO)
                Stop_Play(sender, e);

            if (!GO)
            { 
                if(age > 0)
                    if(DialogResult.No == MessageBox.Show("YOU WILL LOSE UNSAVED WORLD!", "ARE YOU SHURE?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                        return;

                age = 0;

                SetWorldSize(WORLD_WIDTH, WORLD_HEIGHT);

                CELL = 0;
                cell_count = 0;
                print_cell_count = 0;

                clock.Reset();
                prev_milliseconds = 0;

                worldSizeScroll.Enabled = true;
                perfomanceTestMenuItem.Enabled = true;
                worldSettingsToolStripMenuItem.Enabled = true;

                Refresh();
            }
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            xDrawStartIndex = hScrollBar1.Value * 10;
            UpdateScreen();
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            yDrawStartIndex = vScrollBar1.Value * 10;
            UpdateScreen();
        }

        private void ChangeImageSavePath(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                SaveDirectory = folderBrowserDialog1.SelectedPath;
            }
        }

        private void PerfomanceTest_Click(object sender, EventArgs e)
        {
            performanceTest = !performanceTest;

            if(performanceTest)
                seasons = new int[] { 33, 30, 27, 30 };
            else
                seasons = new int[] { 11, 10, 9, 10 };

            NewSimulation(sender, e);
        }

        private void TurnImagesSaving(object sender, EventArgs e)
        {
            saveImage = saveImagesToolStripMenuItem1.Checked;
        }

        private void ShowImageSaveParametresWindow(object sender, EventArgs e)
        {
            ImageSaveParametresFrom imageSaveParametresFrom = new ImageSaveParametresFrom();
            
            imageSaveParametresFrom.mainForm = this;
            
            imageSaveParametresFrom.ShowDialog();
        }

        private void TurnDrawing(object sender, EventArgs e)
        {
            wantToDraw = !wantToDraw;

            if(wantToDraw)
            {
                turnDrawingBT.Text = "Turn Off Drawing";
                UpdateScreen();
                WORLD_BOX.Invalidate();
            }
            else
            {
                turnDrawingBT.Text = "Turn On Drawing";
            }
        }

        private void DoOneStep(object sender, EventArgs e)
        {
            if (GO)
            {
                Stop_Play(sender, e);
                simulationThread.Join();
            }
            
            OneStep();
            UpdateScreen();
        }

        private void TurnWorldSaving(object sender, EventArgs e)
        {
            saveWorld = saveWorldsToolStripMenuItem.Checked;
        }

        private void ShowWorldSettingsWindow(object sender, EventArgs e)
        {
            WorldSettingsForm worldSettingsForm = new WorldSettingsForm();

            worldSettingsForm.mainForm = this;

            worldSettingsForm.ShowDialog();
        }

        private void SaveToText(object sender, EventArgs e)
        {
            bool t = GO;
            if (GO)
            {
                Stop_Play(sender, e);
            }

            if (saveFileDialog2.ShowDialog() == DialogResult.OK)
            {
                SaveFileName = saveFileDialog2.FileName;

                SaveWorldTextFile(SaveFileName);
                label1.Text = saveTime;
            }
            GO = t;
        }

        private void LoadFromText(object sender, EventArgs e)
        {
            if (GO)
                Stop_Play(sender, e);

            if (age > 0)
                if (DialogResult.No == MessageBox.Show("YOU WILL LOSE UNSAVED WORLD!", "ARE YOU SHURE?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    return;


            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                SaveFileName = openFileDialog2.FileName;
                LoadWorldTextFile(SaveFileName);

                clock.Reset();

                imageSaveSize = 1920 / (WORLD_WIDTH);
                prev_milliseconds = 0;
                prev_age = age;

                label1.Text = saveTime;
            }
            UpdateScreen();
        }

        private void WORLD_BOX_MouseDown(object sender, MouseEventArgs e)
        {
            addWorld = true;

            WORLD_BOX_MouseMove(sender, e);
        }

        private void WORLD_BOX_MouseUp(object sender, MouseEventArgs e)
        {
            addWorld = false;
        }

        private void WORLD_BOX_MouseMove(object sender, MouseEventArgs e)
        {
            if (!GO && (age == 0 || !saveDrawing))
            {
                int mouseX = e.X;
                int mouseY = e.Y;

                if (mouseX > WORLD_BOX.Location.X && mouseX < WORLD_BOX.Location.X + WORLD_BOX.Size.Width
                    && mouseY > WORLD_BOX.Location.Y && mouseY < WORLD_BOX.Location.Y + WORLD_BOX.Size.Height)
                {
                    mouseX = (mouseX - 40) / WORLD_SIZE + xDrawStartIndex;
                    mouseY = (mouseY - 40) / WORLD_SIZE + yDrawStartIndex;

                    if (mouseX >= 0 && mouseX < WORLD_WIDTH && mouseY > 0 
                        && mouseY < (WORLD_HEIGHT + 1) && addWorld)
                    {
                        if (world[mouseX, mouseY] != addType)
                        {
                            if (!saveDrawing || world[mouseX, mouseY] <= 0)
                            {
                                if (world[mouseX, mouseY] > 0)
                                    DeleteCell(world[mouseX, mouseY]);

                                if (addType <= 0)
                                    world[mouseX, mouseY] = addType;
                                else
                                    AddCell(mouseX, mouseY);

                                UpdateScreen();
                            }
                        }
                    }
                }
            }
        }

        private void TurnSaveDrawing(object sender, EventArgs e)
        {
            saveDrawing = saveDrawToolStripMenuItem.Checked;
        }

        private void ClearAllWalls(object sender, EventArgs e)
        {
            if (DialogResult.No == MessageBox.Show("ALL DRAWN WALLS WILL BE DELETED!", "ARE YOU SHURE?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                return;

            for (int y = 1; y < WORLD_HEIGHT + 1; y++)
                for (int x = 0; x < WORLD_WIDTH; x++)
                    if (world[x, y] == WC_WALL)
                        world[x, y] = WC_EMPTY;
            UpdateScreen();
        }

        private void TurnRandomGenome(object sender, EventArgs e)
        {
            isRandom = randomGenomeCB.Checked;
        }

        private void AddTypeCell(object sender, EventArgs e)
        {
            addType = 1;
        }

        private void AddTypeWall(object sender, EventArgs e)
        {
            addType = WC_WALL;
        }

        private void AddTypeEmpty(object sender, EventArgs e)
        {
            addType = WC_EMPTY;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (GO)
            {
                GO = false;
                simulationThread.Join();
            }
            System.Windows.Forms.Application.Exit();
        }
    }
    #endregion
}
