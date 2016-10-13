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
            this.components = new System.ComponentModel.Container();
            this.first_biasCheckBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.first_activationFunctionButton = new System.Windows.Forms.Button();
            this.first_neuronsCount = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.loadTrainData_button = new System.Windows.Forms.Button();
            this.trainDataLoaded_label = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.second_biasCheckBox = new System.Windows.Forms.CheckBox();
            this.second_activationFunctionButton = new System.Windows.Forms.Button();
            this.second_neuronsCont = new System.Windows.Forms.NumericUpDown();
            this.third_biasCheckBox = new System.Windows.Forms.CheckBox();
            this.third_activationFunctionButton = new System.Windows.Forms.Button();
            this.third_neuronsCount = new System.Windows.Forms.NumericUpDown();
            this.activationFunctionMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.train_button = new System.Windows.Forms.Button();
            this.compress_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.first_neuronsCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.second_neuronsCont)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.third_neuronsCount)).BeginInit();
            this.SuspendLayout();
            // 
            // first_biasCheckBox
            // 
            this.first_biasCheckBox.AutoSize = true;
            this.first_biasCheckBox.Checked = true;
            this.first_biasCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.first_biasCheckBox.Enabled = false;
            this.first_biasCheckBox.Location = new System.Drawing.Point(442, 58);
            this.first_biasCheckBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.first_biasCheckBox.Name = "first_biasCheckBox";
            this.first_biasCheckBox.Size = new System.Drawing.Size(22, 21);
            this.first_biasCheckBox.TabIndex = 12;
            this.first_biasCheckBox.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(431, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Bias";
            // 
            // first_activationFunctionButton
            // 
            this.first_activationFunctionButton.Location = new System.Drawing.Point(244, 49);
            this.first_activationFunctionButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.first_activationFunctionButton.Name = "first_activationFunctionButton";
            this.first_activationFunctionButton.Size = new System.Drawing.Size(169, 37);
            this.first_activationFunctionButton.TabIndex = 10;
            this.first_activationFunctionButton.Text = "ActivationSigmoid";
            this.first_activationFunctionButton.UseVisualStyleBackColor = true;
            this.first_activationFunctionButton.Click += new System.EventHandler(this.first_activationFunctionButton_Click);
            // 
            // first_neuronsCount
            // 
            this.first_neuronsCount.Enabled = false;
            this.first_neuronsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.first_neuronsCount.Location = new System.Drawing.Point(119, 53);
            this.first_neuronsCount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.first_neuronsCount.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.first_neuronsCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.first_neuronsCount.Name = "first_neuronsCount";
            this.first_neuronsCount.Size = new System.Drawing.Size(102, 28);
            this.first_neuronsCount.TabIndex = 9;
            this.first_neuronsCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.first_neuronsCount.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(262, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Activation function";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(95, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Number of neurons";
            // 
            // loadTrainData_button
            // 
            this.loadTrainData_button.Location = new System.Drawing.Point(329, 200);
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
            this.trainDataLoaded_label.Location = new System.Drawing.Point(126, 205);
            this.trainDataLoaded_label.Name = "trainDataLoaded_label";
            this.trainDataLoaded_label.Size = new System.Drawing.Size(195, 20);
            this.trainDataLoaded_label.TabIndex = 14;
            this.trainDataLoaded_label.Text = "Train data was not loaded!";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(126, 246);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(191, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "Test data was not loaded!";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(329, 241);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 31);
            this.button1.TabIndex = 15;
            this.button1.Text = "Load test data";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // second_biasCheckBox
            // 
            this.second_biasCheckBox.AutoSize = true;
            this.second_biasCheckBox.Location = new System.Drawing.Point(442, 103);
            this.second_biasCheckBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.second_biasCheckBox.Name = "second_biasCheckBox";
            this.second_biasCheckBox.Size = new System.Drawing.Size(22, 21);
            this.second_biasCheckBox.TabIndex = 19;
            this.second_biasCheckBox.UseVisualStyleBackColor = true;
            // 
            // second_activationFunctionButton
            // 
            this.second_activationFunctionButton.Location = new System.Drawing.Point(244, 94);
            this.second_activationFunctionButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.second_activationFunctionButton.Name = "second_activationFunctionButton";
            this.second_activationFunctionButton.Size = new System.Drawing.Size(169, 37);
            this.second_activationFunctionButton.TabIndex = 18;
            this.second_activationFunctionButton.Text = "ActivationSigmoid";
            this.second_activationFunctionButton.UseVisualStyleBackColor = true;
            this.second_activationFunctionButton.Click += new System.EventHandler(this.second_activationFunctionButton_Click);
            // 
            // second_neuronsCont
            // 
            this.second_neuronsCont.Enabled = false;
            this.second_neuronsCont.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.second_neuronsCont.Location = new System.Drawing.Point(119, 98);
            this.second_neuronsCont.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.second_neuronsCont.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.second_neuronsCont.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.second_neuronsCont.Name = "second_neuronsCont";
            this.second_neuronsCont.Size = new System.Drawing.Size(102, 28);
            this.second_neuronsCont.TabIndex = 17;
            this.second_neuronsCont.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.second_neuronsCont.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // third_biasCheckBox
            // 
            this.third_biasCheckBox.AutoSize = true;
            this.third_biasCheckBox.Enabled = false;
            this.third_biasCheckBox.Location = new System.Drawing.Point(442, 148);
            this.third_biasCheckBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.third_biasCheckBox.Name = "third_biasCheckBox";
            this.third_biasCheckBox.Size = new System.Drawing.Size(22, 21);
            this.third_biasCheckBox.TabIndex = 22;
            this.third_biasCheckBox.UseVisualStyleBackColor = true;
            // 
            // third_activationFunctionButton
            // 
            this.third_activationFunctionButton.Location = new System.Drawing.Point(244, 139);
            this.third_activationFunctionButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.third_activationFunctionButton.Name = "third_activationFunctionButton";
            this.third_activationFunctionButton.Size = new System.Drawing.Size(169, 37);
            this.third_activationFunctionButton.TabIndex = 21;
            this.third_activationFunctionButton.Text = "ActivationSigmoid";
            this.third_activationFunctionButton.UseVisualStyleBackColor = true;
            this.third_activationFunctionButton.Click += new System.EventHandler(this.third_activationFunctionButton_Click);
            // 
            // third_neuronsCount
            // 
            this.third_neuronsCount.Enabled = false;
            this.third_neuronsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.third_neuronsCount.Location = new System.Drawing.Point(119, 143);
            this.third_neuronsCount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.third_neuronsCount.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.third_neuronsCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.third_neuronsCount.Name = "third_neuronsCount";
            this.third_neuronsCount.Size = new System.Drawing.Size(102, 28);
            this.third_neuronsCount.TabIndex = 20;
            this.third_neuronsCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.third_neuronsCount.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
            // 
            // activationFunctionMenuStrip
            // 
            this.activationFunctionMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.activationFunctionMenuStrip.Name = "contextMenuStrip1";
            this.activationFunctionMenuStrip.Size = new System.Drawing.Size(61, 4);
            this.activationFunctionMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.activationFunctionMenuStrip_ItemClicked);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 20);
            this.label5.TabIndex = 24;
            this.label5.Text = "1st layer";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 20);
            this.label6.TabIndex = 25;
            this.label6.Text = "3rd layer";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 20);
            this.label7.TabIndex = 26;
            this.label7.Text = "Hidden layer";
            // 
            // train_button
            // 
            this.train_button.BackColor = System.Drawing.Color.Red;
            this.train_button.Location = new System.Drawing.Point(16, 205);
            this.train_button.Name = "train_button";
            this.train_button.Size = new System.Drawing.Size(104, 61);
            this.train_button.TabIndex = 27;
            this.train_button.Text = "Train";
            this.train_button.UseVisualStyleBackColor = false;
            this.train_button.Click += new System.EventHandler(this.train_button_Click);
            // 
            // compress_button
            // 
            this.compress_button.BackColor = System.Drawing.Color.Red;
            this.compress_button.Location = new System.Drawing.Point(16, 278);
            this.compress_button.Name = "compress_button";
            this.compress_button.Size = new System.Drawing.Size(455, 38);
            this.compress_button.TabIndex = 28;
            this.compress_button.Text = "Compress picture";
            this.compress_button.UseVisualStyleBackColor = false;
            this.compress_button.Click += new System.EventHandler(this.button2_Click);
            // 
            // PictureCompressionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 324);
            this.Controls.Add(this.compress_button);
            this.Controls.Add(this.train_button);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.third_biasCheckBox);
            this.Controls.Add(this.third_activationFunctionButton);
            this.Controls.Add(this.third_neuronsCount);
            this.Controls.Add(this.second_biasCheckBox);
            this.Controls.Add(this.second_activationFunctionButton);
            this.Controls.Add(this.second_neuronsCont);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.trainDataLoaded_label);
            this.Controls.Add(this.loadTrainData_button);
            this.Controls.Add(this.first_biasCheckBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.first_activationFunctionButton);
            this.Controls.Add(this.first_neuronsCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PictureCompressionForm";
            this.Text = "PictureCompressionForm";
            this.Load += new System.EventHandler(this.PictureCompressionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.first_neuronsCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.second_neuronsCont)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.third_neuronsCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox first_biasCheckBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button first_activationFunctionButton;
        private System.Windows.Forms.NumericUpDown first_neuronsCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button loadTrainData_button;
        private System.Windows.Forms.Label trainDataLoaded_label;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.CheckBox second_biasCheckBox;
        private System.Windows.Forms.Button second_activationFunctionButton;
        private System.Windows.Forms.NumericUpDown second_neuronsCont;
        private System.Windows.Forms.CheckBox third_biasCheckBox;
        private System.Windows.Forms.Button third_activationFunctionButton;
        private System.Windows.Forms.NumericUpDown third_neuronsCount;
        private System.Windows.Forms.ContextMenuStrip activationFunctionMenuStrip;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button train_button;
        private System.Windows.Forms.Button compress_button;
    }
}