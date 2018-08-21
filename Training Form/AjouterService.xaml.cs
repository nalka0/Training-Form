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

        public ajouterService()
        {
            InitializeComponent();
            Title = "Ajouter un service";
            Closing += AjouterService_Closing;
        }

        private void AjouterService_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (DateTime.Compare((DateTime)debutDTP.SelectedDate, DateTime.Now) >= 0)
            {
                MessageBox.Show("La date est incorrect", "Erreur date", MessageBoxButton.OK, MessageBoxImage.Error);
                e.Cancel = true;
            }
            if (dureeNUD.Value < 0)
            {
                MessageBox.Show("La durée est incorrect", "Erreur durée", MessageBoxButton.OK, MessageBoxImage.Error);
                e.Cancel = true;
            }
        }

        private void annuler_Click(object sender, RoutedEventArgs e)
        {
            Canceled = true;
            Close();
        }

        private void valider_Click(object sender, RoutedEventArgs e)
        {
            Canceled = false;
            Close();
        }

        public void ajouterServiceWin_Loaded(object sender, RoutedEventArgs e)
        {
            dureeNUD.Value = 0;
            debutDTP.SelectedDate = DateTime.Now;
        }

        private void prixHTTB_LostFocus(object sender, RoutedEventArgs e)
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
        }
    }
}