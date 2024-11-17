﻿namespace CyberBiology
{
    partial class WorldSettingsForm
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
            this.xSizeTB = new System.Windows.Forms.MaskedTextBox();
            this.ySizeTB = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ApplyBT = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.MTE_Num = new System.Windows.Forms.NumericUpDown();
            this.ETM_Num = new System.Windows.Forms.NumericUpDown();
            this.ETL_Num = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.setDefBT = new System.Windows.Forms.Button();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MTE_Num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ETM_Num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ETL_Num)).BeginInit();
            this.SuspendLayout();
            // 
            // xSizeTB
            // 
            this.xSizeTB.Location = new System.Drawing.Point(20, 26);
            this.xSizeTB.Margin = new System.Windows.Forms.Padding(2);
            this.xSizeTB.Mask = "00000";
            this.xSizeTB.Name = "xSizeTB";
            this.xSizeTB.PromptChar = ' ';
            this.xSizeTB.Size = new System.Drawing.Size(76, 20);
            this.xSizeTB.TabIndex = 0;
            this.xSizeTB.ValidatingType = typeof(int);
            // 
            // ySizeTB
            // 
            this.ySizeTB.Location = new System.Drawing.Point(21, 59);
            this.ySizeTB.Margin = new System.Windows.Forms.Padding(2);
            this.ySizeTB.Mask = "00000";
            this.ySizeTB.Name = "ySizeTB";
            this.ySizeTB.PromptChar = ' ';
            this.ySizeTB.Size = new System.Drawing.Size(76, 20);
            this.ySizeTB.TabIndex = 1;
            this.ySizeTB.ValidatingType = typeof(int);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 64);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 7);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "World Size";
            // 
            // ApplyBT
            // 
            this.ApplyBT.Location = new System.Drawing.Point(329, 228);
            this.ApplyBT.Margin = new System.Windows.Forms.Padding(2);
            this.ApplyBT.Name = "ApplyBT";
            this.ApplyBT.Size = new System.Drawing.Size(64, 28);
            this.ApplyBT.TabIndex = 5;
            this.ApplyBT.Text = "Apply";
            this.ApplyBT.UseVisualStyleBackColor = true;
            this.ApplyBT.Click += new System.EventHandler(this.ApplyBT_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(326, 29);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(67, 17);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "Pressure";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(138, 26);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 7;
            this.numericUpDown1.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(135, 7);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Mutation Chance";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(135, 48);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Seed";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(138, 64);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(120, 20);
            this.textBox1.TabIndex = 11;
            // 
            // MTE_Num
            // 
            this.MTE_Num.Location = new System.Drawing.Point(138, 154);
            this.MTE_Num.Name = "MTE_Num";
            this.MTE_Num.Size = new System.Drawing.Size(120, 20);
            this.MTE_Num.TabIndex = 12;
            // 
            // ETM_Num
            // 
            this.ETM_Num.Location = new System.Drawing.Point(138, 111);
            this.ETM_Num.Name = "ETM_Num";
            this.ETM_Num.Size = new System.Drawing.Size(120, 20);
            this.ETM_Num.TabIndex = 13;
            this.ETM_Num.ValueChanged += new System.EventHandler(this.ETM_Num_ValueChanged);
            // 
            // ETL_Num
            // 
            this.ETL_Num.Location = new System.Drawing.Point(138, 194);
            this.ETL_Num.Name = "ETL_Num";
            this.ETL_Num.Size = new System.Drawing.Size(120, 20);
            this.ETL_Num.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(135, 95);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Energy To Move";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(137, 138);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Mineral To Energy";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(137, 178);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Energy To Live";
            // 
            // setDefBT
            // 
            this.setDefBT.Location = new System.Drawing.Point(11, 228);
            this.setDefBT.Margin = new System.Windows.Forms.Padding(2);
            this.setDefBT.Name = "setDefBT";
            this.setDefBT.Size = new System.Drawing.Size(64, 28);
            this.setDefBT.TabIndex = 18;
            this.setDefBT.Text = "Default";
            this.setDefBT.UseVisualStyleBackColor = true;
            this.setDefBT.Click += new System.EventHandler(this.setDefBT_Click);
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(20, 111);
            this.maskedTextBox1.Margin = new System.Windows.Forms.Padding(2);
            this.maskedTextBox1.Mask = "0000000";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.PromptChar = ' ';
            this.maskedTextBox1.Size = new System.Drawing.Size(76, 20);
            this.maskedTextBox1.TabIndex = 19;
            this.maskedTextBox1.ValidatingType = typeof(int);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 95);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Season Time";
            // 
            // WorldSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 265);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.setDefBT);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ETL_Num);
            this.Controls.Add(this.ETM_Num);
            this.Controls.Add(this.MTE_Num);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.ApplyBT);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ySizeTB);
            this.Controls.Add(this.xSizeTB);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "WorldSettingsForm";
            this.Text = "World Settings";
            this.Load += new System.EventHandler(this.WorldSettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MTE_Num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ETM_Num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ETL_Num)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox xSizeTB;
        private System.Windows.Forms.MaskedTextBox ySizeTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ApplyBT;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.NumericUpDown MTE_Num;
        private System.Windows.Forms.NumericUpDown ETM_Num;
        private System.Windows.Forms.NumericUpDown ETL_Num;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button setDefBT;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Label label9;
    }
}