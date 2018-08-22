using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class AjouterArticle : Window
    {
        public bool Canceled = true;
        public bool Notify = false;
        public bool Forced = false;
        bool passer = false;

        public AjouterArticle()
        {
            InitializeComponent();
            DataContext = this;
            Title = "Ajouter un article";
            Closing += ProduitWind_Closing;
        }

        private void ProduitWind_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            if (!Canceled && !passer)
            {
                if (NomTextBox.Text == "" || NomTextBox.Text == "Nom")
                {
                    Notify = true;
                }
                if (prixHTTextBox.Text == "0" || TVATextBox.Text == "0")
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

        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            string resultat = "";
            foreach (char element in prixHTTextBox.Text)
            {
                if (element != '.')
                    resultat += element;
                else
                    resultat += ',';
            }
            prixHTTextBox.Text = resultat;
            resultat = "";
            foreach (char element in TVATextBox.Text)
            {
                if (element != '.')
                    resultat += element;
                else
                    resultat += ',';
            }
            TVATextBox.Text = resultat;
            Canceled = false;
            passer = false;
            foreach (char c in prixHTTextBox.Text)
            {
                if (!char.IsDigit(c))
                {
                    prixHTTextBox.Text = "0";
                    prixHTTextBox.Foreground = Brushes.Red;
                }
            }
            foreach (char c in TVATextBox.Text)
            {
                if (!char.IsDigit(c))
                {
                    TVATextBox.Text = "0";
                    TVATextBox.Foreground = Brushes.Red;
                }
            }
            Close();
        }

        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            Canceled = true;
            Close();
        }
        private void PUAnnuler_Click(object sender, RoutedEventArgs e)
        {
            PUWindow.IsOpen = false;
        }

        private void PUContinuer_Click(object sender, RoutedEventArgs e)
        {
            Canceled = false;
            passer = true;
            Close();
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