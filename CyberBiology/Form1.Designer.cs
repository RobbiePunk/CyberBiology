namespace CyberBiology
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.WORLD_BOX = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.FPS_Scroll = new System.Windows.Forms.TrackBar();
            this.WorldSizeScroll = new System.Windows.Forms.TrackBar();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button9 = new System.Windows.Forms.Button();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.saveImagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveImagesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveWorldsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lacationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveParametresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.тестыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.worldSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.viewMode4 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.saveToTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFromTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.WORLD_BOX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FPS_Scroll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WorldSizeScroll)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // WORLD_BOX
            // 
            this.WORLD_BOX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.WORLD_BOX.InitialImage = null;
            this.WORLD_BOX.Location = new System.Drawing.Point(34, 26);
            this.WORLD_BOX.Name = "WORLD_BOX";
            this.WORLD_BOX.Size = new System.Drawing.Size(1193, 702);
            this.WORLD_BOX.TabIndex = 0;
            this.WORLD_BOX.TabStop = false;
            this.WORLD_BOX.Paint += new System.Windows.Forms.PaintEventHandler(this.WORLD_BOX_Paint);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1331, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 51);
            this.button1.TabIndex = 1;
            this.button1.Text = "Size+";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Size_plus);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1230, 28);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 51);
            this.button2.TabIndex = 2;
            this.button2.Text = "Size-";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.size_minus);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1230, 85);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(43, 60);
            this.button3.TabIndex = 3;
            this.button3.Text = "1";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.ViewMode1);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1230, 336);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(197, 60);
            this.button4.TabIndex = 4;
            this.button4.Text = "Save";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Save);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(1230, 191);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(194, 60);
            this.button5.TabIndex = 5;
            this.button5.Text = "Stop/Play";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Stop_Play);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(1230, 402);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(194, 60);
            this.button6.TabIndex = 6;
            this.button6.Text = "Load";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.Load_file);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "NewSave";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(1281, 85);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(43, 60);
            this.button7.TabIndex = 7;
            this.button7.Text = "2";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.ViewMode2);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(1331, 85);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(43, 60);
            this.button8.TabIndex = 8;
            this.button8.Text = "3";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.ViewMode3);
            // 
            // FPS_Scroll
            // 
            this.FPS_Scroll.Location = new System.Drawing.Point(1230, 611);
            this.FPS_Scroll.Maximum = 1000;
            this.FPS_Scroll.Minimum = 1;
            this.FPS_Scroll.Name = "FPS_Scroll";
            this.FPS_Scroll.Size = new System.Drawing.Size(194, 45);
            this.FPS_Scroll.TabIndex = 9;
            this.FPS_Scroll.Value = 100;
            this.FPS_Scroll.Visible = false;
            this.FPS_Scroll.Scroll += new System.EventHandler(this.ChangeFPS);
            // 
            // WorldSizeScroll
            // 
            this.WorldSizeScroll.Location = new System.Drawing.Point(1230, 514);
            this.WorldSizeScroll.Maximum = 5;
            this.WorldSizeScroll.Minimum = 1;
            this.WorldSizeScroll.Name = "WorldSizeScroll";
            this.WorldSizeScroll.Size = new System.Drawing.Size(197, 45);
            this.WorldSizeScroll.TabIndex = 10;
            this.WorldSizeScroll.Value = 1;
            this.WorldSizeScroll.Scroll += new System.EventHandler(this.WorldSizeChange);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1230, 580);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(194, 20);
            this.textBox1.TabIndex = 11;
            this.textBox1.Text = "Draw every 100 iteration";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(1230, 479);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(191, 20);
            this.textBox2.TabIndex = 12;
            this.textBox2.Text = "World Size";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox2.Click += new System.EventHandler(this.textBox2_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(1281, 693);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(94, 35);
            this.button9.TabIndex = 13;
            this.button9.Text = "New Simulate";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.NewSimulate);
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.LargeChange = 1;
            this.hScrollBar1.Location = new System.Drawing.Point(20, 749);
            this.hScrollBar1.Maximum = 0;
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(1253, 21);
            this.hScrollBar1.TabIndex = 14;
            this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.LargeChange = 1;
            this.vScrollBar1.Location = new System.Drawing.Point(10, 40);
            this.vScrollBar1.Maximum = 0;
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(21, 709);
            this.vScrollBar1.TabIndex = 15;
            this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveImagesToolStripMenuItem,
            this.тестыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1443, 24);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // saveImagesToolStripMenuItem
            // 
            this.saveImagesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveImagesToolStripMenuItem1,
            this.saveWorldsToolStripMenuItem,
            this.lacationToolStripMenuItem,
            this.saveParametresToolStripMenuItem,
            this.saveToTextToolStripMenuItem,
            this.loadFromTextToolStripMenuItem});
            this.saveImagesToolStripMenuItem.Name = "saveImagesToolStripMenuItem";
            this.saveImagesToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.saveImagesToolStripMenuItem.Text = "Saves";
            // 
            // saveImagesToolStripMenuItem1
            // 
            this.saveImagesToolStripMenuItem1.Name = "saveImagesToolStripMenuItem1";
            this.saveImagesToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.saveImagesToolStripMenuItem1.Text = "Save Images";
            this.saveImagesToolStripMenuItem1.Click += new System.EventHandler(this.saveImagesToolStripMenuItem1_Click);
            // 
            // saveWorldsToolStripMenuItem
            // 
            this.saveWorldsToolStripMenuItem.Name = "saveWorldsToolStripMenuItem";
            this.saveWorldsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveWorldsToolStripMenuItem.Text = "Save Worlds";
            this.saveWorldsToolStripMenuItem.Click += new System.EventHandler(this.saveWorldsToolStripMenuItem_Click);
            // 
            // lacationToolStripMenuItem
            // 
            this.lacationToolStripMenuItem.Name = "lacationToolStripMenuItem";
            this.lacationToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.lacationToolStripMenuItem.Text = "Lacation";
            this.lacationToolStripMenuItem.Click += new System.EventHandler(this.lacationToolStripMenuItem_Click);
            // 
            // saveParametresToolStripMenuItem
            // 
            this.saveParametresToolStripMenuItem.Name = "saveParametresToolStripMenuItem";
            this.saveParametresToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveParametresToolStripMenuItem.Text = "Save Parametres";
            this.saveParametresToolStripMenuItem.Click += new System.EventHandler(this.saveParametresToolStripMenuItem_Click);
            // 
            // тестыToolStripMenuItem
            // 
            this.тестыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.worldSettingsToolStripMenuItem});
            this.тестыToolStripMenuItem.Name = "тестыToolStripMenuItem";
            this.тестыToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.тестыToolStripMenuItem.Text = "Simulation";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem1.Text = "Performans Test";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // worldSettingsToolStripMenuItem
            // 
            this.worldSettingsToolStripMenuItem.Name = "worldSettingsToolStripMenuItem";
            this.worldSettingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.worldSettingsToolStripMenuItem.Text = "World Settings";
            this.worldSettingsToolStripMenuItem.Click += new System.EventHandler(this.worldSettingsToolStripMenuItem_Click);
            // 
            // viewMode4
            // 
            this.viewMode4.Location = new System.Drawing.Point(1381, 85);
            this.viewMode4.Name = "viewMode4";
            this.viewMode4.Size = new System.Drawing.Size(43, 60);
            this.viewMode4.TabIndex = 18;
            this.viewMode4.Text = "4";
            this.viewMode4.UseVisualStyleBackColor = true;
            this.viewMode4.Click += new System.EventHandler(this.viewMode4_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(1231, 257);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(194, 60);
            this.button10.TabIndex = 19;
            this.button10.Text = "Turn Off Drawing";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(1381, 152);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(43, 32);
            this.button11.TabIndex = 20;
            this.button11.Text = ">";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1228, 563);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "#####";
            // 
            // saveToTextToolStripMenuItem
            // 
            this.saveToTextToolStripMenuItem.Name = "saveToTextToolStripMenuItem";
            this.saveToTextToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToTextToolStripMenuItem.Text = "Save To Text";
            this.saveToTextToolStripMenuItem.Click += new System.EventHandler(this.saveToTextToolStripMenuItem_Click);
            // 
            // loadFromTextToolStripMenuItem
            // 
            this.loadFromTextToolStripMenuItem.Name = "loadFromTextToolStripMenuItem";
            this.loadFromTextToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadFromTextToolStripMenuItem.Text = "Load From Text";
            this.loadFromTextToolStripMenuItem.Click += new System.EventHandler(this.loadFromTextToolStripMenuItem_Click);
            // 
            // saveFileDialog2
            // 
            this.saveFileDialog2.DefaultExt = "txt";
            this.saveFileDialog2.FileName = "newSave";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1443, 777);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.viewMode4);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.WorldSizeScroll);
            this.Controls.Add(this.FPS_Scroll);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.WORLD_BOX);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Cyber Biology";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.WORLD_BOX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FPS_Scroll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WorldSizeScroll)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox WORLD_BOX;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.TrackBar FPS_Scroll;
        private System.Windows.Forms.TrackBar WorldSizeScroll;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem saveImagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lacationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveParametresToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ToolStripMenuItem тестыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveImagesToolStripMenuItem1;
        private System.Windows.Forms.Button viewMode4;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.ToolStripMenuItem saveWorldsToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem worldSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadFromTextToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog2;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
    }
}

