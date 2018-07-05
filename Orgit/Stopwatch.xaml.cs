using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Orgit
{
    /// <summary>
    /// Interaction logic for Stopwatch.xaml
    /// </summary>
    public partial class Stopwatch : Page
    {


        private DispatcherTimer timer;
        bool start = false;
        double hh, mm, ss, ms = 0;

        public Stopwatch()
        {
            InitializeComponent();
            timer = new DispatcherTimer();

        }


        private void startbtn_Click(object sender, RoutedEventArgs e)
        {
            //check for start or stop
            if (start == false)
            {
                startimg.Source = new BitmapImage(new Uri("http://s9.picofile.com/file/8329462534/pause.png"));
                start = true;

                //timer = new DispatcherTimer();
                //set interval and start timer obj 
                timer.Interval = new TimeSpan(0,0,0,0,1);
                timer.Tick += timer_Tick;
                timer.Start();
            }
            else
            {
                startimg.Source = new BitmapImage(new Uri("http://s9.picofile.com/file/8329462184/playbtn.png"));
                start = false;
                timer.Tick -= timer_Tick;

                timer.Stop();

            }
        }
        //it's run when timer obj is start and add to variables for timelabel
        private void timer_Tick(object sender, EventArgs e) {

            if (start)
            {
                ms+=1.55;
                if (ms >= 100)
                {
                    ss++;
                    ms = 0;
                        
                }
                if (ss >= 60)
                {
                    mm++;
                    ss = 0;
                }
                if (mm >= 60)
                {
                    hh++;
                    mm = 0;
                }
            }
            mslbl.Content = string.Format("{0:00}", ms);
            sslbl.Content = string.Format("{0:00}", ss);
            mmlbl.Content = string.Format("{0:00}", mm);
            hhlbl.Content = string.Format("{0:00}", hh);

        }
        private void resetbtn_Click(object sender, RoutedEventArgs e)
        {
            //clear label for new stopwatch
            hh = 0;
            mm = 0;
            ss = 0;
            ms = 0;
            mslbl.Content = string.Format("{0:00}", ms);
            sslbl.Content = string.Format("{0:00}", ss);
            mmlbl.Content = string.Format("{0:00}", mm);
            hhlbl.Content = string.Format("{0:00}", hh);
        }
    }
}
