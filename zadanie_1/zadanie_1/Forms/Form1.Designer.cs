namespace zadanie_1
{
    partial class Form1
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.networksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.functionAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mLPNetworkToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.sToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.functionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureCompressionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(14, 62);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(852, 820);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.networksToolStripMenuItem,
            this.functionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(882, 33);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // networksToolStripMenuItem
            // 
            this.networksToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.functionAToolStripMenuItem,
            this.pictureCompressionToolStripMenuItem});
            this.networksToolStripMenuItem.Name = "networksToolStripMenuItem";
            this.networksToolStripMenuItem.Size = new System.Drawing.Size(99, 29);
            this.networksToolStripMenuItem.Text = "Networks";
            // 
            // functionAToolStripMenuItem
            // 
            this.functionAToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mLPNetworkToolStripMenuItem1,
            this.sToolStripMenuItem});
            this.functionAToolStripMenuItem.Name = "functionAToolStripMenuItem";
            this.functionAToolStripMenuItem.Size = new System.Drawing.Size(273, 30);
            this.functionAToolStripMenuItem.Text = "Function approximation";
            // 
            // mLPNetworkToolStripMenuItem1
            // 
            this.mLPNetworkToolStripMenuItem1.Name = "mLPNetworkToolStripMenuItem1";
            this.mLPNetworkToolStripMenuItem1.Size = new System.Drawing.Size(198, 30);
            this.mLPNetworkToolStripMenuItem1.Text = "MLP Network";
            this.mLPNetworkToolStripMenuItem1.Click += new System.EventHandler(this.mLPNetworkToolStripMenuItem1_Click);
            // 
            // sToolStripMenuItem
            // 
            this.sToolStripMenuItem.Name = "sToolStripMenuItem";
            this.sToolStripMenuItem.Size = new System.Drawing.Size(198, 30);
            this.sToolStripMenuItem.Text = "RBF Network";
            this.sToolStripMenuItem.Click += new System.EventHandler(this.sToolStripMenuItem_Click);
            // 
            // functionToolStripMenuItem
            // 
            this.functionToolStripMenuItem.Name = "functionToolStripMenuItem";
            this.functionToolStripMenuItem.Size = new System.Drawing.Size(92, 29);
            this.functionToolStripMenuItem.Text = "Function";
            this.functionToolStripMenuItem.Click += new System.EventHandler(this.functionToolStripMenuItem_Click);
            // 
            // pictureCompressionToolStripMenuItem
            // 
            this.pictureCompressionToolStripMenuItem.Name = "pictureCompressionToolStripMenuItem";
            this.pictureCompressionToolStripMenuItem.Size = new System.Drawing.Size(273, 30);
            this.pictureCompressionToolStripMenuItem.Text = "Picture compression";
            this.pictureCompressionToolStripMenuItem.Click += new System.EventHandler(this.pictureCompressionToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 898);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem networksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem functionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem functionAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mLPNetworkToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem sToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pictureCompressionToolStripMenuItem;
    }
}

