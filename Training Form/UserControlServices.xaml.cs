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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Training_Form
{
    /// <summary>
    /// Logique d'interaction pour UserControlServices.xaml
    /// </summary>
    public partial class UserControlServices : UserControl
    {
        public UserControlServices()
        {
            InitializeComponent();
            DataContext = this;
            dataServices.ItemsSource = JeuxTest.Services;
        }

            private void editerService_Click(object sender, RoutedEventArgs e)
        {
            ajouterService editerService = new ajouterService();
            editerService.Loaded -= editerService.ajouterServiceWin_Loaded;
            editerService.nomTB.Text = JeuxTest.Services[dataServices.SelectedIndex].Nom;
            editerService.descriptionTB.Text = JeuxTest.Services[dataServices.SelectedIndex].Description;
            editerService.prixHTTB.Text = JeuxTest.Services[dataServices.SelectedIndex].PrixHT.ToString();
            editerService.tauxTVATB.Text = JeuxTest.Services[dataServices.SelectedIndex].TauxTVA.ToString();
            editerService.dureeNUD.Value = JeuxTest.Services[dataServices.SelectedIndex].Duree;
            editerService.debutDTP.SelectedDate = JeuxTest.Services[dataServices.SelectedIndex].DebutAbo;
            editerService.ShowDialog();
            JeuxTest.Services[dataServices.SelectedIndex].Nom = editerService.nomTB.Text;
            JeuxTest.Services[dataServices.SelectedIndex].Description = editerService.descriptionTB.Text;
            JeuxTest.Services[dataServices.SelectedIndex].PrixHT = decimal.Parse(editerService.prixHTTB.Text);
            JeuxTest.Services[dataServices.SelectedIndex].TauxTVA = decimal.Parse(editerService.tauxTVATB.Text);
            JeuxTest.Services[dataServices.SelectedIndex].Duree = (int)editerService.dureeNUD.Value;
            JeuxTest.Services[dataServices.SelectedIndex].DebutAbo = (DateTime)editerService.debutDTP.SelectedDate;
            //sert à actualiser l'affichage
            JeuxTest.Services.Add(JeuxTest.Services[dataServices.SelectedIndex]);
            JeuxTest.Services.Move(JeuxTest.Services.Count - 1, dataServices.SelectedIndex);
            JeuxTest.Services.RemoveAt(dataServices.SelectedIndex);
        }

        private void supprimerService_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Voulez-vous vraiment supprimer ce service ?", "Supprimer", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.OK) { JeuxTest.Services.RemoveAt(dataServices.SelectedIndex); }
        }
        public void addService()
        {
            ajouterService fenetreAjout = new ajouterService();
            //fenetreAjout.Owner = this;
            fenetreAjout.ShowDialog();
            if (!fenetreAjout.Canceled)
            {
                string nomNouveauService = fenetreAjout.nomTB.Text;
                int dureeNouveauService = (int)fenetreAjout.dureeNUD.Value;
                string descriptionNouveauService = fenetreAjout.descriptionTB.Text;
                decimal prixHt;
                decimal tauxTva;
                decimal.TryParse(fenetreAjout.prixHTTB.Text, out prixHt);
                decimal.TryParse(fenetreAjout.tauxTVATB.Text, out tauxTva);
                DateTime debutNouveauService = (DateTime)fenetreAjout.debutDTP.SelectedDate;
                JeuxTest.Services.Add(new Service(dureeNouveauService, debutNouveauService, nomNouveauService, descriptionNouveauService, prixHt, tauxTva));
            }
        }

    }
}
