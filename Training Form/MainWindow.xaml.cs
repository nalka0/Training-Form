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
                    ajoutElement.Content="";
                    break;
                case "Article":
                    ;
                    break;
                case "Salarie":
                    ;
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
            DateTime debutNouveauService = (DateTime)fenetreAjout.debutDTP.Value;
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
            fenetreAjout.groupBoxStatuts.Visibility = Visibility.Hidden;
            fenetreAjout.groupBoxInterets.Visibility = Visibility.Hidden;
            fenetreAjout.groupBoxSexe.Visibility = Visibility.Hidden;
            fenetreAjout.ShowDialog();
        }
        void AddClient()
        {
            AjoutUser fenetreAjout = new AjoutUser();
            fenetreAjout.textBoxPassword.Visibility = Visibility.Hidden;
            fenetreAjout.textBoxDateEmbauche.Visibility = Visibility.Hidden;
            fenetreAjout.labelDateEmbauche.Visibility = Visibility.Hidden;
            fenetreAjout.ShowDialog();
        }
        #endregion
    }
}