using System.Runtime.Serialization;

namespace Graph2
{
    public partial class Form1 : Form
    {

        private bool isSecondActive = false;
        private Point? firstPoint = null;
        private Graphics g;
        public Form1()
        {
            InitializeComponent();
            g = Canvas.CreateGraphics();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

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

        private void Swap(ref int x1,ref int x2)
        {
            int x = x1; x1 = x2; x2 = x;
        }

        /*private void line(int x0, int x1, int y0, int y1)
        {
            DrawPoint(x1, y1, 1);
            float dx = x1 - x0; float dy = y1 - y0;
            float gradient = dy / dx;
            float y = y0 + gradient;
            for (var x = x0 + 1; x <= x1 - 1; x++)
            {
                DrawPoint(x, (int)y, 1 - (y - (int)y));
                DrawPoint(x, (int)y + 1, y - (int)y);
                y += gradient;
            }
        }*/
    

        /*private void line(int x0, int x1, int y0, int y1)
        {
            int deltax = Math.Abs(x1 - x0);
            int deltay = Math.Abs(y1 - y0);
            double error = 0;
            double deltaerr = (deltay + 1);
            int y = y0;
            int diry = y1 - y0;
            if (diry > 0)
                diry = 1;
            if (diry < 0)
                diry = -1;
            for (int x = x0; x < x1; x++)
            {
                DrawPoint(x,y,)
                error = error + deltaerr;
                if (error >= 1.0)
                {
                    y = y + diry;
                    error = error - 1.0;
                }
            }
        }*/

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

        private void TryDrawLine(Point newPoint)
        {
            if (firstPoint == null)
            {
                firstPoint = newPoint;
                return;
            }
            Pen pen_r = new Pen(Color.Red, 1);
            //g.DrawRectangle(pen_r, new Rectangle(10, 10, 1, 1));

            WuLine(firstPoint.Value.X, newPoint.X, firstPoint.Value.Y, newPoint.Y);
            /*
            int x1 = firstPoint.Value.X; int y1 = firstPoint.Value.Y;
            int x2 = newPoint.X; int y2 = newPoint.Y;

            int sx = x1>x2?-1:1;
            int sy = y1>y2?-1:1;

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
                        yStart+=sy;
                        dStart += 2 * (dy - dx);
                    }


                    xStart+=sx;
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
                        xStart+=sx;
                        dStart += 2 * (dx - dy);
                    }


                    yStart+= sy;
                }
            }

            */
            firstPoint = newPoint;
        }

        private void Button3_Click(object sender, EventArgs e)
        {

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
    }
}