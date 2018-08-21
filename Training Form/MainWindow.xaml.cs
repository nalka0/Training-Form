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
using MaterialDesignThemes.Wpf;
using LiveCharts;
using LiveCharts.Wpf;
using System.Collections;
using System.Collections.ObjectModel;
using LiveCharts.Defaults;

namespace Training_Form
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Title = "Gestion de Training Form";
            WindowState = WindowState.Maximized;
            DataContext = this;
            dataArticles.ItemsSource = JeuxTest.Articles;
            dataClients.ItemsSource = JeuxTest.Clients;
            dataServices.ItemsSource = JeuxTest.Services;
            dataSalaries.ItemsSource = JeuxTest.Salaries;
            dataDerniersClients.ItemsSource = afficherDeniersClients();
            Chart.Series = JeuxTest.SeriesCollection;
            Charts2.Series = JeuxTest.SeriesCollection2;
            emplacementActuel.Content = "DASHBOARD";
            DashBoard();
        }

        #region evenements

        #region editer
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

        private void editerSalarie_Click(object sender, RoutedEventArgs e)
        {
            AjouterSalarie editerSalarie = new AjouterSalarie();
            editerSalarie.Loaded -= editerSalarie.AjoutUser_Loaded;
            editerSalarie.textBoxNom.Text = JeuxTest.Salaries[dataSalaries.SelectedIndex].Nom;
            editerSalarie.textBoxPrenom.Text = JeuxTest.Salaries[dataSalaries.SelectedIndex].Prenom;
            editerSalarie.textBoxEmail.Text = JeuxTest.Salaries[dataSalaries.SelectedIndex].Mail;
            editerSalarie.textBoxDateNaissance.SelectedDate = JeuxTest.Salaries[dataSalaries.SelectedIndex].DateNaissance;
            editerSalarie.textBoxDateEmbauche.SelectedDate = JeuxTest.Salaries[dataSalaries.SelectedIndex].DateEmbauche;
            editerSalarie.textBoxAdresse.Text = JeuxTest.Salaries[dataSalaries.SelectedIndex].Adresse;
            editerSalarie.numTelephonneTB.Text = JeuxTest.Salaries[dataSalaries.SelectedIndex].NumTelephone;
            editerSalarie.textBoxPassword.Text = JeuxTest.Salaries[dataSalaries.SelectedIndex].Password;
            editerSalarie.ShowDialog();
            JeuxTest.Salaries[dataSalaries.SelectedIndex].Nom = editerSalarie.textBoxNom.Text;
            JeuxTest.Salaries[dataSalaries.SelectedIndex].Prenom = editerSalarie.textBoxPrenom.Text;
            JeuxTest.Salaries[dataSalaries.SelectedIndex].Mail = editerSalarie.textBoxEmail.Text;
            JeuxTest.Salaries[dataSalaries.SelectedIndex].Adresse = editerSalarie.textBoxAdresse.Text;
            JeuxTest.Salaries[dataSalaries.SelectedIndex].DateNaissance = (DateTime)editerSalarie.textBoxDateNaissance.SelectedDate;
            JeuxTest.Salaries[dataSalaries.SelectedIndex].DateEmbauche = (DateTime)editerSalarie.textBoxDateEmbauche.SelectedDate;
            JeuxTest.Salaries[dataSalaries.SelectedIndex].NumTelephone = editerSalarie.numTelephonneTB.Text;
            JeuxTest.Salaries[dataSalaries.SelectedIndex].Password = editerSalarie.textBoxPassword.Text;
            //sert à actualiser l'affichage
            JeuxTest.Salaries.Add(JeuxTest.Salaries[dataSalaries.SelectedIndex]);
            JeuxTest.Salaries.Move(JeuxTest.Salaries.Count - 1, dataSalaries.SelectedIndex);
            JeuxTest.Salaries.RemoveAt(dataSalaries.SelectedIndex);
        }

        private void editerClient_Click(object sender, RoutedEventArgs e)
        {
            AjoutClient editerClient = new AjoutClient();
            editerClient.Loaded -= editerClient.AjoutClient_Loaded;
            editerClient.tbNom.Text = JeuxTest.Clients[dataClients.SelectedIndex].Nom;
            editerClient.tbPrenom.Text = JeuxTest.Clients[dataClients.SelectedIndex].Prenom;
            editerClient.tbDateNaissance.SelectedDate = JeuxTest.Clients[dataClients.SelectedIndex].DateNaissance;
            editerClient.tbMail.Text = JeuxTest.Clients[dataClients.SelectedIndex].Mail;
            editerClient.tbTelephone.Text = JeuxTest.Clients[dataClients.SelectedIndex].NumTelephone;
            editerClient.tbAdresse.Text = JeuxTest.Clients[dataClients.SelectedIndex].Adresse;
            //Si la liste des interets contient l'interet, alors la checkBox qui y correspond devient checkée, sinon elle est pas checkée
            editerClient.cbCardio.IsChecked = JeuxTest.Clients[dataClients.SelectedIndex].Interets.Contains("Cardio");
            editerClient.cbFitness.IsChecked = JeuxTest.Clients[dataClients.SelectedIndex].Interets.Contains("Fitness");
            editerClient.cbMuscu.IsChecked = JeuxTest.Clients[dataClients.SelectedIndex].Interets.Contains("Muscu");
            editerClient.cbPilate.IsChecked = JeuxTest.Clients[dataClients.SelectedIndex].Interets.Contains("Pilate");
            editerClient.cbZumba.IsChecked = JeuxTest.Clients[dataClients.SelectedIndex].Interets.Contains("Zumba");
            switch (JeuxTest.Clients[dataClients.SelectedIndex].Statut)
            {
                case Statuts.Couple:
                    editerClient.rbCouple.IsChecked = true;
                    break;
                case Statuts.Etudiant:
                    editerClient.rbEtudiant.IsChecked = true;
                    break;
                default:
                    editerClient.rbAdulte.IsChecked = true;
                    break;
            }
            editerClient.ShowDialog();
            JeuxTest.Clients[dataClients.SelectedIndex].Nom = editerClient.tbNom.Text;
            JeuxTest.Clients[dataClients.SelectedIndex].Prenom = editerClient.tbPrenom.Text;
            JeuxTest.Clients[dataClients.SelectedIndex].DateNaissance = (DateTime)editerClient.tbDateNaissance.SelectedDate;
            JeuxTest.Clients[dataClients.SelectedIndex].Mail = editerClient.tbMail.Text;
            JeuxTest.Clients[dataClients.SelectedIndex].NumTelephone = editerClient.tbTelephone.Text;
            JeuxTest.Clients[dataClients.SelectedIndex].Adresse = editerClient.tbAdresse.Text;
            //Si la checkbox est cochée, on ajoute l'interet concerné dans la liste des interets, sinon on y ajoute rien
            JeuxTest.Clients[dataClients.SelectedIndex].Interets = ""; 
            JeuxTest.Clients[dataClients.SelectedIndex].Interets += (bool)editerClient.cbCardio.IsChecked ? "Cardio, " : "";
            JeuxTest.Clients[dataClients.SelectedIndex].Interets += (bool)editerClient.cbFitness.IsChecked ? "Fitness, " : "";
            JeuxTest.Clients[dataClients.SelectedIndex].Interets += (bool)editerClient.cbMuscu.IsChecked ? "Muscu, " : "";
            JeuxTest.Clients[dataClients.SelectedIndex].Interets += (bool)editerClient.cbPilate.IsChecked ? "Pilate ," : "";
            JeuxTest.Clients[dataClients.SelectedIndex].Interets += (bool)editerClient.cbZumba.IsChecked ? "Zumba, " : "";
            //Si le radioButton est sur couple alors le statut devient Couple sinon si le radioButton est sur Etudiant le statut devient étudiant sinon il devient adulte.
            JeuxTest.Clients[dataClients.SelectedIndex].Statut = (bool)editerClient.rbCouple.IsChecked ? Statuts.Couple : (bool)editerClient.rbEtudiant.IsChecked ? Statuts.Etudiant : Statuts.Adulte;
            //sert à actualiser l'affichage
            JeuxTest.Clients.Add(JeuxTest.Clients[dataClients.SelectedIndex]);
            JeuxTest.Clients.Move(JeuxTest.Clients.Count - 1, dataClients.SelectedIndex);
            JeuxTest.Clients.RemoveAt(dataClients.SelectedIndex);
        }

        private void editerArticle_Click(object sender, RoutedEventArgs e)
        {
            AjouterArticle editerArticle = new AjouterArticle();
            editerArticle.NomTextBox.Text = JeuxTest.Articles[dataArticles.SelectedIndex].Nom;
            editerArticle.descriptTextBox.Text = JeuxTest.Articles[dataArticles.SelectedIndex].Description;
            editerArticle.prixHTTextBox.Text = JeuxTest.Articles[dataArticles.SelectedIndex].PrixHT.ToString();
            editerArticle.TVATextBox.Text = JeuxTest.Articles[dataArticles.SelectedIndex].TauxTVA.ToString();
            editerArticle.ShowDialog();
            JeuxTest.Articles[dataArticles.SelectedIndex].Nom = editerArticle.NomTextBox.Text;
            JeuxTest.Articles[dataArticles.SelectedIndex].Description = editerArticle.descriptTextBox.Text;
            JeuxTest.Articles[dataArticles.SelectedIndex].PrixHT = decimal.Parse(editerArticle.prixHTTextBox.Text);
            JeuxTest.Articles[dataArticles.SelectedIndex].TauxTVA = decimal.Parse(editerArticle.TVATextBox.Text);
            //sert à actualiser l'affichage
            JeuxTest.Articles.Add(JeuxTest.Articles[dataArticles.SelectedIndex]);
            JeuxTest.Articles.Move(JeuxTest.Articles.Count - 1, dataArticles.SelectedIndex);
            JeuxTest.Articles.RemoveAt(dataArticles.SelectedIndex);
        }
        #endregion

        #region supprimer
        private void supprimerClient_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result =  MessageBox.Show("Voulez-vous vraiment supprimer ce client ?", "Supprimer", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.OK) { JeuxTest.Clients.RemoveAt(dataClients.SelectedIndex); }
        }

        private void supprimerArticle_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Voulez-vous vraiment supprimer cet article ?", "Supprimer", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.OK) { JeuxTest.Articles.RemoveAt(dataArticles.SelectedIndex); }
        }

        private void supprimerService_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Voulez-vous vraiment supprimer ce service ?", "Supprimer", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.OK) { JeuxTest.Services.RemoveAt(dataServices.SelectedIndex); }
        }
        private void supprimerSalarie_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Voulez-vous vraiment supprimer ce salarié ?", "Supprimer", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.OK) { JeuxTest.Salaries.RemoveAt(dataSalaries.SelectedIndex); }
        }
        #endregion

        private void TabItem_GotFocus(object sender, RoutedEventArgs e)
        {
            TabItem tab = sender as TabItem;
            if (tab.Name == "dashBoard")
            {
                emplacementActuel.Content = String.Format("{0}", tab.Name.ToUpper());
            }
            else
            {
                ajoutElement.ToolTip = "Ajouter un " + tab.Name.ToLower();
                emplacementActuel.Content = String.Format("Gestion des {0}s", tab.Name.ToLower());
                switch (tab.Name)
                {
                    case "Service":
                        ajoutElement.Content = new PackIcon() { Kind = PackIconKind.Dumbbell, Height = 24, Width = 24 };
                        break;
                    case "Article":
                        ajoutElement.Content = new PackIcon() { Kind = PackIconKind.PlusBoxOutline, Height = 24, Width = 24 };
                        break;
                    case "Salarie":
                        ajoutElement.Content = new PackIcon() { Kind = PackIconKind.AccountPlus, Height = 24, Width = 24 };
                        break;
                    case "Client":
                        ajoutElement.Content = new PackIcon() { Kind = PackIconKind.AccountPlus, Height = 24, Width = 24 };
                        break;
                }
            }
        }

        private void recherche_TextChanged(object sender, TextChangedEventArgs e)
        {
            TabItem tabRecherche = onglets.SelectedItem as TabItem;
            if (tabRecherche != null)
            {
                switch (tabRecherche.Name)
                {
                    case "Article":
                        dataArticles.ItemsSource = JeuxTest.Articles.Where(item => (item.CodeProduit.ToLower().Contains(recherche.Text.ToLower())) || (item.Nom.ToLower().Contains(recherche.Text.ToLower()))).ToList();
                        break;
                    case "Client":
                        dataClients.ItemsSource = JeuxTest.Clients.Where(item => (item.Identifiant.ToString().ToLower().Contains(recherche.Text.ToLower())) || (item.Nom.ToLower().Contains(recherche.Text.ToLower())) || (item.Prenom.ToLower().Contains(recherche.Text.ToLower()))).ToList();
                        break;
                    case "Salarie":
                        dataSalaries.ItemsSource = JeuxTest.Salaries.Where(item => (item.Identifiant.ToString().ToLower().Contains(recherche.Text.ToLower())) || (item.Nom.ToLower().Contains(recherche.Text.ToLower())) || (item.Prenom.ToLower().Contains(recherche.Text.ToLower()))).ToList();
                        break;
                    case "Service":
                        dataServices.ItemsSource = JeuxTest.Services.Where(item => (item.CodeProduit.ToLower().Contains(recherche.Text.ToLower())) || (item.Nom.ToLower().Contains(recherche.Text.ToLower()))).ToList();
                        break;
                }
            }
        }

        #region ajouter
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
                decimal prixHT = decimal.Parse(fenetreAjout.prixHTTB.Text);
                decimal tauxTVA = decimal.Parse(fenetreAjout.tauxTVATB.Text);
                DateTime debutNouveauService = (DateTime)fenetreAjout.debutDTP.SelectedDate;
                if ((bool)fenetreAjout.moisRB.IsChecked)
                    JeuxTest.Services.Add(new Service(debutNouveauService, dureeNouveauService, nomNouveauService, descriptionNouveauService, prixHT, tauxTVA, true));
                else if ((bool)fenetreAjout.semainesRB.IsChecked)
                    JeuxTest.Services.Add(new Service(debutNouveauService, dureeNouveauService, nomNouveauService, descriptionNouveauService, prixHT, tauxTVA, false));
            }
        }

        void addArticle()
        {
            AjouterArticle fenetreAjout = new AjouterArticle();
            fenetreAjout.ShowDialog();
            decimal prixHT;
            decimal tauxTva;
            if ((!fenetreAjout.Canceled || fenetreAjout.Forced) && decimal.TryParse(fenetreAjout.prixHTTextBox.Text, out prixHT) && decimal.TryParse(fenetreAjout.TVATextBox.Text, out tauxTva))
                JeuxTest.Articles.Add(new Article(fenetreAjout.NomTextBox.Text, fenetreAjout.descriptTextBox.Text, prixHT, tauxTva));
        }

        void addSalarie()
        {
            AjouterSalarie fenetreAjout = new AjouterSalarie();
            fenetreAjout.ShowDialog();
            if (!fenetreAjout.Canceled)
            {
                string nom = fenetreAjout.textBoxNom.Text;
                string prenom = fenetreAjout.textBoxPrenom.Text;
                DateTime dateNaissance = (DateTime)fenetreAjout.textBoxDateNaissance.SelectedDate;
                string adresse = fenetreAjout.textBoxAdresse.Text;
                string email = fenetreAjout.textBoxEmail.Text;
                string password = fenetreAjout.textBoxPassword.Text;
                DateTime dateEmbauche = (DateTime)fenetreAjout.textBoxDateEmbauche.SelectedDate;
                string numTelephonne = fenetreAjout.numTelephonneTB.Text;
                JeuxTest.Salaries.Add(new Salarie(nom, prenom, email, dateNaissance, Permissions.Salarie, dateEmbauche, password, numTelephonne, adresse));
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
                Statuts statut = Statuts.Adulte;
                if ((bool)fenetreAjout.rbCouple.IsChecked)
                    statut = Statuts.Couple;
                else if ((bool)fenetreAjout.rbEtudiant.IsChecked)
                    statut = Statuts.Etudiant;
                Client client = new Client(nom, prenom, email, dateNaissance, "justificatif", "Muscu", tel, adresse, statut);
                JeuxTest.Clients.Add(client);
            }
        }

        public ObservableCollection<Client> afficherDeniersClients()
        {
            ObservableCollection<Client> listeClient = new ObservableCollection<Client>();
            int i = JeuxTest.Clients.Count - 1;

            while(i >= JeuxTest.Clients.Count - 5)
            {
                listeClient.Add(JeuxTest.Clients[i]);
                i--;
            }
            return listeClient;
        }
        #endregion

        #region DashBoard
        Activite bodyScultp = new Activite() { Title = "Body Scultp", Value = 80 };
        Activite stretch = new Activite() { Title = "Stretch", Value = 55 };
        Activite Cross = new Activite() { Title = "Cross", Value = 40 };
        Activite zumba = new Activite() { Title = "Zumba", Value = 140 };
        Activite yoga = new Activite() { Title = "Yoga", Value = 50 };
        Activite pilates = new Activite() { Title = "Pilates", Value = 60 };

        Abonnement abo1 = new Abonnement() { Mois = "janvier", Value = 10 };
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }

        public void DashBoard()
        {
            JeuxTest.SeriesCollection.Add(new PieSeries {Title = bodyScultp.Title, Values = new ChartValues<ObservableValue> { new ObservableValue(bodyScultp.Value) }, DataLabels = true });
            JeuxTest.SeriesCollection.Add(
            new PieSeries
            {
                Title = stretch.Title,
                Values = new ChartValues<ObservableValue> { new ObservableValue(stretch.Value) },
                DataLabels = true
            });
            JeuxTest.SeriesCollection.Add(
            new PieSeries
            {
                Title = Cross.Title,
                Values = new ChartValues<ObservableValue> { new ObservableValue(Cross.Value) },
                DataLabels = true
            });
            JeuxTest.SeriesCollection.Add(
                new PieSeries
                {
                    Title = zumba.Title,
                    Values = new ChartValues<ObservableValue> { new ObservableValue(zumba.Value) },
                    DataLabels = true
                });
            JeuxTest.SeriesCollection.Add(
                new PieSeries
                {
                    Title = yoga.Title,
                    Values = new ChartValues<ObservableValue> { new ObservableValue(yoga.Value) },
                    DataLabels = true
                });
            JeuxTest.SeriesCollection.Add(
                new PieSeries
                {
                    Title = pilates.Title,
                    Values = new ChartValues<ObservableValue> { new ObservableValue(pilates.Value) },
                    DataLabels = true
                });
            JeuxTest.SeriesCollection2.Add(
                new ColumnSeries
                {
                    Title = "2017",
                    Values = new ChartValues<double> { 5, 8, 6, 5, 6, 4, 2, 11, 12, 1, 5, 2 },
                    Fill = Brushes.LightSlateGray
                }
            );
            JeuxTest.SeriesCollection2.Add(new ColumnSeries
            {
                Title = "2018",
                Values = new ChartValues<double> { 10, 5, 10, 7, 14, 20, 10, 11, 14, 5, 0, 10 },
                Fill = Brushes.DarkTurquoise

            });

            Labels = new[] { "janvier", "fevrier", "mars", "avril", "mai", "juin", "juillet", "aout", "septembre", "octobre", "novembre", "decembre" };
            Formatter = value => value.ToString("N");
            Charts2.DataContext = this;
        }
        #endregion

       
    }


    #region class dashboardTest
    public class Activite
    {
        public string Title;
        public int Value;
    }
    public class Abonnement
    {
        public string Mois;
        public int Value;
    }
    #endregion
}