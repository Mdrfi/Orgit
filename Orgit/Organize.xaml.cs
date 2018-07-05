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
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Controls.Primitives;

namespace Orgit
{
    /// <summary>
    /// Interaction logic for Organize.xaml
    /// </summary>
    public partial class Organize : Page
    {
        public Organize()
        {
            InitializeComponent();
        }
        string hesabanclr = "#FF1A237E";
        string fizikclr = "#FF01579B";
        string shimiclr = "#FF880E4F";
        string zaminclr = "#FF3E2723";
        string hendeseclr = "#FF827717";
        string farsiclr = "#FF33691E";
        string diniclr = "#FFF57F17";
        string arabiclr = "#FF004D40";
        string zabanclr = "#FFBF360C";
        string amarclr = "#FF263238";


        Lessons lessons = new Lessons();
        Mysqlconnector connect = new Mysqlconnector();
        private void Riazibtn_Click(object sender, RoutedEventArgs e)
        {
           ((MainWindow)Application.Current.MainWindow).multiform.Content = null;
           ((MainWindow)Application.Current.MainWindow).multiform.Content = lessons;
           lessons.dahomtr.Items.Clear();
            lessons.yazdahomtr.Items.Clear();
            lessons.davazdahomtr.Items.Clear();

            //connecting to server and send a query


            if (lessons.dahomtr.Items.IsEmpty)
            {
                IList<Lessonname> listriazidahom = new List<Lessonname>();
                Fillinglist(listriazidahom, "Riazi1");
                Filling(listriazidahom, hesabanclr, lessons.dahomtr);
            }
            if (lessons.yazdahomtr.Items.IsEmpty)
            {
              IList<Lessonname> listriaziyazdahom = new List<Lessonname>();
              Fillinglist(listriaziyazdahom, "Hesaban1");
              Filling(listriaziyazdahom, hesabanclr, lessons.yazdahomtr);
            }
            if (lessons.davazdahomtr.Items.IsEmpty)
            {
            }



        }


        private void Fizikbtn_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).multiform.Content = null;
            ((MainWindow)Application.Current.MainWindow).multiform.Content = lessons;
            lessons.dahomtr.Items.Clear();
            lessons.yazdahomtr.Items.Clear();
            lessons.davazdahomtr.Items.Clear();

        }

        private void Shimibtn_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).multiform.Content = null;
            ((MainWindow)Application.Current.MainWindow).multiform.Content = lessons;
            lessons.dahomtr.Items.Clear();
            lessons.yazdahomtr.Items.Clear();
            lessons.davazdahomtr.Items.Clear();
        }

        private void Zaminbtn_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).multiform.Content = null;
            ((MainWindow)Application.Current.MainWindow).multiform.Content = lessons;
            lessons.dahomtr.Items.Clear();
            lessons.yazdahomtr.Items.Clear();
            lessons.davazdahomtr.Items.Clear();
        }

        private void Hendesebtn_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).multiform.Content = null;
            ((MainWindow)Application.Current.MainWindow).multiform.Content = lessons;
            lessons.dahomtr.Items.Clear();
            lessons.yazdahomtr.Items.Clear();
            lessons.davazdahomtr.Items.Clear();
        }

        private void Zabanbtn_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).multiform.Content = null;
            ((MainWindow)Application.Current.MainWindow).multiform.Content = lessons;
            lessons.dahomtr.Items.Clear();
            lessons.yazdahomtr.Items.Clear();
            lessons.davazdahomtr.Items.Clear();
        }

        private void Dinibtn_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).multiform.Content = null;
            ((MainWindow)Application.Current.MainWindow).multiform.Content = lessons;
            lessons.dahomtr.Items.Clear();
            lessons.yazdahomtr.Items.Clear();
            lessons.davazdahomtr.Items.Clear();
        }

        private void Farsibtn_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).multiform.Content = null;
            ((MainWindow)Application.Current.MainWindow).multiform.Content = lessons;
            lessons.dahomtr.Items.Clear();
            lessons.yazdahomtr.Items.Clear();
            lessons.davazdahomtr.Items.Clear();
        }

        private void Arabibtn_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).multiform.Content = null;
            ((MainWindow)Application.Current.MainWindow).multiform.Content = lessons;
            lessons.dahomtr.Items.Clear();
            lessons.yazdahomtr.Items.Clear();
            lessons.davazdahomtr.Items.Clear();
        }

        private void Amarbtn_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).multiform.Content = null;
            ((MainWindow)Application.Current.MainWindow).multiform.Content = lessons;
            lessons.dahomtr.Items.Clear();
            lessons.yazdahomtr.Items.Clear();
            lessons.davazdahomtr.Items.Clear();
        }

        public void Filling(IList<Lessonname> studentList, string color, TreeView year)
        {
            bool hassub = false;
            for (int i = 0; i < studentList.Count; i++)
            {
                
                //check for orginal item

                if (studentList[i].chechsub == 0)
                {
                    //for evry row we need new hassub

                    hassub = false;
                    TreeViewItem item = new TreeViewItem();
                    item.Header = studentList[i].name;
                    
                    //add subitem

                    for (int j = 0; j < studentList.Count; j++)
                    {
                        if (studentList[i].id == studentList[j].chechsub)
                        {
                            hassub = true;

                            //create slider for showing mastery and add it to item 

                            Slider slider = new Slider
                            {
                                Height = 20,
                                Width = 225,
                                AutoToolTipPlacement = AutoToolTipPlacement.TopLeft,
                                Minimum = 0,
                                Maximum = 100,
                                Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom(color)),
                                Value = studentList[j].mastery,
                                IsDirectionReversed = true
                            };
                            TreeViewItem subitem = new TreeViewItem();
                            subitem.Header = studentList[j].name;
                            subitem.Items.Add(slider);
                            item.Items.Add(subitem);
                        }
                    }

                    //it's for when item does not has subitem

                    if (hassub == false)
                    {

                        Slider oslider = new Slider
                        {
                            Height = 20,
                            Width = 225,
                            AutoToolTipPlacement = AutoToolTipPlacement.TopLeft,
                            Minimum = 0,
                            Maximum = 100,
                            Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom(color)),
                            Value = studentList[i].mastery,
                            IsDirectionReversed = true
                        };
                        item.Items.Add(oslider);
                    }
                   
                    //add item to treeview 

                    year.Items.Add(item);
                }
            }

        }
        public void Fillinglist(IList<Lessonname> lessonlist, string lessontbl )
        {
            connect.Connection();
            MySqlCommand command = new MySqlCommand("SELECT  ID, LessonName, Mastery, Checksub FROM "+lessontbl, connect.conn);
            connect.conn.Open();
            MySqlDataReader reader = command.ExecuteReader();     

            //write database in arrey

            while (reader.Read())
            {
                lessonlist.Add(new Lessonname()
                {
                    id = reader.GetInt32("ID"),
                    name = reader.GetString("LessonName"),
                    mastery = reader.GetInt32("Mastery"),
                    chechsub = reader.GetInt32("checksub")
                });
            }   
            connect.conn.Close();
        }



    }

}
public class Lessonname
{
    public int id { get; set; }
    public string name { get; set; }
    public int mastery { get; set; }
    public int chechsub { get; set; }
}
