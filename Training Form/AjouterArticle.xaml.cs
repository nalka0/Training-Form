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
        public string Message;
        public AjouterArticle()
        {
            InitializeComponent();
            DataContext = this;
            Closing += ProduitWind_Closing;
        }
        
        private void ProduitWind_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(!Canceled)
            {
                if (NomTextBox.Text == "" || NomTextBox.Text == "Nom")
                {
                    //MessageBox.Show("Le nom n'a pas été renseigné", "Nom manquant", MessageBoxButton.OK, MessageBoxImage.Error);
                    snackBarMessage.Content = "Le nom n'a pas été renseigné";
                    e.Cancel = true;
                }
                if (prixHTTextBox.Text == "" || prixHTTextBox.Text == "Prix HT")
                {
                    MessageBox.Show("Le prix hors taxe n'a pas été renseigné", "PrixHT manquant", MessageBoxButton.OK, MessageBoxImage.Error);
                    e.Cancel = true;
                }
                if (TVATextBox.Text == "" || TVATextBox.Text == "TVA")
                {
                    MessageBox.Show("La TVA n'a pas été renseignée", "TVA manquante", MessageBoxButton.OK, MessageBoxImage.Error);
                    e.Cancel = true;
                }
                if (RefTextBox.Text == "" || RefTextBox.Text == "Référence")
                {
                    MessageBox.Show("La référence n'a pas été renseignée", "Référence manquante", MessageBoxButton.OK, MessageBoxImage.Error);
                    e.Cancel = true;
                }
            }

        }

        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            snackBar.IsActive = true;
            Canceled = false;
            Close();
        }

        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            Canceled = true;
            Close();
        }
    }
}