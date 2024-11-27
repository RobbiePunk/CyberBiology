using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CyberBiology
{
    public class StateRandom : System.Random
    {
        UInt64 _numberOfInvokes;

        public UInt64 NumberOfInvokes { get { return _numberOfInvokes; } }

        public StateRandom(int Seed, UInt64 forward = 0) : base(Seed)
        {
            _numberOfInvokes = 0;
            for (UInt64 i = 0; i < forward; ++i)
                Next();
        }

        public override Int32 Next(Int32 maxValue)
        {
            _numberOfInvokes += 1;
            return base.Next(maxValue);
        }

        public override Int32 Next()
        {
            _numberOfInvokes += 1;
            return base.Next();
        }
    }

    public static class Simulation
    {
        public static int seed = 1;
        public static Stopwatch clock = new Stopwatch();
        public static StateRandom rand = new StateRandom(1);


        public static int WORLD_WIDTH = 180;
        public static int WORLD_HEIGHT = 192;
        public static int MAX_CELLS;

        public static int[,] cells;
        public static int[,] world;

        public static int ETM = 5;
        public static int MTE = 2;
        public static int ETL = 3;
        public static int ETAS = 10;
        public static int muteChance = 10;

        public static int currentSeason = 0;
        public static int[] seasons = { 11, 10, 9, 10};
        public static string[] seasonsString = { "Summer", "Autumn", "Winter", "Spring"};
        public static int season = 11;
        public static int seasonTime = 10000;

        public static int age = 0;
        public static int CELL = 0;
        public static int cell_count;
        public static int print_cell_count;

        public static int viewMode = 1;
        public static int WORLD_SIZE = 6;

        public static bool isPressure = false;
        public static bool isAutoDivide = true;
        public static bool isRandom = false;
    }
}
