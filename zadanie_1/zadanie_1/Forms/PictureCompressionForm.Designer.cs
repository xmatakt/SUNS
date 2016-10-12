namespace zadanie_1.Forms
{
    partial class PictureCompressionForm
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
            this.biasCheckBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.activationFunctionButton = new System.Windows.Forms.Button();
            this.neuronsCount = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.loadTrainData_button = new System.Windows.Forms.Button();
            this.trainDataLoaded_label = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.neuronsCount)).BeginInit();
            this.SuspendLayout();
            // 
            // biasCheckBox
            // 
            this.biasCheckBox.AutoSize = true;
            this.biasCheckBox.Location = new System.Drawing.Point(407, 72);
            this.biasCheckBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.biasCheckBox.Name = "biasCheckBox";
            this.biasCheckBox.Size = new System.Drawing.Size(22, 21);
            this.biasCheckBox.TabIndex = 12;
            this.biasCheckBox.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(397, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Bias";
            // 
            // activationFunctionButton
            // 
            this.activationFunctionButton.Location = new System.Drawing.Point(203, 68);
            this.activationFunctionButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.activationFunctionButton.Name = "activationFunctionButton";
            this.activationFunctionButton.Size = new System.Drawing.Size(169, 31);
            this.activationFunctionButton.TabIndex = 10;
            this.activationFunctionButton.Text = "ActivationSigmoid";
            this.activationFunctionButton.UseVisualStyleBackColor = true;
            // 
            // neuronsCount
            // 
            this.neuronsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.neuronsCount.Location = new System.Drawing.Point(78, 70);
            this.neuronsCount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.neuronsCount.Maximum = new decimal(new int[] {
            55,
            0,
            0,
            0});
            this.neuronsCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.neuronsCount.Name = "neuronsCount";
            this.neuronsCount.Size = new System.Drawing.Size(102, 28);
            this.neuronsCount.TabIndex = 9;
            this.neuronsCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.neuronsCount.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(233, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Activation function";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Number of neurons";
            // 
            // loadTrainData_button
            // 
            this.loadTrainData_button.Location = new System.Drawing.Point(237, 124);
            this.loadTrainData_button.Name = "loadTrainData_button";
            this.loadTrainData_button.Size = new System.Drawing.Size(135, 31);
            this.loadTrainData_button.TabIndex = 13;
            this.loadTrainData_button.Text = "Load train data";
            this.loadTrainData_button.UseVisualStyleBackColor = true;
            this.loadTrainData_button.Click += new System.EventHandler(this.loadTrainData_button_Click);
            // 
            // trainDataLoaded_label
            // 
            this.trainDataLoaded_label.AutoSize = true;
            this.trainDataLoaded_label.Location = new System.Drawing.Point(34, 129);
            this.trainDataLoaded_label.Name = "trainDataLoaded_label";
            this.trainDataLoaded_label.Size = new System.Drawing.Size(195, 20);
            this.trainDataLoaded_label.TabIndex = 14;
            this.trainDataLoaded_label.Text = "Train data was not loaded!";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(191, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "Test data was not loaded!";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(237, 165);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 31);
            this.button1.TabIndex = 15;
            this.button1.Text = "Load test data";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // PictureCompressionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 221);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.trainDataLoaded_label);
            this.Controls.Add(this.loadTrainData_button);
            this.Controls.Add(this.biasCheckBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.activationFunctionButton);
            this.Controls.Add(this.neuronsCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PictureCompressionForm";
            this.Text = "PictureCompressionForm";
            ((System.ComponentModel.ISupportInitialize)(this.neuronsCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox biasCheckBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button activationFunctionButton;
        private System.Windows.Forms.NumericUpDown neuronsCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button loadTrainData_button;
        private System.Windows.Forms.Label trainDataLoaded_label;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}