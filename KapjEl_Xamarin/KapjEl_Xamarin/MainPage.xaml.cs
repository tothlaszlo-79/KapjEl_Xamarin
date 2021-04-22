using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace KapjEl_Xamarin
{
    public partial class MainPage : ContentPage
    {
        int Hits;
        int Misses;
        Random rnd;
        bool IsTimerOn;

        public MainPage()
        {
            InitializeComponent();
            rnd = new Random();
        }

        private void alPlayground_Tapped(object sender, EventArgs e)
        {
            if (!IsTimerOn) return;
            Misses++;
            llMisses.Text = Misses.ToString();
        }

        private void ibCasper_Clicked(object sender, EventArgs e)
        {
            if (!IsTimerOn) return;
            Hits++;
            llHits.Text = Hits.ToString();
        }

        private void btStart_Clicked(object sender, EventArgs e)
        {
            if (IsTimerOn) return;
            llCaption.Text = "Játék elindítva!";
            IsTimerOn = true;
            Device.StartTimer(TimeSpan.FromMilliseconds(1000), TimerTick);
        }

        private bool TimerTick()
        {
            if (!IsTimerOn) return false;
            double x = rnd.NextDouble() * (alPlayground.Width - ibCasper.Width);
            double y = rnd.NextDouble() * (alPlayground.Height - ibCasper.Height);

            AbsoluteLayout.SetLayoutBounds(ibCasper, new Rectangle(x, y, ibCasper.Width, ibCasper.Height));
            return IsTimerOn;

        }

        private void btReset_Clicked(object sender, EventArgs e)
        {
            Hits = 0;
            Misses = 0;
            llHits.Text = "0";
            llMisses.Text = "0";
        }

        private void btStop_Clicked(object sender, EventArgs e)
        {
            IsTimerOn = false;
            llCaption.Text = "Játék megállítva";
        }
    }
}
