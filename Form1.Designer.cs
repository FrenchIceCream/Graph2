
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
            trackBar1 = new TrackBar();
            p1y = new TextBox();
            p1x = new TextBox();
            p2y = new TextBox();
            p2x = new TextBox();
            p3y = new TextBox();
            p3x = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)Canvas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
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
            Canvas.MouseDown += Canvas_MouseDown;
            Canvas.MouseMove += Canvas_MouseMove;
            // 
            // Button1
            // 
            Button1.Location = new Point(881, 27);
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
            Button3.Location = new Point(881, 198);
            Button3.Name = "Button3";
            Button3.Size = new Size(135, 36);
            Button3.TabIndex = 3;
            Button3.Text = "Задание 3";
            Button3.UseVisualStyleBackColor = true;
            Button3.Click += Button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(881, 240);
            button4.Name = "button4";
            button4.Size = new Size(135, 36);
            button4.TabIndex = 4;
            button4.Text = "Рисовать";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(881, 281);
            button5.Name = "button5";
            button5.Size = new Size(135, 36);
            button5.TabIndex = 5;
            button5.Text = "Залить";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(881, 323);
            button6.Name = "button6";
            button6.Size = new Size(135, 48);
            button6.TabIndex = 6;
            button6.Text = "Выделить границы";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Location = new Point(881, 376);
            button7.Name = "button7";
            button7.Size = new Size(135, 51);
            button7.TabIndex = 7;
            button7.Text = "Загрузить изображение";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(881, 139);
            trackBar1.Margin = new Padding(3, 4, 3, 4);
            trackBar1.Maximum = 1;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(135, 56);
            trackBar1.TabIndex = 8;
            trackBar1.Scroll += trackBar1_Scroll;
            // 
            // p1y
            // 
            p1y.Location = new Point(962, 433);
            p1y.Name = "p1y";
            p1y.Size = new Size(54, 27);
            p1y.TabIndex = 12;
            // 
            // p1x
            // 
            p1x.Location = new Point(881, 433);
            p1x.Name = "p1x";
            p1x.Size = new Size(54, 27);
            p1x.TabIndex = 11;
            // 
            // p2y
            // 
            p2y.Location = new Point(962, 466);
            p2y.Name = "p2y";
            p2y.Size = new Size(54, 27);
            p2y.TabIndex = 14;
            // 
            // p2x
            // 
            p2x.Location = new Point(881, 466);
            p2x.Name = "p2x";
            p2x.Size = new Size(54, 27);
            p2x.TabIndex = 13;
            // 
            // p3y
            // 
            p3y.Location = new Point(962, 499);
            p3y.Name = "p3y";
            p3y.Size = new Size(54, 27);
            p3y.TabIndex = 16;
            // 
            // p3x
            // 
            p3x.Location = new Point(881, 499);
            p3x.Name = "p3x";
            p3x.Size = new Size(54, 27);
            p3x.TabIndex = 15;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(833, 436);
            label1.Name = "label1";
            label1.Size = new Size(28, 20);
            label1.TabIndex = 17;
            label1.Text = "P1:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(833, 469);
            label2.Name = "label2";
            label2.Size = new Size(28, 20);
            label2.TabIndex = 18;
            label2.Text = "P2:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(833, 502);
            label3.Name = "label3";
            label3.Size = new Size(28, 20);
            label3.TabIndex = 19;
            label3.Text = "P3:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1064, 541);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(p3y);
            Controls.Add(p3x);
            Controls.Add(p2y);
            Controls.Add(p2x);
            Controls.Add(p1y);
            Controls.Add(p1x);
            Controls.Add(trackBar1);
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
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private TrackBar trackBar1;
        private TextBox p1y;
        private TextBox p1x;
        private TextBox p2y;
        private TextBox p2x;
        private TextBox p3y;
        private TextBox p3x;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}