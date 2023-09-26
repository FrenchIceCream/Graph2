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

        private void TryDrawLine(Point newPoint)
        {
            if (firstPoint == null)
            {
                firstPoint = newPoint;
                return;
            }
            Pen pen_r = new Pen(Color.Red, 1);
            g.DrawRectangle(pen_r,new Rectangle(10,10,1,1));

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