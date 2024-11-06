namespace CyberBiology2
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
            this.components = new System.ComponentModel.Container();
            this.WORLD_BOX = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
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
            this.lacationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveParametresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.тестыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.WORLD_BOX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FPS_Scroll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WorldSizeScroll)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // WORLD_BOX
            // 
            this.WORLD_BOX.InitialImage = null;
            this.WORLD_BOX.Location = new System.Drawing.Point(3, 34);
            this.WORLD_BOX.Margin = new System.Windows.Forms.Padding(4);
            this.WORLD_BOX.Name = "WORLD_BOX";
            this.WORLD_BOX.Size = new System.Drawing.Size(1920, 988);
            this.WORLD_BOX.TabIndex = 0;
            this.WORLD_BOX.TabStop = false;
            this.WORLD_BOX.Paint += new System.Windows.Forms.PaintEventHandler(this.WORLD_BOX_Paint);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1775, 34);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 63);
            this.button1.TabIndex = 1;
            this.button1.Text = "Size+";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Size_plus);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1640, 34);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(125, 63);
            this.button2.TabIndex = 2;
            this.button2.Text = "Size-";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.size_minus);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1640, 105);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(57, 74);
            this.button3.TabIndex = 3;
            this.button3.Text = "1";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.ViewMode1);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1640, 384);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(263, 74);
            this.button4.TabIndex = 4;
            this.button4.Text = "Save";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Save);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(1640, 203);
            this.button5.Margin = new System.Windows.Forms.Padding(4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(259, 74);
            this.button5.TabIndex = 5;
            this.button5.Text = "Stop/Play";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Stop_Play);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(1640, 481);
            this.button6.Margin = new System.Windows.Forms.Padding(4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(259, 74);
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
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(1740, 105);
            this.button7.Margin = new System.Windows.Forms.Padding(4);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(57, 74);
            this.button7.TabIndex = 7;
            this.button7.Text = "2";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.ViewMode2);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(1840, 105);
            this.button8.Margin = new System.Windows.Forms.Padding(4);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(57, 74);
            this.button8.TabIndex = 8;
            this.button8.Text = "3";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.ViewMode3);
            // 
            // FPS_Scroll
            // 
            this.FPS_Scroll.Location = new System.Drawing.Point(1640, 321);
            this.FPS_Scroll.Margin = new System.Windows.Forms.Padding(4);
            this.FPS_Scroll.Maximum = 1000;
            this.FPS_Scroll.Minimum = 10;
            this.FPS_Scroll.Name = "FPS_Scroll";
            this.FPS_Scroll.Size = new System.Drawing.Size(259, 56);
            this.FPS_Scroll.TabIndex = 9;
            this.FPS_Scroll.Value = 10;
            this.FPS_Scroll.Scroll += new System.EventHandler(this.ChangeFPS);
            // 
            // WorldSizeScroll
            // 
            this.WorldSizeScroll.Location = new System.Drawing.Point(1640, 633);
            this.WorldSizeScroll.Margin = new System.Windows.Forms.Padding(4);
            this.WorldSizeScroll.Maximum = 5;
            this.WorldSizeScroll.Minimum = 1;
            this.WorldSizeScroll.Name = "WorldSizeScroll";
            this.WorldSizeScroll.Size = new System.Drawing.Size(263, 56);
            this.WorldSizeScroll.TabIndex = 10;
            this.WorldSizeScroll.Value = 1;
            this.WorldSizeScroll.Scroll += new System.EventHandler(this.WorldSizeChange);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1640, 289);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(257, 22);
            this.textBox1.TabIndex = 11;
            this.textBox1.Text = "FPS Control";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(1640, 590);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(253, 22);
            this.textBox2.TabIndex = 12;
            this.textBox2.Text = "World Size";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(1740, 900);
            this.button9.Margin = new System.Windows.Forms.Padding(4);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(125, 43);
            this.button9.TabIndex = 13;
            this.button9.Text = "New Simulate";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.NewSimulate);
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.LargeChange = 1;
            this.hScrollBar1.Location = new System.Drawing.Point(26, 922);
            this.hScrollBar1.Maximum = 0;
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(1671, 21);
            this.hScrollBar1.TabIndex = 14;
            this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.LargeChange = 1;
            this.vScrollBar1.Location = new System.Drawing.Point(13, 49);
            this.vScrollBar1.Maximum = 0;
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(21, 873);
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
            this.menuStrip1.Size = new System.Drawing.Size(1924, 28);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // saveImagesToolStripMenuItem
            // 
            this.saveImagesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lacationToolStripMenuItem,
            this.saveParametresToolStripMenuItem});
            this.saveImagesToolStripMenuItem.Name = "saveImagesToolStripMenuItem";
            this.saveImagesToolStripMenuItem.Size = new System.Drawing.Size(106, 24);
            this.saveImagesToolStripMenuItem.Text = "Save Images";
            // 
            // lacationToolStripMenuItem
            // 
            this.lacationToolStripMenuItem.Name = "lacationToolStripMenuItem";
            this.lacationToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.lacationToolStripMenuItem.Text = "Lacation";
            this.lacationToolStripMenuItem.Click += new System.EventHandler(this.lacationToolStripMenuItem_Click);
            // 
            // saveParametresToolStripMenuItem
            // 
            this.saveParametresToolStripMenuItem.Name = "saveParametresToolStripMenuItem";
            this.saveParametresToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.saveParametresToolStripMenuItem.Text = "Save Parametres";
            // 
            // тестыToolStripMenuItem
            // 
            this.тестыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.тестыToolStripMenuItem.Name = "тестыToolStripMenuItem";
            this.тестыToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.тестыToolStripMenuItem.Text = "Tests";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(196, 26);
            this.toolStripMenuItem1.Text = "Performans Test";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1924, 956);
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
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Cyeber Biology";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintWorld);
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
        public System.Windows.Forms.Timer timer1;
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
    }
}

