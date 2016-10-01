namespace zadanie_1.Forms
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
            ((System.ComponentModel.ISupportInitialize)(this.neuronsCount_1)).BeginInit();
            this.SuspendLayout();
            // 
            // addLayerButton
            // 
            this.addLayerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.addLayerButton.Location = new System.Drawing.Point(51, 71);
            this.addLayerButton.Name = "addLayerButton";
            this.addLayerButton.Size = new System.Drawing.Size(52, 28);
            this.addLayerButton.TabIndex = 0;
            this.addLayerButton.Text = "+";
            this.addLayerButton.UseVisualStyleBackColor = true;
            this.addLayerButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Number of neurons";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(189, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Activation function";
            // 
            // neuronsCount_1
            // 
            this.neuronsCount_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.neuronsCount_1.Location = new System.Drawing.Point(51, 35);
            this.neuronsCount_1.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.neuronsCount_1.Name = "neuronsCount_1";
            this.neuronsCount_1.Size = new System.Drawing.Size(91, 24);
            this.neuronsCount_1.TabIndex = 3;
            this.neuronsCount_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.neuronsCount_1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // activationFunctionMenuStrip
            // 
            this.activationFunctionMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.activationFunctionMenuStrip.Name = "contextMenuStrip1";
            this.activationFunctionMenuStrip.Size = new System.Drawing.Size(67, 4);
            this.activationFunctionMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // activationFunctionButton_1
            // 
            this.activationFunctionButton_1.Location = new System.Drawing.Point(162, 34);
            this.activationFunctionButton_1.Name = "activationFunctionButton_1";
            this.activationFunctionButton_1.Size = new System.Drawing.Size(150, 25);
            this.activationFunctionButton_1.TabIndex = 4;
            this.activationFunctionButton_1.Text = "ActivationSigmoid";
            this.activationFunctionButton_1.UseVisualStyleBackColor = true;
            this.activationFunctionButton_1.Click += new System.EventHandler(this.activationFunctionButton_1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(335, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Bias";
            // 
            // biasCheckBox_1
            // 
            this.biasCheckBox_1.AutoSize = true;
            this.biasCheckBox_1.Location = new System.Drawing.Point(344, 37);
            this.biasCheckBox_1.Name = "biasCheckBox_1";
            this.biasCheckBox_1.Size = new System.Drawing.Size(18, 17);
            this.biasCheckBox_1.TabIndex = 6;
            this.biasCheckBox_1.UseVisualStyleBackColor = true;
            // 
            // removeLayerButton
            // 
            this.removeLayerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.removeLayerButton.Location = new System.Drawing.Point(109, 71);
            this.removeLayerButton.Name = "removeLayerButton";
            this.removeLayerButton.Size = new System.Drawing.Size(33, 28);
            this.removeLayerButton.TabIndex = 7;
            this.removeLayerButton.Text = "-";
            this.removeLayerButton.UseVisualStyleBackColor = true;
            this.removeLayerButton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // generateNetworkButton
            // 
            this.generateNetworkButton.Location = new System.Drawing.Point(206, 71);
            this.generateNetworkButton.Name = "generateNetworkButton";
            this.generateNetworkButton.Size = new System.Drawing.Size(156, 28);
            this.generateNetworkButton.TabIndex = 8;
            this.generateNetworkButton.Text = "Generate network";
            this.generateNetworkButton.UseVisualStyleBackColor = true;
            // 
            // MLPNetworkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 114);
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
            this.Name = "MLPNetworkForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MLPNetworkForm";
            this.Load += new System.EventHandler(this.MLPNetworkForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.neuronsCount_1)).EndInit();
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
    }
}