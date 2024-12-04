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
            this.plusSizeBT = new System.Windows.Forms.Button();
            this.minusSizeBT = new System.Windows.Forms.Button();
            this.viewMode1BT = new System.Windows.Forms.Button();
            this.saveWorldBT = new System.Windows.Forms.Button();
            this.stopPlayBT = new System.Windows.Forms.Button();
            this.loadWorldBT = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.viewMode2BT = new System.Windows.Forms.Button();
            this.viewMode3BT = new System.Windows.Forms.Button();
            this.worldSizeScroll = new System.Windows.Forms.TrackBar();
            this.worldSizeTB = new System.Windows.Forms.TextBox();
            this.newSimulationBT = new System.Windows.Forms.Button();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.saveImagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveImagesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveWorldsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lacationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveParametresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFromTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.тестыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.perfomanceTestMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.worldSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveDrawToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearAllWallsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.viewMode4 = new System.Windows.Forms.Button();
            this.turnDrawingBT = new System.Windows.Forms.Button();
            this.oneStepBT = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.randomGenomeCB = new System.Windows.Forms.CheckBox();
            this.addCellBT = new System.Windows.Forms.Button();
            this.addWallBT = new System.Windows.Forms.Button();
            this.eraseCellBT = new System.Windows.Forms.Button();
            this.WORLD_BOX = new System.Windows.Forms.PictureBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.CellColorBT = new System.Windows.Forms.Button();
            this.viewMode5 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.worldSizeScroll)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WORLD_BOX)).BeginInit();
            this.SuspendLayout();
            // 
            // plusSizeBT
            // 
            this.plusSizeBT.Location = new System.Drawing.Point(1775, 34);
            this.plusSizeBT.Margin = new System.Windows.Forms.Padding(4);
            this.plusSizeBT.Name = "plusSizeBT";
            this.plusSizeBT.Size = new System.Drawing.Size(125, 63);
            this.plusSizeBT.TabIndex = 1;
            this.plusSizeBT.Text = "Size+";
            this.plusSizeBT.UseVisualStyleBackColor = true;
            this.plusSizeBT.Click += new System.EventHandler(this.Size_plus);
            // 
            // minusSizeBT
            // 
            this.minusSizeBT.Location = new System.Drawing.Point(1640, 34);
            this.minusSizeBT.Margin = new System.Windows.Forms.Padding(4);
            this.minusSizeBT.Name = "minusSizeBT";
            this.minusSizeBT.Size = new System.Drawing.Size(125, 63);
            this.minusSizeBT.TabIndex = 2;
            this.minusSizeBT.Text = "Size-";
            this.minusSizeBT.UseVisualStyleBackColor = true;
            this.minusSizeBT.Click += new System.EventHandler(this.Size_minus);
            // 
            // viewMode1BT
            // 
            this.viewMode1BT.Location = new System.Drawing.Point(1640, 105);
            this.viewMode1BT.Margin = new System.Windows.Forms.Padding(4);
            this.viewMode1BT.Name = "viewMode1BT";
            this.viewMode1BT.Size = new System.Drawing.Size(57, 74);
            this.viewMode1BT.TabIndex = 3;
            this.viewMode1BT.Text = "1";
            this.viewMode1BT.UseVisualStyleBackColor = true;
            this.viewMode1BT.Click += new System.EventHandler(this.TurnViewMode1);
            // 
            // saveWorldBT
            // 
            this.saveWorldBT.Location = new System.Drawing.Point(1641, 533);
            this.saveWorldBT.Margin = new System.Windows.Forms.Padding(4);
            this.saveWorldBT.Name = "saveWorldBT";
            this.saveWorldBT.Size = new System.Drawing.Size(263, 74);
            this.saveWorldBT.TabIndex = 4;
            this.saveWorldBT.Text = "Save";
            this.saveWorldBT.UseVisualStyleBackColor = true;
            this.saveWorldBT.Click += new System.EventHandler(this.Save);
            // 
            // stopPlayBT
            // 
            this.stopPlayBT.Location = new System.Drawing.Point(1641, 354);
            this.stopPlayBT.Margin = new System.Windows.Forms.Padding(4);
            this.stopPlayBT.Name = "stopPlayBT";
            this.stopPlayBT.Size = new System.Drawing.Size(259, 74);
            this.stopPlayBT.TabIndex = 5;
            this.stopPlayBT.Text = "Stop/Play";
            this.stopPlayBT.UseVisualStyleBackColor = true;
            this.stopPlayBT.Click += new System.EventHandler(this.Stop_Play);
            // 
            // loadWorldBT
            // 
            this.loadWorldBT.Location = new System.Drawing.Point(1641, 614);
            this.loadWorldBT.Margin = new System.Windows.Forms.Padding(4);
            this.loadWorldBT.Name = "loadWorldBT";
            this.loadWorldBT.Size = new System.Drawing.Size(259, 74);
            this.loadWorldBT.TabIndex = 6;
            this.loadWorldBT.Text = "Load";
            this.loadWorldBT.UseVisualStyleBackColor = true;
            this.loadWorldBT.Click += new System.EventHandler(this.Load_file);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "NewSave";
            // 
            // viewMode2BT
            // 
            this.viewMode2BT.Location = new System.Drawing.Point(1708, 105);
            this.viewMode2BT.Margin = new System.Windows.Forms.Padding(4);
            this.viewMode2BT.Name = "viewMode2BT";
            this.viewMode2BT.Size = new System.Drawing.Size(57, 74);
            this.viewMode2BT.TabIndex = 7;
            this.viewMode2BT.Text = "2";
            this.viewMode2BT.UseVisualStyleBackColor = true;
            this.viewMode2BT.Click += new System.EventHandler(this.TurnViewMode2);
            // 
            // viewMode3BT
            // 
            this.viewMode3BT.Location = new System.Drawing.Point(1775, 105);
            this.viewMode3BT.Margin = new System.Windows.Forms.Padding(4);
            this.viewMode3BT.Name = "viewMode3BT";
            this.viewMode3BT.Size = new System.Drawing.Size(57, 74);
            this.viewMode3BT.TabIndex = 8;
            this.viewMode3BT.Text = "3";
            this.viewMode3BT.UseVisualStyleBackColor = true;
            this.viewMode3BT.Click += new System.EventHandler(this.TurnViewMode3);
            // 
            // worldSizeScroll
            // 
            this.worldSizeScroll.Location = new System.Drawing.Point(1641, 752);
            this.worldSizeScroll.Margin = new System.Windows.Forms.Padding(4);
            this.worldSizeScroll.Maximum = 5;
            this.worldSizeScroll.Minimum = 1;
            this.worldSizeScroll.Name = "worldSizeScroll";
            this.worldSizeScroll.Size = new System.Drawing.Size(263, 56);
            this.worldSizeScroll.TabIndex = 10;
            this.worldSizeScroll.Value = 1;
            this.worldSizeScroll.Scroll += new System.EventHandler(this.ChangeWorldSize);
            // 
            // worldSizeTB
            // 
            this.worldSizeTB.Location = new System.Drawing.Point(1641, 709);
            this.worldSizeTB.Margin = new System.Windows.Forms.Padding(4);
            this.worldSizeTB.Name = "worldSizeTB";
            this.worldSizeTB.ReadOnly = true;
            this.worldSizeTB.Size = new System.Drawing.Size(253, 22);
            this.worldSizeTB.TabIndex = 12;
            this.worldSizeTB.Text = "World Size";
            this.worldSizeTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // newSimulationBT
            // 
            this.newSimulationBT.Location = new System.Drawing.Point(1708, 853);
            this.newSimulationBT.Margin = new System.Windows.Forms.Padding(4);
            this.newSimulationBT.Name = "newSimulationBT";
            this.newSimulationBT.Size = new System.Drawing.Size(125, 43);
            this.newSimulationBT.TabIndex = 13;
            this.newSimulationBT.Text = "New Simulate";
            this.newSimulationBT.UseVisualStyleBackColor = true;
            this.newSimulationBT.Click += new System.EventHandler(this.NewSimulation);
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.LargeChange = 1;
            this.hScrollBar1.Location = new System.Drawing.Point(27, 922);
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
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1924, 28);
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
            this.saveImagesToolStripMenuItem.Size = new System.Drawing.Size(60, 26);
            this.saveImagesToolStripMenuItem.Text = "Saves";
            // 
            // saveImagesToolStripMenuItem1
            // 
            this.saveImagesToolStripMenuItem1.CheckOnClick = true;
            this.saveImagesToolStripMenuItem1.Name = "saveImagesToolStripMenuItem1";
            this.saveImagesToolStripMenuItem1.Size = new System.Drawing.Size(200, 26);
            this.saveImagesToolStripMenuItem1.Text = "Save Images";
            this.saveImagesToolStripMenuItem1.Click += new System.EventHandler(this.TurnImagesSaving);
            // 
            // saveWorldsToolStripMenuItem
            // 
            this.saveWorldsToolStripMenuItem.CheckOnClick = true;
            this.saveWorldsToolStripMenuItem.Name = "saveWorldsToolStripMenuItem";
            this.saveWorldsToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.saveWorldsToolStripMenuItem.Text = "Save Worlds";
            this.saveWorldsToolStripMenuItem.Click += new System.EventHandler(this.TurnWorldSaving);
            // 
            // lacationToolStripMenuItem
            // 
            this.lacationToolStripMenuItem.Name = "lacationToolStripMenuItem";
            this.lacationToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.lacationToolStripMenuItem.Text = "Lacation";
            this.lacationToolStripMenuItem.Click += new System.EventHandler(this.ChangeImageSavePath);
            // 
            // saveParametresToolStripMenuItem
            // 
            this.saveParametresToolStripMenuItem.Name = "saveParametresToolStripMenuItem";
            this.saveParametresToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.saveParametresToolStripMenuItem.Text = "Save Parametres";
            this.saveParametresToolStripMenuItem.Click += new System.EventHandler(this.ShowImageSaveParametresWindow);
            // 
            // saveToTextToolStripMenuItem
            // 
            this.saveToTextToolStripMenuItem.Name = "saveToTextToolStripMenuItem";
            this.saveToTextToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.saveToTextToolStripMenuItem.Text = "Save To Text";
            this.saveToTextToolStripMenuItem.Click += new System.EventHandler(this.SaveToText);
            // 
            // loadFromTextToolStripMenuItem
            // 
            this.loadFromTextToolStripMenuItem.Name = "loadFromTextToolStripMenuItem";
            this.loadFromTextToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.loadFromTextToolStripMenuItem.Text = "Load From Text";
            this.loadFromTextToolStripMenuItem.Click += new System.EventHandler(this.LoadFromText);
            // 
            // тестыToolStripMenuItem
            // 
            this.тестыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.perfomanceTestMenuItem,
            this.worldSettingsToolStripMenuItem,
            this.saveDrawToolStripMenuItem,
            this.clearAllWallsToolStripMenuItem});
            this.тестыToolStripMenuItem.Name = "тестыToolStripMenuItem";
            this.тестыToolStripMenuItem.Size = new System.Drawing.Size(94, 26);
            this.тестыToolStripMenuItem.Text = "Simulation";
            // 
            // perfomanceTestMenuItem
            // 
            this.perfomanceTestMenuItem.CheckOnClick = true;
            this.perfomanceTestMenuItem.Name = "perfomanceTestMenuItem";
            this.perfomanceTestMenuItem.Size = new System.Drawing.Size(196, 26);
            this.perfomanceTestMenuItem.Text = "Performans Test";
            this.perfomanceTestMenuItem.Click += new System.EventHandler(this.PerfomanceTest_Click);
            // 
            // worldSettingsToolStripMenuItem
            // 
            this.worldSettingsToolStripMenuItem.Name = "worldSettingsToolStripMenuItem";
            this.worldSettingsToolStripMenuItem.Size = new System.Drawing.Size(196, 26);
            this.worldSettingsToolStripMenuItem.Text = "World Settings";
            this.worldSettingsToolStripMenuItem.Click += new System.EventHandler(this.ShowWorldSettingsWindow);
            // 
            // saveDrawToolStripMenuItem
            // 
            this.saveDrawToolStripMenuItem.Checked = true;
            this.saveDrawToolStripMenuItem.CheckOnClick = true;
            this.saveDrawToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.saveDrawToolStripMenuItem.Name = "saveDrawToolStripMenuItem";
            this.saveDrawToolStripMenuItem.Size = new System.Drawing.Size(196, 26);
            this.saveDrawToolStripMenuItem.Text = "Save Drawing";
            this.saveDrawToolStripMenuItem.Click += new System.EventHandler(this.TurnSaveDrawing);
            // 
            // clearAllWallsToolStripMenuItem
            // 
            this.clearAllWallsToolStripMenuItem.Name = "clearAllWallsToolStripMenuItem";
            this.clearAllWallsToolStripMenuItem.Size = new System.Drawing.Size(196, 26);
            this.clearAllWallsToolStripMenuItem.Text = "Clear All Walls";
            this.clearAllWallsToolStripMenuItem.Click += new System.EventHandler(this.ClearAllWalls);
            // 
            // viewMode4
            // 
            this.viewMode4.Location = new System.Drawing.Point(1841, 105);
            this.viewMode4.Margin = new System.Windows.Forms.Padding(4);
            this.viewMode4.Name = "viewMode4";
            this.viewMode4.Size = new System.Drawing.Size(57, 34);
            this.viewMode4.TabIndex = 18;
            this.viewMode4.Text = "4";
            this.viewMode4.UseVisualStyleBackColor = true;
            this.viewMode4.Click += new System.EventHandler(this.TurnViewMode4);
            // 
            // turnDrawingBT
            // 
            this.turnDrawingBT.Location = new System.Drawing.Point(1642, 435);
            this.turnDrawingBT.Margin = new System.Windows.Forms.Padding(4);
            this.turnDrawingBT.Name = "turnDrawingBT";
            this.turnDrawingBT.Size = new System.Drawing.Size(259, 74);
            this.turnDrawingBT.TabIndex = 19;
            this.turnDrawingBT.Text = "Turn Off Drawing";
            this.turnDrawingBT.UseVisualStyleBackColor = true;
            this.turnDrawingBT.Click += new System.EventHandler(this.TurnDrawing);
            // 
            // oneStepBT
            // 
            this.oneStepBT.Location = new System.Drawing.Point(1841, 187);
            this.oneStepBT.Margin = new System.Windows.Forms.Padding(4);
            this.oneStepBT.Name = "oneStepBT";
            this.oneStepBT.Size = new System.Drawing.Size(57, 39);
            this.oneStepBT.TabIndex = 20;
            this.oneStepBT.Text = ">";
            this.oneStepBT.UseVisualStyleBackColor = true;
            this.oneStepBT.Click += new System.EventHandler(this.DoOneStep);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1588, 900);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 21;
            this.label1.Text = "#####";
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
            // randomGenomeCB
            // 
            this.randomGenomeCB.AutoSize = true;
            this.randomGenomeCB.Location = new System.Drawing.Point(1708, 903);
            this.randomGenomeCB.Name = "randomGenomeCB";
            this.randomGenomeCB.Size = new System.Drawing.Size(128, 20);
            this.randomGenomeCB.TabIndex = 22;
            this.randomGenomeCB.Text = "random genome";
            this.randomGenomeCB.UseVisualStyleBackColor = true;
            this.randomGenomeCB.CheckedChanged += new System.EventHandler(this.TurnRandomGenome);
            // 
            // addCellBT
            // 
            this.addCellBT.Location = new System.Drawing.Point(1641, 188);
            this.addCellBT.Margin = new System.Windows.Forms.Padding(4);
            this.addCellBT.Name = "addCellBT";
            this.addCellBT.Size = new System.Drawing.Size(57, 39);
            this.addCellBT.TabIndex = 23;
            this.addCellBT.Text = "o";
            this.addCellBT.UseVisualStyleBackColor = true;
            this.addCellBT.Click += new System.EventHandler(this.AddTypeCell);
            // 
            // addWallBT
            // 
            this.addWallBT.Location = new System.Drawing.Point(1708, 187);
            this.addWallBT.Margin = new System.Windows.Forms.Padding(4);
            this.addWallBT.Name = "addWallBT";
            this.addWallBT.Size = new System.Drawing.Size(57, 39);
            this.addWallBT.TabIndex = 24;
            this.addWallBT.Text = "||";
            this.addWallBT.UseVisualStyleBackColor = true;
            this.addWallBT.Click += new System.EventHandler(this.AddTypeWall);
            // 
            // eraseCellBT
            // 
            this.eraseCellBT.Location = new System.Drawing.Point(1776, 188);
            this.eraseCellBT.Margin = new System.Windows.Forms.Padding(4);
            this.eraseCellBT.Name = "eraseCellBT";
            this.eraseCellBT.Size = new System.Drawing.Size(57, 39);
            this.eraseCellBT.TabIndex = 25;
            this.eraseCellBT.Text = "X";
            this.eraseCellBT.UseVisualStyleBackColor = true;
            this.eraseCellBT.Click += new System.EventHandler(this.AddTypeEmpty);
            // 
            // WORLD_BOX
            // 
            this.WORLD_BOX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.WORLD_BOX.InitialImage = null;
            this.WORLD_BOX.Location = new System.Drawing.Point(40, 32);
            this.WORLD_BOX.Margin = new System.Windows.Forms.Padding(4);
            this.WORLD_BOX.Name = "WORLD_BOX";
            this.WORLD_BOX.Size = new System.Drawing.Size(1590, 864);
            this.WORLD_BOX.TabIndex = 0;
            this.WORLD_BOX.TabStop = false;
            this.WORLD_BOX.Paint += new System.Windows.Forms.PaintEventHandler(this.WORLD_BOX_Paint);
            this.WORLD_BOX.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WORLD_BOX_MouseDown);
            this.WORLD_BOX.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WORLD_BOX_MouseMove);
            this.WORLD_BOX.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WORLD_BOX_MouseUp);
            // 
            // CellColorBT
            // 
            this.CellColorBT.BackColor = System.Drawing.Color.OrangeRed;
            this.CellColorBT.Location = new System.Drawing.Point(1641, 245);
            this.CellColorBT.Name = "CellColorBT";
            this.CellColorBT.Size = new System.Drawing.Size(56, 38);
            this.CellColorBT.TabIndex = 26;
            this.CellColorBT.Text = "Color";
            this.CellColorBT.UseVisualStyleBackColor = false;
            this.CellColorBT.Click += new System.EventHandler(this.CellColorBT_Click);
            // 
            // viewMode5
            // 
            this.viewMode5.Location = new System.Drawing.Point(1841, 145);
            this.viewMode5.Margin = new System.Windows.Forms.Padding(4);
            this.viewMode5.Name = "viewMode5";
            this.viewMode5.Size = new System.Drawing.Size(57, 34);
            this.viewMode5.TabIndex = 27;
            this.viewMode5.Text = "5";
            this.viewMode5.UseVisualStyleBackColor = true;
            this.viewMode5.Click += new System.EventHandler(this.TurnViewMode5);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1662, 226);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 16);
            this.label2.TabIndex = 28;
            this.label2.Text = "/\\";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1924, 956);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.viewMode5);
            this.Controls.Add(this.CellColorBT);
            this.Controls.Add(this.eraseCellBT);
            this.Controls.Add(this.addWallBT);
            this.Controls.Add(this.addCellBT);
            this.Controls.Add(this.randomGenomeCB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.oneStepBT);
            this.Controls.Add(this.turnDrawingBT);
            this.Controls.Add(this.viewMode4);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.newSimulationBT);
            this.Controls.Add(this.worldSizeTB);
            this.Controls.Add(this.worldSizeScroll);
            this.Controls.Add(this.viewMode3BT);
            this.Controls.Add(this.viewMode2BT);
            this.Controls.Add(this.loadWorldBT);
            this.Controls.Add(this.stopPlayBT);
            this.Controls.Add(this.saveWorldBT);
            this.Controls.Add(this.viewMode1BT);
            this.Controls.Add(this.minusSizeBT);
            this.Controls.Add(this.plusSizeBT);
            this.Controls.Add(this.WORLD_BOX);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cyber Biology";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.worldSizeScroll)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WORLD_BOX)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox WORLD_BOX;
        private System.Windows.Forms.Button plusSizeBT;
        private System.Windows.Forms.Button minusSizeBT;
        private System.Windows.Forms.Button viewMode1BT;
        private System.Windows.Forms.Button saveWorldBT;
        private System.Windows.Forms.Button stopPlayBT;
        private System.Windows.Forms.Button loadWorldBT;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button viewMode2BT;
        private System.Windows.Forms.Button viewMode3BT;
        private System.Windows.Forms.TrackBar worldSizeScroll;
        private System.Windows.Forms.TextBox worldSizeTB;
        private System.Windows.Forms.Button newSimulationBT;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem saveImagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lacationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveParametresToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ToolStripMenuItem тестыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem perfomanceTestMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveImagesToolStripMenuItem1;
        private System.Windows.Forms.Button viewMode4;
        private System.Windows.Forms.Button turnDrawingBT;
        private System.Windows.Forms.Button oneStepBT;
        private System.Windows.Forms.ToolStripMenuItem saveWorldsToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem worldSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadFromTextToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog2;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.ToolStripMenuItem saveDrawToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearAllWallsToolStripMenuItem;
        private System.Windows.Forms.CheckBox randomGenomeCB;
        private System.Windows.Forms.Button addCellBT;
        private System.Windows.Forms.Button addWallBT;
        private System.Windows.Forms.Button eraseCellBT;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button CellColorBT;
        private System.Windows.Forms.Button viewMode5;
        private System.Windows.Forms.Label label2;
    }
}

