using static CyberBiology.Constants;
using static CyberBiology.Simulation;
using static CyberBiology.CellAditionalFunctions;
using System.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System;

namespace CyberBiology
{
    public static class ServiceFunctions
    {
        public static String SaveImageDirectory;
        public static String season_str = "Summer";

        public static int GetLightForHeight(int y, int s)
        {
            int light = s - ((y / (WORLD_HEIGHT / 96) - 1) / 8);
            return light > 0 ? light : 0;
        }

        public static void EarthBlockCreate(int num)
        {
            for (int i = 0; i < 8; i++)
            {
                int x = X_from_vector_a(num, i);
                int y = Y_from_vector_a(num, i);
                if (world[x, y] > 0)
                {
                    if (cells[world[x, y], LIVING] == LV_EARTH || cells[world[x, y], LIVING] == LV_FALLING_EARTH)
                    {
                        if (cells[num, MIND_SIZE + i] == world[x, y])
                        {
                            cells[num, MIND_SIZE - i]++;
                            if (cells[num, MIND_SIZE - i] > 500)
                            {
                                cells[num, MIND_SIZE - i] = 500;
                            }
                        }
                        else
                        {
                            cells[num, MIND_SIZE + i] = world[x, y];
                            cells[num, MIND_SIZE - i] = 0;
                        }
                    }
                    else
                    {
                        cells[num, MIND_SIZE + i] = 0;
                        cells[num, MIND_SIZE - i] = 0;
                    }
                }
                else
                {
                    cells[num, MIND_SIZE + i] = 0;
                    cells[num, MIND_SIZE - i] = 0;
                }
            }
        }
        public static void delete_cell(int num)
        {
            world[cells[num, X_COORD], cells[num, Y_COORD]] = WC_EMPTY;
            cells[cells[num, PREV], NEXT] = cells[num, NEXT];
            cells[cells[num, NEXT], PREV] = cells[num, PREV];
            for (int i = M1; i <= M8; i++)
            {
                if (cells[num, i] != 0)
                {
                    for (int j = M1; j <= M8; j++)
                    {
                        if (cells[cells[num, i], j] == num)
                        {
                            cells[cells[num, i], j] = 0;
                            break;
                        }
                    }
                    cells[num, i] = 0;
                }
            }
            cells[num, LIVING] = LV_FREE;
        }
        public static void move_cell(int num, int x, int y)
        {
            world[x, y] = num;
            world[cells[num, X_COORD], cells[num, Y_COORD]] = WC_EMPTY;
            cells[num, X_COORD] = x;
            cells[num, Y_COORD] = y;
        }
        public static void Fall(int num)
        {
            int x = cells[num, X_COORD];
            int y = cells[num, Y_COORD] + 1;

            if (world[x, y] == WC_EMPTY)
            {
                world[x, y - 1] = WC_EMPTY;
                world[x, y] = num;
                cells[num, Y_COORD] = y;
            }
        }

        public static void Pressure(int num)
        {
            cells[num, PUSH] = 0;
            int x = cells[num, X_COORD];
            int cy = cells[num, Y_COORD];
            if (world[x, cy + 1] == WC_WALL || cells[world[x, cy + 1], LIVING] >= LV_EARTH)
            {
                for (int y = cy - 1; y > 1; y--)
                {
                    if (world[x, y] > 0)
                    {
                        int S = cells[world[x, y], LIVING];
                        if (S == LV_DEAD)
                        {
                            cells[num, PUSH]++;
                        }
                        else if (S == LV_FALLING_EARTH)
                        {
                            cells[num, PUSH] += 2;
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        return;
                    }

                }
            }
        }
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

        public static void go_GREEN(int num, int val)
        {
            if (cells[num, C_GREEN] + val > 255)
            {
                cells[num, C_GREEN] = 255;
            }
            else
            {
                cells[num, C_GREEN] += val;
            }

            int vl = val / 2;

            if (cells[num, C_RED] - vl < 0)
            {
                cells[num, C_RED] = 0;
            }
            else
            {
                cells[num, C_RED] -= vl;
            }

            if (cells[num, C_BLUE] - vl < 0)
            {
                cells[num, C_BLUE] = 0;
            }
            else
            {
                cells[num, C_BLUE] -= vl;
            }
        }
        public static void go_RED(int num, int val)
        {
            if (cells[num, C_RED] + val > 255)
            {
                cells[num, C_RED] = 255;
            }
            else
            {
                cells[num, C_RED] += val;
            }

            int vl = val / 2;

            if (cells[num, C_GREEN] - vl < 0)
            {
                cells[num, C_GREEN] = 0;
            }
            else
            {
                cells[num, C_GREEN] -= vl;
            }

            if (cells[num, C_BLUE] - vl < 0)
            {
                cells[num, C_BLUE] = 0;
            }
            else
            {
                cells[num, C_BLUE] -= vl;
            }
        }
        public static void go_BLUE(int num, int val)
        {
            if (cells[num, C_BLUE] + val > 255)
            {
                cells[num, C_BLUE] = 255;
            }
            else
            {
                cells[num, C_BLUE] += val;
            }

            int vl = val / 2;

            if (cells[num, C_GREEN] - vl < 0)
            {
                cells[num, C_GREEN] = 0;
            }
            else
            {
                cells[num, C_GREEN] -= vl;
            }

            if (cells[num, C_RED] - vl < 0)
            {
                cells[num, C_RED] = 0;
            }
            else
            {
                cells[num, C_RED] -= vl;
            }
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
