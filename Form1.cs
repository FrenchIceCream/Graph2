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
            Bitmap bitmap = new Bitmap(Canvas.ClientSize.Width, Canvas.ClientSize.Height);
            Canvas.Image = bitmap;
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            isSecondActive = false;

        }

        private void Button2_Click(object sender, EventArgs e)
        {
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

            DrawPoint(steep, x0, y0, 1); // Эта функция автоматом меняет координаты местами в зависимости от переменной steep
            DrawPoint(steep, x1, y1, 1); // Последний аргумент — интенсивность в долях единицы
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

        private void Button3_Click(object sender, EventArgs e)
        {
            isSecondActive = false;

        }

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
               /* Canvas.Image = new Bitmap(dlg.FileName);
               Canvas.Invalidate();
                */texture = new Bitmap(dlg.FileName);

            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }


        Point draw_p;
        private void Canvas_MouseDown(object sender, MouseEventArgs e)
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

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (draw_mode && e.Button == MouseButtons.Left)
            {
                 g = Graphics.FromImage(Canvas.Image);
                //g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.DrawLine(new Pen(borderColor, 1), draw_p, e.Location);
                draw_p = e.Location;
                Canvas.Invalidate();
            }
        }

        private void fill_algorithm(Point p, Color fill_color)
        {
            Bitmap bitmap = (Bitmap)Canvas.Image;
            int width = bitmap.Width;
            int height = bitmap.Height;
             g = Graphics.FromImage(bitmap);

            
            if (bitmap.GetPixel(p.X, p.Y).ToArgb() == borderColor.ToArgb() || bitmap.GetPixel(p.X, p.Y).ToArgb() == fill_color.ToArgb())
            {
                return;
            }
            
            while ((p.X-1 > 0) && (bitmap.GetPixel(p.X - 1, p.Y).ToArgb() != borderColor.ToArgb()))
            {
                p.X -= 1;
                
            }

            Point start = p;

            while ((p.X+1 <width) &&  bitmap.GetPixel(p.X + 1, p.Y).ToArgb() != borderColor.ToArgb())
            {
                p.X += 1;
            }
            Point end = p;

            g.DrawLine(new Pen(new SolidBrush(fill_color), 1), start, end);            
            Canvas.Image = bitmap;
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
            int width = bitmap.Width;
            int height = bitmap.Height;
            g = Graphics.FromImage(bitmap);


            if ((bitmap.GetPixel(p.X, p.Y).ToArgb() == borderColor.ToArgb()) || (bitmap.GetPixel(p.X, p.Y).ToArgb() != 0))
            {
                return;
            }

            while ((p.X - 1 > 0) && bitmap.GetPixel(p.X - 1, p.Y).ToArgb() != borderColor.ToArgb())
            {
                p.X -= 1;
            }
            Point start = p;

            while ((p.X + 1 < width) && bitmap.GetPixel(p.X + 1, p.Y).ToArgb() != borderColor.ToArgb())
            {
                p.X += 1;
            }
            Point end = p;

            while (start.X != end.X)
            {
                g.DrawRectangle(new Pen(new SolidBrush(texture.GetPixel(texture_x, texture_y)), 1), new Rectangle(start.X, start.Y, 1, 1));
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
            int width = bitmap.Width;
            int height = bitmap.Height;
            g = Graphics.FromImage(bitmap);
            List<Point> points = new List<Point>();

            while ((p.X + 1 < width) && bitmap.GetPixel(p.X, p.Y).ToArgb() != borderColor.ToArgb())
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