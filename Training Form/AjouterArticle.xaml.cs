﻿using System;
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
        public bool Notify = false;
        public bool Forced = false;

        public AjouterArticle()
        {
            InitializeComponent();
            DataContext = this;
            Title = "Ajouter un article";
            Closing += ProduitWind_Closing;
        }

        private void ProduitWind_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!Canceled)
            {
                if (NomTextBox.Text == "" || NomTextBox.Text == "Nom")
                {
                    //MessageBox.Show("Le nom n'a pas été renseigné", "Nom manquant", MessageBoxButton.OK, MessageBoxImage.Error);
                    Notify = true;
                }
                if (RefTextBox.Text == "" || RefTextBox.Text == "Référence")
                {
                    //MessageBox.Show("La référence n'a pas été renseignée", "Référence manquante", MessageBoxButton.OK, MessageBoxImage.Error);
                    Notify = true;
                }
                if (Notify)
                {
                    snackBar.IsActive = true;
                    e.Cancel = true;
                }
            }
            decimal useless;
            if (!decimal.TryParse(prixHTTextBox.Text, out useless))
            {
               MessageBox.Show("Le prix HT n'est pas une valeur correcte", "PrixHT incorrect", MessageBoxButton.OK, MessageBoxImage.Error);
                e.Cancel = true;
            }
            if (!decimal.TryParse(TVATextBox.Text, out useless))
            {
                MessageBox.Show("La TVA n'est pas une valeur correcte", "TVA incorrecte", MessageBoxButton.OK, MessageBoxImage.Error);
                e.Cancel = true;
            }

        }

        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            Canceled = false;
            Close();
        }

        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            Canceled = true;
            Close();
        }

        private void snackBarMessage_ActionClick(object sender, RoutedEventArgs e)
        {
            Canceled = true;
            Notify = false;
            Forced = true;
            Close();
        }
    }
}