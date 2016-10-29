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
            this.display_all = new GraphLib.PlotterDisplayEx();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.display_prediction = new GraphLib.PlotterDisplayEx();
            this.panel3 = new System.Windows.Forms.Panel();
            this.display_loopPrediction = new GraphLib.PlotterDisplayEx();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // display_all
            // 
            this.display_all.BackColor = System.Drawing.Color.Transparent;
            this.display_all.BackgroundColorBot = System.Drawing.Color.Gray;
            this.display_all.BackgroundColorTop = System.Drawing.Color.White;
            this.display_all.DashedGridColor = System.Drawing.Color.DarkGray;
            this.display_all.DoubleBuffering = false;
            this.display_all.Location = new System.Drawing.Point(4, 4);
            this.display_all.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.display_all.Name = "display_all";
            this.display_all.PlaySpeed = 0.5F;
            this.display_all.Size = new System.Drawing.Size(1135, 302);
            this.display_all.SolidGridColor = System.Drawing.Color.DarkGray;
            this.display_all.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.display_all);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1147, 314);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.display_prediction);
            this.panel2.Location = new System.Drawing.Point(12, 332);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1147, 314);
            this.panel2.TabIndex = 2;
            // 
            // display_prediction
            // 
            this.display_prediction.BackColor = System.Drawing.Color.Transparent;
            this.display_prediction.BackgroundColorBot = System.Drawing.Color.Gray;
            this.display_prediction.BackgroundColorTop = System.Drawing.Color.White;
            this.display_prediction.DashedGridColor = System.Drawing.Color.DarkGray;
            this.display_prediction.DoubleBuffering = false;
            this.display_prediction.Location = new System.Drawing.Point(4, 4);
            this.display_prediction.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.display_prediction.Name = "display_prediction";
            this.display_prediction.PlaySpeed = 0.5F;
            this.display_prediction.Size = new System.Drawing.Size(1135, 302);
            this.display_prediction.SolidGridColor = System.Drawing.Color.DarkGray;
            this.display_prediction.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.display_loopPrediction);
            this.panel3.Location = new System.Drawing.Point(12, 652);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1147, 314);
            this.panel3.TabIndex = 3;
            // 
            // display_loopPrediction
            // 
            this.display_loopPrediction.BackColor = System.Drawing.Color.Transparent;
            this.display_loopPrediction.BackgroundColorBot = System.Drawing.Color.Gray;
            this.display_loopPrediction.BackgroundColorTop = System.Drawing.Color.White;
            this.display_loopPrediction.DashedGridColor = System.Drawing.Color.DarkGray;
            this.display_loopPrediction.DoubleBuffering = false;
            this.display_loopPrediction.Location = new System.Drawing.Point(4, 4);
            this.display_loopPrediction.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.display_loopPrediction.Name = "display_loopPrediction";
            this.display_loopPrediction.PlaySpeed = 0.5F;
            this.display_loopPrediction.Size = new System.Drawing.Size(1135, 302);
            this.display_loopPrediction.SolidGridColor = System.Drawing.Color.DarkGray;
            this.display_loopPrediction.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1673, 1096);
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

        private GraphLib.PlotterDisplayEx display_all;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private GraphLib.PlotterDisplayEx display_prediction;
        private System.Windows.Forms.Panel panel3;
        private GraphLib.PlotterDisplayEx display_loopPrediction;

    }
}

