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
            WindowState = WindowState.Maximized;
            InitializeComponent();
            DataContext = this;            
            dataArticles.ItemsSource = JeuxTest.Articles;
            dataClients.ItemsSource = JeuxTest.Clients;
            dataServices.ItemsSource = JeuxTest.Services;
            dataSalaries.ItemsSource = JeuxTest.Salaries;
        }

        #region evenements
        private void editerClient_Click(object sender, RoutedEventArgs e)
        {
            AjoutClient test = new AjoutClient();
            test.Loaded -= test.AjoutClient_Loaded;
            test.Closing -= test.AjoutClient_Closing;
            test.tbNom.Text = JeuxTest.Clients[dataClients.SelectedIndex].Nom;
            test.tbPrenom.Text = JeuxTest.Clients[dataClients.SelectedIndex].Prenom;
            test.tbDateNaissance.SelectedDate = JeuxTest.Clients[dataClients.SelectedIndex].DateNaissance;
            test.tbMail.Text = JeuxTest.Clients[dataClients.SelectedIndex].Mail;
            test.tbTelephone.Text = JeuxTest.Clients[dataClients.SelectedIndex].NumTelephone;
            test.tbAdresse.Text = JeuxTest.Clients[dataClients.SelectedIndex].Adresse;
            //Si la liste des interets contient l'interet, alors la checkBox qui y correspond devient checkée, sinon elle est pas checkée
            test.cbCardio.IsChecked = JeuxTest.Clients[dataClients.SelectedIndex].Interets.Contains("Cardio");
            test.cbFitness.IsChecked = JeuxTest.Clients[dataClients.SelectedIndex].Interets.Contains("Fitness");
            test.cbMuscu.IsChecked = JeuxTest.Clients[dataClients.SelectedIndex].Interets.Contains("Muscu");
            test.cbPilate.IsChecked = JeuxTest.Clients[dataClients.SelectedIndex].Interets.Contains("Pilate");
            test.cbZumba.IsChecked = JeuxTest.Clients[dataClients.SelectedIndex].Interets.Contains("Zumba");
            //test.rbAdulte.IsChecked = JeuxTest.Clients[dataClients.SelectedIndex]
            test.ShowDialog();
        }

        private void TabItem_GotFocus(object sender, RoutedEventArgs e)
        {
            TabItem tab = sender as TabItem;
            ajoutElement.ToolTip = "Ajouter un " + tab.Name.ToLower();
            emplacementActuel.Content = String.Format("Gestion des {0}s", tab.Name.ToLower());
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
                    addArticle();
                    break;
                case "Salarie":
                    addSalarie();
                    break;
                case "Client":
                    addClient();
                    break;
            }
        }
        #endregion

        #region methodes
        void addService()
        {
            ajouterService fenetreAjout = new ajouterService();
            fenetreAjout.ShowDialog();
            if (!fenetreAjout.Canceled)
            {
                string nomNouveauService = fenetreAjout.nomTB.Text;
                int dureeNouveauService = (int)fenetreAjout.dureeNUD.Value;
                string descriptionNouveauService = fenetreAjout.descriptionTB.Text;
                decimal prixHt = decimal.Parse(fenetreAjout.prixHTTB.Text);
                decimal tauxTva = decimal.Parse(fenetreAjout.tauxTVATB.Text);
                DateTime debutNouveauService = (DateTime)fenetreAjout.debutDTP.SelectedDate;
                JeuxTest.Services.Add(new Service(dureeNouveauService, debutNouveauService, "0450560650", nomNouveauService, descriptionNouveauService,prixHt,tauxTva));
            }
        }

        void addArticle()
        {
            AjouterArticle fenetreAjout = new AjouterArticle();
            fenetreAjout.ShowDialog();
            if (!fenetreAjout.Canceled)
                JeuxTest.Articles.Add(new Article(fenetreAjout.RefTextBox.Text, fenetreAjout.NomTextBox.Text, fenetreAjout.descriptTextBox.Text, decimal.Parse(fenetreAjout.prixHTTextBox.Text), decimal.Parse(fenetreAjout.TVATextBox.Text)));
        }

        void addSalarie()
        {
            AjouterSalarie fenetreAjout = new AjouterSalarie();
            fenetreAjout.ShowDialog();
            if (!fenetreAjout.Canceled)
            {
                string nom = fenetreAjout.textBoxNom.Text;
                string prenom = fenetreAjout.textBoxPrenom.Text;
                DateTime dateNaissance = fenetreAjout.textBoxDateNaissance.DisplayDate;
                string adresse = fenetreAjout.textBoxAdresse1.Text + fenetreAjout.textBoxAdresse2.Text;
                string email = fenetreAjout.textBoxEmail.Text;
                string password = fenetreAjout.textBoxPassword.Text;
                DateTime dateEmbauche = fenetreAjout.textBoxDateEmbauche.DisplayDate;
                string numTelephonne = fenetreAjout.numTelephonneTB.Text;
                JeuxTest.Salaries.Add(new Salarie(nom, prenom, email, dateNaissance, Permissions.Salarie, dateEmbauche, password, numTelephonne, "adresse de jean michel pierre paul"));
            }
        }

        void addClient()
        {
            AjoutClient fenetreAjout = new AjoutClient();
            fenetreAjout.ShowDialog();
            if (!fenetreAjout.Canceled)
            {
                string nom = fenetreAjout.tbNom.Text;
                string prenom = fenetreAjout.tbPrenom.Text;
                DateTime dateNaissance = (DateTime)fenetreAjout.tbDateNaissance.SelectedDate;
                string adresse = fenetreAjout.tbAdresse.Text;
                string email = fenetreAjout.tbMail.Text;
                string tel = fenetreAjout.tbTelephone.Text;
                Client client = new Client(nom, prenom, email, dateNaissance, "justificatif", "Muscu", tel, adresse);
                JeuxTest.Clients.Add(client);
            }
        }
        #endregion
    }
}