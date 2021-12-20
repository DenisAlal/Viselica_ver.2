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
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics.Metrics;

namespace Viselica
{
   
    public partial class Game : Window
    {
        public string sendname;
        public Game(string name)
        {
            InitializeComponent();
            TextBlock.Text += name;
            textBox2.IsEnabled = false;
            Button2.IsEnabled = false;
            sendname = name;

            
        }
        public List<char> letters = new List<char>();
        public string str;
        public string text;
        public string word = null;
        public int hp;
        public int result;
        public string wordchanged = null;
        public int pngcount;
        public string Resources;
        public string inputword;
        public string score;
        public string wordchanged1 = null;
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
             inputword = textBox2.Text;
            if (inputword == "")
            {
                MessageBox.Show("Введите букву");
            }
            else 
            {
                if (hp > -1)
                {
                    if (inputword.Length == 1)
                    {
                        
                            result = word.IndexOf(inputword);


                        if (result == -1)
                        {
                            pngcount = pngcount + 1;
                            hp = hp - 1;
                            
                            Resources = "/Resources/0.png";
                            int pos = Resources.LastIndexOf('/');
                            string filename = Resources.Substring(pos);
                            Resources = Resources.Substring(0,pos);
                            Resources = Resources + "/" + pngcount + ".png";
                            this.Image.Source = new BitmapImage(new Uri(Resources, UriKind.Relative)) { CreateOptions = BitmapCreateOptions.IgnoreImageCache };
                            inputword = "";
                            textBox2.Clear();
                            
                        }
                        else 
                        {

                            string str = word;
                            char input = Convert.ToChar(inputword);
                                if (str.Contains(input)) letters.Add(input);
                                wordchanged1 = (string.Concat(str.Select(x => letters.Contains(x) ? x : '-')));
                            textBox2.Clear();
                            label1.Content = wordchanged1;
                            
                            string letters1 = Convert.ToString(wordchanged1);
                            if (String.Compare(wordchanged1, word) == 0) 
                            {
                                score = score + "1";
                                textBox2.IsEnabled = false;
                                Button2.IsEnabled = false;
                                new EndGame(sendname,score).Show();
                                textBox2.IsEnabled = false;
                                Button2.IsEnabled = false;
                                countLabel.Content = "Чтобы продолжить игру";
                                label1.Content = "Нажмите кнопку Начать игру";
                            }
                        } 
                    }
                    else 
                    {
                        MessageBox.Show("Введите 1 букву!");
                        textBox2.Clear();
                    }


                    
                }

                else
                {
                    MessageBox.Show("К сожалению попытки закончились, начните игру снова");
                }
            }

        }
      
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DevInfo devinfo = new DevInfo();
            devinfo.Show();
        }
        


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AboutGame aboutgame = new AboutGame();
            aboutgame.Show();
        }
      
        private void GameHistory_Click(object sender, RoutedEventArgs e)
        {
            Score score = new Score();
            score.Show();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            hp = 10;
            wordchanged = null;
            string[] randoms = new string[21];
            randoms[0] = "слон";
            randoms[1] = "телевизор";
            randoms[2] = "кутикула";
            randoms[3] = "амплитуда";
            randoms[4] = "монитор";
            randoms[5] = "мышь";
            randoms[6] = "ноутбук";
            randoms[7] = "колонка";
            randoms[8] = "клавиатура";
            randoms[9] = "телефон";
            randoms[10] = "дом";
            randoms[11] = "квартира";
            randoms[12] = "диван";
            randoms[13] = "зеркало";
            randoms[14] = "сушка";
            randoms[15] = "клавиша";
            randoms[16] = "тумблер";
            randoms[17] = "подставка";
            randoms[18] = "матрица";
            randoms[19] = "крем";
            randoms[20] = "человек";
            Random r = new Random();
            word = (randoms[r.Next(0, 20)]);
            //вывод количества букв
            var letters = new List<char>();
            int count = 0;
            foreach (var el in word) if (char.IsLetter(el)) count++;
            for (int i = 0; i < count; i++)
            wordchanged = wordchanged + "-";
            countLabel.Content = "Количество букв в слове: " + count;
            label1.Content = (string.Concat(word.Select(x => letters.Contains(x) ? x : '-'))); 
            //активация кнопок
            Button2.IsEnabled = true;
            textBox2.IsEnabled = true;
            //вывод картинки
             pngcount = 0;
             Resources = "/Resources/0.png";
             int pos = Resources.LastIndexOf('/');
             string filename = Resources.Substring(pos);
             Resources = Resources.Substring(0,pos);
             Resources = Resources + "/" + pngcount + ".png";
             this.Image.Source = new BitmapImage(new Uri(Resources, UriKind.Relative)) { CreateOptions = BitmapCreateOptions.IgnoreImageCache };


        }
      
    }
}
