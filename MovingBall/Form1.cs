namespace MovingBall
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer timer;
        int x = 0;
        int backword = 0;

        public Form1()
        {
            InitializeComponent();

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 100;
            timer.Tick += Timer_Tick;
            backword = ClientSize.Width - 100;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (x < ClientSize.Width - 100)
            {
                e.Graphics.FillEllipse(Brushes.White, x, ClientSize.Height / 2 - 50, 100, 100);
                e.Graphics.FillEllipse(Brushes.Black, x + 50, ClientSize.Height / 2 - 25, 20, 20);
                e.Graphics.FillEllipse(Brushes.Black, x + 75, ClientSize.Height / 2 - 25, 20, 20);
                e.Graphics.FillEllipse(Brushes.DarkRed, x + 45, ClientSize.Height / 2 + 15, 40, 15);
                x += 30;
                if (x >= ClientSize.Width - 100)
                    backword = ClientSize.Width - 100;
            }
            else
            {
                e.Graphics.FillEllipse(Brushes.White, backword == ClientSize.Width ? backword - 100 : backword, ClientSize.Height / 2 - 50, 100, 100);
                e.Graphics.FillEllipse(Brushes.Black, backword == ClientSize.Width ? backword - 100 : backword + 5, ClientSize.Height / 2 - 25, 20, 20);
                e.Graphics.FillEllipse(Brushes.Black, backword == ClientSize.Width ? backword - 100 : backword + 30, ClientSize.Height / 2 - 25, 20, 20);
                e.Graphics.FillEllipse(Brushes.DarkRed, backword == ClientSize.Width ? backword - 100 : backword + 15, ClientSize.Height / 2 + 15, 40, 15);
                backword -= 30;
                if (backword <= 0)
                    x = 0;
            }

            timer.Start();

            base.OnPaint(e);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Stop the timer
            timer.Stop();

            // Invalidate the form to trigger a repaint
            Invalidate();
        }
    }
}
