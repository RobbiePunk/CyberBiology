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

namespace CyberBiology
{

    public static class ServiceFunctions
    {
        public static String SaveDirectory;
        public static String season_str = "Summer";
        public static string saveTime;

        public static float IPS = 0;
        public static bool isDrawing = true;
        public static bool drawInfo = true;
        public static int saveSize = 0;

        public static long prev_milliseconds = 0;
        public static int prev_age = 0;
        
        public static void FirstCell()
        {
            cells[0, NEXT] = 1;
            cells[0, PREV] = 1;

            cells[1, NEXT] = 0;
            cells[1, PREV] = 0;

            cells[1, C_RED] = 170;
            cells[1, C_GREEN] = 170;
            cells[1, C_BLUE] = 170;

            cells[1, ENERGY] = 900;
            cells[1, MINERAL] = 0;
            cells[1, LIVING] = LV_ALIVE;
            cells[1, DIRECT] = 5;
            cells[1, X_COORD] = WORLD_WIDTH / 2;
            cells[1, Y_COORD] = WORLD_HEIGHT / 4 + 1;

            cells[1, CELL_AGE] = 0;

            for (int j = M1; j < M8 + 1; j++)
            {
                cells[1, j] = 0;
            }
            world[cells[1, X_COORD], cells[1, Y_COORD]] = 1;
            int i = 0;
            while (i < MIND_SIZE)
            {
                if (isRandom)
                    cells[1, i] = rand.Next() % MIND_SIZE;
                else
                    cells[1, i] = 25;
                i++;
            }
            if (!isAutoDivide)
            {
                cells[1, rand.Next() % MIND_SIZE] = 23; //поворот
                cells[1, rand.Next() % MIND_SIZE] = 22; //Деление
            }
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

            for (int j = M1; j < M8 + 1; j++)
            {
                cells[num, j] = 0;
            }
            world[x, y] = num;
            int i = 0;
            while (i < MIND_SIZE)
            {
                if (isRandom)
                    cells[num, i] = rand.Next() % MIND_SIZE;
                else
                    cells[num, i] = 25;
                i++;
            }
            if (!isAutoDivide)
            {
                cells[num, rand.Next() % MIND_SIZE] = 23; //поворот
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
                if (drawCells[num, i] != 0)
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
                sw.Write(WORLD_SIZE);
                sw.Write(ETM);
                sw.Write(MTE);
                sw.Write(ETL);
                sw.Write(currentSeason);
                sw.Write(age);
                sw.Write(cell_count);
                sw.Write(print_cell_count);
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
                WORLD_SIZE = reader.ReadInt32();
                ETM = reader.ReadInt32();
                MTE = reader.ReadInt32();
                ETL = reader.ReadInt32();
                currentSeason = reader.ReadInt32();
                age = reader.ReadInt32();
                cell_count = reader.ReadInt32();
                print_cell_count = reader.ReadInt32();
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
            sw.WriteLine(WORLD_SIZE.ToString());
            sw.WriteLine(ETM.ToString());
            sw.WriteLine(MTE.ToString());
            sw.WriteLine(ETL.ToString());
            sw.WriteLine(currentSeason.ToString());
            sw.WriteLine(age.ToString());
            sw.WriteLine(cell_count.ToString());
            sw.WriteLine(print_cell_count.ToString());
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
                WORLD_SIZE = int.Parse(Str[5]);
                ETM = int.Parse(Str[6]);
                MTE = int.Parse(Str[7]);
                ETL = int.Parse(Str[8]);
                currentSeason = int.Parse(Str[9]);
                age = int.Parse(Str[10]);
                cell_count = int.Parse(Str[11]);
                print_cell_count = int.Parse(Str[12]);
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

        public static void DrawWorld(Graphics graphics, int mode, int size, int xDrawStartIndex, int yDrawStartIndex, float ips = -1)
        {
            SolidBrush BR = new SolidBrush(Color.White);
            graphics.Clear(Color.White);

            int s = season;
            int maxLight = GetLightForHeight(0, s);

            int xBias = 40;
            int yBias = 40;
            if (ips != -1)
            {
                xBias = drawInfo ? 40 : 0;
                yBias = drawInfo ? 40 : 0;
            }

            for (int x = 0; x < WORLD_WIDTH - xDrawStartIndex; x++)
            {
                for (int y = 0; y < WORLD_HEIGHT + 2 - yDrawStartIndex; y++)
                {
                    int light = GetLightForHeight(y + yDrawStartIndex, s);

                    if (drawInfo || ips == -1)
                    {
                        BR.Color = Color.FromArgb(255, 255 * light / maxLight, 255 * light / maxLight, 0);
                        graphics.FillRectangle(BR, 10 - xDrawStartIndex * size, y * size + yBias, 10, size);
                    }

                    int celln = drawWorld[x + xDrawStartIndex, y + yDrawStartIndex];
                    if (celln == WC_EMPTY)
                    {

                    }
                    else if (celln == WC_WALL)
                    { 
                        BR.Color = Color.FromArgb(255, 40, 40, 40);
                        graphics.FillRectangle(BR, x * size + xBias, y * size + yBias, size, size);
                    }
                    else if (drawCells[celln, LIVING] == LV_EARTH)
                    {
                        BR.Color = Color.FromArgb(255, 150, 100, 0);
                        graphics.FillRectangle(BR, x * size + xBias, y * size + yBias, size, size);
                    }
                    else if (drawCells[celln, LIVING] == LV_STONE)
                    {
                        BR.Color = Color.FromArgb(255, 150, 150, 200);
                        graphics.FillRectangle(BR, x * size + xBias, y * size + yBias, size, size);
                    }
                    else
                    {
                        if (drawCells[celln, LIVING] == LV_ALIVE)
                        {
                            Color C;
                            if (mode == 1)
                            {
                                C = Color.FromArgb(255, CheckColor(celln, 1), CheckColor(celln, 2), CheckColor(celln, 3));
                            }
                            else if (mode == 2)
                            {
                                int a = IsMultiForDrawing(celln);
                                if (a > 0)
                                {

                                    C = Color.FromArgb(255, 240 - 20 * a, 10 * a, 200 - 15 * a);
                                }
                                else
                                {
                                    C = Color.FromArgb(255, 0, 240, 240);
                                }
                            }
                            else if (mode == 3)
                            {
                                int E = drawCells[celln, ENERGY];
                                if (E <= 1000 && E >= 0)
                                {
                                    C = Color.FromArgb(255, 255, 255 - E / 4, 0);
                                }
                                else if (E > 1000)
                                {
                                    C = Color.FromArgb(255, 255, 0, 0);
                                }
                                else
                                {
                                    C = Color.FromArgb(255, 150, 150, 150);
                                }
                            }
                            else
                            {
                                int cellAge = drawCells[celln, CELL_AGE];
                                if (cellAge <= 1000 && cellAge >= 0)
                                {
                                    C = Color.FromArgb(255, 255 - cellAge / 5, 200, 200);
                                }
                                else if (cellAge > 1000 && cellAge <= 10000)
                                {
                                    C = Color.FromArgb(255, 55, 200 - (cellAge - 1000) / 50, 200);
                                }
                                else
                                {
                                    C = Color.FromArgb(255, 55, 20, 200);
                                }
                            }

                            BR.Color = C;
                            graphics.FillRectangle(BR, x * size + 40, y * size + 40, size, size);
                        }
                        else
                        {
                            BR.Color = Color.FromArgb(255, 100, 100, 100);
                            graphics.FillRectangle(BR, x * size + xBias, y * size + yBias, size, size);
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

                graphics.FillRectangle(BR, 300, 10, 70, 20);

                BR.Color = Color.Black;
                graphics.DrawString("Cells: " + print_cell_count.ToString(), new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
                BR, 40, 10);
                graphics.DrawString("Iteration: " + age.ToString(), new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
                BR, 150, 10);


                graphics.DrawString(season_str, new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
                BR, 300, 10);

                string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}",
                clock.Elapsed.Hours, clock.Elapsed.Minutes, clock.Elapsed.Seconds);

                graphics.DrawString("Simulation Time: " + elapsedTime, new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
                BR, 400, 10);

                if (ips > 0)
                    IPS = ips;
                else if (clock.ElapsedMilliseconds != 0 && clock.IsRunning)
                    IPS = (age - prev_age) * 1000f / (clock.ElapsedMilliseconds - prev_milliseconds);

                graphics.DrawString($"IPS: {IPS}", new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
                    BR, 600, 10);

            }
            prev_milliseconds = clock.ElapsedMilliseconds;
            prev_age = age;
        }
    }
}
