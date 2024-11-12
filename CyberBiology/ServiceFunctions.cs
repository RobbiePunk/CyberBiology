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

namespace CyberBiology
{

    public static class ServiceFunctions
    {

        public static String SaveDirectory;
        public static String season_str = "Summer";

        
        public static void FirstCell()
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
            cells[1, Y_COORD] = WORLD_HEIGHT / 3;

            cells[1, CELL_AGE] = 0;

            for (int j = M1; j < M8 + 1; j++)
            {
                cells[1, j] = 0;
            }
            world[WORLD_WIDTH / 2, WORLD_HEIGHT / 3] = 1;
            int i = 0;
            while (i < MIND_SIZE)
            {
                cells[1, i] = 25;
                i++;
            }
            //cells[1, MIND_SIZE - 1] = 22; //Деление
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

        static int isMultiForDrawing(int num)
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

            StreamWriter sw = new StreamWriter(path);
            sw.WriteLine(seed.ToString());
            sw.WriteLine(rand.NumberOfInvokes.ToString());

            sw.WriteLine(season_str);
            sw.WriteLine(viewMode.ToString());
            sw.WriteLine(WORLD_SIZE.ToString());
            sw.WriteLine(ETM.ToString());
            sw.WriteLine(MTE.ToString());
            sw.WriteLine(ETL.ToString());
            sw.WriteLine(season.ToString());
            sw.WriteLine(age.ToString());
            sw.WriteLine(cell_count.ToString());
            sw.WriteLine(Print_cell_count.ToString());
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

        public static void DrawWorld(Graphics graphics, int mode, int size, int xDrawStartIndex, int yDrawStartIndex)
        {
            SolidBrush BR = new SolidBrush(Color.White);
            graphics.Clear(Color.White);

            int s = season;
            int maxLight = GetLightForHeight(0, s);

            for (int x = 0; x < WORLD_WIDTH - xDrawStartIndex; x++)
            {
                for (int y = 0; y < WORLD_HEIGHT + 2 - yDrawStartIndex; y++)
                {
                    int light = GetLightForHeight(y + yDrawStartIndex, s);

                    BR.Color = Color.FromArgb(255, 255 * light / maxLight, 255 * light / maxLight, 0);
                    graphics.FillRectangle(BR, 10 - xDrawStartIndex * size, y * size + 40, 10, size);


                    int celln = drawWorld[x + xDrawStartIndex, y + yDrawStartIndex];
                    if (celln == WC_EMPTY)
                    {

                    }
                    else if (celln == WC_WALL)
                    { 
                        BR.Color = Color.FromArgb(255, 40, 40, 40);
                        graphics.FillRectangle(BR, x * size + 40, y * size + 40, size, size);
                    }
                    else if (drawCells[celln, LIVING] == LV_EARTH)
                    {
                        BR.Color = Color.FromArgb(255, 150, 100, 0);
                        graphics.FillRectangle(BR, x * size + 40, y * size + 40, size, size);
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
                                int a = isMultiForDrawing(celln);
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
                            graphics.FillRectangle(BR, x * size + 40, y * size + 40, size, size);
                        }
                    }
                }
            }

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
            graphics.DrawString("Cells: " + Print_cell_count.ToString(), new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
            BR, 40, 10);
            graphics.DrawString("Iteration: " + age.ToString(), new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
            BR, 150, 10);


            graphics.DrawString(season_str, new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
            BR, 300, 10);

            string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}",
            clock.Elapsed.Hours, clock.Elapsed.Minutes, clock.Elapsed.Seconds);

            graphics.DrawString("Simulation Time: " + elapsedTime, new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
            BR, 400, 10);

            if (clock.ElapsedMilliseconds != 0)
                graphics.DrawString("IPS: " + (age * 1000f / clock.ElapsedMilliseconds).ToString(), new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
                BR, 600, 10);
        }
    }
}
