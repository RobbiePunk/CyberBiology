namespace CyberBiology
{
    partial class ImageSaveParametresFrom
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.saveImageStepNum = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.viewMode1CB = new System.Windows.Forms.CheckBox();
            this.viewMode2CB = new System.Windows.Forms.CheckBox();
            this.viewMode3CB = new System.Windows.Forms.CheckBox();
            this.viewMode4CB = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.saveWorldStepNum = new System.Windows.Forms.NumericUpDown();
            this.drawInfoCB = new System.Windows.Forms.CheckBox();
            this.sizeNum = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.AutoImageSizeCB = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.saveImageStepNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saveWorldStepNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizeNum)).BeginInit();
            this.SuspendLayout();
            // 
            // saveImageStepNum
            // 
            this.saveImageStepNum.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.saveImageStepNum.Location = new System.Drawing.Point(12, 33);
            this.saveImageStepNum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.saveImageStepNum.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.saveImageStepNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.saveImageStepNum.Name = "saveImageStepNum";
            this.saveImageStepNum.Size = new System.Drawing.Size(125, 22);
            this.saveImageStepNum.TabIndex = 0;
            this.saveImageStepNum.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.saveImageStepNum.ValueChanged += new System.EventHandler(this.numericSaveStep_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Save image step";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "View mods";
            // 
            // viewMode1CB
            // 
            this.viewMode1CB.AutoSize = true;
            this.viewMode1CB.Checked = true;
            this.viewMode1CB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.viewMode1CB.Location = new System.Drawing.Point(15, 112);
            this.viewMode1CB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.viewMode1CB.Name = "viewMode1CB";
            this.viewMode1CB.Size = new System.Drawing.Size(88, 20);
            this.viewMode1CB.TabIndex = 4;
            this.viewMode1CB.Text = "1 (normal)";
            this.viewMode1CB.UseVisualStyleBackColor = true;
            this.viewMode1CB.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // viewMode2CB
            // 
            this.viewMode2CB.AutoSize = true;
            this.viewMode2CB.Location = new System.Drawing.Point(15, 138);
            this.viewMode2CB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.viewMode2CB.Name = "viewMode2CB";
            this.viewMode2CB.Size = new System.Drawing.Size(87, 20);
            this.viewMode2CB.TabIndex = 5;
            this.viewMode2CB.Text = "2 (colony)";
            this.viewMode2CB.UseVisualStyleBackColor = true;
            this.viewMode2CB.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // viewMode3CB
            // 
            this.viewMode3CB.AutoSize = true;
            this.viewMode3CB.Location = new System.Drawing.Point(15, 164);
            this.viewMode3CB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.viewMode3CB.Name = "viewMode3CB";
            this.viewMode3CB.Size = new System.Drawing.Size(89, 20);
            this.viewMode3CB.TabIndex = 6;
            this.viewMode3CB.Text = "3 (energy)";
            this.viewMode3CB.UseVisualStyleBackColor = true;
            this.viewMode3CB.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // viewMode4CB
            // 
            this.viewMode4CB.AutoSize = true;
            this.viewMode4CB.Location = new System.Drawing.Point(15, 190);
            this.viewMode4CB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.viewMode4CB.Name = "viewMode4CB";
            this.viewMode4CB.Size = new System.Drawing.Size(71, 20);
            this.viewMode4CB.TabIndex = 7;
            this.viewMode4CB.Text = "4 (age)";
            this.viewMode4CB.UseVisualStyleBackColor = true;
            this.viewMode4CB.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(323, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Save world step";
            // 
            // saveWorldStepNum
            // 
            this.saveWorldStepNum.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.saveWorldStepNum.Location = new System.Drawing.Point(323, 33);
            this.saveWorldStepNum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.saveWorldStepNum.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.saveWorldStepNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.saveWorldStepNum.Name = "saveWorldStepNum";
            this.saveWorldStepNum.Size = new System.Drawing.Size(125, 22);
            this.saveWorldStepNum.TabIndex = 8;
            this.saveWorldStepNum.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.saveWorldStepNum.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // drawInfoCB
            // 
            this.drawInfoCB.AutoSize = true;
            this.drawInfoCB.Location = new System.Drawing.Point(15, 60);
            this.drawInfoCB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.drawInfoCB.Name = "drawInfoCB";
            this.drawInfoCB.Size = new System.Drawing.Size(84, 20);
            this.drawInfoCB.TabIndex = 10;
            this.drawInfoCB.Text = "Draw Info";
            this.drawInfoCB.UseVisualStyleBackColor = true;
            this.drawInfoCB.CheckedChanged += new System.EventHandler(this.checkBox5_CheckedChanged);
            // 
            // sizeNum
            // 
            this.sizeNum.Enabled = false;
            this.sizeNum.Location = new System.Drawing.Point(172, 33);
            this.sizeNum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sizeNum.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sizeNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sizeNum.Name = "sizeNum";
            this.sizeNum.Size = new System.Drawing.Size(125, 22);
            this.sizeNum.TabIndex = 11;
            this.sizeNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sizeNum.ValueChanged += new System.EventHandler(this.sizeNum_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(168, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Image Size";
            // 
            // AutoImageSizeCB
            // 
            this.AutoImageSizeCB.AutoSize = true;
            this.AutoImageSizeCB.Checked = true;
            this.AutoImageSizeCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AutoImageSizeCB.Location = new System.Drawing.Point(172, 63);
            this.AutoImageSizeCB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AutoImageSizeCB.Name = "AutoImageSizeCB";
            this.AutoImageSizeCB.Size = new System.Drawing.Size(56, 20);
            this.AutoImageSizeCB.TabIndex = 13;
            this.AutoImageSizeCB.Text = "Auto";
            this.AutoImageSizeCB.UseVisualStyleBackColor = true;
            this.AutoImageSizeCB.CheckedChanged += new System.EventHandler(this.AutoImageSizeCB_CheckedChanged);
            // 
            // ImageSaveParametresFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 254);
            this.Controls.Add(this.AutoImageSizeCB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.sizeNum);
            this.Controls.Add(this.drawInfoCB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.saveWorldStepNum);
            this.Controls.Add(this.viewMode4CB);
            this.Controls.Add(this.viewMode3CB);
            this.Controls.Add(this.viewMode2CB);
            this.Controls.Add(this.viewMode1CB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.saveImageStepNum);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ImageSaveParametresFrom";
            this.Text = "Save Parametres";
            this.Load += new System.EventHandler(this.ImageSaveParametresFrom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.saveImageStepNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saveWorldStepNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizeNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown saveImageStepNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox viewMode1CB;
        private System.Windows.Forms.CheckBox viewMode2CB;
        private System.Windows.Forms.CheckBox viewMode3CB;
        private System.Windows.Forms.CheckBox viewMode4CB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown saveWorldStepNum;
        private System.Windows.Forms.CheckBox drawInfoCB;
        private System.Windows.Forms.NumericUpDown sizeNum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox AutoImageSizeCB;
    }
}