using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static CyberBiology.Constants;
using static CyberBiology.Simulation;
using static CyberBiology.ServiceFunctions;

namespace CyberBiology
{
    public partial class InspectForm : Form
    {
        public Form1 mainForm;
        public int cellNum = 0;

        Bitmap bitmap; 
        Graphics gr;

        public InspectForm()
        {
            InitializeComponent();

            bitmap = new Bitmap(1000, 420);
            gr = Graphics.FromImage(bitmap);
        }

        private void InspectForm_Load(object sender, EventArgs e)
        {
            UpdateInfo();
        }

        public void UpdateInfo()
        {
            int x = (int)Math.Sqrt((double)MIND_SIZE);
            int y = MIND_SIZE / x;

            gr.Clear(Color.White);
            SolidBrush BR = new SolidBrush(Color.Black);

            int size = 200 / y;
            int command = cells[cellNum, cells[cellNum, ADR]];

            for (int i = 0; i < y; i++)
            {
                for (int j = 0; (j < x) && (i * x + j < MIND_SIZE); j++)
                {
                    if (i * x + j == cells[cellNum, ADR])
                    {
                        Pen pen = new Pen(Color.Green);
                        gr.DrawRectangle(pen, j * size * 1.75f, i * size * 1.4f, size * 1.5f, size * 1.2f);
                    }
                    gr.DrawString($"{cells[cellNum, i * x + j]}", new Font(new FontFamily("Arial"), size, FontStyle.Regular, GraphicsUnit.Pixel),
                    BR, j * size * 1.75f, i * size * 1.4f);
                }
            }

            switch (cells[cellNum, LIVING])
            {
                case LV_ALIVE:
                    gr.DrawString($"Status: Alive", new Font(new FontFamily("Arial"), 20, FontStyle.Regular, GraphicsUnit.Pixel),
                   BR, 360, 0);
                    break;
                case LV_DEAD:
                    gr.DrawString($"Status: Dead", new Font(new FontFamily("Arial"), 20, FontStyle.Regular, GraphicsUnit.Pixel),
                   BR, 360, 0);
                    break;
                case LV_EARTH:
                    gr.DrawString($"Status: Earth", new Font(new FontFamily("Arial"), 20, FontStyle.Regular, GraphicsUnit.Pixel),
                   BR, 360, 0);
                    break;
                case LV_FREE:
                    gr.DrawString($"Status: Empty", new Font(new FontFamily("Arial"), 20, FontStyle.Regular, GraphicsUnit.Pixel),
                   BR, 360, 0);
                    break;
                case LV_STONE:
                    gr.DrawString($"Status: Stone", new Font(new FontFamily("Arial"), 20, FontStyle.Regular, GraphicsUnit.Pixel),
                   BR, 360, 0);
                    break;
                default:
                    break;
            }
            
            gr.DrawString($"Coordinats: {cells[cellNum, X_COORD]}, {cells[cellNum, X_COORD]}", new Font(new FontFamily("Arial"), 20, FontStyle.Regular, GraphicsUnit.Pixel),
                    BR, 360, 40);
            gr.DrawString($"Energy: {cells[cellNum, ENERGY]}", new Font(new FontFamily("Arial"), 20, FontStyle.Regular, GraphicsUnit.Pixel),
                    BR, 360, 80);
            gr.DrawString($"Mineral: {cells[cellNum, MINERAL]}", new Font(new FontFamily("Arial"), 20, FontStyle.Regular, GraphicsUnit.Pixel),
                    BR, 360, 120);
            gr.DrawString($"Direct: {cells[cellNum, DIRECT]}", new Font(new FontFamily("Arial"), 20, FontStyle.Regular, GraphicsUnit.Pixel),
                    BR, 360, 160);
            gr.DrawString($"Age: {cells[cellNum, CELL_AGE]}", new Font(new FontFamily("Arial"), 20, FontStyle.Regular, GraphicsUnit.Pixel),
                    BR, 360, 200);
            gr.DrawString($"Sleep for: {cells[cellNum, CELL_SLEEP]}", new Font(new FontFamily("Arial"), 20, FontStyle.Regular, GraphicsUnit.Pixel),
                    BR, 360, 280);

            if (command == 19)//сон
            {
                gr.DrawString($"Command: Sleep", new Font(new FontFamily("Arial"), 20, FontStyle.Regular, GraphicsUnit.Pixel),
                    BR, 360, 240);
            }
            else if (command == 20)//растворить в относителном направлении
            {
                gr.DrawString($"Command: Acid Split", new Font(new FontFamily("Arial"), 20, FontStyle.Regular, GraphicsUnit.Pixel),
                    BR, 360, 240);
            }
            else if (command == 21)//растворить в абсолютном направлении
            {
                gr.DrawString($"Command: Acid Split", new Font(new FontFamily("Arial"), 20, FontStyle.Regular, GraphicsUnit.Pixel),
                    BR, 360, 240);
            }
            else if (command == 22)//Деление с абсолютной сменой команды
            {
                gr.DrawString($"Command: Divide", new Font(new FontFamily("Arial"), 20, FontStyle.Regular, GraphicsUnit.Pixel),
                    BR, 360, 240);
            }
            else if (command == 23)//смена направления относительно
            {
                gr.DrawString($"Command: Change Direction", new Font(new FontFamily("Arial"), 20, FontStyle.Regular, GraphicsUnit.Pixel),
                    BR, 360, 240);
            }
            else if (command == 24)//смена направления абсолютно
            {
                gr.DrawString($"Command: Change Direction", new Font(new FontFamily("Arial"), 20, FontStyle.Regular, GraphicsUnit.Pixel),
                    BR, 360, 240);
            }
            else if (command == 25)//фотосинтез
            {
                gr.DrawString($"Command: Fotosintez", new Font(new FontFamily("Arial"), 20, FontStyle.Regular, GraphicsUnit.Pixel),
                    BR, 360, 240);
            }
            else if (command == 26)//движение относительно
            {
                gr.DrawString($"Command: Move", new Font(new FontFamily("Arial"), 20, FontStyle.Regular, GraphicsUnit.Pixel),
                    BR, 360, 240);
            }
            else if (command == 27)//движение абсолютно
            {
                gr.DrawString($"Command: Move", new Font(new FontFamily("Arial"), 20, FontStyle.Regular, GraphicsUnit.Pixel),
                    BR, 360, 240);
            }
            else if (command == 28)//съесть в относителном направлении
            {
                gr.DrawString($"Command: Eat", new Font(new FontFamily("Arial"), 20, FontStyle.Regular, GraphicsUnit.Pixel),
                    BR, 360, 240);
            }
            else if (command == 29)//съесть в абсолютном направлении
            {
                gr.DrawString($"Command: Eat", new Font(new FontFamily("Arial"), 20, FontStyle.Regular, GraphicsUnit.Pixel),
                    BR, 360, 240);
            }
            else if (command == 30)//посмотреть в относительном направлении
            {
                gr.DrawString($"Command: Look", new Font(new FontFamily("Arial"), 20, FontStyle.Regular, GraphicsUnit.Pixel),
                    BR, 360, 240);
            }
            else if (command == 31)//посмотреть в абсолютном направлении
            {
                gr.DrawString($"Command: Look", new Font(new FontFamily("Arial"), 20, FontStyle.Regular, GraphicsUnit.Pixel),
                    BR, 360, 240);
            }
            else if (command == 32)//поделиться лишними ресурсами в относительном направлении
            {
                gr.DrawString($"Command: Care", new Font(new FontFamily("Arial"), 20, FontStyle.Regular, GraphicsUnit.Pixel),
                    BR, 360, 240);
            }
            else if (command == 33)//поделиться лишними ресурсами в абсолютном направлении
            {
                gr.DrawString($"Command: Care", new Font(new FontFamily("Arial"), 20, FontStyle.Regular, GraphicsUnit.Pixel),
                    BR, 360, 240);
            }
            else if (command == 34)//отдать ресурсы в относительном направлении
            {
                gr.DrawString($"Command: Give Resourse", new Font(new FontFamily("Arial"), 20, FontStyle.Regular, GraphicsUnit.Pixel),
                    BR, 360, 240);
            }
            else if (command == 35)//отдать ресурсы в абсолютном направлении
            {
                gr.DrawString($"Command: Give Resourse", new Font(new FontFamily("Arial"), 20, FontStyle.Regular, GraphicsUnit.Pixel),
                    BR, 360, 240);
            }
            else if (command == 36)//выровняться по горизонтали
            {
                gr.DrawString($"Command: Allign", new Font(new FontFamily("Arial"), 20, FontStyle.Regular, GraphicsUnit.Pixel),
                    BR, 360, 240);
            }
            else if (command == 37)//узнать высоту
            {
                gr.DrawString($"Command: Check Height", new Font(new FontFamily("Arial"), 20, FontStyle.Regular, GraphicsUnit.Pixel),
                    BR, 360, 240);
            }
            else if (command == 38)//узнать количество энергии
            {
                gr.DrawString($"Command: Check Energy", new Font(new FontFamily("Arial"), 20, FontStyle.Regular, GraphicsUnit.Pixel),
                    BR, 360, 240);
            }
            else if (command == 39)//узнать количество минералов
            {
                gr.DrawString($"Command: Check Mineral", new Font(new FontFamily("Arial"), 20, FontStyle.Regular, GraphicsUnit.Pixel),
                    BR, 360, 240);
            }
            else if (command == 40)//многоклеточное деление
            {
                gr.DrawString($"Command: Multi Divide", new Font(new FontFamily("Arial"), 20, FontStyle.Regular, GraphicsUnit.Pixel),
                    BR, 360, 240);
            }
            else if (command == 41)//свободное деление
            {
                gr.DrawString($"Command: Divide", new Font(new FontFamily("Arial"), 20, FontStyle.Regular, GraphicsUnit.Pixel),
                    BR, 360, 240);
            }
            else if (command == 43)//окружена ли клетка?
            {
                gr.DrawString($"Command: Check Full Around", new Font(new FontFamily("Arial"), 20, FontStyle.Regular, GraphicsUnit.Pixel),
                    BR, 360, 240);
            }
            else if (command == 44)//приход энергии есть?
            {
                gr.DrawString($"Command: Check Energy Grow", new Font(new FontFamily("Arial"), 20, FontStyle.Regular, GraphicsUnit.Pixel),
                    BR, 360, 240);
            }
            else if (command == 45)//минералы прибавляются?
            {
                gr.DrawString($"Command: Check Mineral Grow", new Font(new FontFamily("Arial"), 20, FontStyle.Regular, GraphicsUnit.Pixel),
                    BR, 360, 240);
            }
            else if (command == 46)//многоклеточный ли бот?
            {
                gr.DrawString($"Command: Check Is Multi", new Font(new FontFamily("Arial"), 20, FontStyle.Regular, GraphicsUnit.Pixel),
                    BR, 360, 240);
            }
            else if (command == 47)//преобразовать минералы в энергию
            {
                gr.DrawString($"Command: Mineral To Energy", new Font(new FontFamily("Arial"), 20, FontStyle.Regular, GraphicsUnit.Pixel),
                    BR, 360, 240);
            }
            else if (command == 48)//отобрать и поделить
            {
                gr.DrawString($"Command: Colony Sharing", new Font(new FontFamily("Arial"), 20, FontStyle.Regular, GraphicsUnit.Pixel),
                    BR, 360, 240);
            }
            else//Смена комадны
            {
                gr.DrawString($"Command: Change Command", new Font(new FontFamily("Arial"), 20, FontStyle.Regular, GraphicsUnit.Pixel),
                    BR, 360, 240);
            }

            pictureBox1.Image = bitmap;
        }

        private void InspectForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            inspectedNums.Remove(cellNum);
            mainForm.UpdateScreen();
            mainForm.inspectForm.Remove(this);
        }
    }
}
