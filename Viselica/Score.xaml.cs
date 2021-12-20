using System.Windows;
using System.Data.SQLite;
using System.Data;
using Path = System.IO.Path;
using System.Data.Entity;



namespace Viselica
{

    public partial class Score : Window
    {
        
        public Score()
        {
            InitializeComponent();
            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var path = Path.GetDirectoryName(location);
            SQLiteConn = new SQLiteConnection("Data Source=" + path + V + ";Version=3;");
            SQLiteConn.Open();
            SQLiteCommand command = new SQLiteCommand();
            command.Connection = SQLiteConn;
            string query = "SELECT * FROM Users";
            command.CommandText = query;
            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                listBox1.Items.Add("Имя: " + reader["name"].ToString() + " Счет: " + reader["score"].ToString());
                
            }
            SQLiteConn.Close();

        }
        private const string V = "\\score.db";
        private SQLiteConnection SQLiteConn;
        private DataTable dTable;
    }

    }    
    

