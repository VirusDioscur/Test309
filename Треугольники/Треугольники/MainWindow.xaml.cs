using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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


//Практическая работа №1

namespace Треугольники
{
    //output.Text += strr.ReadToEnd() + Environment.NewLine;
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            side1.MaxLength = 6;
            side2.MaxLength = 6;
            side3.MaxLength = 6;
        }
        private const char LimitChar = ',';
        private const int MaxCount = 1;
        private const char LimitChar2 = '.';
        public double a;
        public double b;
        public double c;

        private static readonly Regex _regex = new Regex("[^0-9,.]");
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);           //Запрет на буквы
        }


        private int CountOccurrences(string input, char character)
        {
            int count = 0;

            foreach (char c in input)
            {
                if (c == character)
                {
                    count++;
                }
            }

            return count;
        }





        private void side1_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string currentText4 = side1.Text;
            string inputZap = e.Text;
            // Проверяем количество вхождений запятой в текущем тексте
            int currentCount = CountOccurrences(currentText4, LimitChar);
            int currentCount2 = CountOccurrences(currentText4, LimitChar2);

            e.Handled = !IsTextAllowed(e.Text);         
            side1.TextAlignment = TextAlignment.Center; // основной запрет на символы


            if ((currentText4.Contains('.') && inputZap == ",") || (currentText4.Contains(',') && inputZap == "."))
            {
                e.Handled = true;
                MessageBox.Show("Нельзя чтобы точка и запятая находились одновременно");
            }


            if (e.Text == LimitChar.ToString())
            {
                if (currentCount >= MaxCount)
                {
                    e.Handled = true;
                    MessageBox.Show("Нельзя ввести больше знаков запятой или точки");
                }
            }

            if (e.Text == LimitChar2.ToString())
            {
                if (currentCount2 >= MaxCount)
                {
                    e.Handled = true;
                    MessageBox.Show("Нельзя ввести больше знаков запятой или точки");
                }
            }


        }


        private void side2_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string currentText2 = side2.Text;
            string inputZap = e.Text;
            // Проверяем количество вхождений запятой в текущем тексте
            int currentCount = CountOccurrences(currentText2, LimitChar);
            int currentCount2 = CountOccurrences(currentText2, LimitChar2);

            e.Handled = !IsTextAllowed(e.Text);
            side2.TextAlignment = TextAlignment.Center;

            if ((currentText2.Contains('.') && inputZap == ",") || (currentText2.Contains(',') && inputZap == "."))
            {
                e.Handled = true;
                MessageBox.Show("Нельзя чтобы точка и запятая находились одновременно");
            }



            if (e.Text == LimitChar.ToString())
            {
                if (currentCount >= MaxCount)
                {
                    e.Handled = true;
                    MessageBox.Show("Нельзя ввести больше знаков запятой или точки");
                }
            }

            if (e.Text == LimitChar2.ToString())
            {
                if (currentCount2 >= MaxCount)
                {
                    e.Handled = true;
                    MessageBox.Show("Нельзя ввести больше знаков запятой или точки");
                }
            }



        }

        private void side3_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string currentText3 = side3.Text;
            string inputZap = e.Text;
            // Проверяем количество вхождений запятой в текущем тексте
            int currentCount = CountOccurrences(currentText3, LimitChar);
            int currentCount2 = CountOccurrences(currentText3, LimitChar2);

            e.Handled = !IsTextAllowed(e.Text);
            side3.TextAlignment = TextAlignment.Center;



            if ((currentText3.Contains('.') && inputZap == ",") || (currentText3.Contains(',') && inputZap == "."))
            {
                e.Handled = true;
                MessageBox.Show("Нельзя чтобы точка и запятая находились одновременно");
            }


            if (e.Text == LimitChar.ToString())
            {
                if (currentCount >= MaxCount)
                {
                    e.Handled = true;
                    MessageBox.Show("Нельзя ввести больше знаков запятой или точки");
                }
            }

            if (e.Text == LimitChar2.ToString())
            {
                if (currentCount2 >= MaxCount)
                {
                    e.Handled = true;
                    MessageBox.Show("Нельзя ввести больше знаков запятой или точки");
                }
            }


        }

        private void b2_Click(object sender, RoutedEventArgs e)
        {
            side1.Text = string.Empty;
            side2.Text = string.Empty;
            side3.Text = string.Empty;
            tb2.Text   = string.Empty;

            {
                side1.Visibility = Visibility.Visible;
                side2.Visibility = Visibility.Visible;
                side3.Visibility = Visibility.Visible;

                tb1.Visibility = Visibility.Visible;
                b1.Visibility = Visibility.Visible;

                tb2.Opacity = 0;
                b2.Opacity = 0;
            } //Переход к главной


        }

        private void b1_Click(object sender, RoutedEventArgs e)
        {
            side1.Text = side1.Text.Replace(".", ",");
            side2.Text = side2.Text.Replace(".", ",");
            side3.Text = side3.Text.Replace(".", ",");
            side1.Text = side1.Text.Replace(",,", ",");

            try
            {
                a = Convert.ToDouble(side1.Text);
                b = Convert.ToDouble(side2.Text);
                c = Convert.ToDouble(side3.Text);

                if (a <= 0 || b <= 0 || c <= 0)
                {
                    System.Windows.MessageBox.Show("Стороны треугольника не могут быть отрицательными или равными нулю");
                    return;
                }
            }
            catch
            {
                System.Windows.MessageBox.Show("Вы не ввели достаточно значений в формуле");
                return;
            }

            if (a == b && b == c)
                tb2.Text = "Треугольник равносторонний";
            else if (a==b && b!=c || b==c && a!=b || b==c && c!=a)
                tb2.Text = "Треугольник равнобедренный";
            else if (a!=b && b!=c && c!=a)
                tb2.Text = "Треугольник разносторонний";

            if (a * a + b * b == c * c)
                tb2.Text += " и прямоугольный";


            {
                side1.Visibility = Visibility.Hidden;
                side2.Visibility = Visibility.Hidden;
                side3.Visibility = Visibility.Hidden;

                tb1.Visibility = Visibility.Hidden;
                b1.Visibility = Visibility.Hidden;

                tb2.Opacity = 1;
                b2.Opacity = 1;
            } //Переход к результату



            if (side1.Text == null || side2.Text == null || side3.Text == null)
            {
                System.Windows.MessageBox.Show("Вы не ввели какие-то значения в полях");
                return;
            }
        }

    }
}
