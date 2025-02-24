using static CyberBiology.Constants;
using static CyberBiology.Simulation;
using static CyberBiology.CellAditionalFunctions;
using System.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Text;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.Windows.Forms;
using System.Collections.Generic;

namespace CyberBiology
{

    public static class ServiceFunctions
    {
        public static string[] modeStrings = { "Normal Mode", "Colony Mode", "Energy Mode", "Age Mode", "Clan Mode" };

        public static Color originColor = Color.OrangeRed;

        public static String SaveDirectory;
        public static String season_str = "Summer";
        public static string saveTime;

        public static float IPS = 0;
        public static bool isDrawing = true;
        public static bool drawInfo = true;
        public static float saveSize = 0;

        public static long prev_milliseconds = 0;
        public static int prev_age = 0;

        public static List<int> inspectedNums = new List<int>();
        
        public static void FirstCell()
        {
            if (world[WORLD_WIDTH / 2, WORLD_HEIGHT / 4 + 1] != WC_WALL)
                AddCell(WORLD_WIDTH / 2, WORLD_HEIGHT / 4 + 1);
        }
        public static void CreatePerformanceTestWorld()
        {
            cells[0, NEXT] = 1;
            cells[0, PREV] = 1;

            cells[1, NEXT] = 0;
            cells[1, PREV] = 0;

            cells[1, C_RED] = 170;
            cells[1, C_GREEN] = 170;
            cells[1, C_BLUE] = 170;

            cells[1, ENERGY] = 990;
            cells[1, MINERAL] = 0;
            cells[1, LIVING] = LV_ALIVE;
            cells[1, DIRECT] = 5;
            cells[1, X_COORD] = WORLD_WIDTH / 2;
            cells[1, Y_COORD] = 1;

            cells[1, CELL_AGE] = 0;

            for (int j = M1; j < M8 + 1; j++)
            {
                cells[1, j] = 0;
            }
            world[WORLD_WIDTH / 2, 1] = 1;
            int i = 0;
            while (i < MIND_SIZE)
            {
                if (i % 6 == 0)
                    cells[1, i] = 48;
                else if (i % 8 == 0)
                    cells[1, i] = 47;
                else
                    cells[1, i] = 25;
                i++;
            }

            cells[1, 10] = 30;
            cells[1, 20] = 32;
            cells[1, 30] = 33;
            //cells[1, 32] = 40;
            cells[1, 40] = 34;
            cells[1, 50] = 35;
            cells[1, 63] = 40;
        }

        public static void AddCell(int x, int y)
        {
            if (world[x, y] == WC_WALL)
                return;

            int num = FindEmptyCell();

            cells[num, NEXT] = cells[0, NEXT];
            cells[cells[num, NEXT], PREV] = num;
            cells[num, PREV] = 0;
            cells[0, NEXT] = num;

            cells[num, C_RED] = 170;
            cells[num, C_GREEN] = 170;
            cells[num, C_BLUE] = 170;

            cells[num, ENERGY] = 900;
            cells[num, MINERAL] = 0;
            cells[num, LIVING] = LV_ALIVE;
            cells[num, DIRECT] = 5;
            cells[num, X_COORD] = x;
            cells[num, Y_COORD] = y;

            cells[num, CELL_AGE] = 0;

            cells[num, ORIGIN_C_RED] = originColor.R;
            cells[num, ORIGIN_C_GREEN] = originColor.G;
            cells[num, ORIGIN_C_BLUE] = originColor.B;

            for (int j = M1; j < M8 + 1; j++)
            {
                cells[num, j] = 0;
            }
            world[x, y] = num;
            int i = 0;
            while (i < MIND_SIZE)
            {
                if (newCellType == CT_RANDOM)
                    cells[num, i] = rand.Next() % MIND_SIZE;
                else if (newCellType == CT_FOTOSINTEZ)
                    cells[num, i] = 25;
                else if (newCellType == CT_MINERAL)
                    cells[num, i] = 47;
                i++;
            }
            if (!isAutoDivide)
            {
                //cells[num, rand.Next() % MIND_SIZE] = 23; //поворот
                cells[num, rand.Next() % MIND_SIZE] = 22; //Деление
            }
        }

        public static void AddWall(int x, int y)
        {
            world[x, y] = WC_WALL;
        }

        public static int CheckColor(int num, int type)
        {
            if (type == 1)
            {
                if (cells[num, C_RED] > 255) { return (255); }
                if (cells[num, C_RED] < 0) { return (0); }
                return (cells[num, C_RED]);
            }
            if (type == 3)
            {
                if (cells[num, C_BLUE] > 255) { return (255); }
                if (cells[num, C_BLUE] < 0) { return (0); }
                return (cells[num, C_BLUE]);
            }
            if (type == 2)
            {
                if (cells[num, C_GREEN] > 255) { return (255); }
                if (cells[num, C_GREEN] < 0) { return (0); }
                return (cells[num, C_GREEN]);
            }
            return (0);
        }

        static int IsMultiForDrawing(int num)
        {
            int a = 0;
            for (int i = MIND_SIZE + 12; i < MIND_SIZE + 20; i++)
            {
                if (cells[num, i] != 0)
                {
                    a++;
                }
            }
            return (a);
        }

        public static void SaveWorldFile(string path = "")
        {
            Stopwatch time = new Stopwatch();
            time.Start();

            if (path == "")
            {
                string catalogName = @"Worlds\";
                if (SaveDirectory == null)
                    path = $"{Directory.GetCurrentDirectory()}/{catalogName}";
                else
                    path = $"{SaveDirectory}/{catalogName}";

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                path = $"{path}/{age}";
            }

            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            using (BinaryWriter sw = new BinaryWriter(fs, Encoding.UTF8))
            {
                sw.Write(seed);
                sw.Write(rand.NumberOfInvokes);

                sw.Write(muteChance);
                sw.Write(season_str);
                sw.Write(viewMode);
                sw.Write(worldSize);
                sw.Write(ETM);
                sw.Write(MTE);
                sw.Write(ETL);
                sw.Write(currentSeason);
                sw.Write(age);
                sw.Write(cellCount);
                sw.Write(printCellCount);
                sw.Write(WORLD_HEIGHT);
                sw.Write(WORLD_WIDTH);

                for (int i = 0; i < seasons.Length; i++)
                    sw.Write(seasons[i]);

                for (int x = 0; x < WORLD_WIDTH; x++)
                    for (int y = 0; y < WORLD_HEIGHT + 2; y++)
                        sw.Write(world[x, y]);

                sw.Write(cells[0, NEXT]);

                for (int i = 1; i < MAX_CELLS; i++)
                {
                    int cellState = cells[i, LIVING];
                    if (cellState == LV_ALIVE)
                        for (int j = 0; j < CELL_SIZE; j++)
                            sw.Write(cells[i, j]);
                    else
                    {
                        sw.Write((Int32)(-1));
                        sw.Write(cells[i, LIVING]);
                        if(cellState != LV_FREE)
                        {
                            sw.Write(cells[i, X_COORD]);
                            sw.Write(cells[i, Y_COORD]);
                            sw.Write(cells[i, NEXT]);
                            sw.Write(cells[i, PREV]);
                        }
                    }
                }
            }

            time.Stop();
            saveTime = string.Format("{0:00}:{1:00}", time.Elapsed.Seconds, time.Elapsed.Milliseconds);
        }

        public static void LoadWorldFile(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            using (BinaryReader reader = new BinaryReader(fs, Encoding.UTF8))
            {
                seed = reader.ReadInt32();

                UInt64 state = reader.ReadUInt64();
                rand = new StateRandom(seed, state);

                muteChance = reader.ReadInt32();
                season_str = reader.ReadString();
                viewMode = reader.ReadInt32();
                worldSize = reader.ReadInt32();
                ETM = reader.ReadInt32();
                MTE = reader.ReadInt32();
                ETL = reader.ReadInt32();
                currentSeason = reader.ReadInt32();
                age = reader.ReadInt32();
                cellCount = reader.ReadInt32();
                printCellCount = reader.ReadInt32();
                WORLD_HEIGHT = reader.ReadInt32();
                WORLD_WIDTH = reader.ReadInt32();

                MAX_CELLS = WORLD_HEIGHT * WORLD_WIDTH + 1;
                cells = new int[MAX_CELLS, CELL_SIZE];
                world = new int[WORLD_WIDTH, WORLD_HEIGHT + 2];

                for (int i = 0; i < seasons.Length; i++)
                    seasons[i] = reader.ReadInt32();

                for (int x = 0; x < WORLD_WIDTH; x++)
                    for (int y = 0; y < WORLD_HEIGHT + 2; y++)
                        world[x, y] = reader.ReadInt32();

                cells[0, NEXT] = reader.ReadInt32();
                for (int i = 1; i < MAX_CELLS; i++)
                {
                    int cellState = reader.ReadInt32();

                    if (cellState > 0)
                    {
                        cells[i, 0] = cellState;
                        for (int j = 1; j < CELL_SIZE; j++)
                            cells[i, j] = reader.ReadInt32();
                    }
                    else
                    {
                        cells[i, LIVING] = reader.ReadInt32();
                        if (cells[i, LIVING] != LV_FREE)
                        {
                            cells[i, X_COORD] = reader.ReadInt32();
                            cells[i, Y_COORD] = reader.ReadInt32();
                            cells[i, NEXT] = reader.ReadInt32();
                            cells[i, PREV] = reader.ReadInt32();
                        }
                    }
                }
            }

        }

        public static void SaveWorldTextFile(string path)
        {
            StreamWriter sw = new StreamWriter(path);
            sw.WriteLine(seed.ToString());
            sw.WriteLine(rand.NumberOfInvokes.ToString());

            sw.WriteLine(muteChance);
            sw.WriteLine(season_str);
            sw.WriteLine(viewMode.ToString());
            sw.WriteLine(worldSize.ToString());
            sw.WriteLine(ETM.ToString());
            sw.WriteLine(MTE.ToString());
            sw.WriteLine(ETL.ToString());
            sw.WriteLine(currentSeason.ToString());
            sw.WriteLine(age.ToString());
            sw.WriteLine(cellCount.ToString());
            sw.WriteLine(printCellCount.ToString());
            sw.WriteLine(WORLD_HEIGHT.ToString());
            sw.WriteLine(WORLD_WIDTH.ToString());

            for (int i = 0; i < seasons.Length; i++)
                sw.WriteLine(seasons[i].ToString());

            for (int x = 0; x < WORLD_WIDTH; x++)
            {
                for (int y = 0; y < WORLD_HEIGHT + 2; y++)
                {
                    sw.WriteLine(world[x, y].ToString());
                }
            }
            for (int i = 0; i < MAX_CELLS; i++)
            {
                for (int j = 0; j < CELL_SIZE; j++)
                {
                    sw.WriteLine(cells[i, j].ToString());
                }
            }
            sw.Dispose();
        }

        public static void LoadWorldTextFile(string path)
        {
                String[] Str = File.ReadAllLines(path);
                seed = int.Parse(Str[0]);

                UInt64 state = UInt64.Parse(Str[1]);
                rand = new StateRandom(seed, state);

                muteChance = int.Parse(Str[2]); ;
                season_str = Str[3];
                viewMode = int.Parse(Str[4]);
                worldSize = int.Parse(Str[5]);
                ETM = int.Parse(Str[6]);
                MTE = int.Parse(Str[7]);
                ETL = int.Parse(Str[8]);
                currentSeason = int.Parse(Str[9]);
                age = int.Parse(Str[10]);
                cellCount = int.Parse(Str[11]);
                printCellCount = int.Parse(Str[12]);
                WORLD_HEIGHT = int.Parse(Str[13]);
                WORLD_WIDTH = int.Parse(Str[14]);

                MAX_CELLS = WORLD_HEIGHT * WORLD_WIDTH + 1;
                cells = new int[MAX_CELLS, CELL_SIZE];
                world = new int[WORLD_WIDTH, WORLD_HEIGHT + 2];

                int Count = 15;

                for (int i = 0; i < seasons.Length; i++)
                    seasons[i] = int.Parse(Str[Count + i]);

                Count = 15 + seasons.Length;

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
                        cells[i, j] = int.Parse(Str[Count]);
                        Count++;
                    }
                }
        }

        static Color GetCellColor(int x, int y, float size, int mode)
        {
            if(x > WORLD_WIDTH || y > WORLD_HEIGHT + 2)
                return Color.White;

            if (size < 1)
            {
                int num = (int)Math.Round(1 / worldSize);

                int r = 0;
                int g = 0;
                int b = 0;

                for (int i = 0; i < num; i++)
                {
                    for (int j = 0; j < num; j++)
                    {
                        Color C = GetCellColor(x + i, y + j, 1, mode);
                        r += C.R;
                        g += C.G;
                        b += C.B;
                    }
                }

                return Color.FromArgb(255, (int)(r / (num * num)), (int)(g / (num * num)), (int)(b / (num * num)));
            }
            else
            {
                int celln = world[x, y];

                if (celln == WC_EMPTY)
                    return Color.White;
                else if (celln == WC_WALL)
                    return Color.FromArgb(255, 40, 40, 40);
                else if (cells[celln, LIVING] == LV_EARTH)
                    return Color.FromArgb(255, 150, 100, 0);
                else if (cells[celln, LIVING] == LV_STONE)
                    return Color.FromArgb(255, 150, 150, 200);
                else
                {
                    if (cells[celln, LIVING] == LV_ALIVE)
                    {
                        Color C;
                        if (mode == 1)
                            return Color.FromArgb(255, CheckColor(celln, 1), CheckColor(celln, 2), CheckColor(celln, 3));
                        else if (mode == 2)
                        {
                            int a = IsMultiForDrawing(celln);
                            if (a > 0)
                                return Color.FromArgb(255, 240 - 10 * a, 8 * a, 200 - 10 * a);
                            else
                                return Color.FromArgb(255, 0, 240, 240);
                        }
                        else if (mode == 3)
                        {
                            int E = cells[celln, ENERGY];
                            if (E <= 1000 && E >= 0)
                                return Color.FromArgb(255, 255, 255 - E / 4, 0);
                            else if (E > 1000)
                                return Color.FromArgb(255, 255, 0, 0);
                            else
                                return Color.FromArgb(255, 150, 150, 150);
                        }
                        else if (mode == 4)
                        {
                            int cellAge = cells[celln, CELL_AGE];
                            if (cellAge <= 1000 && cellAge >= 0)
                                return Color.FromArgb(255, 255 - cellAge / 5, 200, 200);
                            else if (cellAge > 1000 && cellAge <= 10000)
                                return Color.FromArgb(255, 55, 200 - (cellAge - 1000) / 50, 200);
                            else
                                return Color.FromArgb(255, 55, 20, 200);
                        }
                        else
                            return Color.FromArgb(255, cells[celln, ORIGIN_C_RED], cells[celln, ORIGIN_C_GREEN], cells[celln, ORIGIN_C_BLUE]);
                    }
                    else
                        return Color.FromArgb(255, 100, 100, 100);
                }
            }
        }

        public static void DrawWorld(Graphics graphics, int mode, float size, int xDrawStartIndex, int yDrawStartIndex, float ips = -1)
        {
            SolidBrush BR = new SolidBrush(Color.White);
            graphics.Clear(Color.White);

            int s = season;
            int maxLight = GetLightForHeight(0, s);
            int maxMineral = GetMineralForHeight(WORLD_HEIGHT + 1);

            int xBias = 40;
            int yBias = 40;
            if (ips != -1)
            {
                xBias = drawInfo ? 40 : 0;
                yBias = drawInfo ? 40 : 0;
            }

            int step = size >= 1f ? 1 : (int)Math.Round(1f / size);

            int drawSize = size >= 1f ? (int)size : 1;

            for (int x = 0; x < WORLD_WIDTH - xDrawStartIndex; x += step)
            {
                for (int y = 0; y < WORLD_HEIGHT + 2 - yDrawStartIndex; y += step)
                {
                    if (drawInfo || ips == -1)
                    {
                        int light = GetLightForHeight(y + yDrawStartIndex, s);
                        int mineral = GetMineralForHeight(y + yDrawStartIndex);

                        BR.Color = Color.FromArgb(255, 255 * light / maxLight, 255 * light / maxLight, 0);
                        graphics.FillRectangle(BR, 10, y * drawSize / step + yBias, 10, drawSize);

                        BR.Color = Color.FromArgb(255, 0, 0, 255 * mineral / maxMineral);
                        graphics.FillRectangle(BR, 25, y * drawSize / step + yBias, 10, drawSize);
                    }

                    BR.Color = GetCellColor(x + xDrawStartIndex, y + yDrawStartIndex, size, mode);

                    if (BR.Color != Color.White)
                    {
                        graphics.FillRectangle(BR, x * drawSize / step + xBias, y * drawSize / step + yBias, drawSize, drawSize);
                    }
                }
            }

            if (ips == -1)
            {
                foreach (int inspect in inspectedNums)
                {
                    if (cells[inspect, LIVING] != LV_FREE)
                    {
                        int x = cells[inspect, X_COORD] - xDrawStartIndex;
                        int y = cells[inspect, Y_COORD] - yDrawStartIndex;
                        if (x > 0 && y > 0)
                        {
                            Pen pen = new Pen(Color.FromArgb(255, 150, 25, 25));
                            graphics.DrawRectangle(pen, x * drawSize + xBias, y * drawSize + yBias, drawSize, drawSize);
                            graphics.DrawRectangle(pen, x * drawSize + xBias - 1, y * drawSize + yBias - 1, drawSize + 2, drawSize + 2);
                        }
                    }
                }
            }

            if (drawInfo || ips == -1)
            {
                if (season_str == "Summer")
                    BR.Color = Color.FromArgb(255, 240, 240, 20);
                else if (season_str == "Autumn")
                    BR.Color = Color.FromArgb(255, 240, 60, 0);
                else if (season_str == "Winter")
                    BR.Color = Color.FromArgb(255, 30, 60, 240);
                else
                    BR.Color = Color.FromArgb(255, 50, 240, 50);

                graphics.FillRectangle(BR, 320, 10, 70, 20);

                BR.Color = Color.Black;
                graphics.DrawString($"Cells: {printAliveCellCount}/{printCellCount}", new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
                BR, 10, 10);
                graphics.DrawString($"Iteration: {age}", new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
                BR, 175, 10);

                graphics.DrawString(season_str, new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
                BR, 320, 10);

                string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}",
                clock.Elapsed.Hours, clock.Elapsed.Minutes, clock.Elapsed.Seconds);

                graphics.DrawString($"Simulation Time: {elapsedTime}", new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
                BR, 400, 10);

                if (ips > 0)
                    IPS = ips;
                else if (clock.ElapsedMilliseconds != 0 && clock.IsRunning)
                    IPS = (age - prev_age) * 1000f / (clock.ElapsedMilliseconds - prev_milliseconds);

                graphics.DrawString($"IPS: {IPS}", new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
                    BR, 600, 10);

                graphics.DrawString($"{modeStrings[mode - 1]}", new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
                    BR, 800, 10);

            }
            
            

            prev_milliseconds = clock.ElapsedMilliseconds;
            prev_age = age;
        }
    }
}
