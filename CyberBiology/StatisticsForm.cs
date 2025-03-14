using static CyberBiology.ServiceFunctions;
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
    public partial class StaticsticsForm : Form
    {
        Graphics GR;
        Bitmap bmp;

        public Form1 mainForm;

        Dictionary<int, int> cellCountStat = new Dictionary<int, int>();
        Dictionary<int, int> aliveCellCountStat = new Dictionary<int, int>();

        public StaticsticsForm()
        {
            InitializeComponent();
        }

        private void StaticsticsForm_Load(object sender, EventArgs e)
        {
            statPB.Size = new Size(this.Width - 35, this.Height - 60);
            bmp = new Bitmap(statPB.Width, statPB.Height);
            GR = Graphics.FromImage(bmp);

            DrawCellCountStat();
        }

        public void DrawCellCountStat()
        {
            aliveCellCountStat = LoadCellCountLog(1);
            cellCountStat = LoadCellCountLog(2);

            if (cellCountStat.Count == 0)
                return;

            SolidBrush BR = new SolidBrush(Color.Black);
            Pen p = new Pen(Color.Gray);
            Pen pLegend = new Pen(Color.Black);
            GR.Clear(Color.White);

            int xBias = 52;
            int pbWidth = statPB.Width - xBias;
            int pbHeight = statPB.Height - 18;

            int count = cellCountStat.Count;
             
            float maxValue = Math.Max(aliveCellCountStat.Max(x => x.Value), cellCountStat.Max(x => x.Value));
            float maxKey = cellCountStat.Max(x => x.Key);

            int pow = 0;
            while (maxValue > 10)
            {
                maxValue /= 10;
                pow++;
            }

            maxValue = (float)Math.Ceiling(maxValue);
            maxValue *= (float)Math.Pow(10, pow);

            float yScaling = pbHeight / (float)maxValue;
            float xScaling = pbWidth / (float)maxKey;

            GR.DrawString($"iter.", new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
                        BR, pbWidth + 10, pbHeight);
            GR.DrawString($"cells", new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
                        BR, 0, 0);

            for (int i = 1; i < 10; i++)
            {
                int y = pbHeight - i * pbHeight / 10;

                string str = $"{i * maxValue / 10}";
                if (maxValue > 10000)
                    str = $"{i * maxValue / 10000}k";
                else if (maxValue > 10000000)
                    str = $"{i * maxValue / 10000000}m";

                int strBiasX = 42 - str.Length * 8;

                GR.DrawLine(pLegend, xBias, y, xBias + pbWidth, y);
                GR.DrawString(str, new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
                        BR, strBiasX, y - 10);
            }

            GR.DrawLine(pLegend, xBias, pbHeight, xBias + pbWidth, pbHeight);

            for (int i = 0; i < 10; i++)
            {
                int x = xBias + i * pbWidth / 10;

                GR.DrawLine(pLegend, x, 0, x, pbHeight);

                string str = $"{i * maxKey / 10}";
                if (maxKey > 10000)
                    str = $"{i * maxKey / 10000}k";
                else if (maxKey > 10000000)
                    str = $"{i * maxKey / 10000000}m";

                int strBiasX = str.Length;

                GR.DrawString(str, new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
                        BR, x - 15 - strBiasX, pbHeight);
            }

            for (int x = 1; x < count; x++)
            {
                float xPos = xBias + cellCountStat.ElementAt(x).Key * xScaling;
                float yPos = pbHeight - cellCountStat.ElementAt(x).Value * yScaling;

                float xPrevPos = xBias + cellCountStat.ElementAt(x - 1).Key * xScaling;
                float yPrevPos = pbHeight - cellCountStat.ElementAt(x - 1).Value * yScaling;

                GR.DrawLine(p, xPrevPos, yPrevPos, xPos, yPos);
            }

            p = new Pen(Color.Green);
            for (int x = 1; x < count; x++)
            {
                float xPos = xBias + aliveCellCountStat.ElementAt(x).Key * xScaling;
                float yPos = pbHeight - aliveCellCountStat.ElementAt(x).Value * yScaling;

                float xPrevPos = xBias + aliveCellCountStat.ElementAt(x - 1).Key * xScaling;
                float yPrevPos = pbHeight - aliveCellCountStat.ElementAt(x - 1).Value * yScaling;

                GR.DrawLine(p, xPrevPos, yPrevPos, xPos, yPos);
            }

            statPB.Image = bmp;

        }

        private void StaticsticsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainForm.statForms.Remove(this);
        }

        private void StaticsticsForm_SizeChanged(object sender, EventArgs e)
        {
            StaticsticsForm_Load(this, EventArgs.Empty);
        }
    }
}
