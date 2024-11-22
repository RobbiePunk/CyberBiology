using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CyberBiology.ServiceFunctions;

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
            mainForm.imageSaveStep = (int)saveImageStepNum.Value;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            mainForm.imageSaveViewMode[0] = viewMode1CB.Checked ? 1 : 0;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            mainForm.imageSaveViewMode[1] = viewMode2CB.Checked ? 1 : 0;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            mainForm.imageSaveViewMode[2] = viewMode3CB.Checked ? 1 : 0;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            mainForm.imageSaveViewMode[3] = viewMode4CB.Checked ? 1 : 0;
        }

        private void ImageSaveParametresFrom_Load(object sender, EventArgs e)
        {
            saveImageStepNum.Value = mainForm.imageSaveStep;
            saveWorldStepNum.Value = mainForm.worldSaveStep;
            viewMode1CB.Checked = mainForm.imageSaveViewMode[0] == 1;
            viewMode2CB.Checked = mainForm.imageSaveViewMode[1] == 1;
            viewMode3CB.Checked = mainForm.imageSaveViewMode[2] == 1;
            viewMode4CB.Checked = mainForm.imageSaveViewMode[3] == 1;
            drawInfoCB.Checked = drawInfo;

            if (saveSize != 0)
                AutoImageSizeCB_CheckedChanged(sender, e);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            mainForm.worldSaveStep = (int)saveWorldStepNum.Value;
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            drawInfo = drawInfoCB.Checked;
            mainForm.ChangeSaveBitmap();
        }

        private void AutoImageSizeCB_CheckedChanged(object sender, EventArgs e)
        {
            sizeNum.Enabled = !AutoImageSizeCB.Checked;

            if (AutoImageSizeCB.Checked)
                saveSize = 0;
            else
            {
                saveSize = (int)sizeNum.Value;
                mainForm.imageSaveSize = saveSize;
            }
            mainForm.ChangeSaveBitmap();
        }

        private void sizeNum_ValueChanged(object sender, EventArgs e)
        {
            saveSize = (int)sizeNum.Value;
            mainForm.imageSaveSize = saveSize;
            mainForm.ChangeSaveBitmap();
        }
    }
}
