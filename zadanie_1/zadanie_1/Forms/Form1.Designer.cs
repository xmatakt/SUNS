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
            this.mLPNetworkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rBFNetworkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.functionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 50);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(757, 656);
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
            this.menuStrip1.Size = new System.Drawing.Size(784, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // networksToolStripMenuItem
            // 
            this.networksToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mLPNetworkToolStripMenuItem,
            this.rBFNetworkToolStripMenuItem});
            this.networksToolStripMenuItem.Name = "networksToolStripMenuItem";
            this.networksToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.networksToolStripMenuItem.Text = "Networks";
            // 
            // mLPNetworkToolStripMenuItem
            // 
            this.mLPNetworkToolStripMenuItem.Name = "mLPNetworkToolStripMenuItem";
            this.mLPNetworkToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.mLPNetworkToolStripMenuItem.Text = "MLP network";
            this.mLPNetworkToolStripMenuItem.Click += new System.EventHandler(this.mLPNetworkToolStripMenuItem_Click);
            // 
            // rBFNetworkToolStripMenuItem
            // 
            this.rBFNetworkToolStripMenuItem.Name = "rBFNetworkToolStripMenuItem";
            this.rBFNetworkToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.rBFNetworkToolStripMenuItem.Text = "RBF network";
            this.rBFNetworkToolStripMenuItem.Click += new System.EventHandler(this.rBFNetworkToolStripMenuItem_Click);
            // 
            // functionToolStripMenuItem
            // 
            this.functionToolStripMenuItem.Name = "functionToolStripMenuItem";
            this.functionToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.functionToolStripMenuItem.Text = "Function";
            this.functionToolStripMenuItem.Click += new System.EventHandler(this.functionToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 718);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
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
        private System.Windows.Forms.ToolStripMenuItem mLPNetworkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rBFNetworkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem functionToolStripMenuItem;
    }
}

