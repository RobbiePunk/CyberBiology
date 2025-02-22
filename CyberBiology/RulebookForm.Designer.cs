namespace CyberBiology
{
    partial class RulebookForm
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
            this.CellColorBT = new System.Windows.Forms.Button();
            this.backBT = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cellColorLeftBT = new System.Windows.Forms.Button();
            this.cellColorRightBT = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // CellColorBT
            // 
            this.CellColorBT.Location = new System.Drawing.Point(12, 12);
            this.CellColorBT.Name = "CellColorBT";
            this.CellColorBT.Size = new System.Drawing.Size(287, 47);
            this.CellColorBT.TabIndex = 0;
            this.CellColorBT.Text = "Cell Color";
            this.CellColorBT.UseVisualStyleBackColor = true;
            this.CellColorBT.Click += new System.EventHandler(this.CellColorBT_Click);
            // 
            // backBT
            // 
            this.backBT.Location = new System.Drawing.Point(12, 633);
            this.backBT.Name = "backBT";
            this.backBT.Size = new System.Drawing.Size(100, 47);
            this.backBT.TabIndex = 1;
            this.backBT.Text = "Back";
            this.backBT.UseVisualStyleBackColor = true;
            this.backBT.Click += new System.EventHandler(this.backBT_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(353, 161);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(78, 321);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // cellColorLeftBT
            // 
            this.cellColorLeftBT.Location = new System.Drawing.Point(12, 580);
            this.cellColorLeftBT.Name = "cellColorLeftBT";
            this.cellColorLeftBT.Size = new System.Drawing.Size(100, 47);
            this.cellColorLeftBT.TabIndex = 3;
            this.cellColorLeftBT.Text = "<==";
            this.cellColorLeftBT.UseVisualStyleBackColor = true;
            this.cellColorLeftBT.Click += new System.EventHandler(this.cellColorLeftBT_Click);
            // 
            // cellColorRightBT
            // 
            this.cellColorRightBT.Location = new System.Drawing.Point(447, 580);
            this.cellColorRightBT.Name = "cellColorRightBT";
            this.cellColorRightBT.Size = new System.Drawing.Size(100, 47);
            this.cellColorRightBT.TabIndex = 4;
            this.cellColorRightBT.Text = "==>";
            this.cellColorRightBT.UseVisualStyleBackColor = true;
            this.cellColorRightBT.Click += new System.EventHandler(this.cellColorRightBT_Click);
            // 
            // RulebookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 692);
            this.Controls.Add(this.cellColorRightBT);
            this.Controls.Add(this.cellColorLeftBT);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.backBT);
            this.Controls.Add(this.CellColorBT);
            this.Name = "RulebookForm";
            this.Text = "Rulebook";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CellColorBT;
        private System.Windows.Forms.Button backBT;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button cellColorLeftBT;
        private System.Windows.Forms.Button cellColorRightBT;
    }
}