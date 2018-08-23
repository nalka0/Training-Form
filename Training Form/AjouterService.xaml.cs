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
    /// Logique d'interaction pour ajouterService.xaml
    /// </summary>
    public partial class ajouterService : Window
    {
        public bool Canceled = true;
        public bool Notify = false;
        public bool passer = false;

        public ajouterService()
        {
            InitializeComponent();
            DataContext = this;
            Title = "Ajouter un service";
            Closing += AjouterService_Closing;
        }

        private void AjouterService_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!Canceled && !passer)
            {
                if (nomTB.Text == "" || nomTB.Text == nomTB.ToolTip.ToString())
                {
                    Notify = true;
                }
                if (descriptionTB.Text == "" || descriptionTB.Text == descriptionTB.ToolTip.ToString())
                {
                    Notify = true;
                }
                if (prixHTTB.Text == "0" || prixHTTB.Text == prixHTTB.ToolTip.ToString())
                {
                    Notify = true;
                }
                if (tauxTVATB.Text == "0" || tauxTVATB.Text == tauxTVATB.ToolTip.ToString())
                {
                    Notify = true;
                }
                if (DateTime.Compare((DateTime)debutDTP.SelectedDate, DateTime.Now) >= 0)
                {
                    Notify = true;
                }
                if (dureeNUD.Value < 0)
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

        private void annuler_Click(object sender, RoutedEventArgs e)
        {
            Canceled = true;
            passer = false;
            Close();
        }

        private void valider_Click(object sender, RoutedEventArgs e)
        {
            string resultat = "";
            foreach (char element in prixHTTB.Text)
            {
                if (element != '.')
                    resultat += element;
                else
                    resultat += ',';
            }
            prixHTTB.Text = resultat;
            resultat = "";
            foreach (char element in tauxTVATB.Text)
            {
                if (element != '.')
                    resultat += element;
                else
                    resultat += ',';
            }
            tauxTVATB.Text = resultat;
            foreach (char c in prixHTTB.Text)
            {
                if (!char.IsDigit(c))
                {
                    prixHTTB.Text = "0";
                    prixHTTB.Foreground = Brushes.Red;
                }
            }
            foreach (char c in tauxTVATB.Text)
            {
                if (!char.IsDigit(c))
                {
                    tauxTVATB.Text = "0";
                    tauxTVATB.Foreground = Brushes.Red;
                }
            }
            Canceled = false;
            passer = false;
            Close();
        }

        public void ajouterServiceWin_Loaded(object sender, RoutedEventArgs e)
        {
            dureeNUD.Value = 0;
            debutDTP.SelectedDate = DateTime.Now;
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