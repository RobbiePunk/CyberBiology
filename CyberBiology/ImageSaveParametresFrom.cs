using CyberBiology2;
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
    public partial class ImageSaveParametresFrom : Form
    {
        public Form1 mainForm;

        public ImageSaveParametresFrom()
        {
            InitializeComponent();
        }

        private void numericSaveStep_ValueChanged(object sender, EventArgs e)
        {
            mainForm.imageSaveStep = (int)numericSaveStep.Value;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            mainForm.imageSaveViewMode[0] = checkBox1.Checked ? 1 : 0;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            mainForm.imageSaveViewMode[1] = checkBox2.Checked ? 1 : 0;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            mainForm.imageSaveViewMode[2] = checkBox3.Checked ? 1 : 0;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            mainForm.imageSaveSize = (int)numericUpDown1.Value;
        }

        private void ImageSaveParametresFrom_Load(object sender, EventArgs e)
        {
            numericSaveStep.Value = mainForm.imageSaveStep;
            checkBox1.Checked = mainForm.imageSaveViewMode[0] == 1;
            checkBox2.Checked = mainForm.imageSaveViewMode[1] == 1;
            checkBox3.Checked = mainForm.imageSaveViewMode[2] == 1;
            numericUpDown1.Value = mainForm.imageSaveSize;
        }
    }
}
