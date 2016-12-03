namespace FaceRecognition
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
            this.trainBtn = new System.Windows.Forms.Button();
            this.testBtn = new System.Windows.Forms.Button();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // trainBtn
            // 
            this.trainBtn.BackColor = System.Drawing.SystemColors.Control;
            this.trainBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.trainBtn.Location = new System.Drawing.Point(12, 488);
            this.trainBtn.Name = "trainBtn";
            this.trainBtn.Size = new System.Drawing.Size(113, 30);
            this.trainBtn.TabIndex = 1;
            this.trainBtn.Text = "Train";
            this.trainBtn.UseVisualStyleBackColor = false;
            this.trainBtn.Click += new System.EventHandler(this.trainBtn_Click);
            // 
            // testBtn
            // 
            this.testBtn.BackColor = System.Drawing.SystemColors.Control;
            this.testBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.testBtn.Location = new System.Drawing.Point(131, 488);
            this.testBtn.Name = "testBtn";
            this.testBtn.Size = new System.Drawing.Size(111, 30);
            this.testBtn.TabIndex = 2;
            this.testBtn.Text = "Test";
            this.testBtn.UseVisualStyleBackColor = false;
            this.testBtn.Click += new System.EventHandler(this.testBtn_Click);
            // 
            // richTextBox
            // 
            this.richTextBox.Location = new System.Drawing.Point(12, 12);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(230, 470);
            this.richTextBox.TabIndex = 4;
            this.richTextBox.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(255, 525);
            this.Controls.Add(this.richTextBox);
            this.Controls.Add(this.testBtn);
            this.Controls.Add(this.trainBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "FaceRecognition";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button trainBtn;
        private System.Windows.Forms.Button testBtn;
        private System.Windows.Forms.RichTextBox richTextBox;

    }
}

