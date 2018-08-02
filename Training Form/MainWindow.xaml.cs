﻿using System;
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
            emplacementActuel.Content = "Gestion Client";
            dataArticles.ItemsSource = JeuxTest.Articles;
            dataClients.ItemsSource = JeuxTest.Clients;
            dataServices.ItemsSource = JeuxTest.Services;
        }
        
        private void TabItem_GotFocus(object sender, RoutedEventArgs e)
        {
            TabItem tab = sender as TabItem;
            emplacementActuel.Content = String.Format("Gestion {0}", tab.Name);
            ajoutElement.Content = String.Format("Ajouter {0}", tab.Name);
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
            }
        }

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
    }
}