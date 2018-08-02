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
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.WindowState = WindowState.Maximized;
            InitializeComponent();
            this.DataContext = this;            
            dataArticles.ItemsSource = JeuxTest.Articles;
            dataClients.ItemsSource = JeuxTest.Clients;
            dataServices.ItemsSource = JeuxTest.Services;
            dataSalaries.ItemsSource = JeuxTest.Salaries;
        }

        #region evenements
        private void TabItem_GotFocus(object sender, RoutedEventArgs e)
        {
            TabItem tab = sender as TabItem;
            emplacementActuel.Content = String.Format("Gestion {0}", tab.Name);
            switch (tab.Name)
            {
                case "Service":
                   ajoutElement.Content = new MaterialDesignThemes.Wpf.PackIcon() { Kind = MaterialDesignThemes.Wpf.PackIconKind.Dumbbell, Height = 24, Width = 24};
                    break;
                case "Article":
                    ajoutElement.Content = new MaterialDesignThemes.Wpf.PackIcon() { Kind = MaterialDesignThemes.Wpf.PackIconKind.PlusBoxOutline, Height = 24, Width = 24};
                    break;
                case "Salarie":
                    ajoutElement.Content = new MaterialDesignThemes.Wpf.PackIcon() { Kind = MaterialDesignThemes.Wpf.PackIconKind.AccountPlus, Height = 24, Width = 24};
                    break;
                case "Client":
                    ajoutElement.Content = new MaterialDesignThemes.Wpf.PackIcon() { Kind = MaterialDesignThemes.Wpf.PackIconKind.AccountPlus, Height = 24, Width = 24};
                    break;

            }

        }

        private void ajoutElement_Click(object sender, RoutedEventArgs e)
        {
            TabItem ongletActuel = onglets.SelectedItem as TabItem;
            switch (ongletActuel.Name)
            {
                case "Service":
                    addService();
                    break;
                case "Article":
                    AddArticle();
                    break;
                case "Salarie":
                    AddSalarie();
                    break;
                case "Client":
                    AddClient();
                    break;
            }
        }
        #endregion

        #region methodes
        void addService()
        {
            ajouterService fenetreAjout = new ajouterService();
            fenetreAjout.ShowDialog();
            string nomNouveauService = fenetreAjout.nomTB.Text;
            int dureeNouveauService = (int)fenetreAjout.dureeNUD.Value;
            string descriptionNouveauService = fenetreAjout.descriptionTB.Text;
            DateTime debutNouveauService = (DateTime)fenetreAjout.debutDTP.SelectedDate;
            JeuxTest.Services.Add(new Service(dureeNouveauService, debutNouveauService, "0450560650", nomNouveauService, descriptionNouveauService));
        }
        void AddArticle()
        {
            ProduitWind fenetreAjout = new ProduitWind();
            fenetreAjout.ShowDialog();
        }
        void AddSalarie()
        {
            AjoutUser fenetreAjout = new AjoutUser();
            fenetreAjout.ShowDialog();
        }
        void AddClient()
        {
            AjoutClient fenetreAjout = new AjoutClient();
            fenetreAjout.ShowDialog();
            string nom = fenetreAjout.tbNom.Text;
            string prenom = fenetreAjout.tbPrenom.Text;
            DateTime dateNaissance = (DateTime)fenetreAjout.tbDateNaissance.SelectedDate;
            string adresse = fenetreAjout.tbVille.Text + fenetreAjout.tbRue.Text;
            string email = fenetreAjout.tbMail.Text;
            string tel = fenetreAjout.tbTelephone.Text;
            Client client = new Client(nom, prenom, email, dateNaissance, "justificatif", "Muscu", tel, "adresse de jean michel pierre paul");
            JeuxTest.Clients.Add(client);
        }
        #endregion

        private void editerClient_Click(object sender, RoutedEventArgs e)
        {
            AjoutClient test = new AjoutClient();
            test.Loaded -= test.AjoutClient_Loaded;
            test.Closing -= test.AjoutClient_Closing;
            test.tbNom.Text = JeuxTest.Clients[dataClients.SelectedIndex].Nom;
            test.tbPrenom.Text = JeuxTest.Clients[dataClients.SelectedIndex].Prenom;
            test.tbDateNaissance.SelectedDate = JeuxTest.Clients[dataClients.SelectedIndex].DateNaissance;
            test.tbMail.Text = JeuxTest.Clients[dataClients.SelectedIndex].Mail;
            test.ShowDialog();
        }
    }
}