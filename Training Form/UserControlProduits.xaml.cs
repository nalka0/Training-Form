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
    /// Logique d'interaction pour UserControlProduits.xaml
    /// </summary>
    public partial class UserControlProduits : UserControl
    {
        public UserControlProduits()
        {
            InitializeComponent();
            DataContext = this;
            dataArticles.ItemsSource = JeuxTest.Articles;
        }

        private void supprimerArticle_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Voulez-vous vraiment supprimer cet article ?", "Supprimer", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.OK) { JeuxTest.Articles.RemoveAt(dataArticles.SelectedIndex); }
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
        public void addArticle()
        {
            AjouterArticle fenetreAjout = new AjouterArticle();
            //fenetreAjout.Owner = this;
            fenetreAjout.ShowDialog();
            decimal prixHT;
            decimal tauxTva;
            if ((!fenetreAjout.Canceled || fenetreAjout.Forced) && decimal.TryParse(fenetreAjout.prixHTTextBox.Text, out prixHT) && decimal.TryParse(fenetreAjout.TVATextBox.Text, out tauxTva))
                JeuxTest.Articles.Add(new Article(fenetreAjout.NomTextBox.Text, fenetreAjout.descriptTextBox.Text, prixHT, tauxTva));
        }

    }
}
