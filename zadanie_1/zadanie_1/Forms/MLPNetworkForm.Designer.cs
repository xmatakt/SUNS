﻿namespace zadanie_1.Forms
{
    partial class MLPNetworkForm
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
            this.addLayerButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.neuronsCount_1 = new System.Windows.Forms.NumericUpDown();
            this.activationFunctionMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.activationFunctionButton_1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.biasCheckBox_1 = new System.Windows.Forms.CheckBox();
            this.removeLayerButton = new System.Windows.Forms.Button();
            this.generateNetworkButton = new System.Windows.Forms.Button();
            this.showLogButton = new System.Windows.Forms.Button();
            this.errorGraphButton = new System.Windows.Forms.Button();
            this.requiredErrorUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.maxCountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.neuronsCount_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.requiredErrorUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxCountNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // addLayerButton
            // 
            this.addLayerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.addLayerButton.Location = new System.Drawing.Point(18, 100);
            this.addLayerButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.addLayerButton.Name = "addLayerButton";
            this.addLayerButton.Size = new System.Drawing.Size(99, 35);
            this.addLayerButton.TabIndex = 0;
            this.addLayerButton.Text = "+";
            this.addLayerButton.UseVisualStyleBackColor = true;
            this.addLayerButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Number of neurons";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(226, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Activation function";
            // 
            // neuronsCount_1
            // 
            this.neuronsCount_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.neuronsCount_1.Location = new System.Drawing.Point(71, 188);
            this.neuronsCount_1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.neuronsCount_1.Maximum = new decimal(new int[] {
            55,
            0,
            0,
            0});
            this.neuronsCount_1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.neuronsCount_1.Name = "neuronsCount_1";
            this.neuronsCount_1.Size = new System.Drawing.Size(102, 28);
            this.neuronsCount_1.TabIndex = 3;
            this.neuronsCount_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.neuronsCount_1.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // activationFunctionMenuStrip
            // 
            this.activationFunctionMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.activationFunctionMenuStrip.Name = "contextMenuStrip1";
            this.activationFunctionMenuStrip.Size = new System.Drawing.Size(199, 37);
            this.activationFunctionMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // activationFunctionButton_1
            // 
            this.activationFunctionButton_1.Location = new System.Drawing.Point(196, 186);
            this.activationFunctionButton_1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.activationFunctionButton_1.Name = "activationFunctionButton_1";
            this.activationFunctionButton_1.Size = new System.Drawing.Size(169, 31);
            this.activationFunctionButton_1.TabIndex = 4;
            this.activationFunctionButton_1.Text = "ActivationSigmoid";
            this.activationFunctionButton_1.UseVisualStyleBackColor = true;
            this.activationFunctionButton_1.Click += new System.EventHandler(this.activationFunctionButton_1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(390, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Bias";
            // 
            // biasCheckBox_1
            // 
            this.biasCheckBox_1.AutoSize = true;
            this.biasCheckBox_1.Location = new System.Drawing.Point(400, 190);
            this.biasCheckBox_1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.biasCheckBox_1.Name = "biasCheckBox_1";
            this.biasCheckBox_1.Size = new System.Drawing.Size(22, 21);
            this.biasCheckBox_1.TabIndex = 6;
            this.biasCheckBox_1.UseVisualStyleBackColor = true;
            // 
            // removeLayerButton
            // 
            this.removeLayerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.removeLayerButton.Location = new System.Drawing.Point(135, 100);
            this.removeLayerButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.removeLayerButton.Name = "removeLayerButton";
            this.removeLayerButton.Size = new System.Drawing.Size(104, 35);
            this.removeLayerButton.TabIndex = 7;
            this.removeLayerButton.Text = "-";
            this.removeLayerButton.UseVisualStyleBackColor = true;
            this.removeLayerButton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // generateNetworkButton
            // 
            this.generateNetworkButton.Location = new System.Drawing.Point(272, 16);
            this.generateNetworkButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.generateNetworkButton.Name = "generateNetworkButton";
            this.generateNetworkButton.Size = new System.Drawing.Size(176, 35);
            this.generateNetworkButton.TabIndex = 8;
            this.generateNetworkButton.Text = "Generate network";
            this.generateNetworkButton.UseVisualStyleBackColor = true;
            this.generateNetworkButton.Click += new System.EventHandler(this.generateNetworkButton_Click);
            // 
            // showLogButton
            // 
            this.showLogButton.Enabled = false;
            this.showLogButton.Location = new System.Drawing.Point(272, 60);
            this.showLogButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.showLogButton.Name = "showLogButton";
            this.showLogButton.Size = new System.Drawing.Size(176, 32);
            this.showLogButton.TabIndex = 10;
            this.showLogButton.Text = "Show log";
            this.showLogButton.UseVisualStyleBackColor = true;
            // 
            // errorGraphButton
            // 
            this.errorGraphButton.Enabled = false;
            this.errorGraphButton.Location = new System.Drawing.Point(272, 100);
            this.errorGraphButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.errorGraphButton.Name = "errorGraphButton";
            this.errorGraphButton.Size = new System.Drawing.Size(176, 35);
            this.errorGraphButton.TabIndex = 11;
            this.errorGraphButton.Text = "Show error graph";
            this.errorGraphButton.UseVisualStyleBackColor = true;
            this.errorGraphButton.Click += new System.EventHandler(this.errorGraphButton_Click);
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
            this.requiredErrorUpDown.Location = new System.Drawing.Point(154, 60);
            this.requiredErrorUpDown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
            this.requiredErrorUpDown.Size = new System.Drawing.Size(84, 26);
            this.requiredErrorUpDown.TabIndex = 15;
            this.requiredErrorUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.requiredErrorUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label4.Location = new System.Drawing.Point(14, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "Required error:";
            // 
            // maxCountNumericUpDown
            // 
            this.maxCountNumericUpDown.Location = new System.Drawing.Point(154, 21);
            this.maxCountNumericUpDown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
            this.maxCountNumericUpDown.Size = new System.Drawing.Size(84, 26);
            this.maxCountNumericUpDown.TabIndex = 13;
            this.maxCountNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.maxCountNumericUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Max epoch count:";
            // 
            // MLPNetworkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 239);
            this.Controls.Add(this.requiredErrorUpDown);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.maxCountNumericUpDown);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.errorGraphButton);
            this.Controls.Add(this.showLogButton);
            this.Controls.Add(this.generateNetworkButton);
            this.Controls.Add(this.removeLayerButton);
            this.Controls.Add(this.biasCheckBox_1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.activationFunctionButton_1);
            this.Controls.Add(this.neuronsCount_1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addLayerButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MLPNetworkForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MLPNetworkForm";
            this.Load += new System.EventHandler(this.MLPNetworkForm_Load);
            this.Shown += new System.EventHandler(this.MLPNetworkForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.neuronsCount_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.requiredErrorUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxCountNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addLayerButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown neuronsCount_1;
        private System.Windows.Forms.ContextMenuStrip activationFunctionMenuStrip;
        private System.Windows.Forms.Button activationFunctionButton_1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox biasCheckBox_1;
        private System.Windows.Forms.Button removeLayerButton;
        private System.Windows.Forms.Button generateNetworkButton;
        private System.Windows.Forms.Button showLogButton;
        private System.Windows.Forms.Button errorGraphButton;
        private System.Windows.Forms.NumericUpDown requiredErrorUpDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown maxCountNumericUpDown;
        private System.Windows.Forms.Label label5;
    }
}