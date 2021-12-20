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
using System.Windows.Shapes;
using System.Data.SQLite;
using System.Data;
using System.IO;
using Path = System.IO.Path;

namespace Viselica
{
    /// <summary>
    /// Логика взаимодействия для EndGame.xaml
    /// </summary>
    public partial class EndGame : Window
    {
        public string newname;
        public string newscore;
        public EndGame(string name,string score)
        {
            newname = name;
            newscore = score;
            InitializeComponent();
        }

        private const string V = "\\score.db";
        private SQLiteConnection SQLiteConn;
        private DataTable dTable;

        private void MainForm_Load(object sender, EventArgs e)
        {
            SQLiteConn = new SQLiteConnection();
            dTable = new DataTable();
        }
        private void OpenDBFile()
        {
            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var path = Path.GetDirectoryName(location);
            SQLiteConn = new SQLiteConnection("Data Source=" + path + V + ";Version=3;");
            SQLiteConn.Open();
            SQLiteCommand command = new SQLiteCommand();
            command.Connection = SQLiteConn;
        }
        private void ADD() 
        {
            SQLiteCommand command = new SQLiteCommand(SQLiteConn);
            command.CommandText = "INSERT INTO Users('name','score') VALUES ('"+newname+"','"+newscore+"')";
            command.ExecuteNonQuery();  
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {  
           this.Close(); 
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)

        {
            OpenDBFile();
            ADD();
            this.Close(); 
        }
    }
}
