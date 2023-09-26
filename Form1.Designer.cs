
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
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            ((System.ComponentModel.ISupportInitialize)Canvas).BeginInit();
            SuspendLayout();
            // 
            // Canvas
            // 
            Canvas.BackColor = SystemColors.Window;
            Canvas.Location = new Point(0, 0);
            Canvas.Name = "Canvas";
            Canvas.Size = new Size(827, 543);
            Canvas.TabIndex = 0;
            Canvas.TabStop = false;
            Canvas.Click += Canvas_Click;
            // 
            // Button1
            // 
            Button1.Location = new Point(881, 26);
            Button1.Name = "Button1";
            Button1.Size = new Size(135, 36);
            Button1.TabIndex = 1;
            Button1.Text = "Задание 1";
            Button1.UseVisualStyleBackColor = true;
            Button1.Click += Button1_Click;
            // 
            // Button2
            // 
            Button2.Location = new Point(881, 96);
            Button2.Name = "Button2";
            Button2.Size = new Size(135, 36);
            Button2.TabIndex = 2;
            Button2.Text = "Задание 2";
            Button2.UseVisualStyleBackColor = true;
            Button2.Click += Button2_Click;
            // 
            // Button3
            // 
            Button3.Location = new Point(881, 163);
            Button3.Name = "Button3";
            Button3.Size = new Size(135, 36);
            Button3.TabIndex = 3;
            Button3.Text = "Задание 3";
            Button3.UseVisualStyleBackColor = true;
            Button3.Click += Button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(881, 233);
            button4.Name = "button4";
            button4.Size = new Size(135, 36);
            button4.TabIndex = 4;
            button4.Text = "Рисовать";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(881, 299);
            button5.Name = "button5";
            button5.Size = new Size(135, 36);
            button5.TabIndex = 5;
            button5.Text = "Залить";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(881, 364);
            button6.Name = "button6";
            button6.Size = new Size(135, 48);
            button6.TabIndex = 6;
            button6.Text = "Выделить границы";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Location = new Point(881, 436);
            button7.Name = "button7";
            button7.Size = new Size(135, 51);
            button7.TabIndex = 7;
            button7.Text = "Загрузить изображение";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1064, 541);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(Button3);
            Controls.Add(Button2);
            Controls.Add(Button1);
            Controls.Add(Canvas);
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
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
    }
}