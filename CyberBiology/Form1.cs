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

using static CyberBiology.Constants;
using static CyberBiology.Simulation;
using static CyberBiology.CellFunctions;
using static CyberBiology.CellAditionalFunctions;
using static CyberBiology.ServiceFunctions;
using static CyberBiology.Templates;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;


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
        bool keepWalls = false;
        int addType = WC_WALL;

        bool wantToDraw = true;
        int drawInterval = 100;
        int LogFrequency = 1000;

        bool saveWorld = false;
        bool saveImage = false;
        bool tryToSave = false;
        public int worldSaveStep = 1000;
        public int imageSaveStep = 100;
        public float imageSaveSize = 10;
        public int[] imageSaveViewMode = { 1, 0, 0, 0, 0};

        int xDrawStartIndex = 0;
        int yDrawStartIndex = 0;
        int xScreenSize = 1060;
        int yScreenSize = 560;

        int stopIteration = 0;

        public int customMuteChance = 10;

        int prevWidth;
        int prevHeight;

        int prevDrawX;
        int prevDrawY;

        public List<InspectForm> inspectForm = new List<InspectForm>();
        public List<StaticsticsForm> statForms = new List<StaticsticsForm>();

        public Form1()
        {
            InitializeComponent();
            AdaptElements();


            prevWidth = this.Width;
            prevHeight = this.Height;

            bmp = new Bitmap(WORLD_BOX.Width, WORLD_BOX.Height);
            GR = Graphics.FromImage(bmp);

            SetWorldSize(180, 96);

            newSimulationBT.PerformClick();

            ClearLogs();
        }

        public void OneStep()
        {
            season = seasons[currentSeason];

            CELL = cells[0, NEXT];
            cellCount = 0;
            aliveCellCount = 0;
            while (CELL != 0)
            {
                cellCount++;
                CELL = CellStep(CELL);
            }
                
            printCellCount = cellCount;
            printAliveCellCount = aliveCellCount;
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

            if (aliveCellCount == 0 || stopIteration == age)
                GO = false;

            if (LogFrequency > 0 && age % LogFrequency == 0)
            {
                try
                {
                    int dead = cellCount - aliveCellCount;
                    SaveCellCountLog(age, aliveCellCount, dead);
                    //foreach (StaticsticsForm sf in statForms)
                    //sf.DrawCellCountStat();
                }
                catch
                {
                    MessageBox.Show("Error", "Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                    throw;
                }
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

            aliveCellCount++;

            if (cells[num, CELL_SLEEP] > 0)
            {
                cells[num, CELL_SLEEP]--;
                cells[num, ENERGY] -= ETL/3;
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
            if (cyc < 2)
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

                cells[num, MINERAL] += GetMineralForHeight(cells[num, Y_COORD]);
                if (cells[num,MINERAL] > 499) { cells[num, MINERAL] = 499; }

                cells[num, CELL_AGE]++;
                if(!performanceTest && agingMutation && cells[num, CELL_AGE] % agingFactor == 0)
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

        public void TryToDraw(int mouseX, int mouseY)
        {
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

                        Console.WriteLine($"{mouseX}, {mouseY}");
                        //UpdateScreen();
                    }
                }
            }
        }

        public void ChangeSaveBitmap()
        {
            if (drawInfo)
            {
                bmpSave = new Bitmap((int)Math.Ceiling(imageSaveSize * WORLD_WIDTH + 80), (int)Math.Ceiling(imageSaveSize * WORLD_HEIGHT + 80));
                GR_save = Graphics.FromImage(bmpSave);
            }
            else
            {
                bmpSave = new Bitmap((int)Math.Ceiling(imageSaveSize * WORLD_WIDTH), (int)Math.Ceiling(imageSaveSize * WORLD_HEIGHT));
                GR_save = Graphics.FromImage(bmpSave);
            }
        }

        void SetScrollers()
        {
            hScrollBar1.Maximum = WORLD_WIDTH < (xScreenSize / (int)Math.Ceiling(worldSize)) ? 0 : WORLD_WIDTH - (xScreenSize / (int)Math.Ceiling(worldSize));
            hScrollBar1.Maximum /= 10;
            xDrawStartIndex = hScrollBar1.Value * 10;

            vScrollBar1.Maximum = (WORLD_HEIGHT + 2) < (yScreenSize / (int)Math.Ceiling(worldSize)) ? 0 : (WORLD_HEIGHT + 2) - (yScreenSize / (int)Math.Ceiling(worldSize));
            vScrollBar1.Maximum /= 10;
            yDrawStartIndex = vScrollBar1.Value * 10;
        }

        private void SaveImagePng()
        {
            tryToSave = true;
            //Stopwatch time = new Stopwatch();
            //time.Start();

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

        public void UpdateScreen()
        {
            if (world == null)
                return;

            isDrawing = true;

            DrawWorld(GR, viewMode, worldSize, xDrawStartIndex, yDrawStartIndex);

            WORLD_BOX.Image = bmp;

            foreach(InspectForm inspectF in inspectForm)
                inspectF.UpdateInfo();

            try
            {
                foreach (StaticsticsForm sf in statForms)
                    sf.DrawCellCountStat();
            }
            catch
            {

            }

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
            printCellCount = 1;
            printAliveCellCount = 1;
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


                int[,] buffer = new int[w, h + 2];
                //world.CopyTo(buffer, 0);

                if (world != null)
                    for (int _y = 1; _y < Math.Min(world.GetLength(1), h)  - 1; _y++)
                        for (int _x = 0; _x < Math.Min(world.GetLength(0), w); _x++)
                                buffer[_x, _y] = world[_x, _y];


                cells = new int[MAX_CELLS, CELL_SIZE];
                world = new int[WORLD_WIDTH, WORLD_HEIGHT + 2];

                if (saveSize == 0)
                {
                    imageSaveSize = 1000 / (WORLD_WIDTH);
                    if (imageSaveSize <= 0.5f)
                        imageSaveSize = 0.5f;
                }
                else
                {
                    imageSaveSize = saveSize;
                }

                ChangeSaveBitmap();

                if(keepWalls)
                {
                    for (int _y = 1; _y < WORLD_HEIGHT - 1; _y++)
                    {
                        for (int _x = 0; _x < WORLD_WIDTH; _x++)
                        {
                            if (buffer[_x, _y] == WC_WALL)
                            {
                                world[_x, _y] = buffer[_x, _y];
                            }
                        }
                    }
                }

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

        public void AdaptElements()
        {
            int screenX = Screen.PrimaryScreen.Bounds.Width;
            int screenY = Screen.PrimaryScreen.Bounds.Height;

            float xRatio = screenX / 1920f;
            float yRatio = screenY / 1080f;

            int xBias = screenX - 1920;
            int yBias = screenY - 1080;

            this.Size = new Size(screenX, screenY - 40);

            plusSizeBT.Location = new Point(1800 + xBias, 40);
            minusSizeBT.Location = new Point(1700 + xBias, 40);

            viewMode1BT.Location = new Point(1700 + xBias, 100);
            viewMode2BT.Location = new Point(1750 + xBias, 100);
            viewMode3BT.Location = new Point(1800 + xBias, 100);
            viewMode4.Location = new Point(1850 + xBias, 100);
            viewMode5.Location = new Point(1850 + xBias, 132);

            addCellBT.Location = new Point(1700 + xBias, 170);
            addWallBT.Location = new Point(1750 + xBias, 170);
            eraseCellBT.Location = new Point(1800 + xBias, 170);
            oneStepBT.Location = new Point(1850 + xBias, 170);

            label2.Location = new Point(1713 + xBias, 202);
            label3.Location = new Point(1750 + xBias, 202);
            label4.Location = new Point(1750 + xBias, 242);

            CellColorBT.Location = new Point(1700 + xBias, 220);
            newCellTypeUD.Location = new Point(1750 + xBias, 220);
            stopIterationNUM.Location = new Point(1750 + xBias, 260);

            stopPlayBT.Location = new Point(1700 + xBias, 300);
            turnDrawingBT.Location = new Point(1700 + xBias, 365);

            saveWorldBT.Location = new Point(1700 + xBias, 450);
            loadWorldBT.Location = new Point(1700 + xBias, 515);

            worldSizeTB.Location = new Point(1700 + xBias, 600);
            worldSizeScroll.Location = new Point(1700 + xBias, 630);

            newSimulationBT.Location = new Point(1750 + xBias, 700);

            WORLD_BOX.Size = new Size(1650 + xBias, 900 + yBias);

        }

        #endregion

        #region Events

        private void SetWindowElemets(object sender, EventArgs e)
        {
            int width = this.Width;
            int height = this.Height;

            int difW = width - prevWidth;
            int difH = height - prevHeight;

            WORLD_BOX.Size += new Size(difW, difH);

            bmp = new Bitmap(WORLD_BOX.Width, WORLD_BOX.Height);
            GR = Graphics.FromImage(bmp);
            UpdateScreen();

            prevHeight = height;
            prevWidth = width;
        }

        private void WORLD_BOX_Paint(object sender, PaintEventArgs e)
        {
            if (isDrawing && GO || !wantToDraw || !GO || tryToSave)
                return;

            UpdateScreen();
        }

        private void Size_plus(object sender, EventArgs e)
        {
            if (worldSize < 1f)
            {
                worldSize *= 2;
                SetScrollers();
                UpdateScreen();
                Refresh();
            }
            else if (worldSize < 10)
            {
                worldSize++;
                SetScrollers();
                UpdateScreen();
                Refresh();
            }

            label1.Text = worldSize.ToString();
        }

        private void Size_minus(object sender, EventArgs e)
        {
            if (worldSize > 1)
            {
                worldSize--;
                SetScrollers();
                UpdateScreen();
                Refresh();
            }
            else if(worldSize > 0.5f)
            {
                worldSize /= 2;
                SetScrollers();
                UpdateScreen();
                Refresh();
            }

            label1.Text = worldSize.ToString();
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

        private void TurnViewMode5(object sender, EventArgs e)
        {
            viewMode = 5;
            UpdateScreen();
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

                clock.Reset();
                prev_milliseconds = 0;

                worldSizeScroll.Enabled = true;
                perfomanceTestMenuItem.Enabled = true;
                worldSettingsToolStripMenuItem.Enabled = true;

                Refresh();
            }

            ClearLogs();
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
            WORLD_BOX.Refresh();
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
            if (worldSize < 1)
                return;

            if (e.Button == MouseButtons.Left)
            {
                addWorld = true;

                prevDrawX = (e.X - 40) / (int)Math.Ceiling(worldSize) + xDrawStartIndex;
                prevDrawY = (e.Y - 40) / (int)Math.Ceiling(worldSize) + yDrawStartIndex;

                WORLD_BOX_MouseMove(sender, e);
            }
            else if(e.Button == MouseButtons.Right)
            {
                int mouseX = e.X;
                int mouseY = e.Y;

                if (mouseX > WORLD_BOX.Location.X && mouseX < WORLD_BOX.Location.X + WORLD_BOX.Size.Width
                    && mouseY > WORLD_BOX.Location.Y && mouseY < WORLD_BOX.Location.Y + WORLD_BOX.Size.Height)
                {
                    mouseX = (mouseX - 40) / (int)Math.Ceiling(worldSize) + xDrawStartIndex;
                    mouseY = (mouseY - 40) / (int)Math.Ceiling(worldSize) + yDrawStartIndex;

                    if (mouseX >= 0 && mouseX < WORLD_WIDTH && mouseY > 0
                        && mouseY < (WORLD_HEIGHT + 1))
                    {
                        if (world[mouseX, mouseY] > 0 && inspectedNums.IndexOf(world[mouseX, mouseY]) == -1)
                        {
                            InspectForm newInspectForm = new InspectForm();
                            newInspectForm.mainForm = this;
                            newInspectForm.cellNum = world[mouseX, mouseY];
                            newInspectForm.Show();
                            inspectForm.Add(newInspectForm);
                            inspectedNums.Add(world[mouseX, mouseY]);

                            UpdateScreen();
                        }
                    }
                }
            }
        }

        private void WORLD_BOX_MouseUp(object sender, MouseEventArgs e)
        {
            addWorld = false;
        }

        private void WORLD_BOX_MouseMove(object sender, MouseEventArgs e)
        {
            if (!addWorld)
                return;

            if (!GO && (age == 0 || !saveDrawing))
            {
                int mouseX = e.X;
                int mouseY = e.Y;

                if (mouseX > WORLD_BOX.Location.X && mouseX < WORLD_BOX.Location.X + WORLD_BOX.Size.Width
                    && mouseY > WORLD_BOX.Location.Y && mouseY < WORLD_BOX.Location.Y + WORLD_BOX.Size.Height)
                {
                    mouseX = (mouseX - 40) / (int)Math.Ceiling(worldSize) + xDrawStartIndex;
                    mouseY = (mouseY - 40) / (int)Math.Ceiling(worldSize) + yDrawStartIndex;

                    //Алгоритм брезенхема
                    int deltaX = Math.Abs(mouseX - prevDrawX);
                    int deltaY = Math.Abs(mouseY - prevDrawY);
                    int signX = prevDrawX < mouseX ? 1 : -1;
                    int signY = prevDrawY < mouseY ? 1 : -1;

                    int error = deltaX - deltaY;


                    TryToDraw(mouseX, mouseY);

                    while(prevDrawX != mouseX || prevDrawY != mouseY)
                    {
                        TryToDraw(prevDrawX, prevDrawY);
                        int error2 = error * 2;
                        if(error2 > -deltaY)
                        {
                            error -= deltaY;
                            prevDrawX += signX;
                        }
                        if(error2 < deltaX)
                        {
                            error += deltaX;
                            prevDrawY += signY;
                        }
                    }

                    prevDrawX = mouseX;
                    prevDrawY = mouseY;
                    UpdateScreen();
                    WORLD_BOX.Refresh();
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

        private void CellColorBT_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                originColor = colorDialog1.Color;
                CellColorBT.BackColor = originColor;
            }
        }

        private void TemplateDualWorld(object sender, EventArgs e)
        {
            if (GO)
                Stop_Play(sender, e);

            if (!GO)
            {
                if (age > 0)
                    if (DialogResult.No == MessageBox.Show("YOU WILL LOSE UNSAVED WORLD!", "ARE YOU SHURE?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                        return;

                age = 0;

                CreateDualWorld();

                CELL = 0;

                clock.Reset();
                prev_milliseconds = 0;

                worldSizeScroll.Enabled = true;
                perfomanceTestMenuItem.Enabled = true;
                worldSettingsToolStripMenuItem.Enabled = true;
                UpdateScreen();
                Refresh();
            }
        }

        private void TemplateQuadrupleWorld(object sender, EventArgs e)
        {
            if (GO)
                Stop_Play(sender, e);

            if (!GO)
            {
                if (age > 0)
                    if (DialogResult.No == MessageBox.Show("YOU WILL LOSE UNSAVED WORLD!", "ARE YOU SHURE?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                        return;

                age = 0;

                CreateQuadroWorld();

                CELL = 0;

                clock.Reset();
                prev_milliseconds = 0;

                worldSizeScroll.Enabled = true;
                perfomanceTestMenuItem.Enabled = true;
                worldSettingsToolStripMenuItem.Enabled = true;
                UpdateScreen();
                Refresh();
            }
        }

        private void TemplateLabyrinthWorld(object sender, EventArgs e)
        {
            if (GO)
                Stop_Play(sender, e);

            if (!GO)
            {
                if (age > 0)
                    if (DialogResult.No == MessageBox.Show("YOU WILL LOSE UNSAVED WORLD!", "ARE YOU SHURE?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                        return;

                age = 0;

                CreateLabyrinthWorld();

                CELL = 0;

                clock.Reset();
                prev_milliseconds = 0;

                worldSizeScroll.Enabled = true;
                perfomanceTestMenuItem.Enabled = true;
                worldSettingsToolStripMenuItem.Enabled = true;
                UpdateScreen();
                Refresh();
            }
        }

        private void NewCellTypeSwitch(object sender, EventArgs e)
        {
            switch (newCellTypeUD.Text)
            {
                case "FOTOSINTEZ":
                    newCellType = CT_FOTOSINTEZ;
                    break;
                case "MINERAL":
                    newCellType = CT_MINERAL;
                    break;
                case "RANDOM":
                    newCellType = CT_RANDOM;
                    break;
                default:
                    break;
            }
        }

        void SetStopIteration(object sender, EventArgs e)
        {
            stopIteration = (int)stopIterationNUM.Value;
        }

        void TurnFullScreen(object sender, EventArgs e)
        {
            if (fullScreenBT.Checked)
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Normal;
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void ShowRulebook(object sender, EventArgs e)
        {
            RulebookForm rulebookForm = new RulebookForm();
            rulebookForm.Show();
        }

        private void saveWallsMBT_Click(object sender, EventArgs e)
        {
            keepWalls = saveWallsMBT.Checked;
        }

        private void CellCountLog(object sender, EventArgs e)
        {
            StaticsticsForm staticsticsForm = new StaticsticsForm();

            staticsticsForm.mainForm = this;
            statForms.Add(staticsticsForm);
            staticsticsForm.Show();
        }

        private void ChangeLogFrequency(object sender, EventArgs e)
        {
            int newLogFrequency;
            if (int.TryParse(toolStripTextBox2.Text, out newLogFrequency) == false)
                return;

            LogFrequency = newLogFrequency;
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 'f' || e.KeyChar == 'а')
            {
                fullScreenBT.PerformClick();
            }
        }
    }
    #endregion
}
