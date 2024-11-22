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
                int x = XFromVectorA(num, i);
                int y = YFromVectorA(num, i);
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
        public static bool IsSolidBelow(int num)
        {
            int x = cells[num, X_COORD];
            int y = cells[num, Y_COORD] + 1;

            return (world[x, y] == -5 || cells[world[x, y], LIVING] > cells[num, LIVING]);  
        }

        public static void DeleteCell(int num)
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
        public static void MoveCell(int num, int x, int y)
        {
            world[x, y] = num;
            world[cells[num, X_COORD], cells[num, Y_COORD]] = WC_EMPTY;
            cells[num, X_COORD] = x;
            cells[num, Y_COORD] = y;
        }
        public static int PushCell(int num, int dr)
        {
            return CellMove(num, dr, 1);
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

        public static int IsEarthBlock(int num)
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
        public static int IsRelative(int num0, int num1)
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
        public static int IsEnergyGrow(int num)
        {
            int t;
            if (cells[num, MINERAL] < 100) { t = 0; }
            else if (cells[num, MINERAL] < 400) { t = 1; }
            else { t = 2; }
            int nrg = GetLightForHeight(cells[num, Y_COORD], season) + t;
            if (nrg >= 3) { return (1); }
            else { return (2); }

        }
        public static int IsMulti(int num)
        {
            int a = 0;
            for (int i = M1; i <= M8; i++)
                if (cells[num, i] != 0)
                    a++;

            return (a);
        }

        public static int GetParam(int num)
        {
            return (cells[num, cells[num, ADR] + 1] % MIND_SIZE);
        }
        public static int WhatIsThereR(int num, int dr)
        {
            int x = XFromVectorR(num, dr);
            int y = YFromVectorR(num, dr);
            int result = world[x, y];
            return (result);
        }
        public static int WhatIsThereA(int num, int dr)
        {
            int x = XFromVectorA(num, dr);
            int y = YFromVectorA(num, dr);
            int result = world[x, y];
            return (result);
        }
        public static int YFromVectorA(int num, int n)
        {
            int y = cells[num, Y_COORD];
            if (n < 3)
                y--;
            else if(n == 4 || n == 5 || n == 6)
                y++;

            return (y);
        }
        public static int XFromVectorA(int num, int n)
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
        public static int YFromVectorR(int num, int n)
        {
            int y = cells[num, Y_COORD];
            n += cells[num, DIRECT] % 8;

            if (n < 3)
                y--;
            else if(n == 4 || n == 5 || n == 6)      
                y++;

            return (y);
        }
        public static int XFromVectorR(int num, int n)
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
        public static void IncCommandAddress(int num, int n)
        {
            cells[num, ADR] = (cells[num, ADR] + n) % MIND_SIZE;
        }
        public static int FindEmptyDirection(int num)
        {
            for (int i = 0; i < 8; i++)
            {
                int x = XFromVectorR(num, i);
                int y = YFromVectorR(num, i);
                if (world[x, y] == WC_EMPTY) { return (i); }
            }
            return (8);
        }
        public static int FindEmptyCell()
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

        public static int IsColonyMove(int num, int x, int y)
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
        public static int FindEmptyMulti(int num)
        {
            for (int i = M1; i <= M8; i++)
                if (cells[num, i] == 0)
                    return (i);
            return (0);
        }
        public static int IsFullAround(int num)
        {
            for (int i = 0; i < 8; i++)
            {
                int x = XFromVectorR(num, i);
                int y = YFromVectorR(num, i);
                if (world[x, y] == WC_EMPTY) { return (2); }
            }
            return (1);
        }
        public static void IndirectIncCmdAddress(int num, int a)
        {
            cells[num, ADR] = (cells[num, ADR] + cells[num, (cells[num, ADR] + a) % MIND_SIZE]) % MIND_SIZE;
        }

        public static void GoGreen(int num, int val)
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
        public static void GoRed(int num, int val)
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
        public static void GoBlue(int num, int val)
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
