using static CyberBiology.Constants;
using static CyberBiology.Simulation;
using static CyberBiology.CellAditionalFunctions;

namespace CyberBiology
{
    public static class ServiceFunctions
    {
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

    }
}
