﻿using System;
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

    public partial class MainWindow : Window
    {

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
            //PanelActif = PanelActif;  ?????????????????????????????
            switch (PanelActif)
            {
                case 0:
                    UserControlClients client = new UserControlClients();
                    client.addClient();
                    break;
                case 1:
                    UserControlClients client2 = new UserControlClients();
                    client2.addClient();
                    break;
                case 2:
                    UserControlProduits produit = new UserControlProduits();
                    produit.addArticle();
                    break;
                case 3:
                    UserControlServices service = new UserControlServices();
                    service.addService();
                    break;
                case 4:
                    UserControlSalarie salarie = new UserControlSalarie();
                    salarie.addSalarie();
                    break;
            }
        }
    }
}
