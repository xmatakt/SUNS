namespace zadanie_1.Forms
{
    partial class FunctionPropertiesForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.nodesCountUpDown = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nodesCountUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number of nodes:";
            // 
            // nodesCountUpDown
            // 
            this.nodesCountUpDown.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nodesCountUpDown.Location = new System.Drawing.Point(161, 25);
            this.nodesCountUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nodesCountUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nodesCountUpDown.Name = "nodesCountUpDown";
            this.nodesCountUpDown.Size = new System.Drawing.Size(120, 22);
            this.nodesCountUpDown.TabIndex = 1;
            this.nodesCountUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nodesCountUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nodesCountUpDown.ValueChanged += new System.EventHandler(this.nodesCountUpDown_ValueChanged);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(117, 60);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FunctionPropertiesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 99);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.nodesCountUpDown);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FunctionPropertiesForm";
            this.Text = "FunctionPropertiesForm";
            this.Load += new System.EventHandler(this.FunctionPropertiesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nodesCountUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nodesCountUpDown;
        private System.Windows.Forms.Button button1;
    }
}