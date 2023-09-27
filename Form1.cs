using System.Diagnostics;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace Graph2
{
    public partial class Form1 : Form
    {
        private bool isSecondActive = false;
        private Point? firstPoint = null;
        private Graphics g;

        bool draw_mode = false;
        bool fill_mode = false;
        bool border_mode = false;
        Color borderColor = Color.Black;
        Bitmap texture = null;
        public Form1()
        {
            InitializeComponent();
            g = Canvas.CreateGraphics();
            p1x.Text = "100";
            p2x.Text = "350";
            p3x.Text = "600";
            p1y.Text = "400";
            p2y.Text = "100";
            p3y.Text = "400";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            isSecondActive = false;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            if (!isSecondActive)
            {
                isSecondActive = true;
            }
            else
            {
                isSecondActive = false;
                firstPoint = null;

            }
        }

        private void DrawPoint(bool steep, int x, int y, float a)
        {
            Pen pen = new Pen(Color.FromArgb((int)(a * 255), 255, 0, 0), 1);
            if (steep)
            {
                g.DrawRectangle(pen, new Rectangle(y, x, 1, 1));

            }
            else
            {
                g.DrawRectangle(pen, new Rectangle(x, y, 1, 1));

            }

        }

        private void Swap(ref int x1, ref int x2)
        {
            int x = x1; x1 = x2; x2 = x;
        }

        private void WuLine(int x0, int y0, int x1, int y1)
        {
            var steep = Math.Abs(y1 - y0) > Math.Abs(x1 - x0);
            if (steep)
            {
                Swap(ref x0, ref y0);
                Swap(ref x1, ref y1);
            }
            if (x0 > x1)
            {
                Swap(ref x0, ref x1);
                Swap(ref y0, ref y1);
            }

            DrawPoint(steep, x0, y0, 1); // ��� ������� ��������� ������ ���������� ������� � ����������� �� ���������� steep
            DrawPoint(steep, x1, y1, 1); // ��������� �������� � ������������� � ����� �������
            float dx = x1 - x0;
            float dy = y1 - y0;
            float gradient = dy / dx;
            float y = y0 + gradient;
            for (var x = x0 + 1; x <= x1 - 1; x++)
            {
                DrawPoint(steep, x, (int)y, 1 - (y - (int)y));
                DrawPoint(steep, x, (int)y + 1, y - (int)y);
                y += gradient;
            }
        }

        private void drawLine(int x1, int y1, int x2, int y2)
        {
            Pen pen_r = new Pen(Color.Red, 1);

            int sx = x1 > x2 ? -1 : 1;
            int sy = y1 > y2 ? -1 : 1;

            int dy = Math.Abs(y2 - y1);
            int dx = Math.Abs(x2 - x1);
            bool gradient = Math.Abs(dy / (double)dx) <= 1;
            if (gradient)
            {


                int dStart = 2 * dy - dx;


                int xStart = x1;
                int yStart = y1;
                for (int i = 0; i < dx; i++)
                {
                    g.DrawRectangle(pen_r, new Rectangle(xStart, yStart, 1, 1));
                    if (dStart < 0)
                    {
                        dStart += dy * 2;
                    }
                    else
                    {
                        yStart += sy;
                        dStart += 2 * (dy - dx);
                    }


                    xStart += sx;
                }


            }
            else
            {


                int dStart = 2 * dx - dy;
                int xStart = x1;
                int yStart = y1;
                for (int i = 0; i < dy; i++)

                {
                    g.DrawRectangle(pen_r, new Rectangle(xStart, yStart, 1, 1));
                    if (dStart < 0)
                    {
                        dStart += dx * 2;
                    }
                    else
                    {
                        xStart += sx;
                        dStart += 2 * (dx - dy);
                    }


                    yStart += sy;
                }
            }
        }

        private void TryDrawLine(Point newPoint)
        {
            if (firstPoint == null)
            {
                firstPoint = newPoint;
                return;
            }
            if (trackBar1.Value == 0)
            {
                WuLine(firstPoint.Value.X, firstPoint.Value.Y, newPoint.X, newPoint.Y);
            }
            else
                drawLine(firstPoint.Value.X, firstPoint.Value.Y, newPoint.X, newPoint.Y);

            firstPoint = newPoint;
        }

        //Задание 3
        private void Button3_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);

            Point p1 = new Point(int.Parse(p1x.Text), int.Parse(p1y.Text));
            Point p2 = new Point(int.Parse(p2x.Text), int.Parse(p2y.Text));
            Point p3 = new Point(int.Parse(p3x.Text), int.Parse(p3y.Text));

            DrawTriangle(p1, p2, p3, Color.Red, Color.Blue, Color.Yellow);
        }

        private void DrawTriangle(Point p1_og, Point p2_og, Point p3_og, Color c1, Color c2, Color c3)
        {
            List<Point> sorted = new List<Point> { p1_og, p2_og, p3_og };
            sorted.Sort((Point pp1, Point pp2) => -pp1.Y.CompareTo(pp2.Y));
            //sorted.Reverse();

            Point p1 = sorted[0];
            Point p2 = sorted[1];
            Point p3 = sorted[2];

            //вспомогательные ф-ии для нахождения самого левого и правого иксов
            float dy = p1.Y - p2.Y;
            float dx = p1.X - p2.X;
            float coef1 = dx / dy;

            float dy2 = p1.Y - p3.Y;
            float dx2 = p1.X - p3.X;
            float coef2 = dx2 / dy2;

            Bitmap bmp = new Bitmap(Canvas.Width, Canvas.Height, g);

            int yi = p1.Y;
            int xi = p1.X;
            int y_start = p1.Y;
            Color c_left = c1;
            Color c_right = c1;
            int x1; int x2;

            int y_left = p2.Y;
            int y_right = p3.Y;

            while (yi != p2.Y)
            {
                float coef_left = (y_start - yi) / (float)(y_start - y_left); //пройденное расстояние на общее расстояние
                float coef_right = (y_start - yi) / (float)(y_start - y_right);
                c_left = Color.FromArgb(255, (int)(c1.R * (1f - coef_left) + c2.R * coef_left), (int)(c1.G * (1f - coef_left) + c2.G * coef_left), (int)(c1.B * (1f - coef_left) + c2.B * coef_left));
                c_right = Color.FromArgb(255, (int)(c1.R * (1f - coef_right) + c3.R * coef_right), (int)(c1.G * (1f - coef_right) + c3.G * coef_right), (int)(c1.B * (1f - coef_right) + c3.B * coef_right));

                yi--;
                (x1, x2) = FindLeftAndRight(yi, xi, coef1, coef2, p1, p1);
                FillLine(x1, x2, yi, c_right, c_left, bmp, p1, p3, y_start);
            }
            y_start = yi;
            dy = p2.Y - p3.Y;
            dx = p2.X - p3.X;
            coef1 = (dx / dy);
            y_left = p3.Y;

            while (yi != p3.Y)
            {
                float coef_left = (y_start - yi) / (float)(y_start - y_left); //пройденное расстояние на общее расстояние
                float coef_right = (p1.Y - yi) / (float)(p1.Y - y_right);
                c_left = Color.FromArgb(255, (int)(c2.R * (1f - coef_left) + c3.R * coef_left), (int)(c2.G * (1f - coef_left) + c3.G * coef_left), (int)(c2.B * (1f - coef_left) + c3.B * coef_left));
                c_right = Color.FromArgb(255, (int)(c1.R * (1f - coef_right) + c3.R * coef_right), (int)(c1.G * (1f - coef_right) + c3.G * coef_right), (int)(c1.B * (1f - coef_right) + c3.B * coef_right));

                yi--;
                (x1, x2) = FindLeftAndRight(yi, xi, coef1, coef2, p2, p3);
                FillLine(x1, x2, yi, c_right, c_left, bmp, p1, p3, y_start);
            }

            g.DrawImage(bmp, 0, 0);
        }

        ValueTuple<int, int> FindLeftAndRight(float yi, int xi, float coef1, float coef2, Point extract1, Point extract2)
        {
            float y1_add = extract1.Y;
            float y2_add = extract2.Y;
            float x1_add = extract1.X;
            float x2_add = extract2.X;

            ValueTuple<int, int> lr;
            int x_new = xi;
            float x1 = (yi - y1_add) * coef1 + x1_add;
            float x2 = (yi - y2_add) * coef2 + x2_add;
            if (x1 < x_new)
                while (x1 < x_new + 1)
                    x_new--;
            else
                while (x1 > x_new - 1)
                    x_new++;
            lr.Item1 = x_new;

            x_new = xi;
            if (x2 < x_new)
                while (x2 < x_new + 1)
                    x_new--;
            else
                while (x2 > x_new - 1)
                    x_new++;
            lr.Item2 = x_new;

            if (lr.Item1 > lr.Item2)
                lr = (lr.Item2, lr.Item1);

            return lr;
        }

        void FillLine(int x1, int x2, int yi, Color c_left, Color c_right, Bitmap bmp, Point p1, Point p2, int y_start)
        {
            int dist = x2 - x1;

            Color c = c_left;

            for (int i = x1 + 1; i <= x2; i++)
            {
                int j = i - x1;
                float coef = (float)j / (float)dist;
                float coef_minus = 1f - coef;
                Debug.WriteLine(coef + " " + coef_minus + "\n");
                c = Color.FromArgb(255, (int)(c_left.R * coef + c_right.R * coef_minus), (int)(c_left.G * coef + c_right.G * coef_minus), (int)(c_left.B * coef + c_right.B * coef_minus));
                bmp.SetPixel(i, yi, c);
            }
        }
        //конец задания 3


        private void Canvas_Click(object sender, EventArgs e)
        {
            MouseEventArgs mouseEventArgs = (MouseEventArgs)e;
            Console.WriteLine(string.Format("X: {0} Y: {1}", mouseEventArgs.X, mouseEventArgs.Y));
            if (isSecondActive)
            {
                TryDrawLine(new Point(mouseEventArgs.X, mouseEventArgs.Y));
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            draw_mode = !draw_mode;
            fill_mode = false;
            border_mode = false;
            button5.BackColor = SystemColors.Control;
            button6.BackColor = SystemColors.Control;

            if (draw_mode)
            {
                button4.BackColor = Color.DodgerBlue;
            }
            else
            {
                button4.BackColor = SystemColors.Control;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            fill_mode = !fill_mode;
            draw_mode = false;
            border_mode = false;
            button5.BackColor = SystemColors.Control;
            button6.BackColor = SystemColors.Control;

            if (fill_mode)
            {
                button5.BackColor = Color.DodgerBlue;
            }
            else
            {
                button5.BackColor = SystemColors.Control;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            border_mode = !border_mode;
            draw_mode = false;
            fill_mode = false;
            button4.BackColor = SystemColors.Control;
            button5.BackColor = SystemColors.Control;

            if (border_mode)
            {
                button6.BackColor = Color.DodgerBlue;
            }
            else
            {
                button6.BackColor = SystemColors.Control;
            }
        }


        private void button7_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = ".jpg";
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
            if (dlg.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            else
            {
                /*pictureBox.Image = new Bitmap(dlg.FileName);
                pictureBox.Invalidate();*/
                texture = new Bitmap(dlg.FileName);

            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }


        Point draw_p;
        /* private void Canvas_MouseDown(object sender, MouseEventArgs e)
         {
             draw_p = e.Location;

             if (fill_mode && texture == null)
             {
                 fill_algorithm(draw_p, Color.Red);
             }

             else if (fill_mode && texture != null)
             {
                 fill_texture_algorithm(draw_p, 0, 0);
             }

             else if (border_mode)
             {
                 border_algorithm(draw_p);
             }
         }
        */
        /* private void Canvas_MouseMove(object sender, MouseEventArgs e)
         {
             if (draw_mode && e.Button == MouseButtons.Left)
             {
                 Graphics g = Graphics.FromImage(Canvas.Image);
                 //g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                 g.DrawLine(new Pen(borderColor, 1), draw_p, e.Location);
                 draw_p = e.Location;
                 Canvas.Invalidate();
             }
         }
        */
        private void fill_algorithm(Point p, Color fill_color)
        {
            Bitmap bitmap = (Bitmap)Canvas.Image;
            Graphics g = Graphics.FromImage(bitmap);

            if (bitmap.GetPixel(p.X, p.Y).ToArgb() == borderColor.ToArgb() || bitmap.GetPixel(p.X, p.Y).ToArgb() == fill_color.ToArgb())
            {
                return;
            }

            while (bitmap.GetPixel(p.X - 1, p.Y).ToArgb() != borderColor.ToArgb())
            {
                p.X -= 1;
            }
            Point start = p;


            while (bitmap.GetPixel(p.X + 1, p.Y).ToArgb() != borderColor.ToArgb())
            {
                p.X += 1;
            }
            Point end = p;

            g.DrawLine(new Pen(new SolidBrush(fill_color), 1), start, end);
            Canvas.Invalidate();

            while (start.X != end.X)
            {
                fill_algorithm(new Point(start.X, start.Y + 1), fill_color);
                fill_algorithm(new Point(start.X, start.Y - 1), fill_color);

                start.X += 1;
            }
        }


        List<Point> fill_texture_points = new List<Point>();
        private void fill_texture_algorithm(Point p, int texture_x, int texture_y)
        {
            Bitmap bitmap = (Bitmap)Canvas.Image;
            Graphics g = Graphics.FromImage(bitmap);

            if ((bitmap.GetPixel(p.X, p.Y).ToArgb() == borderColor.ToArgb()) || (bitmap.GetPixel(p.X, p.Y).ToArgb() != 0))
            {
                return;
            }

            while (bitmap.GetPixel(p.X - 1, p.Y).ToArgb() != borderColor.ToArgb())
            {
                p.X -= 1;
            }
            Point start = p;

            while (bitmap.GetPixel(p.X + 1, p.Y).ToArgb() != borderColor.ToArgb())
            {
                p.X += 1;
            }
            Point end = p;

            while (start.X != end.X)
            {
                g.DrawRectangle(new Pen(new SolidBrush(texture.GetPixel(texture_x, texture_y)), 1), new Rectangle(start.X, start.Y, 1, 1));
                fill_texture_points.Add(start);
                Canvas.Invalidate();

                fill_texture_algorithm(new Point(start.X, start.Y + 1), texture_x, (texture_y + 1) % texture.Height);
                fill_texture_algorithm(new Point(start.X, start.Y - 1), texture_x, texture_y - 1 < 0 ? texture.Height - 1 : texture_y - 1);

                start.X += 1;
                texture_x = (texture_x + 1) % texture.Width;
            }
        }

        private void border_algorithm(Point p)
        {
            Bitmap bitmap = (Bitmap)Canvas.Image;
            Graphics g = Graphics.FromImage(bitmap);
            List<Point> points = new List<Point>();

            while (bitmap.GetPixel(p.X, p.Y).ToArgb() != borderColor.ToArgb())
            {
                p.X += 1;
            }

            border_algorithm_REC(p, bitmap, ref points);

            for (int i = 0; i < points.Count(); i++)
            {
                g.DrawRectangle(new Pen(Brushes.Red, 1), new Rectangle(points[i], new Size(1, 1)));
            }
            Canvas.Invalidate();
        }

        public void border_algorithm_REC(Point p, Bitmap bitmap, ref List<Point> points)
        {
            if (!points.Contains(p))
            {
                points.Add(p);

                if (bitmap.GetPixel(p.X + 1, p.Y).ToArgb() == borderColor.ToArgb())
                {
                    border_algorithm_REC(new Point(p.X + 1, p.Y), bitmap, ref points);
                }
                if (bitmap.GetPixel(p.X + 1, p.Y - 1).ToArgb() == borderColor.ToArgb())
                {
                    border_algorithm_REC(new Point(p.X + 1, p.Y - 1), bitmap, ref points);
                }
                if (bitmap.GetPixel(p.X, p.Y - 1).ToArgb() == borderColor.ToArgb())
                {
                    border_algorithm_REC(new Point(p.X, p.Y - 1), bitmap, ref points);
                }
                if (bitmap.GetPixel(p.X - 1, p.Y - 1).ToArgb() == borderColor.ToArgb())
                {
                    border_algorithm_REC(new Point(p.X - 1, p.Y - 1), bitmap, ref points);
                }
                if (bitmap.GetPixel(p.X - 1, p.Y).ToArgb() == borderColor.ToArgb())
                {
                    border_algorithm_REC(new Point(p.X - 1, p.Y), bitmap, ref points);
                }
                if (bitmap.GetPixel(p.X - 1, p.Y + 1).ToArgb() == borderColor.ToArgb())
                {
                    border_algorithm_REC(new Point(p.X - 1, p.Y + 1), bitmap, ref points);
                }
                if (bitmap.GetPixel(p.X, p.Y + 1).ToArgb() == borderColor.ToArgb())
                {
                    border_algorithm_REC(new Point(p.X, p.Y + 1), bitmap, ref points);
                }
                if (bitmap.GetPixel(p.X + 1, p.Y + 1).ToArgb() == borderColor.ToArgb())
                {
                    border_algorithm_REC(new Point(p.X + 1, p.Y + 1), bitmap, ref points);
                }
            }
        }

    }
}