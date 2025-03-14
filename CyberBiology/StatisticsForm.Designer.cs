namespace CyberBiology
{
    partial class StaticsticsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StaticsticsForm));
            this.statPB = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.statPB)).BeginInit();
            this.SuspendLayout();
            // 
            // statPB
            // 
            this.statPB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.statPB.Location = new System.Drawing.Point(12, 12);
            this.statPB.Name = "statPB";
            this.statPB.Size = new System.Drawing.Size(1131, 588);
            this.statPB.TabIndex = 0;
            this.statPB.TabStop = false;
            // 
            // StaticsticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 612);
            this.Controls.Add(this.statPB);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StaticsticsForm";
            this.Text = "Statistics";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.StaticsticsForm_Load);
            this.SizeChanged += new System.EventHandler(this.StaticsticsForm_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.statPB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox statPB;
    }
}