namespace TimeSeriesPrediction
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.zedGraph_all = new ZedGraph.ZedGraphControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.zedGraph_serial = new ZedGraph.ZedGraphControl();
            this.panel3 = new System.Windows.Forms.Panel();
            this.zedGraph_looped = new ZedGraph.ZedGraphControl();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.zedGraph_all);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1185, 314);
            this.panel1.TabIndex = 1;
            // 
            // zedGraph_all
            // 
            this.zedGraph_all.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraph_all.Location = new System.Drawing.Point(0, 0);
            this.zedGraph_all.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.zedGraph_all.Name = "zedGraph_all";
            this.zedGraph_all.ScrollGrace = 0D;
            this.zedGraph_all.ScrollMaxX = 0D;
            this.zedGraph_all.ScrollMaxY = 0D;
            this.zedGraph_all.ScrollMaxY2 = 0D;
            this.zedGraph_all.ScrollMinX = 0D;
            this.zedGraph_all.ScrollMinY = 0D;
            this.zedGraph_all.ScrollMinY2 = 0D;
            this.zedGraph_all.Size = new System.Drawing.Size(1181, 310);
            this.zedGraph_all.TabIndex = 1;
            this.zedGraph_all.KeyDown += new System.Windows.Forms.KeyEventHandler(this.zedGraph_all_KeyDown);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.zedGraph_serial);
            this.panel2.Location = new System.Drawing.Point(12, 332);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1185, 314);
            this.panel2.TabIndex = 2;
            // 
            // zedGraph_serial
            // 
            this.zedGraph_serial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraph_serial.Location = new System.Drawing.Point(0, 0);
            this.zedGraph_serial.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.zedGraph_serial.Name = "zedGraph_serial";
            this.zedGraph_serial.ScrollGrace = 0D;
            this.zedGraph_serial.ScrollMaxX = 0D;
            this.zedGraph_serial.ScrollMaxY = 0D;
            this.zedGraph_serial.ScrollMaxY2 = 0D;
            this.zedGraph_serial.ScrollMinX = 0D;
            this.zedGraph_serial.ScrollMinY = 0D;
            this.zedGraph_serial.ScrollMinY2 = 0D;
            this.zedGraph_serial.Size = new System.Drawing.Size(1181, 310);
            this.zedGraph_serial.TabIndex = 2;
            this.zedGraph_serial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.zedGraph_serial_KeyDown);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.zedGraph_looped);
            this.panel3.Location = new System.Drawing.Point(12, 652);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1185, 314);
            this.panel3.TabIndex = 3;
            // 
            // zedGraph_looped
            // 
            this.zedGraph_looped.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraph_looped.Location = new System.Drawing.Point(0, 0);
            this.zedGraph_looped.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.zedGraph_looped.Name = "zedGraph_looped";
            this.zedGraph_looped.ScrollGrace = 0D;
            this.zedGraph_looped.ScrollMaxX = 0D;
            this.zedGraph_looped.ScrollMaxY = 0D;
            this.zedGraph_looped.ScrollMaxY2 = 0D;
            this.zedGraph_looped.ScrollMinX = 0D;
            this.zedGraph_looped.ScrollMinY = 0D;
            this.zedGraph_looped.ScrollMinY2 = 0D;
            this.zedGraph_looped.Size = new System.Drawing.Size(1181, 310);
            this.zedGraph_looped.TabIndex = 2;
            this.zedGraph_looped.KeyDown += new System.Windows.Forms.KeyEventHandler(this.zedGraph_looped_KeyDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1711, 973);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private ZedGraph.ZedGraphControl zedGraph_all;
        private ZedGraph.ZedGraphControl zedGraph_serial;
        private ZedGraph.ZedGraphControl zedGraph_looped;

    }
}

