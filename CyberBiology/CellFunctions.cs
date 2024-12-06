using static CyberBiology.Constants;
using static CyberBiology.Simulation;
using static CyberBiology.CellAditionalFunctions;
using static CyberBiology.ServiceFunctions;

namespace CyberBiology
{
    public static class CellFunctions
    {
        public static void ColonySharing(int num)
        {
            int C = 1;
            int En = cells[num, ENERGY];
            int Min = cells[num, MINERAL];
            for (int i = M1; i <= M8; i++)
            {
                if (cells[num, i] != 0)
                {
                    C++;
                    En += cells[cells[num, i], ENERGY];
                    Min += cells[cells[num, i], MINERAL];
                }
            }
            int MinMode = Min % C;
            int EnMode = En % C;
            En /= C;
            Min /= C;
            cells[num, ENERGY] = En + EnMode;
            cells[num, MINERAL] = Min + MinMode;
            for (int i = M1; i <= M8; i++)
            {
                if (cells[num, i] != 0)
                {
                    cells[cells[num, i], ENERGY] = En;
                    cells[cells[num, i], MINERAL] = Min;
                }
            }
        }
        public static void CellMineralToEnergy(int num)
        {
            if (cells[num, MINERAL] > 50)
            {
                cells[num, MINERAL] -= 50;
                cells[num, ENERGY] += 50 * MTE;
                GoBlue(num, 50);
            }
            else if(cells[num, MINERAL] > 0)
            {
                GoBlue(num, cells[num, MINERAL]);
                cells[num, ENERGY] += MTE * cells[num, MINERAL];
                cells[num, MINERAL] = 0;
            }
        }
        public static void Fotosintez(int num)
        {
            int t;
            if (cells[num, MINERAL] < 100) { t = 0; }
            else if (cells[num, MINERAL] < 400) { t = 1; }
            else { t = 2; }
            int hlt = GetLightForHeight(cells[num, Y_COORD], season) + t;
            if (hlt > 0)
            {
                cells[num, ENERGY] += hlt;
                GoGreen(num, hlt);
            }
        }

        public static int CellMove(int num, int dr, int ra)
        {
            cells[num, ENERGY] -= ETM;
            int x;
            int y;
            if (ra == 0)
            {
                x = XFromVectorR(num, dr);
                y = YFromVectorR(num, dr);
            }
            else
            {
                x = XFromVectorA(num, dr);
                y = YFromVectorA(num, dr);
            }
            if (world[x, y] == WC_EMPTY)
            {
                MoveCell(num, x, y);
                return (2);
            }
            if (world[x, y] == WC_WALL)
            {
                return (3);
            }
            if (cells[world[x, y], LIVING] == LV_EARTH)
            {
                return (7);
            }
            if (cells[world[x, y], LIVING] == LV_STONE)
            {
                return (8);
            }
            if (cells[world[x, y], LIVING] == LV_DEAD)
            {
                return (4);
            }
            if (IsRelative(num, world[x, y]) == 1)
            {
                return (6);
            }

            return (5);
        }
        public static int CellMultiMove(int num, int dr, int ra)
        {
            cells[num, ENERGY] -= ETM;
            int x;
            int y;
            if (ra == 0)
            {
                x = XFromVectorR(num, dr);
                y = YFromVectorR(num, dr);
            }
            else
            {
                x = XFromVectorA(num, dr);
                y = YFromVectorA(num, dr);
            }

            if (world[x, y] == WC_EMPTY)
            {
                if (IsColonyMove(num, x, y) == 1)
                {
                    MoveCell(num, x, y);
                    return (7);
                }
                return (2);
            }
            if (world[x, y] == WC_WALL)
            {
                return (3);
            }
            if (cells[world[x, y], LIVING] == LV_EARTH)
            {
                return (8);
            }
            if (cells[world[x, y], LIVING] == LV_DEAD)
            {
                return (4);
            }
            if (IsRelative(num, world[x, y]) == 1)
            {
                return (6);
            }

            return (5);
        }

        public static int CellEat(int num, int dr, int ra)
        {
            int x;
            int y;
            cells[num, ENERGY] -= 4;
            if (ra == 0)
            {
                x = XFromVectorR(num, dr);
                y = YFromVectorR(num, dr);
            }
            else
            {
                x = XFromVectorA(num, dr);
                y = YFromVectorA(num, dr);
            }
            if (world[x, y] == WC_EMPTY)
            {
                return (2);
            }
            if (world[x, y] == WC_WALL)
            {
                return (3);
            }
            if (cells[world[x, y], LIVING] == LV_EARTH)
            {
                return (6);
            }
            if (cells[world[x, y], LIVING] == LV_STONE)
            {
                return (1);
            }
            if (cells[world[x, y], LIVING] == LV_DEAD)
            {
                DeleteCell(world[x, y]);
                cells[num, ENERGY] += 100;
                GoRed(num, 100);
                return (4);
            }
            int min0 = cells[num, MINERAL];
            int min1 = cells[world[x, y], MINERAL];
            int hl = cells[world[x, y], ENERGY];

            DeleteCell(world[x, y]);
            int cl = 100 + (hl / 2);
            cells[num, ENERGY] += 100 + (hl / 2);
            GoRed(num, cl);
            return (5);
            /*
            if (min0 > min1)
            {
                cells[num, MINERAL] = min0 - min1;
                delete_cell(world[x, y]);
                int cl = 100 + (hl / 2);
                cells[num, ENERGY] += cl;
                go_RED(num, cl);
                return (5);
            }
            cells[num, MINERAL] = 0;
            min1 -= min0;

            if (cells[num, ENERGY] >= 2 * min1)
            {
                delete_cell(world[x, y]);
                int cl = 100 + (hl / 2) - 2 * min1;
                cells[num, ENERGY] += cl;
                go_RED(num, cl);
                return (5);
            }

            cells[world[x, y], MINERAL] = min1 - (cells[num, ENERGY] / 2);
            cells[num, ENERGY] = -10;
            return (5);*/
        }
        public static int AcidSplit(int num, int dr, int ra)
        {
            int x;
            int y;
            cells[num, ENERGY] -= ETAS;
            if (ra == 0)
            {
                x = XFromVectorR(num, dr);
                y = YFromVectorR(num, dr);
            }
            else
            {
                x = XFromVectorA(num, dr);
                y = YFromVectorA(num, dr);
            }
            if (world[x, y] == WC_EMPTY)
            {
                return (2);
            }
            if (world[x, y] == WC_WALL)
            {
                return (3);
            }
            if (cells[world[x, y], LIVING] == LV_EARTH)
            {
                cells[world[x, y], LIVING] = LV_DEAD;
                return (6);
            }
            if (cells[world[x, y], LIVING] == LV_STONE)
            {
                cells[world[x, y], LIVING] = LV_EARTH;
                return (1);
            }
            if (cells[world[x, y], LIVING] == LV_DEAD)
            {
                return (4);
            }
            return (2);
        }

        public static int CellLook(int num, int dr, int ra)
        {
            int wc;
            if (ra == 0)
            {
                wc = WhatIsThereR(num, dr);
            }
            else
            {
                wc = WhatIsThereA(num, dr);
            }
            if (wc == WC_EMPTY)
            {
                return (2);
            }
            if (wc == WC_WALL)
            {
                return (3);
            }
            if (cells[wc, LIVING] == LV_EARTH)
            {
                return (7);
            }
            if (cells[wc, LIVING] == LV_DEAD)
            {
                return (4);
            }
            if (IsRelative(num, wc) == 1)
            {
                return (6);
            }
            else
            {
                return (5);
            }
        }

        public static int CellCare(int num, int dr, int ra)
        {
            int x;
            int y;
            if (ra == 0)
            {
                x = XFromVectorR(num, dr);
                y = YFromVectorR(num, dr);
            }
            else
            {
                x = XFromVectorA(num, dr);
                y = YFromVectorA(num, dr);
            }
            if (world[x, y] == WC_EMPTY)
            {
                return (2);
            }
            if (world[x, y] == WC_WALL)
            {
                return (3);
            }
            if (cells[world[x, y], LIVING] == LV_EARTH)
            {
                return (6);
            }
            if (cells[world[x, y], LIVING] == LV_DEAD)
            {
                return (4);
            }

            int enrg0 = cells[num, ENERGY];
            int enrg1 = cells[world[x, y], ENERGY];
            int min0 = cells[num, MINERAL];
            int min1 = cells[world[x, y], MINERAL];
            if (enrg0 > enrg1)
            {
                int enrg = (enrg0 - enrg1) / 2;
                cells[num, ENERGY] -= enrg;
                cells[world[x, y], ENERGY] += enrg;
            }
            if (min0 > min1)
            {
                int min = (min0 - min1) / 2;
                cells[num, MINERAL] -= min;
                cells[world[x, y], MINERAL] += min;
            }
            return (5);
        }
        public static int CellGive(int num, int dr, int ra)
        {
            int x;
            int y;
            if (ra == 0)
            {
                x = XFromVectorR(num, dr);
                y = YFromVectorR(num, dr);
            }
            else
            {
                x = XFromVectorA(num, dr);
                y = YFromVectorA(num, dr);
            }
            if (world[x, y] == WC_EMPTY)
            {
                return (2);
            }
            if (world[x, y] == WC_WALL)
            {
                return (3);
            }
            if (cells[world[x, y], LIVING] == LV_EARTH)
            {
                return (6);
            }
            if (cells[world[x, y], LIVING] == LV_DEAD)
            {
                return (4);
            }

            int enrg = cells[num, ENERGY] / 4;
            cells[num, ENERGY] -= enrg;
            cells[world[x, y], ENERGY] += enrg;

            if (cells[world[x, y], ENERGY] > 999)
            {
                cells[world[x, y], ENERGY] = 999;
            }

            if (cells[num, MINERAL] > 3)
            {
                int min = cells[num, MINERAL] / 4;
                cells[num, MINERAL] -= min;
                cells[world[x, y], MINERAL] += min;
                if (cells[world[x, y], MINERAL] > 499)
                {
                    cells[world[x, y], MINERAL] = 499;
                }
            }

            return (5);
        }

        public static void CellDouble(int num)
        {
            cells[num, ENERGY] -= 150;
            if (cells[num, ENERGY] <= 0) { return; }

            int n = FindEmptyDirection(num);

            if (n == 8)
            {
                cells[num, ENERGY] = 0;
                return;
            }

            int newcell = FindEmptyCell();
            for (int i = 0; i < MIND_SIZE; i++)
            {
                cells[newcell, i] = cells[num, i];
            }
            int vi = rand.Next();
            if (vi % 100 < muteChance)
            {
                int ma = rand.Next() % MIND_SIZE;
                int mc = rand.Next() % MIND_SIZE;
                cells[newcell, ma] = mc;
            }

            cells[newcell, ADR] = 0;
            cells[newcell, ENERGY] = cells[num, ENERGY] / 2;
            cells[num, ENERGY] = cells[newcell, ENERGY];
            cells[newcell, MINERAL] = cells[num, MINERAL] / 2;
            cells[num, MINERAL] = cells[newcell, MINERAL];
            cells[newcell, X_COORD] = XFromVectorR(num, n);
            cells[newcell, Y_COORD] = YFromVectorR(num, n);

            world[cells[newcell, X_COORD], cells[newcell, Y_COORD]] = newcell;

            cells[newcell, C_RED] = cells[num, C_RED];
            cells[newcell, C_GREEN] = cells[num, C_GREEN];
            cells[newcell, C_BLUE] = cells[num, C_BLUE];

            cells[newcell, ORIGIN_C_RED] = cells[num, ORIGIN_C_RED];
            cells[newcell, ORIGIN_C_GREEN] = cells[num, ORIGIN_C_GREEN];
            cells[newcell, ORIGIN_C_BLUE] = cells[num, ORIGIN_C_BLUE];

            cells[newcell, LIVING] = LV_ALIVE;
            cells[newcell, DIRECT] = rand.Next() % 8;

            int px = cells[num, PREV];

            cells[newcell, PREV] = px;
            cells[px, NEXT] = newcell;
            cells[newcell, NEXT] = num;
            cells[num, PREV] = newcell;

            cells[newcell, CELL_AGE] = 0;

            for (int i = M1; i <= M8; i++)
            {
                cells[newcell, i] = 0;
            }
        }
        public static void CellMulti(int num)
        {
            int C = IsMulti(num);

            if (C == 8) { return; }

            cells[num, ENERGY] -= 150;
            if (cells[num, ENERGY] <= 0) { return; }
            int n = FindEmptyDirection(num);

            if (n == 8)
            {
                //cells[num, ENERGY] /= 2;
                return;
            }

            int newcell = FindEmptyCell();
            for (int i = 0; i < MIND_SIZE; i++)
            {
                cells[newcell, i] = cells[num, i];
            }
            int vi = rand.Next();
            if (vi % 100 < muteChance)
            {
                int ma = rand.Next() % 64;
                int mc = rand.Next() % 64;
                cells[newcell, ma] = mc;
            }

            cells[newcell, ADR] = 0;
            cells[newcell, ENERGY] = cells[num, ENERGY] / 2;
            cells[num, ENERGY] = cells[newcell, ENERGY];
            cells[newcell, MINERAL] = cells[num, MINERAL] / 2;
            cells[num, MINERAL] = cells[newcell, MINERAL];
            cells[newcell, X_COORD] = XFromVectorR(num, n);
            cells[newcell, Y_COORD] = YFromVectorR(num, n);

            world[cells[newcell, X_COORD], cells[newcell, Y_COORD]] = newcell;

            cells[newcell, C_RED] = cells[num, C_RED];
            cells[newcell, C_GREEN] = cells[num, C_GREEN];
            cells[newcell, C_BLUE] = cells[num, C_BLUE];

            cells[newcell, ORIGIN_C_RED] = cells[num, ORIGIN_C_RED];
            cells[newcell, ORIGIN_C_GREEN] = cells[num, ORIGIN_C_GREEN];
            cells[newcell, ORIGIN_C_BLUE] = cells[num, ORIGIN_C_BLUE];

            cells[newcell, LIVING] = LV_ALIVE;
            cells[newcell, DIRECT] = rand.Next() % 8;

            int px = cells[num, PREV];

            cells[newcell, PREV] = px;
            cells[px, NEXT] = newcell;
            cells[newcell, NEXT] = num;
            cells[num, PREV] = newcell;

            cells[newcell, CELL_AGE] = 0;

            for (int i = M1; i <= M8; i++)
            {
                cells[newcell, i] = 0;
            }
            for (int i = M1; i <= M8; i++)
            {
                if (cells[num, i] == 0)
                {
                    cells[num, i] = newcell;
                    cells[newcell, M1] = num;
                    break;
                }
            }
        }
        
        public static void CellDie(int num)
        {
            cells[num, LIVING] = LV_DEAD;
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
        }

    }
}
