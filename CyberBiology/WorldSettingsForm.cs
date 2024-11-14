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

        public WorldSettingsForm()
        {
            InitializeComponent();
        }

        private void WorldSettingsForm_Load(object sender, EventArgs e)
        {
            xSizeTB.Text = WORLD_WIDTH.ToString();
            ySizeTB.Text = WORLD_HEIGHT.ToString();
            checkBox1.Checked = isPressure;
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
            Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //isPressure = checkBox1.Checked;
        }
    }
}
