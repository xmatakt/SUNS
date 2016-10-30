namespace TimeSeriesPrediction.Forms
{
    partial class ErrorForm
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
            this.zedGraph_error = new ZedGraph.ZedGraphControl();
            this.SuspendLayout();
            // 
            // zedGraph_error
            // 
            this.zedGraph_error.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zedGraph_error.Location = new System.Drawing.Point(13, 13);
            this.zedGraph_error.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.zedGraph_error.Name = "zedGraph_error";
            this.zedGraph_error.ScrollGrace = 0D;
            this.zedGraph_error.ScrollMaxX = 0D;
            this.zedGraph_error.ScrollMaxY = 0D;
            this.zedGraph_error.ScrollMaxY2 = 0D;
            this.zedGraph_error.ScrollMinX = 0D;
            this.zedGraph_error.ScrollMinY = 0D;
            this.zedGraph_error.ScrollMinY2 = 0D;
            this.zedGraph_error.Size = new System.Drawing.Size(1582, 667);
            this.zedGraph_error.TabIndex = 0;
            this.zedGraph_error.KeyDown += new System.Windows.Forms.KeyEventHandler(this.zedGraph_error_KeyDown);
            // 
            // ErrorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1608, 693);
            this.Controls.Add(this.zedGraph_error);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "ErrorForm";
            this.Text = "ErrorForm";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ErrorForm_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        public ZedGraph.ZedGraphControl zedGraph_error;

    }
}