using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Training_Form
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window { 

        private int _panelActif;


        public int PanelActif
        {
            get
            {
                return _panelActif;
            }
            set
            {
                _panelActif = value;

            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            GridMain.Children.Clear();
            int index = ListViewMenu.SelectedIndex;
            PanelActif = index;
            switch (index)
            {
                case 0:
                    GridMain.Children.Clear();
                    GridMain.Children.Add(new UserControlHome());
                    recherche.Visibility = Visibility.Collapsed;
                    iconElement.Kind = MaterialDesignThemes.Wpf.PackIconKind.Face;
                    textBlockTitre.Text = accueilText.Text;
                    break;
                case 1:
                    GridMain.Children.Clear();
                    GridMain.Children.Add(new UserControlClients());
                    recherche.Visibility = Visibility.Visible;
                    iconElement.Kind = MaterialDesignThemes.Wpf.PackIconKind.Face;
                    textBlockTitre.Text = clientText.Text;
                    break;
                case 2:
                    GridMain.Children.Clear();
                    GridMain.Children.Add(new UserControlProduits());
                    recherche.Visibility = Visibility.Visible;
                    iconElement.Kind = MaterialDesignThemes.Wpf.PackIconKind.CartPlus;
                    textBlockTitre.Text = articleText.Text;
                    break;
                case 3:
                    GridMain.Children.Clear();
                    GridMain.Children.Add(new UserControlServices());
                    recherche.Visibility = Visibility.Visible;
                    iconElement.Kind = MaterialDesignThemes.Wpf.PackIconKind.Basketball;
                    textBlockTitre.Text = serviceText.Text;
                    break;
                case 4:
                    GridMain.Children.Clear();
                    GridMain.Children.Add(new UserControlSalarie());
                    recherche.Visibility = Visibility.Visible;
                    iconElement.Kind = MaterialDesignThemes.Wpf.PackIconKind.Worker;
                    textBlockTitre.Text = salarieText.Text;
                    break;
                default:
                    break;
            }
        }
        private void ajoutElement_Click(object sender, RoutedEventArgs e)
        {
            PanelActif = PanelActif;
                switch (PanelActif)
                {
                    case 0:
                       addClient();
                       break;
                    case 3:
                        addService();
                        break;
                    case 2:
                        addArticle();
                        break;
                    case 4:
                        addSalarie();
                        break;
                    case 1:
                        addClient();
                        break;
                }
            }
            void addService()
            {
                ajouterService fenetreAjout = new ajouterService();
                fenetreAjout.Owner = this;
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

            void addArticle()
            {
                AjouterArticle fenetreAjout = new AjouterArticle();
                fenetreAjout.Owner = this;
                fenetreAjout.ShowDialog();
                decimal prixHT;
                decimal tauxTva;
                if ((!fenetreAjout.Canceled || fenetreAjout.Forced) && decimal.TryParse(fenetreAjout.prixHTTextBox.Text, out prixHT) && decimal.TryParse(fenetreAjout.TVATextBox.Text, out tauxTva))
                    JeuxTest.Articles.Add(new Article(fenetreAjout.NomTextBox.Text, fenetreAjout.descriptTextBox.Text, prixHT, tauxTva));
            }

            void addSalarie()
            {
                AjouterSalarie fenetreAjout = new AjouterSalarie();
                 fenetreAjout.Owner = this;
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
            fenetreAjout.Owner = this;
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
                    string interets = "";
                    if ((bool)fenetreAjout.cbCardio.IsChecked)
                    {
                        interets += "Cardio ";
                    }
                    if ((bool)fenetreAjout.cbFitness.IsChecked)
                    {
                        interets += "Fitness ";
                    }
                    if ((bool)fenetreAjout.cbMuscu.IsChecked)
                    {
                        interets += "Muscu ";
                    }
                    if ((bool)fenetreAjout.cbPilate.IsChecked)
                    {
                        interets += "Pilate ";
                    }
                    if ((bool)fenetreAjout.cbZumba.IsChecked)
                    {
                        interets += "Zumba ";
                    }
                    Client client = new Client(nom, prenom, email, dateNaissance, "justificatif", interets, tel, adresse, statut);
                    JeuxTest.Clients.Add(client);
                }
            }
        }
    }
