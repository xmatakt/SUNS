namespace TimeSeriesPrediction.Forms
{
    partial class BigGraphForm
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
            this.zedGraph_main = new ZedGraph.ZedGraphControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.zedGraph_error = new ZedGraph.ZedGraphControl();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // zedGraph_main
            // 
            this.zedGraph_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraph_main.Location = new System.Drawing.Point(0, 0);
            this.zedGraph_main.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.zedGraph_main.Name = "zedGraph_main";
            this.zedGraph_main.ScrollGrace = 0D;
            this.zedGraph_main.ScrollMaxX = 0D;
            this.zedGraph_main.ScrollMaxY = 0D;
            this.zedGraph_main.ScrollMaxY2 = 0D;
            this.zedGraph_main.ScrollMinX = 0D;
            this.zedGraph_main.ScrollMinY = 0D;
            this.zedGraph_main.ScrollMinY2 = 0D;
            this.zedGraph_main.Size = new System.Drawing.Size(1379, 377);
            this.zedGraph_main.TabIndex = 0;
            this.zedGraph_main.KeyDown += new System.Windows.Forms.KeyEventHandler(this.zedGraphControl1_KeyDown);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.zedGraph_main);
            this.panel1.Location = new System.Drawing.Point(12, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1381, 379);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.zedGraph_error);
            this.panel2.Location = new System.Drawing.Point(13, 392);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1381, 379);
            this.panel2.TabIndex = 2;
            // 
            // zedGraph_error
            // 
            this.zedGraph_error.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraph_error.Location = new System.Drawing.Point(0, 0);
            this.zedGraph_error.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.zedGraph_error.Name = "zedGraph_error";
            this.zedGraph_error.ScrollGrace = 0D;
            this.zedGraph_error.ScrollMaxX = 0D;
            this.zedGraph_error.ScrollMaxY = 0D;
            this.zedGraph_error.ScrollMaxY2 = 0D;
            this.zedGraph_error.ScrollMinX = 0D;
            this.zedGraph_error.ScrollMinY = 0D;
            this.zedGraph_error.ScrollMinY2 = 0D;
            this.zedGraph_error.Size = new System.Drawing.Size(1379, 377);
            this.zedGraph_error.TabIndex = 0;
            // 
            // BigGraphForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1405, 779);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "BigGraphForm";
            this.Text = "BigGraphForm";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public ZedGraph.ZedGraphControl zedGraph_main;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        public ZedGraph.ZedGraphControl zedGraph_error;
    }
}