namespace Graph2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Canvas = new PictureBox();
            Button1 = new Button();
            Button2 = new Button();
            Button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)Canvas).BeginInit();
            SuspendLayout();
            // 
            // Canvas
            // 
            Canvas.BackColor = SystemColors.Window;
            Canvas.Location = new Point(0, 0);
            Canvas.Margin = new Padding(3, 2, 3, 2);
            Canvas.Name = "Canvas";
            Canvas.Size = new Size(724, 407);
            Canvas.TabIndex = 0;
            Canvas.TabStop = false;
            Canvas.Click += Canvas_Click;
            // 
            // Button1
            // 
            Button1.Location = new Point(771, 46);
            Button1.Margin = new Padding(3, 2, 3, 2);
            Button1.Name = "Button1";
            Button1.Size = new Size(118, 27);
            Button1.TabIndex = 1;
            Button1.Text = "Задание 1";
            Button1.UseVisualStyleBackColor = true;
            Button1.Click += Button1_Click;
            // 
            // Button2
            // 
            Button2.Location = new Point(771, 118);
            Button2.Margin = new Padding(3, 2, 3, 2);
            Button2.Name = "Button2";
            Button2.Size = new Size(118, 27);
            Button2.TabIndex = 2;
            Button2.Text = "Задание 2";
            Button2.UseVisualStyleBackColor = true;
            Button2.Click += Button2_Click;
            // 
            // Button3
            // 
            Button3.Location = new Point(771, 190);
            Button3.Margin = new Padding(3, 2, 3, 2);
            Button3.Name = "Button3";
            Button3.Size = new Size(118, 27);
            Button3.TabIndex = 3;
            Button3.Text = "Задание 3";
            Button3.UseVisualStyleBackColor = true;
            Button3.Click += Button3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(931, 406);
            Controls.Add(Button3);
            Controls.Add(Button2);
            Controls.Add(Button1);
            Controls.Add(Canvas);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Графика. Лабораторная 2";
            ((System.ComponentModel.ISupportInitialize)Canvas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox Canvas;
        private Button Button1;
        private Button Button2;
        private Button Button3;
    }
}