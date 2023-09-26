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

        private void DrawPoint(int x, int y, float a)
        {
            Pen pen = new Pen(Color.FromArgb((int)(a * 255), 255, 0, 0), 1);
            g.DrawRectangle(pen, new Rectangle(x, y, 1, 1));

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
        private void line(int x0, int x1, int y0, int y1)
        {

            int sx = x0 > x1 ? -1 : 1;
            int sy = y0 > y1 ? -1 : 1;

            float dy = Math.Abs(y1 - y0);
            float dx = Math.Abs(x1 - x0);
            bool gradient2 = Math.Abs(dy / (double)dx) <= 1;
            float gradient = dy / dx;



            float y = y0 + gradient;
            for (var x = x0 + 1; x <= x1 - 1; x++)
            {
                DrawPoint(x, (int)y, 1 - (y - (int)y));
                DrawPoint(x, (int)y + 1, y - (int)y);
                y += gradient;
            }


        }

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

        void DrawWuLine(int x0, int y0, int x1, int y1)
        {
            //Вычисление изменения координат
            int dx = (x1 > x0) ? (x1 - x0) : (x0 - x1);
            int dy = (y1 > y0) ? (y1 - y0) : (y0 - y1);
            //Если линия параллельна одной из осей, рисуем обычную линию - заполняем все пикселы в ряд
            if (dx == 0 || dy == 0)
            {
                g.DrawLine(new Pen(Color.Red), x0, y0, x1, y1);
                return;
            }

            //Для Х-линии (коэффициент наклона < 1)
            if (dy < dx)
            {
                //Первая точка должна иметь меньшую координату Х
                if (x1 < x0)
                {
                    x1 += x0; x0 = x1 - x0; x1 -= x0;
                    y1 += y0; y0 = y1 - y0; y1 -= y0;
                }
                //Относительное изменение координаты Y
                float grad = (float)dy / dx;
                //Промежуточная переменная для Y
                float intery = y0 + grad;
                //Первая точка
                DrawPoint(x0, y0, 1f);

                for (int x = x0 + 1; x < x1; x++)
                {
                    //Верхняя точка
                    DrawPoint(x, (int)(intery), (1 - (intery % 1)));
                    //Нижняя точка
                    DrawPoint(x, (int)(intery) + 1, (intery %1));
                    //Изменение координаты Y
                    intery += grad;
                }

                //Последняя точка
                DrawPoint(x1, y1, 1);
            }

            //Для Y-линии (коэффициент наклона > 1)
            else
            {
                //Первая точка должна иметь меньшую координату Y
                if (y1 < y0)
                {
                    x1 += x0; x0 = x1 - x0; x1 -= x0;
                    y1 += y0; y0 = y1 - y0; y1 -= y0;
                }
                //Относительное изменение координаты X
                float grad = (float)dx / dy;
                //Промежуточная переменная для X
                float interx = x0 + grad;
                //Первая точка
                DrawPoint(x0, y0, 1);

                for (int y = y0 + 1; y < y1; y++)
                {
                    //Верхняя точка
                    DrawPoint((int)(interx), y, 1 - (interx %1));
                    //Нижняя точка
                    DrawPoint((int)(interx) + 1, y, (interx % 1));
                    //Изменение координаты X
                    interx += grad;
                }
                //Последняя точка
                DrawPoint(x1, y1, 1);
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

            DrawWuLine(firstPoint.Value.X, newPoint.X, firstPoint.Value.Y, newPoint.Y);
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