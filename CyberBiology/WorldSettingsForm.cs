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
            pressureCB.Checked = isPressure;
            autoDivideCB.Checked = isAutoDivide;
            mutationChanceNum.Value = mainForm.customMuteChance;

            ETL_Num.Value = ETL;
            MTE_Num.Value = MTE;
            ETM_Num.Value = ETM;

            seasonTimeTB.Text = seasonTime.ToString();

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

            isPressure = pressureCB.Checked;
            isAutoDivide = autoDivideCB.Checked;

            mainForm.customMuteChance = (int)mutationChanceNum.Value;

            if (seedNum.Text == "")
                mainForm.SetWorldSettings();
            else
            {
                try
                {
                    mainForm.SetWorldSettings(int.Parse(seedNum.Text));
                }
                catch
                {
                    int s = 0;
                    string str = seedNum.Text;
                    for (int i = 0; i < str.Length; i++)
                        s += str[i];
                    mainForm.SetWorldSettings(s);
                }
            }

            ETL = (int)ETL_Num.Value;
            MTE = (int)MTE_Num.Value;
            ETM = (int)ETM_Num.Value;

            if(int.Parse(seasonTimeTB.Text) > 0)
                seasonTime = int.Parse(seasonTimeTB.Text);

            seasonsBuf.CopyTo(seasons, 0);

            Close();
        }

        private void setDefBT_Click(object sender, EventArgs e)
        {
            mainForm.SetWorldSize(180, 96);

            isPressure = false;
            isAutoDivide = true;
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
            int n = Array.IndexOf(seasonsString, seasonsStringUD.Text);
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
            int n = Array.IndexOf(seasonsString, seasonsStringUD.Text);
            if (n == -1)
            {

            }
            else
            {
                seasonsBuf[n] = (int)SeasonsNum.Value;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            isAutoDivide = autoDivideCB.Checked;
        }
    }
}
