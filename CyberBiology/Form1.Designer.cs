﻿namespace CyberBiology
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullScreenBT = new System.Windows.Forms.ToolStripMenuItem();
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
            this.saveWallsMBT = new System.Windows.Forms.ToolStripMenuItem();
            this.templatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dualWorldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quadroWorldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labirintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statisticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripTextBox2 = new System.Windows.Forms.ToolStripTextBox();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rulebookMBT = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.viewMode4 = new System.Windows.Forms.Button();
            this.turnDrawingBT = new System.Windows.Forms.Button();
            this.oneStepBT = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.addCellBT = new System.Windows.Forms.Button();
            this.addWallBT = new System.Windows.Forms.Button();
            this.eraseCellBT = new System.Windows.Forms.Button();
            this.WORLD_BOX = new System.Windows.Forms.PictureBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.CellColorBT = new System.Windows.Forms.Button();
            this.viewMode5 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.newCellTypeUD = new System.Windows.Forms.DomainUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.stopIterationNUM = new System.Windows.Forms.NumericUpDown();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.worldSizeScroll)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WORLD_BOX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stopIterationNUM)).BeginInit();
            this.SuspendLayout();
            // 
            // plusSizeBT
            // 
            this.plusSizeBT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.minusSizeBT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.viewMode1BT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.saveWorldBT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.stopPlayBT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.loadWorldBT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.viewMode2BT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.viewMode3BT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.worldSizeScroll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.worldSizeTB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.newSimulationBT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.newSimulationBT.Location = new System.Drawing.Point(1708, 853);
            this.newSimulationBT.Margin = new System.Windows.Forms.Padding(4);
            this.newSimulationBT.Name = "newSimulationBT";
            this.newSimulationBT.Size = new System.Drawing.Size(125, 43);
            this.newSimulationBT.TabIndex = 13;
            this.newSimulationBT.Text = "New Simulation";
            this.newSimulationBT.UseVisualStyleBackColor = true;
            this.newSimulationBT.Click += new System.EventHandler(this.NewSimulation);
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hScrollBar1.LargeChange = 1;
            this.hScrollBar1.Location = new System.Drawing.Point(0, 935);
            this.hScrollBar1.Maximum = 0;
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(1924, 21);
            this.hScrollBar1.TabIndex = 14;
            this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.vScrollBar1.LargeChange = 1;
            this.vScrollBar1.Location = new System.Drawing.Point(0, 0);
            this.vScrollBar1.Maximum = 0;
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(21, 935);
            this.vScrollBar1.TabIndex = 15;
            this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.saveImagesToolStripMenuItem,
            this.тестыToolStripMenuItem,
            this.templatesToolStripMenuItem,
            this.statisticsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(21, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1903, 28);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fullScreenBT});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // fullScreenBT
            // 
            this.fullScreenBT.CheckOnClick = true;
            this.fullScreenBT.Name = "fullScreenBT";
            this.fullScreenBT.Size = new System.Drawing.Size(224, 26);
            this.fullScreenBT.Text = "Full Screen";
            this.fullScreenBT.Click += new System.EventHandler(this.TurnFullScreen);
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
            this.saveImagesToolStripMenuItem.Size = new System.Drawing.Size(60, 24);
            this.saveImagesToolStripMenuItem.Text = "Saves";
            // 
            // saveImagesToolStripMenuItem1
            // 
            this.saveImagesToolStripMenuItem1.CheckOnClick = true;
            this.saveImagesToolStripMenuItem1.Name = "saveImagesToolStripMenuItem1";
            this.saveImagesToolStripMenuItem1.Size = new System.Drawing.Size(224, 26);
            this.saveImagesToolStripMenuItem1.Text = "Save Images";
            this.saveImagesToolStripMenuItem1.Click += new System.EventHandler(this.TurnImagesSaving);
            // 
            // saveWorldsToolStripMenuItem
            // 
            this.saveWorldsToolStripMenuItem.CheckOnClick = true;
            this.saveWorldsToolStripMenuItem.Name = "saveWorldsToolStripMenuItem";
            this.saveWorldsToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.saveWorldsToolStripMenuItem.Text = "Save Worlds";
            this.saveWorldsToolStripMenuItem.Click += new System.EventHandler(this.TurnWorldSaving);
            // 
            // lacationToolStripMenuItem
            // 
            this.lacationToolStripMenuItem.Name = "lacationToolStripMenuItem";
            this.lacationToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.lacationToolStripMenuItem.Text = "Lacation";
            this.lacationToolStripMenuItem.Click += new System.EventHandler(this.ChangeImageSavePath);
            // 
            // saveParametresToolStripMenuItem
            // 
            this.saveParametresToolStripMenuItem.Name = "saveParametresToolStripMenuItem";
            this.saveParametresToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.saveParametresToolStripMenuItem.Text = "Save Parametres";
            this.saveParametresToolStripMenuItem.Click += new System.EventHandler(this.ShowImageSaveParametresWindow);
            // 
            // saveToTextToolStripMenuItem
            // 
            this.saveToTextToolStripMenuItem.Name = "saveToTextToolStripMenuItem";
            this.saveToTextToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.saveToTextToolStripMenuItem.Text = "Save To Text";
            this.saveToTextToolStripMenuItem.Click += new System.EventHandler(this.SaveToText);
            // 
            // loadFromTextToolStripMenuItem
            // 
            this.loadFromTextToolStripMenuItem.Name = "loadFromTextToolStripMenuItem";
            this.loadFromTextToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.loadFromTextToolStripMenuItem.Text = "Load From Text";
            this.loadFromTextToolStripMenuItem.Click += new System.EventHandler(this.LoadFromText);
            // 
            // тестыToolStripMenuItem
            // 
            this.тестыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.perfomanceTestMenuItem,
            this.worldSettingsToolStripMenuItem,
            this.saveDrawToolStripMenuItem,
            this.clearAllWallsToolStripMenuItem,
            this.saveWallsMBT});
            this.тестыToolStripMenuItem.Name = "тестыToolStripMenuItem";
            this.тестыToolStripMenuItem.Size = new System.Drawing.Size(94, 24);
            this.тестыToolStripMenuItem.Text = "Simulation";
            // 
            // perfomanceTestMenuItem
            // 
            this.perfomanceTestMenuItem.CheckOnClick = true;
            this.perfomanceTestMenuItem.Name = "perfomanceTestMenuItem";
            this.perfomanceTestMenuItem.Size = new System.Drawing.Size(224, 26);
            this.perfomanceTestMenuItem.Text = "Performans Test";
            this.perfomanceTestMenuItem.Click += new System.EventHandler(this.PerfomanceTest_Click);
            // 
            // worldSettingsToolStripMenuItem
            // 
            this.worldSettingsToolStripMenuItem.Name = "worldSettingsToolStripMenuItem";
            this.worldSettingsToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.worldSettingsToolStripMenuItem.Text = "World Settings";
            this.worldSettingsToolStripMenuItem.Click += new System.EventHandler(this.ShowWorldSettingsWindow);
            // 
            // saveDrawToolStripMenuItem
            // 
            this.saveDrawToolStripMenuItem.Checked = true;
            this.saveDrawToolStripMenuItem.CheckOnClick = true;
            this.saveDrawToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.saveDrawToolStripMenuItem.Name = "saveDrawToolStripMenuItem";
            this.saveDrawToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.saveDrawToolStripMenuItem.Text = "Save Drawing";
            this.saveDrawToolStripMenuItem.Click += new System.EventHandler(this.TurnSaveDrawing);
            // 
            // clearAllWallsToolStripMenuItem
            // 
            this.clearAllWallsToolStripMenuItem.Name = "clearAllWallsToolStripMenuItem";
            this.clearAllWallsToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.clearAllWallsToolStripMenuItem.Text = "Clear All Walls";
            this.clearAllWallsToolStripMenuItem.Click += new System.EventHandler(this.ClearAllWalls);
            // 
            // saveWallsMBT
            // 
            this.saveWallsMBT.CheckOnClick = true;
            this.saveWallsMBT.Name = "saveWallsMBT";
            this.saveWallsMBT.Size = new System.Drawing.Size(224, 26);
            this.saveWallsMBT.Text = "Save Walls";
            this.saveWallsMBT.Click += new System.EventHandler(this.saveWallsMBT_Click);
            // 
            // templatesToolStripMenuItem
            // 
            this.templatesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dualWorldToolStripMenuItem,
            this.quadroWorldToolStripMenuItem,
            this.labirintToolStripMenuItem});
            this.templatesToolStripMenuItem.Name = "templatesToolStripMenuItem";
            this.templatesToolStripMenuItem.Size = new System.Drawing.Size(91, 24);
            this.templatesToolStripMenuItem.Text = "Templates";
            // 
            // dualWorldToolStripMenuItem
            // 
            this.dualWorldToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("dualWorldToolStripMenuItem.Image")));
            this.dualWorldToolStripMenuItem.Name = "dualWorldToolStripMenuItem";
            this.dualWorldToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.dualWorldToolStripMenuItem.Text = "Dual World";
            this.dualWorldToolStripMenuItem.Click += new System.EventHandler(this.TemplateDualWorld);
            // 
            // quadroWorldToolStripMenuItem
            // 
            this.quadroWorldToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("quadroWorldToolStripMenuItem.Image")));
            this.quadroWorldToolStripMenuItem.Name = "quadroWorldToolStripMenuItem";
            this.quadroWorldToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.quadroWorldToolStripMenuItem.Text = "Quadruple World";
            this.quadroWorldToolStripMenuItem.Click += new System.EventHandler(this.TemplateQuadrupleWorld);
            // 
            // labirintToolStripMenuItem
            // 
            this.labirintToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("labirintToolStripMenuItem.Image")));
            this.labirintToolStripMenuItem.Name = "labirintToolStripMenuItem";
            this.labirintToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.labirintToolStripMenuItem.Text = "Labyrinth";
            this.labirintToolStripMenuItem.Click += new System.EventHandler(this.TemplateLabyrinthWorld);
            // 
            // statisticsToolStripMenuItem
            // 
            this.statisticsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripSeparator1,
            this.toolStripTextBox1,
            this.toolStripTextBox2});
            this.statisticsToolStripMenuItem.Name = "statisticsToolStripMenuItem";
            this.statisticsToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.statisticsToolStripMenuItem.Text = "Statistics";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.Image")));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(224, 26);
            this.toolStripMenuItem1.Text = "Cell Count";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.CellCountLog);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.ReadOnly = true;
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 27);
            this.toolStripTextBox1.Text = "LOG EVERY:";
            // 
            // toolStripTextBox2
            // 
            this.toolStripTextBox2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBox2.Name = "toolStripTextBox2";
            this.toolStripTextBox2.Size = new System.Drawing.Size(100, 27);
            this.toolStripTextBox2.Text = "1000";
            this.toolStripTextBox2.TextChanged += new System.EventHandler(this.ChangeLogFrequency);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rulebookMBT});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // rulebookMBT
            // 
            this.rulebookMBT.Image = ((System.Drawing.Image)(resources.GetObject("rulebookMBT.Image")));
            this.rulebookMBT.Name = "rulebookMBT";
            this.rulebookMBT.Size = new System.Drawing.Size(224, 26);
            this.rulebookMBT.Text = "Rulebook";
            this.rulebookMBT.Click += new System.EventHandler(this.ShowRulebook);
            // 
            // viewMode4
            // 
            this.viewMode4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.turnDrawingBT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.turnDrawingBT.Location = new System.Drawing.Point(1643, 434);
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
            this.oneStepBT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
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
            // addCellBT
            // 
            this.addCellBT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.addWallBT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.eraseCellBT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.CellColorBT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CellColorBT.BackColor = System.Drawing.Color.OrangeRed;
            this.CellColorBT.Location = new System.Drawing.Point(1641, 245);
            this.CellColorBT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CellColorBT.Name = "CellColorBT";
            this.CellColorBT.Size = new System.Drawing.Size(56, 38);
            this.CellColorBT.TabIndex = 26;
            this.CellColorBT.Text = "Color";
            this.CellColorBT.UseVisualStyleBackColor = false;
            this.CellColorBT.Click += new System.EventHandler(this.CellColorBT_Click);
            // 
            // viewMode5
            // 
            this.viewMode5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1659, 226);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 16);
            this.label2.TabIndex = 28;
            this.label2.Text = "/\\";
            // 
            // newCellTypeUD
            // 
            this.newCellTypeUD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.newCellTypeUD.Items.Add("FOTOSINTEZ");
            this.newCellTypeUD.Items.Add("MINERAL");
            this.newCellTypeUD.Items.Add("RANDOM");
            this.newCellTypeUD.Location = new System.Drawing.Point(1704, 254);
            this.newCellTypeUD.Margin = new System.Windows.Forms.Padding(4);
            this.newCellTypeUD.Name = "newCellTypeUD";
            this.newCellTypeUD.ReadOnly = true;
            this.newCellTypeUD.Size = new System.Drawing.Size(128, 22);
            this.newCellTypeUD.TabIndex = 29;
            this.newCellTypeUD.Text = "FOTOSINTEZ";
            this.newCellTypeUD.SelectedItemChanged += new System.EventHandler(this.NewCellTypeSwitch);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1704, 234);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 16);
            this.label3.TabIndex = 30;
            this.label3.Text = "Cell Type";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1705, 281);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 16);
            this.label4.TabIndex = 33;
            this.label4.Text = "Stop Iteration At";
            // 
            // stopIterationNUM
            // 
            this.stopIterationNUM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.stopIterationNUM.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.stopIterationNUM.Location = new System.Drawing.Point(1704, 299);
            this.stopIterationNUM.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.stopIterationNUM.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.stopIterationNUM.Name = "stopIterationNUM";
            this.stopIterationNUM.Size = new System.Drawing.Size(129, 22);
            this.stopIterationNUM.TabIndex = 34;
            this.stopIterationNUM.ValueChanged += new System.EventHandler(this.SetStopIteration);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(221, 6);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 956);
            this.Controls.Add(this.stopIterationNUM);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.newCellTypeUD);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.viewMode5);
            this.Controls.Add(this.CellColorBT);
            this.Controls.Add(this.eraseCellBT);
            this.Controls.Add(this.addWallBT);
            this.Controls.Add(this.addCellBT);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cyber Biology";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.Resize += new System.EventHandler(this.SetWindowElemets);
            ((System.ComponentModel.ISupportInitialize)(this.worldSizeScroll)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WORLD_BOX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stopIterationNUM)).EndInit();
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
        private System.Windows.Forms.Button addCellBT;
        private System.Windows.Forms.Button addWallBT;
        private System.Windows.Forms.Button eraseCellBT;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button CellColorBT;
        private System.Windows.Forms.Button viewMode5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem templatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dualWorldToolStripMenuItem;
        private System.Windows.Forms.DomainUpDown newCellTypeUD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem quadroWorldToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem labirintToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown stopIterationNUM;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fullScreenBT;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rulebookMBT;
        private System.Windows.Forms.ToolStripMenuItem saveWallsMBT;
        private System.Windows.Forms.ToolStripMenuItem statisticsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

