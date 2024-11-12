using System;
using System.Diagnostics;

namespace CyberBiology
{
    public static class Simulation
    {
        public static int seed = 1;
        public static Stopwatch clock = new Stopwatch();
        public static Random rand = new Random(seed);


        public static int WORLD_WIDTH = 360;
        public static int WORLD_HEIGHT = 192;
        public static int MAX_CELLS;

        public static int[,] cells;
        public static int[,] world;

        public static int[,] drawWorld;
        public static int[,] drawCells;

        public static int ETM = 5;
        public static int MTE = 2;
        public static int ETL = 3;
        public static int MuteChance = 10;

        public static int currentSeason = 0;
        public static int[] seasons = { 11, 10, 9, 10};
        public static int season = 11;

        public static int age = 0;
        public static int CELL = 0;
        public static int cell_count;
        public static int Print_cell_count;


    }
}
