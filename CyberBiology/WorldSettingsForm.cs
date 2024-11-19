using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using static CyberBiology.Constants;
using static CyberBiology.Simulation;
using static CyberBiology.CellFunctions;
using static CyberBiology.CellAditionalFunctions;
using static CyberBiology.ServiceFunctions;

namespace CyberBiology
{
    public partial class WorldSettingsForm : Form
    {

        public Form1 mainForm;
        int[] seasonsBuf = { 0, 0, 0, 0};

        public WorldSettingsForm()
        {
            InitializeComponent();
        }

        private void WorldSettingsForm_Load(object sender, EventArgs e)
        {
            xSizeTB.Text = WORLD_WIDTH.ToString();
            ySizeTB.Text = WORLD_HEIGHT.ToString();
            checkBox1.Checked = isPressure;
            numericUpDown1.Value = mainForm.customMuteChance;

            ETL_Num.Value = ETL;
            MTE_Num.Value = MTE;
            ETM_Num.Value = ETM;

            maskedTextBox1.Text = seasonTime.ToString();

            seasons.CopyTo(seasonsBuf, 0);

            SeasonsUD_SelectedItemChanged(sender, e);
        }

        private void ApplyBT_Click(object sender, EventArgs e)
        {
            int newWidth = int.Parse(xSizeTB.Text);
            if (newWidth > 0)
            {
                int newHeight = int.Parse(ySizeTB.Text);
                if (newHeight > 0)
                {
                    mainForm.SetWorldSize(newWidth, newHeight);
                }
            }
            isPressure = checkBox1.Checked;
            mainForm.customMuteChance = (int)numericUpDown1.Value;
            if (textBox1.Text == "")
                mainForm.SetWorldSettings();
            else
            {
                try
                {
                    mainForm.SetWorldSettings(int.Parse(textBox1.Text));
                }
                catch
                {
                    int s = 0;
                    string str = textBox1.Text;
                    for (int i = 0; i < str.Length; i++)
                        s += str[i];
                    mainForm.SetWorldSettings(s);
                }
            }

            ETL = (int)ETL_Num.Value;
            MTE = (int)MTE_Num.Value;
            ETM = (int)ETM_Num.Value;

            if(int.Parse(maskedTextBox1.Text) > 0)
                seasonTime = int.Parse(maskedTextBox1.Text);

            seasonsBuf.CopyTo(seasons, 0);

            Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //isPressure = checkBox1.Checked;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void ETM_Num_ValueChanged(object sender, EventArgs e)
        {

        }

        private void setDefBT_Click(object sender, EventArgs e)
        {
            mainForm.SetWorldSize(180, 96);

            isPressure = false;
            mainForm.customMuteChance = 10;
            mainForm.SetWorldSettings();

            ETL = 3;
            MTE = 2;
            ETM = 5;

            seasonTime = 10000;

            seasonsBuf = new int[]{ 11, 10, 9, 10};

            WorldSettingsForm_Load(sender, e);
        }

        private void SeasonsUD_SelectedItemChanged(object sender, EventArgs e)
        {
            int n = Array.IndexOf(seasonsString, SeasonsUD.Text);
            if (n == -1)
            {

            }
            else
            {
                SeasonsNum.Value = seasonsBuf[n];
            }
        }

        private void SeasonsNum_ValueChanged(object sender, EventArgs e)
        {
            int n = Array.IndexOf(seasonsString, SeasonsUD.Text);
            if (n == -1)
            {

            }
            else
            {
                seasonsBuf[n] = (int)SeasonsNum.Value;
            }
        }
    }
}
