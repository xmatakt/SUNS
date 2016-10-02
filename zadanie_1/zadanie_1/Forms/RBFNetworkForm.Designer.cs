namespace zadanie_1.Forms
{
    partial class RBFNetworkForm
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
            this.maxCountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.requiredErrorUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.errorGraphButton = new System.Windows.Forms.Button();
            this.generateNetworkButton = new System.Windows.Forms.Button();
            this.showLogButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.maxCountNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.requiredErrorUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Max epoch count:";
            // 
            // maxCountNumericUpDown
            // 
            this.maxCountNumericUpDown.Location = new System.Drawing.Point(137, 7);
            this.maxCountNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.maxCountNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxCountNumericUpDown.Name = "maxCountNumericUpDown";
            this.maxCountNumericUpDown.Size = new System.Drawing.Size(75, 22);
            this.maxCountNumericUpDown.TabIndex = 1;
            this.maxCountNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.maxCountNumericUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // requiredErrorUpDown
            // 
            this.requiredErrorUpDown.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.requiredErrorUpDown.DecimalPlaces = 4;
            this.requiredErrorUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.requiredErrorUpDown.Location = new System.Drawing.Point(137, 38);
            this.requiredErrorUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.requiredErrorUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.requiredErrorUpDown.Name = "requiredErrorUpDown";
            this.requiredErrorUpDown.Size = new System.Drawing.Size(75, 22);
            this.requiredErrorUpDown.TabIndex = 3;
            this.requiredErrorUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.requiredErrorUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Required error:";
            // 
            // errorGraphButton
            // 
            this.errorGraphButton.Enabled = false;
            this.errorGraphButton.Location = new System.Drawing.Point(12, 139);
            this.errorGraphButton.Name = "errorGraphButton";
            this.errorGraphButton.Size = new System.Drawing.Size(200, 26);
            this.errorGraphButton.TabIndex = 13;
            this.errorGraphButton.Text = "Show error graph";
            this.errorGraphButton.UseVisualStyleBackColor = true;
            this.errorGraphButton.Click += new System.EventHandler(this.errorGraphButton_Click);
            // 
            // generateNetworkButton
            // 
            this.generateNetworkButton.Location = new System.Drawing.Point(12, 73);
            this.generateNetworkButton.Name = "generateNetworkButton";
            this.generateNetworkButton.Size = new System.Drawing.Size(200, 28);
            this.generateNetworkButton.TabIndex = 12;
            this.generateNetworkButton.Text = "Generate network";
            this.generateNetworkButton.UseVisualStyleBackColor = true;
            this.generateNetworkButton.Click += new System.EventHandler(this.generateNetworkButton_Click);
            // 
            // showLogButton
            // 
            this.showLogButton.Enabled = false;
            this.showLogButton.Location = new System.Drawing.Point(12, 107);
            this.showLogButton.Name = "showLogButton";
            this.showLogButton.Size = new System.Drawing.Size(200, 26);
            this.showLogButton.TabIndex = 14;
            this.showLogButton.Text = "Show log";
            this.showLogButton.UseVisualStyleBackColor = true;
            // 
            // RBFNetworkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 174);
            this.Controls.Add(this.showLogButton);
            this.Controls.Add(this.errorGraphButton);
            this.Controls.Add(this.generateNetworkButton);
            this.Controls.Add(this.requiredErrorUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.maxCountNumericUpDown);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "RBFNetworkForm";
            this.Text = "RBFNetworkForm";
            this.Load += new System.EventHandler(this.RBFNetworkForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.maxCountNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.requiredErrorUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown maxCountNumericUpDown;
        private System.Windows.Forms.NumericUpDown requiredErrorUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button errorGraphButton;
        private System.Windows.Forms.Button generateNetworkButton;
        private System.Windows.Forms.Button showLogButton;
    }
}