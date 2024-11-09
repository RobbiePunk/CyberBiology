using System;
using static CyberBiology.Constants;
using static CyberBiology.Simulation;

namespace CyberBiology
{
    public static class CellAditionalFunctions
    {
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
            int nrg = season - ((cells[num, Y_COORD] / (WORLD_HEIGHT / 96) - 1) / 8) + t;
            if (nrg >= 3) { return (1); }
            else { return (2); }

        }
        public static int isMulti(int num)
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

        public static int get_param(int num)
        {
            int adr = cells[num, ADR] + 1;
            if (adr >= MIND_SIZE) { adr -= MIND_SIZE; }
            return (cells[num, adr]);
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
            {
                y--;
            }
            else
            {
                if (n == 4 || n == 5 || n == 6)
                {
                    y++;
                }
            }
            return (y);
        }
        public static int X_from_vector_a(int num, int n)
        {
            int x = cells[num, X_COORD];
            if (n == 0 || n == 6 || n == 7)
            {
                x--;
                if (x < 0) { x = WORLD_WIDTH - 1; }
            }
            else
            {
                if (n == 2 || n == 3 || n == 4)
                {
                    x++;
                    if (x > WORLD_WIDTH - 1)
                    {
                        x = 0;
                    }
                }
            }
            return (x);
        }
        public static int Y_from_vector_r(int num, int n)
        {
            int y = cells[num, Y_COORD];
            n += cells[num, DIRECT];
            if (n > 7) { n -= 8; }
            if (n < 3) { y--; }
            else
            {
                if (n == 4 || n == 5 || n == 6)
                {
                    y++;
                }
            }
            return (y);
        }
        public static int X_from_vector_r(int num, int n)
        {
            int x = cells[num, X_COORD];
            n += cells[num, DIRECT];
            if (n > 7) { n -= 8; }
            if (n == 0 || n == 6 || n == 7)
            {
                x--;
                if (x < 0) { x = WORLD_WIDTH - 1; }
            }
            else
            {
                if (n == 2 || n == 3 || n == 4)
                {
                    x++;
                    if (x > WORLD_WIDTH - 1)
                    {
                        x = 0;
                    }
                }
            }
            return (x);
        }
        public static void inc_command_address(int num, int n)
        {
            int adr = cells[num, ADR] + n;
            if (adr >= MIND_SIZE) { adr -= MIND_SIZE; }
            cells[num, ADR] = adr;
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
            for (int i = MIND_SIZE + 12; i < MIND_SIZE + 20; i++)
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
            for (int i = MIND_SIZE + 12; i < MIND_SIZE + 20; i++)
            {
                if (cells[num, i] == 0)
                {
                    return (i);
                }
            }
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
            int adr = cells[num, ADR];
            adr += a;
            if (adr >= MIND_SIZE) { adr -= MIND_SIZE; }
            int bias = cells[num, adr];
            inc_command_address(num, bias);
        }
    }
}
