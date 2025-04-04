namespace CyberBiology
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
            this.worldSizeLB = new System.Windows.Forms.Label();
            this.applyBT = new System.Windows.Forms.Button();
            this.pressureCB = new System.Windows.Forms.CheckBox();
            this.mutationChanceNum = new System.Windows.Forms.NumericUpDown();
            this.mutationChanceLB = new System.Windows.Forms.Label();
            this.seedLB = new System.Windows.Forms.Label();
            this.seedNum = new System.Windows.Forms.TextBox();
            this.MTE_Num = new System.Windows.Forms.NumericUpDown();
            this.ETM_Num = new System.Windows.Forms.NumericUpDown();
            this.ETL_Num = new System.Windows.Forms.NumericUpDown();
            this.ETM_LB = new System.Windows.Forms.Label();
            this.MTE_LB = new System.Windows.Forms.Label();
            this.ETL_LB = new System.Windows.Forms.Label();
            this.setDefBT = new System.Windows.Forms.Button();
            this.seasonTimeTB = new System.Windows.Forms.MaskedTextBox();
            this.seasonTimeLB = new System.Windows.Forms.Label();
            this.seasonsStringUD = new System.Windows.Forms.DomainUpDown();
            this.seasonsLB = new System.Windows.Forms.Label();
            this.SeasonsNum = new System.Windows.Forms.NumericUpDown();
            this.autoDivideCB = new System.Windows.Forms.CheckBox();
            this.agingMutationCB = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.agingFactorNUD = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.mutationChanceNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MTE_Num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ETM_Num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ETL_Num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SeasonsNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.agingFactorNUD)).BeginInit();
            this.SuspendLayout();
            // 
            // xSizeTB
            // 
            this.xSizeTB.Location = new System.Drawing.Point(27, 32);
            this.xSizeTB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.xSizeTB.Mask = "00000";
            this.xSizeTB.Name = "xSizeTB";
            this.xSizeTB.PromptChar = ' ';
            this.xSizeTB.Size = new System.Drawing.Size(100, 22);
            this.xSizeTB.TabIndex = 0;
            this.xSizeTB.ValidatingType = typeof(int);
            // 
            // ySizeTB
            // 
            this.ySizeTB.Location = new System.Drawing.Point(28, 73);
            this.ySizeTB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ySizeTB.Mask = "00000";
            this.ySizeTB.Name = "ySizeTB";
            this.ySizeTB.PromptChar = ' ';
            this.ySizeTB.Size = new System.Drawing.Size(100, 22);
            this.ySizeTB.TabIndex = 1;
            this.ySizeTB.ValidatingType = typeof(int);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Y";
            // 
            // worldSizeLB
            // 
            this.worldSizeLB.AutoSize = true;
            this.worldSizeLB.Location = new System.Drawing.Point(24, 9);
            this.worldSizeLB.Name = "worldSizeLB";
            this.worldSizeLB.Size = new System.Drawing.Size(72, 16);
            this.worldSizeLB.TabIndex = 4;
            this.worldSizeLB.Text = "World Size";
            // 
            // applyBT
            // 
            this.applyBT.Location = new System.Drawing.Point(439, 290);
            this.applyBT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.applyBT.Name = "applyBT";
            this.applyBT.Size = new System.Drawing.Size(85, 34);
            this.applyBT.TabIndex = 5;
            this.applyBT.Text = "Apply";
            this.applyBT.UseVisualStyleBackColor = true;
            this.applyBT.Click += new System.EventHandler(this.ApplyBT_Click);
            // 
            // pressureCB
            // 
            this.pressureCB.AutoSize = true;
            this.pressureCB.Location = new System.Drawing.Point(435, 36);
            this.pressureCB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pressureCB.Name = "pressureCB";
            this.pressureCB.Size = new System.Drawing.Size(83, 20);
            this.pressureCB.TabIndex = 6;
            this.pressureCB.Text = "Pressure";
            this.pressureCB.UseVisualStyleBackColor = true;
            // 
            // mutationChanceNum
            // 
            this.mutationChanceNum.Location = new System.Drawing.Point(184, 32);
            this.mutationChanceNum.Margin = new System.Windows.Forms.Padding(4);
            this.mutationChanceNum.Name = "mutationChanceNum";
            this.mutationChanceNum.Size = new System.Drawing.Size(160, 22);
            this.mutationChanceNum.TabIndex = 7;
            this.mutationChanceNum.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // mutationChanceLB
            // 
            this.mutationChanceLB.AutoSize = true;
            this.mutationChanceLB.Location = new System.Drawing.Point(180, 9);
            this.mutationChanceLB.Name = "mutationChanceLB";
            this.mutationChanceLB.Size = new System.Drawing.Size(106, 16);
            this.mutationChanceLB.TabIndex = 8;
            this.mutationChanceLB.Text = "Mutation Chance";
            // 
            // seedLB
            // 
            this.seedLB.AutoSize = true;
            this.seedLB.Location = new System.Drawing.Point(180, 59);
            this.seedLB.Name = "seedLB";
            this.seedLB.Size = new System.Drawing.Size(40, 16);
            this.seedLB.TabIndex = 10;
            this.seedLB.Text = "Seed";
            // 
            // seedNum
            // 
            this.seedNum.Location = new System.Drawing.Point(184, 79);
            this.seedNum.Margin = new System.Windows.Forms.Padding(4);
            this.seedNum.Name = "seedNum";
            this.seedNum.Size = new System.Drawing.Size(159, 22);
            this.seedNum.TabIndex = 11;
            // 
            // MTE_Num
            // 
            this.MTE_Num.Location = new System.Drawing.Point(184, 190);
            this.MTE_Num.Margin = new System.Windows.Forms.Padding(4);
            this.MTE_Num.Name = "MTE_Num";
            this.MTE_Num.Size = new System.Drawing.Size(160, 22);
            this.MTE_Num.TabIndex = 12;
            // 
            // ETM_Num
            // 
            this.ETM_Num.Location = new System.Drawing.Point(184, 137);
            this.ETM_Num.Margin = new System.Windows.Forms.Padding(4);
            this.ETM_Num.Name = "ETM_Num";
            this.ETM_Num.Size = new System.Drawing.Size(160, 22);
            this.ETM_Num.TabIndex = 13;
            // 
            // ETL_Num
            // 
            this.ETL_Num.Location = new System.Drawing.Point(184, 239);
            this.ETL_Num.Margin = new System.Windows.Forms.Padding(4);
            this.ETL_Num.Name = "ETL_Num";
            this.ETL_Num.Size = new System.Drawing.Size(160, 22);
            this.ETL_Num.TabIndex = 14;
            // 
            // ETM_LB
            // 
            this.ETM_LB.AutoSize = true;
            this.ETM_LB.Location = new System.Drawing.Point(180, 117);
            this.ETM_LB.Name = "ETM_LB";
            this.ETM_LB.Size = new System.Drawing.Size(107, 16);
            this.ETM_LB.TabIndex = 15;
            this.ETM_LB.Text = "Energy To Move";
            // 
            // MTE_LB
            // 
            this.MTE_LB.AutoSize = true;
            this.MTE_LB.Location = new System.Drawing.Point(183, 170);
            this.MTE_LB.Name = "MTE_LB";
            this.MTE_LB.Size = new System.Drawing.Size(117, 16);
            this.MTE_LB.TabIndex = 16;
            this.MTE_LB.Text = "Mineral To Energy";
            // 
            // ETL_LB
            // 
            this.ETL_LB.AutoSize = true;
            this.ETL_LB.Location = new System.Drawing.Point(183, 219);
            this.ETL_LB.Name = "ETL_LB";
            this.ETL_LB.Size = new System.Drawing.Size(98, 16);
            this.ETL_LB.TabIndex = 17;
            this.ETL_LB.Text = "Energy To Live";
            // 
            // setDefBT
            // 
            this.setDefBT.Location = new System.Drawing.Point(15, 290);
            this.setDefBT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.setDefBT.Name = "setDefBT";
            this.setDefBT.Size = new System.Drawing.Size(85, 34);
            this.setDefBT.TabIndex = 18;
            this.setDefBT.Text = "Default";
            this.setDefBT.UseVisualStyleBackColor = true;
            this.setDefBT.Click += new System.EventHandler(this.setDefBT_Click);
            // 
            // seasonTimeTB
            // 
            this.seasonTimeTB.Location = new System.Drawing.Point(27, 137);
            this.seasonTimeTB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.seasonTimeTB.Mask = "0000000";
            this.seasonTimeTB.Name = "seasonTimeTB";
            this.seasonTimeTB.PromptChar = ' ';
            this.seasonTimeTB.Size = new System.Drawing.Size(100, 22);
            this.seasonTimeTB.TabIndex = 19;
            this.seasonTimeTB.ValidatingType = typeof(int);
            // 
            // seasonTimeLB
            // 
            this.seasonTimeLB.AutoSize = true;
            this.seasonTimeLB.Location = new System.Drawing.Point(24, 117);
            this.seasonTimeLB.Name = "seasonTimeLB";
            this.seasonTimeLB.Size = new System.Drawing.Size(88, 16);
            this.seasonTimeLB.TabIndex = 20;
            this.seasonTimeLB.Text = "Season Time";
            // 
            // seasonsStringUD
            // 
            this.seasonsStringUD.Items.Add("Summer");
            this.seasonsStringUD.Items.Add("Autumn");
            this.seasonsStringUD.Items.Add("Winter");
            this.seasonsStringUD.Items.Add("Spring");
            this.seasonsStringUD.Location = new System.Drawing.Point(183, 290);
            this.seasonsStringUD.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.seasonsStringUD.Name = "seasonsStringUD";
            this.seasonsStringUD.ReadOnly = true;
            this.seasonsStringUD.Size = new System.Drawing.Size(80, 22);
            this.seasonsStringUD.TabIndex = 21;
            this.seasonsStringUD.Text = "Summer";
            this.seasonsStringUD.SelectedItemChanged += new System.EventHandler(this.SeasonsUD_SelectedItemChanged);
            // 
            // seasonsLB
            // 
            this.seasonsLB.AutoSize = true;
            this.seasonsLB.Location = new System.Drawing.Point(183, 271);
            this.seasonsLB.Name = "seasonsLB";
            this.seasonsLB.Size = new System.Drawing.Size(61, 16);
            this.seasonsLB.TabIndex = 22;
            this.seasonsLB.Text = "Seasons";
            // 
            // SeasonsNum
            // 
            this.SeasonsNum.Location = new System.Drawing.Point(272, 290);
            this.SeasonsNum.Margin = new System.Windows.Forms.Padding(4);
            this.SeasonsNum.Name = "SeasonsNum";
            this.SeasonsNum.Size = new System.Drawing.Size(72, 22);
            this.SeasonsNum.TabIndex = 23;
            this.SeasonsNum.ValueChanged += new System.EventHandler(this.SeasonsNum_ValueChanged);
            // 
            // autoDivideCB
            // 
            this.autoDivideCB.AutoSize = true;
            this.autoDivideCB.Checked = true;
            this.autoDivideCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoDivideCB.Location = new System.Drawing.Point(435, 73);
            this.autoDivideCB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.autoDivideCB.Name = "autoDivideCB";
            this.autoDivideCB.Size = new System.Drawing.Size(98, 20);
            this.autoDivideCB.TabIndex = 24;
            this.autoDivideCB.Text = "Auto Divide";
            this.autoDivideCB.UseVisualStyleBackColor = true;
            this.autoDivideCB.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // agingMutationCB
            // 
            this.agingMutationCB.AutoSize = true;
            this.agingMutationCB.Checked = true;
            this.agingMutationCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.agingMutationCB.Location = new System.Drawing.Point(435, 113);
            this.agingMutationCB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.agingMutationCB.Name = "agingMutationCB";
            this.agingMutationCB.Size = new System.Drawing.Size(117, 20);
            this.agingMutationCB.TabIndex = 25;
            this.agingMutationCB.Text = "Aging Mutation";
            this.agingMutationCB.UseVisualStyleBackColor = true;
            this.agingMutationCB.CheckedChanged += new System.EventHandler(this.agingMutationCB_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(432, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 16);
            this.label3.TabIndex = 26;
            this.label3.Text = "Aging Factor";
            // 
            // agingFactorNUD
            // 
            this.agingFactorNUD.Location = new System.Drawing.Point(435, 170);
            this.agingFactorNUD.Margin = new System.Windows.Forms.Padding(4);
            this.agingFactorNUD.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.agingFactorNUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.agingFactorNUD.Name = "agingFactorNUD";
            this.agingFactorNUD.Size = new System.Drawing.Size(99, 22);
            this.agingFactorNUD.TabIndex = 27;
            this.agingFactorNUD.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // WorldSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 334);
            this.Controls.Add(this.agingFactorNUD);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.agingMutationCB);
            this.Controls.Add(this.autoDivideCB);
            this.Controls.Add(this.SeasonsNum);
            this.Controls.Add(this.seasonsLB);
            this.Controls.Add(this.seasonsStringUD);
            this.Controls.Add(this.seasonTimeLB);
            this.Controls.Add(this.seasonTimeTB);
            this.Controls.Add(this.setDefBT);
            this.Controls.Add(this.ETL_LB);
            this.Controls.Add(this.MTE_LB);
            this.Controls.Add(this.ETM_LB);
            this.Controls.Add(this.ETL_Num);
            this.Controls.Add(this.ETM_Num);
            this.Controls.Add(this.MTE_Num);
            this.Controls.Add(this.seedNum);
            this.Controls.Add(this.seedLB);
            this.Controls.Add(this.mutationChanceLB);
            this.Controls.Add(this.mutationChanceNum);
            this.Controls.Add(this.pressureCB);
            this.Controls.Add(this.applyBT);
            this.Controls.Add(this.worldSizeLB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ySizeTB);
            this.Controls.Add(this.xSizeTB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "WorldSettingsForm";
            this.Text = "World Settings";
            this.Load += new System.EventHandler(this.WorldSettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mutationChanceNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MTE_Num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ETM_Num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ETL_Num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SeasonsNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.agingFactorNUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox xSizeTB;
        private System.Windows.Forms.MaskedTextBox ySizeTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label worldSizeLB;
        private System.Windows.Forms.Button applyBT;
        private System.Windows.Forms.CheckBox pressureCB;
        private System.Windows.Forms.NumericUpDown mutationChanceNum;
        private System.Windows.Forms.Label mutationChanceLB;
        private System.Windows.Forms.Label seedLB;
        private System.Windows.Forms.TextBox seedNum;
        private System.Windows.Forms.NumericUpDown MTE_Num;
        private System.Windows.Forms.NumericUpDown ETM_Num;
        private System.Windows.Forms.NumericUpDown ETL_Num;
        private System.Windows.Forms.Label ETM_LB;
        private System.Windows.Forms.Label MTE_LB;
        private System.Windows.Forms.Label ETL_LB;
        private System.Windows.Forms.Button setDefBT;
        private System.Windows.Forms.MaskedTextBox seasonTimeTB;
        private System.Windows.Forms.Label seasonTimeLB;
        private System.Windows.Forms.DomainUpDown seasonsStringUD;
        private System.Windows.Forms.Label seasonsLB;
        private System.Windows.Forms.NumericUpDown SeasonsNum;
        private System.Windows.Forms.CheckBox autoDivideCB;
        private System.Windows.Forms.CheckBox agingMutationCB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown agingFactorNUD;
    }
}