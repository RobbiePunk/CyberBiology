using System;
using static CyberBiology.Constants;
using static CyberBiology.Simulation;
using static CyberBiology.CellFunctions;
using static CyberBiology.ServiceFunctions;

namespace CyberBiology
{
    public static class CellAditionalFunctions
    {
        public static int GetLightForHeight(int y, int s)
        {
            int light = s - ((96 * y  / WORLD_HEIGHT - 1) / 8);
            return (light > 0) ? light : 0;
        }

        public static void EarthBlockCreate(int num)
        {
            for (int i = 0; i < 8; i++)
            {
                int x = X_from_vector_a(num, i);
                int y = Y_from_vector_a(num, i);
                if (world[x, y] > 0)
                {
                    if (cells[world[x, y], LIVING] == LV_EARTH)
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
        public static bool SolidBelow(int num)
        {
            int x = cells[num, X_COORD];
            int y = cells[num, Y_COORD] + 1;

            return (world[x, y] == -5 || cells[world[x, y], LIVING] > cells[num, LIVING]);  
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
        public static int push_cell(int num, int dr)
        {
            return cell_move(num, dr, 1);
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
                        else if (S == LV_EARTH)
                        {
                            cells[num, PUSH] += 2;
                        }
                        else if (S == LV_STONE)
                        {
                            cells[num, PUSH] += 3;
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

        public static int isEarthBlock(int num)
        {
            int n = 0;
            for (int i = 0; i < 8; i++)
            {
                if (cells[num, MIND_SIZE - i] == 500)
                {
                    n++;
                }
            }
            return (n);
        }
        public static int is_relative(int num0, int num1)
        {
            if (cells[num1, LIVING] < LV_ALIVE) { return (0); }
            int dif = 0;
            for (int i = 0; i < MIND_SIZE; i++)
            {
                if (cells[num0, i] != cells[num1, i])
                {
                    dif++;
                    if (dif == 2) { return (0); }
                }
            }
            return (1);
        }
        public static int is_energy_grow(int num)
        {
            int t;
            if (cells[num, MINERAL] < 100) { t = 0; }
            else if (cells[num, MINERAL] < 400) { t = 1; }
            else { t = 2; }
            int nrg = GetLightForHeight(cells[num, Y_COORD], season) + t;
            if (nrg >= 3) { return (1); }
            else { return (2); }

        }
        public static int isMulti(int num)
        {
            int a = 0;
            for (int i = M1; i <= M8; i++)
                if (cells[num, i] != 0)
                    a++;

            return (a);
        }

        public static int get_param(int num)
        {
            return (cells[num, cells[num, ADR] + 1] % MIND_SIZE);
        }
        public static int what_is_there_r(int num, int dr)
        {
            int x = X_from_vector_r(num, dr);
            int y = Y_from_vector_r(num, dr);
            int result = world[x, y];
            return (result);
        }
        public static int what_is_there_a(int num, int dr)
        {
            int x = X_from_vector_a(num, dr);
            int y = Y_from_vector_a(num, dr);
            int result = world[x, y];
            return (result);
        }
        public static int Y_from_vector_a(int num, int n)
        {
            int y = cells[num, Y_COORD];
            if (n < 3)
                y--;
            else if(n == 4 || n == 5 || n == 6)
                y++;

            return (y);
        }
        public static int X_from_vector_a(int num, int n)
        {
            int x = cells[num, X_COORD];
            if (n == 0 || n == 6 || n == 7)
            {
                x--;
                if (x < 0)
                    x = WORLD_WIDTH - 1;
            }
            else if (n == 2 || n == 3 || n == 4)
            {
                x++;
                if (x == WORLD_WIDTH)
                    x = 0;
            }
            return (x);
        }
        public static int Y_from_vector_r(int num, int n)
        {
            int y = cells[num, Y_COORD];
            n += cells[num, DIRECT] % 8;

            if (n < 3)
                y--;
            else if(n == 4 || n == 5 || n == 6)      
                y++;

            return (y);
        }
        public static int X_from_vector_r(int num, int n)
        {
            int x = cells[num, X_COORD];
            n += cells[num, DIRECT] % 8;

            if (n == 0 || n == 6 || n == 7)
            {
                x--;
                if (x < 0)
                    x = WORLD_WIDTH - 1;
            }
            else if (n == 2 || n == 3 || n == 4)
            {
                    x++;
                    if (x > WORLD_WIDTH - 1)
                        x = 0;
            }
            return (x);
        }
        public static void inc_command_address(int num, int n)
        {
            cells[num, ADR] = (cells[num, ADR] + n) % MIND_SIZE;
        }
        public static int find_empty_direction(int num)
        {
            for (int i = 0; i < 8; i++)
            {
                int x = X_from_vector_r(num, i);
                int y = Y_from_vector_r(num, i);
                if (world[x, y] == WC_EMPTY) { return (i); }
            }
            return (8);
        }
        public static int find_empty()
        {
            for (int i = 1; i < MAX_CELLS; i++)
            {
                if (cells[i, LIVING] == LV_FREE)
                {
                    return (i);
                }
            }
            return (0);
        }

        public static int isColonyMove(int num, int x, int y)
        {
            for (int i = M1; i <= M8; i++)
            {
                if (cells[num, i] != 0)
                {
                    int x1 = cells[cells[num, i], X_COORD];
                    int y1 = cells[cells[num, i], Y_COORD];
                    if (Math.Abs(y - y1) > 1)
                    {
                        return (0);
                    }
                    if (x1 == WORLD_WIDTH - 1 && x == 0)
                    {

                    }
                    else if (x1 == 0 && x == WORLD_WIDTH - 1)
                    {

                    }
                    else
                    {
                        if (Math.Abs(x - x1) > 1)
                        {
                            return (0);
                        }
                    }
                }
            }
            return (1);
        }
        public static int find_empty_multi(int num)
        {
            for (int i = M1; i <= M8; i++)
                if (cells[num, i] == 0)
                    return (i);
            return (0);
        }
        public static int full_around(int num)
        {
            for (int i = 0; i < 8; i++)
            {
                int x = X_from_vector_r(num, i);
                int y = Y_from_vector_r(num, i);
                if (world[x, y] == WC_EMPTY) { return (2); }
            }
            return (1);
        }
        public static void indirect_inc_cmd_address(int num, int a)
        {
            cells[num, ADR] = (cells[num, ADR] + cells[num, (cells[num, ADR] + a) % MIND_SIZE]) % MIND_SIZE;
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

    }
}
