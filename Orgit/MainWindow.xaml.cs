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

namespace Orgit
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Lessons lessons = new Lessons();
        //we have define pages obj because we need content in this obj  
        Stopwatch stopwatch = new Stopwatch();
        Organize organize = new Organize();
        Setting setting = new Setting();
        //bool for checking radiobox value 
        bool check = false;
        public MainWindow()
        {
            Mysqlconnector mysqlconnector = new Mysqlconnector();
            mysqlconnector.Connection();
            InitializeComponent();
            multiform.Content = organize;
        }
        
        private void stopwatchbtn_Click(object sender, RoutedEventArgs e)
        {
            lessons.dahomtr.Items.Clear();
            multiform.Content = null;
            multiform.Content = stopwatch;
            
        }

        private void organizebtn_Click(object sender, RoutedEventArgs e)
        {
            lessons.dahomtr.Items.Clear();
            multiform.Content = null;
            multiform.Content = organize;
            RadioButton radiotajrobi = setting.reshtetajrobirbtn;
            RadioButton radioriazi = setting.reshteriazirbtn;
            Radiobtncheck(radiotajrobi,e);
            if (check)
            {
               // organize.Amarbtn.Visibility = System.Windows.Visibility.Hidden;
                organize.Hendesebtn.Content = "زیست شناسی";
                organize.Riazibtn.Content = "ریاضی";
            }
            Radiobtncheck(radioriazi, e);
            if (check)
            {
                //organize.Amarbtn.Visibility = System.Windows.Visibility.Visible;
                organize.Hendesebtn.Content = "هندسه";
                organize.Riazibtn.Content = "حسابان";
            }
        }

        private void settingbtn_Click(object sender, RoutedEventArgs e)
        {
            lessons.dahomtr.Items.Clear();
            multiform.Content = null;
            multiform.Content = setting;

        }

        private void License(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.mdrfi.com");
        }

        private void Radiobtncheck(object sender, RoutedEventArgs e)
        {
            if ((sender as RadioButton).IsChecked == true)
            {
                check = true;
            }
            else
            {
                check = false;
            }
        }

    }
}
