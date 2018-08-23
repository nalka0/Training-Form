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

namespace Training_Form
{
    /// <summary>
    /// Logique d'interaction pour AjoutUser.xaml
    /// </summary>
    public partial class AjouterSalarie : Window
    {
        public bool Canceled = true;
        public bool Notify = false;
        public bool passer = false;

        public AjouterSalarie()
        {
            InitializeComponent();
            Title = "Ajouter un salarié";
            Loaded += AjoutUser_Loaded;
            Closing += AjoutUser_Closing;
        }

        public void AjoutUser_Loaded(object sender, RoutedEventArgs e)
        {
            textBoxDateNaissance.SelectedDate = DateTime.Now;
            textBoxDateEmbauche.SelectedDate = DateTime.Now;
        }

        private void AjoutUser_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!Canceled && !passer)
            {
                if (DateTime.Compare((DateTime)textBoxDateNaissance.SelectedDate, DateTime.Now) >= 0)
                {
                    Notify = true;
                }
                if (!textBoxEmail.Text.Contains("@") && !textBoxEmail.Text.Contains("."))
                {
                    Notify = true;
                }
                foreach (char character in numTelephonneTB.Text)
                    if (!Char.IsDigit(character))
                        Notify = true;
                if (numTelephonneTB.Text.Length != 10 || numTelephonneTB.Text[0] != '0')
                {
                    Notify = true;
                }
                if (DateTime.Compare((DateTime)textBoxDateEmbauche.SelectedDate, DateTime.Now) >= 0)
                {
                    Notify = true;
                }
                if (Notify)
                {
                    PUWindow.IsOpen = true;
                    e.Cancel = true;
                }
            }
        }

        private void boutonValider_Click(object sender, RoutedEventArgs e)
        {
            Canceled = false;
            Close();
        }

        private void boutonAnnuler_Click(object sender, RoutedEventArgs e)
        {
            Canceled = true;
            passer = false;
            Close();
        }

        private void PUContinuer_Click(object sender, RoutedEventArgs e)
        {
            Canceled = false;
            passer = true;
            Close();
        }

        private void PUAnnuler_Click(object sender, RoutedEventArgs e)
        {
            PUWindow.IsOpen = false;
        }
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Text == textBox.ToolTip.ToString())
            {
                textBox.Text = "";
                textBox.Foreground = Brushes.Black;
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Text == "")
            {
                textBox.Text = textBox.ToolTip.ToString();
                textBox.Foreground = Brushes.Red;
            }
        }
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}