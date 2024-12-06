using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static CyberBiology.Constants;
using static CyberBiology.Simulation;
using static CyberBiology.CellFunctions;
using static CyberBiology.CellAditionalFunctions;
using static CyberBiology.ServiceFunctions;
using System.Drawing;

namespace CyberBiology
{
    public static class Templates
    {
        public static void CreateDualWorld()
        {
            for(int y = 0; y < WORLD_HEIGHT + 2; y++)
            {
                for (int x = 0; x < WORLD_WIDTH; x++)
                {
                    if(y == 0 || (y == WORLD_HEIGHT + 1) || x == 0 || (x == WORLD_WIDTH - 1) || (x == WORLD_WIDTH / 2))
                        world[x, y] = WC_WALL;
                    else
                        world[x, y] = WC_EMPTY;
                }
            }

            cells = new int[MAX_CELLS, CELL_SIZE];

            int oldCellType = newCellType;
            Color oldColor = originColor;

            newCellType = CT_FOTOSINTEZ;
            originColor = Color.OrangeRed;
            AddCell(WORLD_WIDTH / 3, WORLD_HEIGHT / 4 + 1);
            originColor = Color.LawnGreen;
            AddCell(2 * WORLD_WIDTH / 3, WORLD_HEIGHT / 4 + 1);

            originColor = oldColor;
            newCellType = oldCellType;
        }

        public static void CreateQuadroWorld()
        {
            for (int y = 0; y < WORLD_HEIGHT + 2; y++)
            {
                for (int x = 0; x < WORLD_WIDTH; x++)
                {
                    if (y == 0 || (y == WORLD_HEIGHT + 1) || x == 0 || (x == WORLD_WIDTH - 1) || (x == WORLD_WIDTH / 2)
                        || (y == WORLD_HEIGHT / 2))
                        world[x, y] = WC_WALL;
                    else
                        world[x, y] = WC_EMPTY;
                }
            }

            cells = new int[MAX_CELLS, CELL_SIZE];

            int oldCellType = newCellType;
            Color oldColor = originColor;

            newCellType = CT_FOTOSINTEZ;
            originColor = Color.OrangeRed;
            AddCell(WORLD_WIDTH / 3, WORLD_HEIGHT / 4 + 1);
            originColor = Color.LawnGreen;
            AddCell(2 * WORLD_WIDTH / 3, WORLD_HEIGHT / 4 + 1);

            newCellType = CT_MINERAL;
            originColor = Color.DeepSkyBlue;
            AddCell(WORLD_WIDTH / 3, 7 * WORLD_HEIGHT / 8 + 1);
            originColor = Color.CadetBlue;
            AddCell(2 * WORLD_WIDTH / 3, 7 * WORLD_HEIGHT / 8 + 1);


            originColor = oldColor;
            newCellType = oldCellType;
        }

        public static void CreateLabyrinthWorld()
        {
            Random nr = new Random();
            for (int y = 0; y < WORLD_HEIGHT + 2; y++)
            {
                for (int x = 0; x < WORLD_WIDTH; x++)
                {
                    if (y == 0 || (y == WORLD_HEIGHT + 1))
                        world[x, y] = WC_WALL;
                    else
                    {
                        world[x, y] = WC_EMPTY;
                        if (world[(x + WORLD_WIDTH - 1) % WORLD_WIDTH, y] == WC_WALL)
                        {
                            if (world[x, (y + WORLD_HEIGHT - 1) % WORLD_HEIGHT] == WC_WALL)
                            {
                                if (nr.Next() % 100 < 5)
                                    world[x, y] = WC_WALL;
                            }
                            else if (nr.Next() % 100 < 85)
                                world[x, y] = WC_WALL;
                        }
                        else if (world[x, (y + WORLD_HEIGHT - 1) % WORLD_HEIGHT] == WC_WALL)
                        {
                            if (nr.Next() % 100 < 85)
                                world[x, y] = WC_WALL;
                        }
                        else if (nr.Next() % 100 < 10)
                            world[x, y] = WC_WALL;
                    }
                }
            }

            cells = new int[MAX_CELLS, CELL_SIZE];

            int oldCellType = newCellType;
            Color oldColor = originColor;

            /*
            newCellType = CT_FOTOSINTEZ;
            originColor = Color.OrangeRed;
            AddCell(WORLD_WIDTH / 3, WORLD_HEIGHT / 4 + 1);
            originColor = Color.LawnGreen;
            AddCell(2 * WORLD_WIDTH / 3, WORLD_HEIGHT / 4 + 1);

            newCellType = CT_MINERAL;
            originColor = Color.DeepSkyBlue;
            AddCell(WORLD_WIDTH / 3, 7 * WORLD_HEIGHT / 8 + 1);
            originColor = Color.CadetBlue;
            AddCell(2 * WORLD_WIDTH / 3, 7 * WORLD_HEIGHT / 8 + 1);
            */

            originColor = oldColor;
            newCellType = oldCellType;
        }

    }
}
