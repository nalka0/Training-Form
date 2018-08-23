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
    /// Logique d'interaction pour AjoutClient.xaml
    /// </summary>
    public partial class AjoutClient : Window
    {
        public bool Canceled = true;
        public bool Notify = false;
        public bool passer = false;

        public AjoutClient()
        {
            InitializeComponent();
            Title = "Ajouter un client";
            Loaded += AjoutClient_Loaded;
            Closing += AjoutClient_Closing;
            foreach (Service S in JeuxTest.Services)
            {
                typeAbo.Items.Add(S.Nom);
            }
        }

        public void AjoutClient_Loaded(object sender, RoutedEventArgs e)
        {
            tbDateNaissance.SelectedDate = DateTime.Now;
        }

        public void AjoutClient_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!Canceled && !passer)
            {
                if (tbNom.Text == "" || tbNom.Text == tbNom.ToolTip.ToString())
                {
                    Notify = true;
                }
                if (tbPrenom.Text == "" || tbPrenom.Text == tbPrenom.ToolTip.ToString())
                {
                    Notify = true;
                }
                if (tbAdresse.Text == "" || tbAdresse.Text== tbAdresse.ToolTip.ToString())
                {
                    Notify = true;
                }
                if (DateTime.Compare((DateTime)tbDateNaissance.SelectedDate, DateTime.Now) >= 0)
                {
                    Notify = true;
                }
                if (!tbMail.Text.Contains("@") && !tbMail.Text.Contains(".") || tbMail.Text == tbMail.ToolTip.ToString())
                {
                    Notify = true;
                }
                foreach (char character in tbTelephone.Text)
                {
                    if (!Char.IsDigit(character))
                        Notify = true;
                }
                if (tbTelephone.Text.Length != 10 || tbTelephone.Text[0] != '0' || tbTelephone.Text == tbTelephone.ToolTip.ToString())
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

        public void boutonAnnuler_Click(object sender, RoutedEventArgs e)
        {
            Canceled = true;
            passer = false;
            Close();
        }

        public void boutonValider_Click(object sender, RoutedEventArgs e)
        {
            Canceled = false;
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

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
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
    }
}