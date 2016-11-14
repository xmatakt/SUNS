namespace SOMnetwork
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.gridWidth_numeUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gridHeight_numeUpDown = new System.Windows.Forms.NumericUpDown();
            this.greyRadio = new System.Windows.Forms.RadioButton();
            this.colorRadio = new System.Windows.Forms.RadioButton();
            this.animationChckBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.iterations_UpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.groupsCount_UpDown = new System.Windows.Forms.NumericUpDown();
            this.trainButton = new System.Windows.Forms.Button();
            this.stopContinueBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.frameRate_upDown = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridWidth_numeUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridHeight_numeUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iterations_UpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupsCount_UpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frameRate_upDown)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(750, 604);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // gridWidth_numeUpDown
            // 
            this.gridWidth_numeUpDown.Location = new System.Drawing.Point(780, 33);
            this.gridWidth_numeUpDown.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.gridWidth_numeUpDown.Name = "gridWidth_numeUpDown";
            this.gridWidth_numeUpDown.Size = new System.Drawing.Size(97, 22);
            this.gridWidth_numeUpDown.TabIndex = 2;
            this.gridWidth_numeUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(777, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Grid width:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(777, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Grid height:";
            // 
            // gridHeight_numeUpDown
            // 
            this.gridHeight_numeUpDown.Location = new System.Drawing.Point(780, 78);
            this.gridHeight_numeUpDown.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.gridHeight_numeUpDown.Name = "gridHeight_numeUpDown";
            this.gridHeight_numeUpDown.Size = new System.Drawing.Size(97, 22);
            this.gridHeight_numeUpDown.TabIndex = 4;
            this.gridHeight_numeUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // greyRadio
            // 
            this.greyRadio.AutoSize = true;
            this.greyRadio.Location = new System.Drawing.Point(784, 287);
            this.greyRadio.Name = "greyRadio";
            this.greyRadio.Size = new System.Drawing.Size(97, 21);
            this.greyRadio.TabIndex = 6;
            this.greyRadio.TabStop = true;
            this.greyRadio.Text = "Grey scale";
            this.greyRadio.UseVisualStyleBackColor = true;
            // 
            // colorRadio
            // 
            this.colorRadio.AutoSize = true;
            this.colorRadio.Location = new System.Drawing.Point(784, 314);
            this.colorRadio.Name = "colorRadio";
            this.colorRadio.Size = new System.Drawing.Size(99, 21);
            this.colorRadio.TabIndex = 7;
            this.colorRadio.TabStop = true;
            this.colorRadio.Text = "Color scale";
            this.colorRadio.UseVisualStyleBackColor = true;
            this.colorRadio.CheckedChanged += new System.EventHandler(this.colorRadio_CheckedChanged);
            // 
            // animationChckBox
            // 
            this.animationChckBox.AutoSize = true;
            this.animationChckBox.Location = new System.Drawing.Point(780, 207);
            this.animationChckBox.Name = "animationChckBox";
            this.animationChckBox.Size = new System.Drawing.Size(115, 21);
            this.animationChckBox.TabIndex = 8;
            this.animationChckBox.Text = "Show training";
            this.animationChckBox.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(779, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Iterations:";
            // 
            // iterations_UpDown
            // 
            this.iterations_UpDown.Location = new System.Drawing.Point(782, 126);
            this.iterations_UpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.iterations_UpDown.Name = "iterations_UpDown";
            this.iterations_UpDown.Size = new System.Drawing.Size(97, 22);
            this.iterations_UpDown.TabIndex = 9;
            this.iterations_UpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(777, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Char. count:";
            // 
            // groupsCount_UpDown
            // 
            this.groupsCount_UpDown.Location = new System.Drawing.Point(780, 176);
            this.groupsCount_UpDown.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.groupsCount_UpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.groupsCount_UpDown.Name = "groupsCount_UpDown";
            this.groupsCount_UpDown.Size = new System.Drawing.Size(97, 22);
            this.groupsCount_UpDown.TabIndex = 11;
            this.groupsCount_UpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.groupsCount_UpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // trainButton
            // 
            this.trainButton.Location = new System.Drawing.Point(788, 350);
            this.trainButton.Name = "trainButton";
            this.trainButton.Size = new System.Drawing.Size(93, 32);
            this.trainButton.TabIndex = 13;
            this.trainButton.Text = "Train";
            this.trainButton.UseVisualStyleBackColor = true;
            this.trainButton.Click += new System.EventHandler(this.trainButton_Click);
            // 
            // stopContinueBtn
            // 
            this.stopContinueBtn.Location = new System.Drawing.Point(788, 388);
            this.stopContinueBtn.Name = "stopContinueBtn";
            this.stopContinueBtn.Size = new System.Drawing.Size(93, 32);
            this.stopContinueBtn.TabIndex = 14;
            this.stopContinueBtn.Text = "Stop";
            this.stopContinueBtn.UseVisualStyleBackColor = true;
            this.stopContinueBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(777, 239);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 17);
            this.label5.TabIndex = 16;
            this.label5.Text = "Frame rate:";
            // 
            // frameRate_upDown
            // 
            this.frameRate_upDown.Location = new System.Drawing.Point(780, 259);
            this.frameRate_upDown.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.frameRate_upDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.frameRate_upDown.Name = "frameRate_upDown";
            this.frameRate_upDown.Size = new System.Drawing.Size(97, 22);
            this.frameRate_upDown.TabIndex = 15;
            this.frameRate_upDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.frameRate_upDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(777, 578);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 17);
            this.label6.TabIndex = 17;
            this.label6.Text = "Elapsed time:";
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Location = new System.Drawing.Point(799, 601);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(12, 17);
            this.timeLabel.TabIndex = 18;
            this.timeLabel.Text = " ";
            this.timeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 627);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.frameRate_upDown);
            this.Controls.Add(this.stopContinueBtn);
            this.Controls.Add(this.trainButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupsCount_UpDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.iterations_UpDown);
            this.Controls.Add(this.animationChckBox);
            this.Controls.Add(this.colorRadio);
            this.Controls.Add(this.greyRadio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gridHeight_numeUpDown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gridWidth_numeUpDown);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridWidth_numeUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridHeight_numeUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iterations_UpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupsCount_UpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frameRate_upDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NumericUpDown gridWidth_numeUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown gridHeight_numeUpDown;
        private System.Windows.Forms.RadioButton greyRadio;
        private System.Windows.Forms.RadioButton colorRadio;
        private System.Windows.Forms.CheckBox animationChckBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown iterations_UpDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown groupsCount_UpDown;
        private System.Windows.Forms.Button trainButton;
        private System.Windows.Forms.Button stopContinueBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown frameRate_upDown;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label timeLabel;

    }
}

