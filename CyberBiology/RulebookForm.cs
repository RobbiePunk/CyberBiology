using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CyberBiology
{
    public partial class RulebookForm : Form
    {
        Bitmap bmp;
        Graphics GR;

        int currentMode = 1;

        public RulebookForm()
        {
            InitializeComponent();

            pictureBox1.Size = new Size(400, 450);
            pictureBox1.Location = new Point(10, 10);

            bmp = new Bitmap(400, 500);
            GR = Graphics.FromImage(bmp);

            pictureBox1.Visible = false;
            cellColorRightBT.Visible = false;
            cellColorLeftBT.Visible = false;
            backBT.Visible = false;
        }

        private void CellColorBT_Click(object sender, EventArgs e)
        {
            backBT.Visible = true;
            pictureBox1.Visible = true;

            cellColorRightBT.Visible = true;
            cellColorLeftBT.Visible = true;
            

            DrawCellColorPage(currentMode);

            CellColorBT.Visible = false;
        }

        private void backBT_Click(object sender, EventArgs e)
        {
            CellColorBT.Visible = true;

            cellColorRightBT.Visible = false;
            cellColorLeftBT.Visible = false;
            pictureBox1.Visible = false;
            backBT.Visible = false;
        }


        void DrawCellColorPage(int mode)
        {
            SolidBrush BR = new SolidBrush(Color.Black);
            GR.Clear(Color.White);

            switch (mode)
            {
                case 1:
                    GR.DrawString($"Normal Mode", new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
                            BR, 10, 10);

                    GR.DrawString($"gets energy from the sun", new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
                            BR, 60, 40);

                    GR.DrawString($"gets energy from minerals", new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
                           BR, 60, 80);

                    GR.DrawString($"gets energy from other cells", new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
                           BR, 60, 120);

                    GR.DrawString($"gets energy from the sun and other cells", new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
                           BR, 60, 160);

                    GR.DrawString($"gets energy from the sun and minerals", new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
                           BR, 60, 200);

                    GR.DrawString($"gets energy from other cells and minerals", new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
                           BR, 60, 240);

                    GR.DrawString($"dead cells", new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
                           BR, 60, 280);

                    GR.DrawString($"earth", new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
                           BR, 60, 320);

                    GR.DrawString($"stones", new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
                           BR, 60, 360);

                    GR.DrawString($"walls", new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
                           BR, 60, 400);

                    BR.Color = Color.FromArgb(255, 0, 255, 0);
                    GR.FillRectangle(BR, 40, 45, 10, 10);

                    BR.Color = Color.FromArgb(255, 0, 0, 255);
                    GR.FillRectangle(BR, 40, 85, 10, 10);

                    BR.Color = Color.FromArgb(255, 255, 0, 0);
                    GR.FillRectangle(BR, 40, 125, 10, 10);

                    BR.Color = Color.FromArgb(255, 255, 255, 0);
                    GR.FillRectangle(BR, 40, 165, 10, 10);

                    BR.Color = Color.FromArgb(255, 0, 255, 255);
                    GR.FillRectangle(BR, 40, 205, 10, 10);

                    BR.Color = Color.FromArgb(255, 255, 0, 255);
                    GR.FillRectangle(BR, 40, 245, 10, 10);

                    BR.Color = Color.FromArgb(255, 100, 100, 100);
                    GR.FillRectangle(BR, 40, 285, 10, 10);

                    BR.Color = Color.FromArgb(255, 150, 100, 0);
                    GR.FillRectangle(BR, 40, 325, 10, 10);

                    BR.Color = Color.FromArgb(255, 150, 150, 200);
                    GR.FillRectangle(BR, 40, 365, 10, 10);

                    BR.Color = Color.FromArgb(255, 40, 40, 40);
                    GR.FillRectangle(BR, 40, 405, 10, 10);
                    break;
                case 2:
                    GR.DrawString($"Colony Mode", new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
                            BR, 10, 10);

                    GR.DrawString($"single cell", new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
                            BR, 60, 40);

                    GR.DrawString($"part of the colony (darker - more neighbors)", new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
                           BR, 60, 80);

                    GR.DrawString($"dead cells", new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
                           BR, 60, 120);

                    GR.DrawString($"earth", new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
                           BR, 60, 160);

                    GR.DrawString($"stones", new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
                           BR, 60, 200);

                    GR.DrawString($"walls", new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
                           BR, 60, 240);

                    BR.Color = Color.FromArgb(255, 0, 240, 240);
                    GR.FillRectangle(BR, 40, 45, 10, 10);

                    BR.Color = Color.FromArgb(255, 220, 10, 185);
                    GR.FillRectangle(BR, 20, 85, 10, 10);

                    BR.Color = Color.FromArgb(255, 160, 64, 120);
                    GR.FillRectangle(BR, 40, 85, 10, 10);

                    BR.Color = Color.FromArgb(255, 100, 100, 100);
                    GR.FillRectangle(BR, 40, 125, 10, 10);

                    BR.Color = Color.FromArgb(255, 150, 100, 0);
                    GR.FillRectangle(BR, 40, 165, 10, 10);

                    BR.Color = Color.FromArgb(255, 150, 150, 200);
                    GR.FillRectangle(BR, 40, 205, 10, 10);

                    BR.Color = Color.FromArgb(255, 40, 40, 40);
                    GR.FillRectangle(BR, 40, 245, 10, 10);
                    break;
                case 3:
                    GR.DrawString($"Energy Mode", new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
                            BR, 10, 10);

                    GR.DrawString($"low energy", new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
                            BR, 60, 40);

                    GR.DrawString($"high energy", new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
                           BR, 60, 80);

                    GR.DrawString($"dead cells", new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
                           BR, 60, 120);

                    GR.DrawString($"earth", new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
                           BR, 60, 160);

                    GR.DrawString($"stones", new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
                           BR, 60, 200);

                    GR.DrawString($"walls", new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
                           BR, 60, 240);

                    BR.Color = Color.FromArgb(255, 255, 255, 0);
                    GR.FillRectangle(BR, 40, 45, 10, 10);

                    BR.Color = Color.FromArgb(255, 255, 0, 0);
                    GR.FillRectangle(BR, 40, 85, 10, 10);

                    BR.Color = Color.FromArgb(255, 100, 100, 100);
                    GR.FillRectangle(BR, 40, 125, 10, 10);

                    BR.Color = Color.FromArgb(255, 150, 100, 0);
                    GR.FillRectangle(BR, 40, 165, 10, 10);

                    BR.Color = Color.FromArgb(255, 150, 150, 200);
                    GR.FillRectangle(BR, 40, 205, 10, 10);

                    BR.Color = Color.FromArgb(255, 40, 40, 40);
                    GR.FillRectangle(BR, 40, 245, 10, 10);
                    break;
                case 4:
                    GR.DrawString($"Age Mode", new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
                            BR, 10, 10);

                    GR.DrawString($"age less then 1000 iterations", new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
                            BR, 60, 40);

                    GR.DrawString($"age between 1000 and 10000 iterations", new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
                           BR, 60, 80);

                    GR.DrawString($"age more then 10000 iterations", new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
                           BR, 60, 120);

                    GR.DrawString($"dead cells", new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
                           BR, 60, 160);

                    GR.DrawString($"earth", new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
                           BR, 60, 200);

                    GR.DrawString($"stones", new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
                           BR, 60, 240);

                    GR.DrawString($"walls", new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
                           BR, 60, 280);

                    BR.Color = Color.FromArgb(255, 250, 200, 200);
                    GR.FillRectangle(BR, 40, 45, 10, 10);

                    BR.Color = Color.FromArgb(255, 55, 200, 200);
                    GR.FillRectangle(BR, 40, 85, 10, 10);

                    BR.Color = Color.FromArgb(255, 55, 20, 200);
                    GR.FillRectangle(BR, 40, 125, 10, 10);

                    BR.Color = Color.FromArgb(255, 100, 100, 100);
                    GR.FillRectangle(BR, 40, 165, 10, 10);

                    BR.Color = Color.FromArgb(255, 150, 100, 0);
                    GR.FillRectangle(BR, 40, 205, 10, 10);

                    BR.Color = Color.FromArgb(255, 150, 150, 200);
                    GR.FillRectangle(BR, 40, 245, 10, 10);

                    BR.Color = Color.FromArgb(255, 40, 40, 40);
                    GR.FillRectangle(BR, 40, 285, 10, 10);
                    break;
                case 5:
                    GR.DrawString($"Clan Mode", new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
                            BR, 10, 10);

                    GR.DrawString($"Color of the cell is set at the beginning\nand is inherited", new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
                            BR, 20, 40);

                    GR.DrawString($"dead cells", new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
                           BR, 60, 120);

                    GR.DrawString($"earth", new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
                           BR, 60, 160);

                    GR.DrawString($"stones", new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
                           BR, 60, 200);

                    GR.DrawString($"walls", new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
                           BR, 60, 240);

                    BR.Color = Color.FromArgb(255, 100, 100, 100);
                    GR.FillRectangle(BR, 40, 125, 10, 10);

                    BR.Color = Color.FromArgb(255, 150, 100, 0);
                    GR.FillRectangle(BR, 40, 165, 10, 10);

                    BR.Color = Color.FromArgb(255, 150, 150, 200);
                    GR.FillRectangle(BR, 40, 205, 10, 10);

                    BR.Color = Color.FromArgb(255, 40, 40, 40);
                    GR.FillRectangle(BR, 40, 245, 10, 10);
                    break;
                default:
                    break;
            }
            pictureBox1.Image = bmp;
        }

        private void cellColorRightBT_Click(object sender, EventArgs e)
        {
            currentMode++;
            if (currentMode > 5)
                currentMode = 1;

            DrawCellColorPage(currentMode);
        }

        private void cellColorLeftBT_Click(object sender, EventArgs e)
        {
            currentMode--;
            if (currentMode < 1)
                currentMode = 5;

            DrawCellColorPage(currentMode);
        }
    }
}
