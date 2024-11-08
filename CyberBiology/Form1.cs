using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics;
using CyberBiology;

namespace CyberBiology2
{
    public partial class Form1 : Form
    {
        Stopwatch clock = new Stopwatch();

        Barrier saveBarrier = new Barrier(2, (bar) =>
        {

        });

        Barrier drawBarrier = new Barrier(2, (bar) =>
        {

        });

        Bitmap bmp;
        Bitmap bmpSave;
        Random rand = new Random();
        Thread t;
        Graphics GR;
        Graphics GR_save;
        SolidBrush BR = new SolidBrush(Color.White);
        String SaveFileName;
        String SaveImageDirectory;
        String season_str = "Summer";
        bool GO = false;
        bool performanceTest = false;

        bool isDrawing = false;

        bool saveImage = false;
        bool tryToSave = false;
        public int imageSaveStep = 100;
        public int imageSaveSize = 1;
        public int[] imageSaveViewMode = { 1, 0, 0};

        int viewMode = 1;
        int WORLD_SIZE = 3;

        int ETM = 5;
        int MTE = 2;
        int ETL = 3;
        int MuteChance = 10;

        int WORLD_WIDTH = 360;
        int WORLD_HEIGHT = 192;

        int xDrawStartIndex = 0;
        int yDrawStartIndex = 0;
        int xScreenSize = 1200;
        int yScreenSize = 650;

        int MAX_CELLS;

        const int MIND_SIZE = 64;
        const int CELL_SIZE = 64 + 21;

        const int ADR = MIND_SIZE + 0;
        const int X_COORD = MIND_SIZE + 1;
        const int Y_COORD = MIND_SIZE + 2;
        const int ENERGY = MIND_SIZE + 3;
        const int MINERAL = MIND_SIZE + 4;
        const int LIVING = MIND_SIZE + 5;
        const int C_RED = MIND_SIZE + 6;
        const int C_GREEN = MIND_SIZE + 7;
        const int C_BLUE = MIND_SIZE + 8;
        const int DIRECT = MIND_SIZE + 9;
        const int PREV = MIND_SIZE + 10;
        const int NEXT = MIND_SIZE + 11;
        const int M1 = MIND_SIZE + 12;
        const int M2 = MIND_SIZE + 13;
        const int M3 = MIND_SIZE + 14;
        const int M4 = MIND_SIZE + 15;
        const int M5 = MIND_SIZE + 16;
        const int M6 = MIND_SIZE + 17;
        const int M7 = MIND_SIZE + 18;
        const int M8 = MIND_SIZE + 19;
        const int PUSH = MIND_SIZE + 20;

        const int WC_EMPTY = 0;
        const int WC_WALL = -5;

        const int LV_FREE = 0;
        const int LV_DEAD = 1;
        const int LV_ALIVE = 2;
        const int LV_EARTH = 3;
        const int LV_STONE = 4;
        const int LV_FALLING_EARTH = 5;
        const int LV_FALLING_STONE = 6;

        int season = 11;
        int season_max = 10;
        int season_time = 0;
        int age_season = 0;

        int age = 0;
        int CELL = 0;
        int cell_count;
        int Print_cell_count;

        int SPF = 1;

        int[,] cells;
        int[,] world;
        int[,] drawWorld;
        int[,] drawCells;

        public Form1()
        {
            InitializeComponent();
            WORLD_WIDTH = 180 * WorldSizeScroll.Value;
            WORLD_HEIGHT = 96 * WorldSizeScroll.Value;
            MAX_CELLS = WORLD_HEIGHT * WORLD_WIDTH;

            cells = new int[MAX_CELLS, CELL_SIZE];
            drawCells = new int[MAX_CELLS, CELL_SIZE];
            world = new int[WORLD_WIDTH, WORLD_HEIGHT + 2];
            drawWorld = new int[WORLD_WIDTH, WORLD_HEIGHT + 2];

            bmp = new Bitmap(WORLD_BOX.Width, WORLD_BOX.Height);
            bmpSave = new Bitmap(WORLD_BOX.Width, WORLD_BOX.Height);
            GR = Graphics.FromImage(bmp);
            GR_save = Graphics.FromImage(bmpSave);
            int x = 0;
            while(x < WORLD_WIDTH)
            {
                world[x, 0] = WC_WALL;
                world[x, WORLD_HEIGHT + 1] = WC_WALL;
                x++;
            }

            drawWorld = (int[,])world.Clone();
            FirstCell();
        }

        public void MainFunction()
        {
            new_circle:
                
                //if(isDrawing)
                    //drawBarrier.SignalAndWait();

                CELL = cells[0, NEXT];
                cell_count = 0;
            cs:
                cell_count++;
                CELL = cell_step(CELL);
                if(CELL != 0) { goto cs; }
                else
                {
                    Print_cell_count = cell_count;
                    age++;
                    if(imageSaveStep != 0 && age % imageSaveStep == 0)
                    {
                        if (saveImage && !tryToSave)
                        {
                            tryToSave = true;
                            saveBarrier.SignalAndWait();
                        }   
                    }
                    if(age % 1000 == 0)
                    {
                        season_time++;
                        if(season_time == season_max)
                        {
                            season_time = 0;
                            age_season++;
                            int seasonTemp = age_season % 4;
                            if(seasonTemp == 0) { season = 11; season_str = "Summer"; }
                            else if(seasonTemp == 2)
                            {
                                season = 9;
                                season_str = "Winter";
                            }
                            else
                            {
                                if(season == 9)
                                {
                                    season_str = "Spring";
                                }
                                else
                                {
                                    season_str = "Autumn";
                                }
                                season = 10;
                            }
                        }
                    }
                    if(GO)
                        goto new_circle;
                }
        }


        int cell_step(int num)
        {
            int lv = cells[num, LIVING];
            if (lv == LV_DEAD)
            {
                Fall(num);
                Pressure(num);
                if(cells[num,PUSH] > 31)
                {
                    int x = cells[num, X_COORD];
                    int y = cells[num, Y_COORD];
                    if(cells[world[x,y - 1],LIVING] == LV_DEAD)
                    {
                        delete_cell(world[x, y - 1]);
                    }
                    cells[num, LIVING] = LV_EARTH;
                }
                return (cells[num, NEXT]);
            }
            if(lv == LV_EARTH  || lv == LV_FALLING_EARTH)
            {
                if(lv == LV_EARTH)
                {
                    
                }
                else if (lv == LV_FALLING_EARTH)
                {
                    Fall(num);
                }
                Pressure(num);
                if(cells[num,PUSH] >= 63)
                {
                    int x = cells[num, X_COORD];
                    int y = cells[num, Y_COORD];
                    if (cells[world[x, y - 1], LIVING] == LV_DEAD)
                    {
                        delete_cell(world[x, y - 1]);
                    }
                    cells[num, LIVING] = LV_STONE;
                }
                return (cells[num, NEXT]);
            }
            if(lv == LV_STONE)
            {
                return (cells[num, NEXT]);
            }
            int cyc = 0;
        ag:
            cyc++;
            if (cyc < 10)
            {
                int command = cells[num, cells[num, ADR]];
                if(command == 22)//Деление с абсолютной сменой команды
                {
                    cell_double(num);
                    inc_command_address(num, 1);
                }
                else if (command == 23)//смена направления относительно
                {
                    int param = get_param(num) % 8;
                    int newdrct = cells[num, DIRECT] + param;
                    if (newdrct > 7) { newdrct -= 8; }
                    cells[num, DIRECT] = newdrct;
                    inc_command_address(num, 2);
                    goto ag;
                }
                else if (command == 24)//смена направления абсолютно
                {
                    cells[num, DIRECT] = get_param(num) % 8;
                    inc_command_address(num, 2);
                    goto ag;
                }
                else if (command == 25)//фотосинтез
                {
                    fotosintez(num);
                    inc_command_address(num, 1);
                    goto Out;
                }
                else if (command == 26)//движение относительно
                {
                    int a = isMulti(num);
                    if (a == 0)
                    {
                        int drct = get_param(num) % 8;
                        indirect_inc_cmd_address(num, cell_move(num, drct, 0));
                    }
                    else if(a < 5)
                    {
                        int drct = get_param(num) % 8;
                        indirect_inc_cmd_address(num, cell_multi_move(num, drct, 0));
                    }
                    else
                    {
                        inc_command_address(num, 1);
                    }

                    goto Out;
                }
                else if (command == 27)//движение абсолютно
                {
                    int a = isMulti(num);
                    if (a == 0)
                    {
                        int drct = get_param(num) % 8;
                        indirect_inc_cmd_address(num, cell_move(num, drct, 1));
                    }
                    else if (a < 5)
                    {
                        int drct = get_param(num) % 8;
                        indirect_inc_cmd_address(num, cell_multi_move(num, drct, 1));
                    }
                    else
                    {
                        inc_command_address(num, 1);
                    }
                    goto Out;
                }
                else if (command == 28)//съесть в относителном направлении
                {
                    int drct = get_param(num) % 8;
                    indirect_inc_cmd_address(num, cell_eat(num, drct, 0));
                    goto Out;
                }
                else if (command == 29)//съесть в абсолютном направлении
                {
                    int drct = get_param(num) % 8;
                    indirect_inc_cmd_address(num, cell_eat(num, drct, 1));
                    goto Out;
                }
                else if (command == 30)//посмотреть в относительном направлении
                {
                    int drct = get_param(num) % 8;
                    indirect_inc_cmd_address(num, cell_look(num, drct, 0));
                    goto ag;
                }
                else if (command == 31)//посмотреть в абсолютном направлении
                {
                    int drct = get_param(num) % 8;
                    indirect_inc_cmd_address(num, cell_look(num, drct, 1));
                    goto ag;
                }
                else if (command == 32)//поделиться лишними ресурсами в относительном направлении
                {
                    int drct = get_param(num) % 8;
                    indirect_inc_cmd_address(num, cell_care(num, drct, 0));
                    goto ag;
                }
                else if (command == 33)//поделиться лишними ресурсами в абсолютном направлении
                {
                    int drct = get_param(num) % 8;
                    indirect_inc_cmd_address(num, cell_care(num, drct, 1));
                    goto ag;
                }
                else if (command == 34)//отдать ресурсы в относительном направлении
                {
                    int drct = get_param(num) % 8;
                    indirect_inc_cmd_address(num, cell_give(num, drct, 0));
                    goto ag;
                }
                else if (command == 35)//отдать ресурсы в абсолютном направлении
                {
                    int drct = get_param(num) % 8;
                    indirect_inc_cmd_address(num, cell_give(num, drct, 1));
                    goto ag;
                }
                else if (command == 36)//выровняться по горизонтали
                {
                    if (rand.Next() % 2 == 0)
                    {
                        cells[num, DIRECT] = 3;
                    }
                    else
                    {
                        cells[num, DIRECT] = 7;
                    }
                    inc_command_address(num, 1);
                    goto ag;
                }
                else if (command == 37)//узнать высоту
                {
                    float param = get_param(num) * WORLD_HEIGHT / 64;
                    if (cells[num, Y_COORD]  < param)
                    {
                        indirect_inc_cmd_address(num, 2);
                    }
                    else
                    {
                        indirect_inc_cmd_address(num, 3);
                    }
                    goto ag;
                }
                else if (command == 38)//узнать количество энергии
                {
                    int param = get_param(num) * 15;
                    if (cells[num, ENERGY] < param)
                    {
                        indirect_inc_cmd_address(num, 2);
                    }
                    else
                    {
                        indirect_inc_cmd_address(num, 3);
                    }
                    goto ag;
                }
                else if (command == 39)//узнать количество минералов
                {
                    int param = get_param(num) * 15;
                    if (cells[num, MINERAL] < param)
                    {
                        indirect_inc_cmd_address(num, 2);
                    }
                    else
                    {
                        indirect_inc_cmd_address(num, 3);
                    }
                    goto ag;
                }
                else if (command == 40)//многоклеточное деление
                {
                    cell_multi(num);
                    inc_command_address(num, 1);
                    goto Out;
                }
                else if (command == 41)//свободное деление
                {
                    cell_double(num);
                    inc_command_address(num, 1);
                    goto Out;
                }
                else if (command == 43)//окружена ли клетка?
                {
                    indirect_inc_cmd_address(num, full_around(num));
                    goto ag;
                }
                else if (command == 44)//приход энергии есть?
                {
                    indirect_inc_cmd_address(num, is_energy_grow(num));
                    goto ag;
                }
                else if (command == 45)//минералы прибавляются?
                {
                    if (cells[num, Y_COORD] > WORLD_HEIGHT / 2)
                    {
                        indirect_inc_cmd_address(num, 1);
                    }
                    else
                    {
                        indirect_inc_cmd_address(num, 2);
                    }
                    goto ag;
                }
                else if (command == 46)//многоклеточный ли бот?
                {
                    int mu = isMulti(num);
                    if (mu == 0) { indirect_inc_cmd_address(num, 1); }
                    else if (mu == 8) { indirect_inc_cmd_address(num, 3); }
                    else { indirect_inc_cmd_address(num, 2); }
                    goto ag;
                }
                else if (command == 47)//преобразовать минералы в энергию
                {
                    cell_mineral2energy(num);
                    inc_command_address(num, 1);
                    goto Out;
                }
                inc_command_address(num, command);
                goto ag;
            }
        Out:
            if (cells[num, LIVING] == LV_ALIVE)
            {
                int a = isMulti(num);

                if(a > 0)
                {
                    colonySharing(num);
                }

                if(cells[num,ENERGY] > 999)
                {
                    if(a > 0) { cell_multi(num); }
                    else { cell_double(num); }
                }
                cells[num, ENERGY] -= ETL;
                if(cells[num,ENERGY] < 1)
                {
                    cell_die(num);
                    return (cells[num, NEXT]);
                }
                if(cells[num,Y_COORD] > WORLD_HEIGHT / 96 * 52)
                {
                    cells[num, MINERAL]++;
                    if(cells[num,Y_COORD] > WORLD_HEIGHT / 96 * 70 ) { cells[num, MINERAL]++; }
                    if (cells[num, Y_COORD] > WORLD_HEIGHT / 96 * 90) { cells[num, MINERAL]++; }
                    if(cells[num,MINERAL] > 499) { cells[num, MINERAL] = 499; }
                }
            }
            return (cells[num, NEXT]);
        }

        #region CellsFunction

        void colonySharing(int num)
        {
            int C = 1;
            int En = cells[num, ENERGY];
            int Min = cells[num, MINERAL];
            for (int i = MIND_SIZE + 12; i < MIND_SIZE + 20; i++)
            {
                if(cells[num,i] != 0)
                {
                    C++;
                    En += cells[cells[num,i], ENERGY];
                    Min += cells[cells[num, i], MINERAL];
                }
            }
            int MinMode = Min % C;
            int EnMode = En % C;
            En /= C;
            Min /= C;
            cells[num, ENERGY] = En + EnMode;
            cells[num, MINERAL] = Min + MinMode;
            for (int i = MIND_SIZE + 12; i < MIND_SIZE + 20; i++)
            {
                if (cells[num, i] != 0)
                {
                    cells[cells[num, i], ENERGY] = En;
                    cells[cells[num, i], MINERAL] = Min;
                }
            }
        }
        void cell_mineral2energy(int num)
        {
            if(cells[num,MINERAL] > 50)
            {
                cells[num, MINERAL] -= 50;
                cells[num, ENERGY] += 50 * MTE;
                go_BLUE(num, 50);
            }
            else
            {
                go_BLUE(num, cells[num, MINERAL]);
                cells[num, ENERGY] += MTE * cells[num, MINERAL];
                cells[num, MINERAL] = 0;
            }
        }
        void fotosintez(int num)
        {
            int t;
            if (cells[num,MINERAL] < 100) { t = 0; }
            else if(cells[num,MINERAL] < 400) { t = 1; }
            else{ t = 2; }
            int hlt = season - ((cells[num, Y_COORD] / (WORLD_HEIGHT / 96) - 1) / 8) + t;
            if(hlt > 0)
            {
                cells[num, ENERGY] += hlt;
                go_GREEN(num, hlt);
            }
        }

        int cell_move(int num, int dr, int ra)
        {
            cells[num, ENERGY] -= ETM;
            int x;
            int y;
            if (ra == 0)
            {
                x = X_from_vector_r(num, dr);
                y = Y_from_vector_r(num, dr);
            }
            else
            {
                x = X_from_vector_a(num, dr);
                y = Y_from_vector_a(num, dr);
            }
            if(world[x,y] == WC_EMPTY)
            {
                move_cell(num, x, y);
                return (2);
            }
            if(world[x, y] == WC_WALL)
            {
                return (3);
            }
            if(cells[world[x, y], LIVING] == LV_EARTH)
            {
                return (7);
            }
            if (cells[world[x, y],LIVING] == LV_DEAD)
            {
                return (4);
            }
            if (is_relative(num,world[x,y]) == 1)
            {
                return (6);
            }

            return (5);
        }

        int cell_multi_move(int num, int dr, int ra)
        {
            cells[num, ENERGY] -= ETM;
            int x;
            int y;
            if (ra == 0)
            {
                x = X_from_vector_r(num, dr);
                y = Y_from_vector_r(num, dr);
            }
            else
            {
                x = X_from_vector_a(num, dr);
                y = Y_from_vector_a(num, dr);
            }
            
            if (world[x, y] == WC_EMPTY)
            {
                if (isColonyMove(num,x,y) == 1)
                {
                    move_cell(num, x, y);
                    return (7);
                }
                return (2);
            }
            if (world[x, y] == WC_WALL)
            {
                return (3);
            }
            if(cells[world[x, y], LIVING] == LV_EARTH)
            {
                return (8);
            }
            if (cells[world[x, y], LIVING] == LV_DEAD)
            {
                return (4);
            }
            if (is_relative(num, world[x, y]) == 1)
            {
                return (6);
            }

            return (5);
        }

        int cell_eat(int num, int dr, int ra)
        {
            int x;
            int y;
            cells[num, ENERGY] -= 4;
            if(ra == 0)
            {
                x = X_from_vector_r(num, dr);
                y = Y_from_vector_r(num, dr);
            }
            else
            {
                x = X_from_vector_a(num, dr);
                y = Y_from_vector_a(num, dr);
            }
            if(world[x,y] == WC_EMPTY)
            {
                return (2);
            }
            if(world[x,y] == WC_WALL)
            {
                return (3);
            }
            if(cells[world[x, y], LIVING] == LV_EARTH)
            {
                return (6);
            }
            if(cells[world[x,y],LIVING] == LV_DEAD)
            {
                delete_cell(world[x, y]);
                cells[num, ENERGY] += 100;
                go_RED(num, 100);
                return (4);
            }
            int min0 = cells[num, MINERAL];
            int min1 = cells[world[x, y], MINERAL];
            int hl = cells[world[x, y], ENERGY];

            if(min0 > min1)
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

            if(cells[num,ENERGY] >= 2*min1)
            {
                delete_cell(world[x, y]);
                int cl = 100 + (hl / 2) - 2 * min1;
                cells[num, ENERGY] += cl;
                go_RED(num, cl);
                return (5);
            }

            cells[world[x, y], MINERAL] = min1 - (cells[num, ENERGY] / 2);
            cells[num, ENERGY] = -10;
            return (5);
        }

        int cell_look(int num,int dr, int ra)
        {
            int wc;
            if(ra == 0)
            {
                wc = what_is_there_r(num, dr);
            }
            else
            {
                wc = what_is_there_a(num, dr);
            }
            if(wc == WC_EMPTY)
            {
                return (2);
            }
            if(wc == WC_WALL)
            {
                return (3);
            }
            if( cells[wc, LIVING] == LV_EARTH)
            {
                return (7);
            }
            if(cells[wc,LIVING] == LV_DEAD)
            {
                return (4);
            }
            if(is_relative(num,wc) == 1)
            {
                return (6);
            }
            else
            {
                return (5);
            }
        }

        int cell_care(int num, int dr, int ra)
        {
            int x;
            int y;
            if (ra == 0)
            {
                x = X_from_vector_r(num, dr);
                y = Y_from_vector_r(num, dr);
            }
            else
            {
                x = X_from_vector_a(num, dr);
                y = Y_from_vector_a(num, dr);
            }
            if (world[x, y] == WC_EMPTY)
            {
                return (2);
            }
            if (world[x, y] == WC_WALL)
            {
                return (3);
            }
            if(cells[world[x, y], LIVING] == LV_EARTH)
            {
                return (6);
            }
            if(cells[world[x,y], LIVING] == LV_DEAD)
            {
                return (4);
            }

            int enrg0 = cells[num, ENERGY];
            int enrg1 = cells[world[x, y], ENERGY];
            int min0 = cells[num, MINERAL];
            int min1 = cells[world[x, y], MINERAL];
            if(enrg0 > enrg1)
            {
                int enrg = (enrg0 - enrg1) / 2;
                cells[num, ENERGY] -= enrg;
                cells[world[x, y], ENERGY] += enrg;
            }
            if(min0 > min1)
            {
                int min = (min0 - min1) / 2;
                cells[num, MINERAL] -= min;
                cells[world[x, y], MINERAL] += min;
            }
            return (5);
        }

        int cell_give(int num, int dr, int ra)
        {
            int x;
            int y;
            if (ra == 0)
            {
                x = X_from_vector_r(num, dr);
                y = Y_from_vector_r(num, dr);
            }
            else
            {
                x = X_from_vector_a(num, dr);
                y = Y_from_vector_a(num, dr);
            }
            if (world[x, y] == WC_EMPTY)
            {
                return (2);
            }
            if (world[x, y] == WC_WALL)
            {
                return (3);
            }
            if(cells[world[x, y], LIVING] == LV_EARTH)
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
            if(cells[num,MINERAL] > 3)
            {
                int min = cells[num, MINERAL] / 4;
                cells[num, MINERAL] -= min;
                cells[world[x, y] , MINERAL] += min;
                if(cells[world[x,y],MINERAL] > 999)
                {
                    cells[world[x, y], MINERAL] = 999;
                }
            }
            return (5);
            
        }

        void cell_double(int num)
        {
            cells[num, ENERGY] -= 150;
            if(cells[num,ENERGY] <= 0) { return; }

            int n = find_empty_direction(num);

            if(n == 8)
            {
                cells[num, ENERGY] = 0;
                return;
            }

            int newcell = find_empty();
            for (int i = 0; i < MIND_SIZE; i++)
            {
                cells[newcell, i] = cells[num, i];
            }
            int vi = rand.Next();
            if(MuteChance != 0 && vi % MuteChance == 0)
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
            cells[newcell, X_COORD] = X_from_vector_r(num, n);
            cells[newcell, Y_COORD] = Y_from_vector_r(num, n);

            world[cells[newcell, X_COORD], cells[newcell, Y_COORD]] = newcell;

            cells[newcell, C_RED] = cells[num, C_RED];
            cells[newcell, C_GREEN] = cells[num, C_GREEN];
            cells[newcell, C_BLUE] = cells[num, C_BLUE];

            cells[newcell, LIVING] = LV_ALIVE;
            cells[newcell, DIRECT] = rand.Next() % 8;

            int px = cells[num, PREV];

            cells[newcell, PREV] = px;
            cells[px, NEXT] = newcell; 
            cells[newcell, NEXT] = num;
            cells[num, PREV] = newcell;
            

            for (int i = MIND_SIZE + 12; i < MIND_SIZE + 20; i++)
            {
                cells[num, i] = 0;
            }
        }

        void cell_multi(int num)
        {
            int C = isMulti(num);

            if(C == 8) { return; }

            cells[num, ENERGY] -= 150;
            if(cells[num,ENERGY] <= 0) { return; }
            int n = find_empty_direction(num);

            if(n == 8)
            {
                //cells[num, ENERGY] /= 2;
                return;
            }

            int newcell = find_empty();
            for (int i = 0; i < MIND_SIZE; i++)
            {
                cells[newcell, i] = cells[num, i];
            }
            int vi = rand.Next();
            if (MuteChance != 0 && vi % MuteChance == 0)
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
            cells[newcell, X_COORD] = X_from_vector_r(num, n);
            cells[newcell, Y_COORD] = Y_from_vector_r(num, n);

            world[cells[newcell, X_COORD], cells[newcell, Y_COORD]] = newcell;

            cells[newcell, C_RED] = cells[num, C_RED];
            cells[newcell, C_GREEN] = cells[num, C_GREEN];
            cells[newcell, C_BLUE] = cells[num, C_BLUE];

            cells[newcell, LIVING] = LV_ALIVE;
            cells[newcell, DIRECT] = rand.Next() % 8;

            int px = cells[num, PREV];

            cells[newcell, PREV] = px;
            cells[px, NEXT] = newcell;
            cells[newcell, NEXT] = num;
            cells[num, PREV] = newcell;


            for (int i = MIND_SIZE + 12; i < MIND_SIZE + 20; i++)
            {
                cells[newcell, i] = 0;
            }
            for (int i = MIND_SIZE + 12; i < MIND_SIZE + 20; i++)
            {
                if(cells[num,i] == 0)
                {
                    cells[num, i] = newcell;
                    cells[newcell, MIND_SIZE + 12] = num;
                    break;
                }
            }
        }
        void cell_die(int num)
        {
            cells[num, LIVING] = LV_DEAD;
            for (int i = MIND_SIZE + 12; i < MIND_SIZE + 20; i++)
            {
                if (cells[num, i] != 0)
                {
                    for (int j = MIND_SIZE + 12; j < MIND_SIZE + 20; j++)
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

        #endregion

        #region CellsCallFunction
        int isEarthBlock(int num)
        {
            int n = 0;
            for (int i = 0; i < 8; i++)
            {
               if(cells[num,MIND_SIZE - i] == 500)
                {
                    n++;
                }
            }
            return (n);
        }
        int is_relative(int num0,int num1)
        {
            if(cells[num1,LIVING] < LV_ALIVE) { return (0); }
            int dif = 0;
            for (int i = 0; i < MIND_SIZE; i++)
            {
                if(cells[num0,i] != cells[num1,i])
                {
                    dif++;
                    if(dif == 2) { return (0); }
                }
            }
            return (1);
        }
        int is_energy_grow(int num)
        {
            int t;
            if(cells[num,MINERAL] < 100) { t = 0; }
            else if(cells[num,MINERAL] < 400) { t = 1; }
            else { t = 2; }
            int nrg = season - ((cells[num, Y_COORD] / (WORLD_HEIGHT / 96) - 1) / 8) + t;
            if(nrg >= 3) { return (1); }
            else { return (2); }

        }
        int isMulti(int num)
        {
            int a = 0;
            for (int i = MIND_SIZE + 12; i < MIND_SIZE + 20; i++)
            {
                if(cells[num,i] != 0)
                {
                    a++;
                }
            }
            return (a);
        }

        int get_param(int num)
        {
            int adr = cells[num, ADR] + 1;
            if(adr >= MIND_SIZE) { adr -= MIND_SIZE; }
            return (cells[num, adr]);
        }
        int what_is_there_r(int num,int dr)
        {
            int x = X_from_vector_r(num, dr);
            int y = Y_from_vector_r(num, dr);
            int result = world[x, y];
            return (result);
        }
        int what_is_there_a(int num, int dr)
        {
            int x = X_from_vector_a(num, dr);
            int y = Y_from_vector_a(num, dr);
            int result = world[x, y];
            return (result);
        }
        int Y_from_vector_a(int num, int n)
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
        int X_from_vector_a(int num, int n)
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
        int Y_from_vector_r(int num, int n)
        {
            int y = cells[num, Y_COORD];
            n += cells[num, DIRECT];
            if (n > 7) { n -= 8; }
            if (n < 3){ y--; }
            else
            {
                if (n == 4 || n == 5 || n == 6)
                {
                    y++;
                }
            }
            return (y);
        }
        int X_from_vector_r(int num, int n)
        {
            int x = cells[num, X_COORD];
            n += cells[num, DIRECT];
            if(n > 7) { n -= 8; }
            if(n == 0 || n == 6 || n == 7)
            {
                x--;
                if(x < 0) { x = WORLD_WIDTH - 1; }
            }
            else
            {
                if(n == 2 || n == 3 || n == 4)
                {
                    x++;
                    if(x > WORLD_WIDTH - 1)
                    {
                        x = 0;
                    }
                }
            }
            return (x);
        }
        void inc_command_address(int num, int n)
        {
            int adr = cells[num, ADR] + n;
            if(adr >= MIND_SIZE) { adr -= MIND_SIZE; }
            cells[num, ADR] = adr;
        }
        int find_empty_direction(int num)
        {
            for (int i = 0; i < 8; i++)
            {
                int x = X_from_vector_r(num, i);
                int y = Y_from_vector_r(num, i);
                if(world[x,y] == WC_EMPTY) { return (i); }
            }
            return (8);
        }
        int find_empty()
        {
            for (int i = 1; i < MAX_CELLS; i++)
            {
                if(cells[i,LIVING] == LV_FREE)
                {
                    return(i);
                }
            }
            return (0);
        }
        
        int isColonyMove(int num, int x, int y)
        {
            for (int i = MIND_SIZE + 12; i < MIND_SIZE + 20; i++)
            {
                if(cells[num,i] != 0)
                {
                    int x1 = cells[cells[num, i], X_COORD];
                    int y1 = cells[cells[num, i], Y_COORD];
                    if(Math.Abs(y - y1) > 1)
                    {
                        return (0);
                    }
                    if(x1 == WORLD_WIDTH -1 && x == 0)
                    {
                        
                    }
                    else if(x1 == 0 && x == WORLD_WIDTH - 1)
                    {

                    }
                    else
                    {
                        if(Math.Abs(x - x1) > 1)
                        {
                            return (0);
                        }
                    }
                }
            }
            return (1);
        }
        int find_empty_multi(int num)
        {
            for (int i = MIND_SIZE + 12; i < MIND_SIZE + 20; i++)
            {
                if(cells[num,i] == 0)
                {
                    return (i);
                }
            }
            return (0);
        }
        int full_around(int num)
        {
            for (int i = 0; i < 8; i++)
            {
                int x = X_from_vector_r(num, i);
                int y = Y_from_vector_r(num, i);
                if(world[x,y] == WC_EMPTY) { return (2); }
            }
            return (1);
        }
        void indirect_inc_cmd_address(int num,int a)
        {
            int adr = cells[num, ADR];
            adr += a;
            if(adr >= MIND_SIZE) { adr -= MIND_SIZE; }
            int bias = cells[num, adr];
            inc_command_address(num, bias);
        }

        #endregion

        #region ServiceFunction
        void EarthBlockCreate(int num)
        {
            for (int i = 0; i < 8; i++)
            {
                int x = X_from_vector_a(num, i);
                int y = Y_from_vector_a(num, i);
                if(world[x,y] > 0)
                {
                    if(cells[world[x,y],LIVING] == LV_EARTH || cells[world[x, y], LIVING] == LV_FALLING_EARTH)
                    {
                        if(cells[num,MIND_SIZE + i] == world[x,y])
                        {
                            cells[num, MIND_SIZE - i]++;
                            if(cells[num,MIND_SIZE - i] > 500)
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
        void delete_cell(int num)
        {
            world[cells[num, X_COORD], cells[num, Y_COORD]] = WC_EMPTY;
            cells[cells[num, PREV], NEXT] = cells[num, NEXT];
            cells[cells[num, NEXT], PREV] = cells[num, PREV];
            for (int i = MIND_SIZE + 12; i < MIND_SIZE + 20; i++)
            {
                if(cells[num,i] != 0)
                {
                    for (int j = MIND_SIZE + 12; j < MIND_SIZE + 20; j++)
                    {
                        if(cells[cells[num,i],j] == num)
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
        void move_cell(int num,int x,int y)
        {
            world[x, y] = num;
            world[cells[num, X_COORD], cells[num, Y_COORD]] = WC_EMPTY;
            cells[num, X_COORD] = x;
            cells[num, Y_COORD] = y;
        }
        void Fall(int num)
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

        void Pressure(int num)
        {
            cells[num, PUSH] = 0;
            int x = cells[num, X_COORD];
            int cy = cells[num, Y_COORD];
            if (world[x, cy + 1] == WC_WALL || cells[world[x, cy + 1], LIVING] >= LV_EARTH)
            {
                for (int y = cy - 1; y > 1 ; y--)
                {
                    if(world[x,y] > 0)
                    {
                        int S = cells[world[x, y], LIVING];
                        if (S == LV_DEAD)
                        {
                            cells[num, PUSH]++;
                        }
                        else if(S == LV_FALLING_EARTH)
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
        void FirstCell()
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


            for (int j = MIND_SIZE + 12; j < MIND_SIZE + 20; j++)
            {
                cells[1, j] = 0;
            }
            world[WORLD_WIDTH / 2, WORLD_HEIGHT / 3] = 1;
            int i = 0;
            while(i < MIND_SIZE)
            {
                cells[1, i] = 25;
                i++;
            }
            //cells[1, MIND_SIZE - 1] = 22; //Деление
        }
        void CreatePerformanceTestWorld()
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

            for (int j = MIND_SIZE + 12; j < MIND_SIZE + 20; j++)
            {
                cells[1, j] = 0;
            }
            world[WORLD_WIDTH / 2, 1] = 1;
            int i = 0;
            while (i < MIND_SIZE)
            {
                if (i % 6 == 0)
                    cells[1, i] = 47;
                else
                    cells[1, i] = 25;
                i++;
            }
            cells[1, MIND_SIZE - 1] = 40;
            cells[1, 10] = 30;
            cells[1, 20] = 32;
            cells[1, 30] = 33;
            cells[1, 40] = 34;
            cells[1, 50] = 35;
        }

        void go_GREEN(int num,int val)
        {
            if(cells[num,C_GREEN] + val > 255)
            {
                cells[num, C_GREEN] = 255;
            }
            else
            {
                cells[num, C_GREEN] += val;
            }
           
            int vl = val / 2;

            if(cells[num,C_RED] - vl < 0)
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
        void go_RED(int num, int val)
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
        void go_BLUE(int num,int val)
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

        int CheckColor(int num,int type)
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

        int isMultiForDrawing(int num)
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

        #endregion

        #region Events

        void SetScrollers()
        {
            hScrollBar1.Maximum = WORLD_WIDTH < (xScreenSize / WORLD_SIZE) ? 0 : WORLD_WIDTH - (xScreenSize / WORLD_SIZE);
            hScrollBar1.Maximum /= 10;
            xDrawStartIndex = hScrollBar1.Value * 10;

            vScrollBar1.Maximum = WORLD_HEIGHT < (yScreenSize / WORLD_SIZE) ? 0 : WORLD_HEIGHT - (yScreenSize / WORLD_SIZE);
            vScrollBar1.Maximum /= 10;
            yDrawStartIndex = vScrollBar1.Value * 10;
        }

        void SaveImagePng(int mode, int size)
        {
            SolidBrush br = new SolidBrush(Color.White);
            GR_save.Clear(Color.White);
            for (int x = 0; x < WORLD_WIDTH; x++)
            {
                for (int y = 0; y < WORLD_HEIGHT + 2; y++)
                {
                    int celln = drawWorld[x, y];
                    if (celln == WC_EMPTY)
                    {

                    }
                    else if (celln == WC_WALL)
                    {
                        br.Color = Color.FromArgb(255, 40, 40, 40);
                        GR_save.FillRectangle(br, x * size + 40, y * size + 40, size, size);
                    }
                    else if (drawCells[celln, LIVING] == LV_EARTH)
                    {
                        br.Color = Color.FromArgb(255, 150, 100, 0);
                        GR_save.FillRectangle(br, x * size + 40, y * size + 40, size, size);
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
                            else
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
                            br.Color = C;
                            GR_save.FillRectangle(br, x * size + 40, y * size + 40, size, size);
                        }
                        else
                        {
                            br.Color = Color.FromArgb(255, 100, 100, 100);
                            GR_save.FillRectangle(br, x * size + 40, y * size + 40, size, size);
                        }
                    }
                }
            }

            if (season_str == "Summer")
                br.Color = Color.FromArgb(255, 240, 240, 20);
            else if (season_str == "Autumn")
                br.Color = Color.FromArgb(255, 240, 60, 0);
            else if (season_str == "Winter")
                br.Color = Color.FromArgb(255, 30, 60, 240);
            else
                br.Color = Color.FromArgb(255, 50, 240, 50);

            GR_save.FillRectangle(br, 300, 10, 70, 20);

            br.Color = Color.Black;
            GR_save.DrawString("Cells: " + Print_cell_count.ToString(), new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
            br, 40, 10);
            GR_save.DrawString("Iteration: " + age.ToString(), new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
            br, 150, 10);

            GR_save.DrawString(season_str, new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
            br, 300, 10);

            string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}",
            clock.Elapsed.Hours, clock.Elapsed.Minutes, clock.Elapsed.Seconds);

            GR_save.DrawString("Simulation Time: " + elapsedTime, new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
            br, 400, 10);

            if (clock.ElapsedMilliseconds != 0)
                GR_save.DrawString("IPS: " + (age * 1000f / clock.ElapsedMilliseconds).ToString(), new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
                br, 600, 10);

            string catalogName = @"Image\" + mode.ToString();
            string path;
            if (SaveImageDirectory == null)
                path = $"{Directory.GetCurrentDirectory()}/{catalogName}";
            else
                path = $"{SaveImageDirectory}/{catalogName}";

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            bmpSave.Save($"{path}/{age.ToString()}.png");

            tryToSave = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void PaintWorld(object sender, PaintEventArgs e)
        {
            if (isDrawing)
                return;

            drawWorld = (int[,])world.Clone();
            drawCells = (int[,])cells.Clone();

            isDrawing = true;
            BR = new SolidBrush(Color.White);
            GR.Clear(Color.White);
            for (int x = 0; x < WORLD_WIDTH - xDrawStartIndex; x++)
            {
                for (int y = 0; y < WORLD_HEIGHT + 2 - yDrawStartIndex; y++)
                {
                    int celln = drawWorld[x + xDrawStartIndex, y + yDrawStartIndex];
                    if(celln == WC_EMPTY)
                    {

                    }
                    else if (celln == WC_WALL)
                    {
                        BR.Color = Color.FromArgb(255, 40, 40, 40);
                        GR.FillRectangle(BR, x * WORLD_SIZE + 40, y * WORLD_SIZE + 40, WORLD_SIZE, WORLD_SIZE);
                    }
                    else if(drawCells[celln,LIVING] == LV_EARTH)
                    {
                        BR.Color = Color.FromArgb(255, 150, 100, 0);
                        GR.FillRectangle(BR, x * WORLD_SIZE + 40, y * WORLD_SIZE + 40, WORLD_SIZE, WORLD_SIZE);
                    }
                    else
                    {
                        if (drawCells[celln, LIVING] == LV_ALIVE)
                        {
                            Color C;
                            if (viewMode == 1)
                            {
                                C = Color.FromArgb(255, CheckColor(celln, 1), CheckColor(celln, 2), CheckColor(celln, 3));
                            }
                            else if(viewMode == 2)
                            {
                                int a = isMultiForDrawing(celln);
                                if (a > 0)
                                {

                                        C = Color.FromArgb(255, 240 - 20*a, 10*a, 200 -15*a);
                                }
                                else
                                {
                                     C = Color.FromArgb(255, 0, 240, 240);
                                }
                            }
                            else
                            {
                                int E = drawCells[celln, ENERGY];
                                if (E <= 1000 && E >= 0)
                                {
                                    C = Color.FromArgb(255, 255, 255 - E / 4, 0);
                                }
                                else if(E > 1000)
                                {
                                    C = Color.FromArgb(255, 255, 0, 0);
                                }
                                else
                                {
                                    C = Color.FromArgb(255, 150, 150, 150);
                                }
                            }
                             BR.Color = C;
                             GR.FillRectangle(BR, x * WORLD_SIZE + 40, y * WORLD_SIZE + 40, WORLD_SIZE, WORLD_SIZE);
                        }
                        else
                        {
                            BR.Color = Color.FromArgb(255, 100, 100, 100);
                            GR.FillRectangle(BR, x * WORLD_SIZE + 40, y * WORLD_SIZE + 40, WORLD_SIZE, WORLD_SIZE);
                        }
                    }
                }
            }
            
            if (season_str == "Summer")
                BR.Color = Color.FromArgb(255,240,240,20);
            else if (season_str == "Autumn")
                BR.Color = Color.FromArgb(255, 240, 60, 0);
            else if (season_str == "Winter")
                BR.Color = Color.FromArgb(255, 30, 60, 240);
            else
                BR.Color = Color.FromArgb(255, 50, 240, 50);

            GR.FillRectangle(BR, 300, 10, 70, 20);

            BR.Color = Color.Black;
            GR.DrawString("Cells: " + Print_cell_count.ToString(), new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
            BR, 40, 10);
            GR.DrawString("Iteration: " + age.ToString(), new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
            BR, 150, 10);
               

            GR.DrawString(season_str, new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
            BR, 300, 10);

            string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}",
            clock.Elapsed.Hours, clock.Elapsed.Minutes, clock.Elapsed.Seconds);

            GR.DrawString("Simulation Time: " + elapsedTime, new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
            BR, 400, 10);

            if(clock.ElapsedMilliseconds != 0)
                GR.DrawString("IPS: " + (age * 1000f / clock.ElapsedMilliseconds).ToString(), new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
                BR, 600, 10);


            WORLD_BOX.Image = bmp;

            if (tryToSave)
            {
                for (int i = 0; i < imageSaveViewMode.Length; i++)
                {
                    if (imageSaveViewMode[i] == 1)
                        SaveImagePng(i + 1, imageSaveSize);
                }
                saveBarrier.SignalAndWait();
            }

            //if(GO)
                //drawBarrier.SignalAndWait();

            isDrawing = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(!isDrawing)
                Refresh();
        }

        private void Size_plus(object sender, EventArgs e)
        {
            if(WORLD_SIZE < 6)
            {
                WORLD_SIZE++;
                SetScrollers();
                Refresh();
            }
        }

        private void size_minus(object sender, EventArgs e)
        {
            if (WORLD_SIZE > 1)
            {
                WORLD_SIZE--;
                SetScrollers();
                Refresh();
            }
        }

        private void Save(object sender, EventArgs e)
        {

            bool t = GO;
            GO = false;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                SaveFileName = saveFileDialog1.FileName;
                //File.WriteAllText(SaveFileName, File.ReadAllText("Save1.txt"));

                StreamWriter sw = new StreamWriter(SaveFileName);
                sw.WriteLine(season_str);
                sw.WriteLine(viewMode.ToString());
                sw.WriteLine(WORLD_SIZE.ToString());
                sw.WriteLine(ETM.ToString());
                sw.WriteLine(MTE.ToString());
                sw.WriteLine(ETL.ToString());
                sw.WriteLine(season.ToString());
                sw.WriteLine(season_max.ToString());
                sw.WriteLine(season_time.ToString());
                sw.WriteLine(age_season.ToString());
                sw.WriteLine(age.ToString());
                sw.WriteLine(cell_count.ToString());
                sw.WriteLine(Print_cell_count.ToString());
                sw.WriteLine(WORLD_HEIGHT.ToString());
                sw.WriteLine(WORLD_WIDTH.ToString());
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
            GO = t;
        }

        private void Stop_Play(object sender, EventArgs e)
        {
            GO = !GO;
            if (GO)
            {
                t = new System.Threading.Thread(MainFunction);
                t.Start();
                clock.Start();
            }
            else
            {
                clock.Stop();
            }
        }

        private void Load_file(object sender, EventArgs e)
        {
            GO = false;
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                SaveFileName = openFileDialog1.FileName;
                String[] Str = File.ReadAllLines(SaveFileName);
                season_str = Str[0];
                viewMode = int.Parse(Str[1]);
                WORLD_SIZE = int.Parse(Str[2]);
                ETM = int.Parse(Str[3]);
                MTE = int.Parse(Str[4]);
                ETL = int.Parse(Str[5]);
                season = int.Parse(Str[6]);
                season_max = int.Parse(Str[7]);
                season_time = int.Parse(Str[8]);
                age_season = int.Parse(Str[9]);
                age = int.Parse(Str[10]);
                cell_count = int.Parse(Str[11]);
                Print_cell_count = int.Parse(Str[12]);
                WORLD_HEIGHT = int.Parse(Str[13]);
                WORLD_WIDTH = int.Parse(Str[14]);
                MAX_CELLS = WORLD_HEIGHT * WORLD_WIDTH;
                cells = new int[MAX_CELLS, CELL_SIZE];
                world = new int[WORLD_WIDTH, WORLD_HEIGHT + 2];
                int Count = 15;
                for (int x = 0; x < WORLD_WIDTH; x++)
                {
                    for (int y = 0; y < WORLD_HEIGHT + 2; y++)
                    {
                        world[x, y] = int.Parse(Str[Count]);
                            Count++;
                    }
                }
                for (int i = 0; i < MAX_CELLS; i++)
                {
                    for (int j = 0; j < CELL_SIZE; j++)
                    {
                        cells[i,j] = int.Parse(Str[Count]);
                            Count++;
                    }
                }
            }
        }

        private void ViewMode1(object sender, EventArgs e)
        {
            viewMode = 1;
            Refresh();
        }

        private void ViewMode2(object sender, EventArgs e)
        {
            viewMode = 2;
            Refresh();
        }

        private void ViewMode3(object sender, EventArgs e)
        {
            viewMode = 3;
            Refresh();
        }

        private void ChangeFPS(object sender, EventArgs e)
        {
            timer1.Interval = FPS_Scroll.Value;
        }

        private void WorldSizeChange(object sender, EventArgs e)
        {
            if (!GO && age == 0)
            {
                WORLD_WIDTH = 180 * WorldSizeScroll.Value;
                WORLD_HEIGHT = 96 * WorldSizeScroll.Value;
                MAX_CELLS = WORLD_HEIGHT * WORLD_WIDTH;

                cells = new int[MAX_CELLS, CELL_SIZE];
                drawCells = new int[MAX_CELLS, CELL_SIZE];
                world = new int[WORLD_WIDTH, WORLD_HEIGHT + 2];
                drawWorld = new int[WORLD_WIDTH, WORLD_HEIGHT + 2];

                int x = 0;
                while (x < WORLD_WIDTH)
                {
                    world[x, 0] = WC_WALL;
                    world[x, WORLD_HEIGHT + 1] = WC_WALL;
                    x++;
                }

                SetScrollers();
                FirstCell();
                Refresh();
            }
        }

        private void NewSimulate(object sender, EventArgs e)
        {
            GO = false;
            age = 0;
            WorldSizeChange(sender, e);

            cells = new int[MAX_CELLS, CELL_SIZE];
            drawCells = new int[MAX_CELLS, CELL_SIZE];
            world = new int[WORLD_WIDTH, WORLD_HEIGHT + 2];
            drawWorld = new int[WORLD_WIDTH, WORLD_HEIGHT + 2];

            season = 11;
            season_max = 10;
            season_time = 0;
            age_season = 0;
            CELL = 0;
            cell_count = 0;
            Print_cell_count = 0;
            int x = 0;
            while (x < WORLD_WIDTH)
            {
                world[x, 0] = WC_WALL;
                world[x, WORLD_HEIGHT + 1] = WC_WALL;
                x++;
            }
            if (!performanceTest)
            {
                MuteChance = 10;
                FirstCell();
            }
            else
            {
                MuteChance = 0;
                CreatePerformanceTestWorld();
            }

            clock.Restart();
            clock.Stop();
            Refresh();
        }

        private void WORLD_BOX_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (GO)
            {
                GO = false;
                t.Join();    
            }
            System.Windows.Forms.Application.Exit();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            xDrawStartIndex = hScrollBar1.Value * 10;
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            yDrawStartIndex = vScrollBar1.Value * 10;
        }

        private void lacationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                SaveImageDirectory = folderBrowserDialog1.SelectedPath;
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            //button1.Location = new Point(this.Size.Width - 125, 34);
            //button2.Location = new Point(this.Size.Width - 250, 34);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            performanceTest = !performanceTest;
            toolStripMenuItem1.Checked = performanceTest;
        }

        private void saveImagesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            saveImage = !saveImage;
            saveImagesToolStripMenuItem1.Checked = saveImage;
        }

        private void saveParametresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageSaveParametresFrom imageSaveParametresFrom = new ImageSaveParametresFrom();
            
            imageSaveParametresFrom.mainForm = this;
            
            imageSaveParametresFrom.ShowDialog();
        }
    }
    #endregion
}
