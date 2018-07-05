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
using MySql.Data.MySqlClient;

namespace Orgit
{
    class Mysqlconnector
    {
        
        public MySqlConnection conn;
        public void Connection()
        {
            try
            {
                string connstring = "SERVER=db4free.net;DATABASE=orgitgit;UID=orgitgit;PWD=Myorgitgit";
                conn = new MySqlConnection(connstring);          
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                
            }
        }
        public void Openconn() {
            conn.Open();
        }
        public void closeconn() {
            conn.Close();
        }
    }
}
