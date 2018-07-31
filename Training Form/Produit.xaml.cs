using System;
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
    public partial class ProduitWind : Window
    {
        private ObservableCollection<Article> CollectionArticles { get; set; }

        public ProduitWind()
        {
            InitializeComponent();
            this.DataContext = this;
            CollectionArticles = new ObservableCollection<Article>();
            dataGrid.ItemsSource = CollectionArticles;
            Article proteine = new Article() { Nom = "prot200", CodeProduit = "000141", Description = "La meilleur du marché de tibo inshape" };
            Article proteine2 = new Article() { Nom = "prot200", CodeProduit = "000141", Description = "La meilleur du marché de tibo inshape" };
            Article proteine3 = new Article() { Nom = "prot200", CodeProduit ="000141", Description = "La meilleur du marché de tibo inshape" };
            Article proteine4 = new Article() { Nom = "prot200", CodeProduit = "000141", Description = "La meilleur du marché de tibo inshape" };
            CollectionArticles.Add(proteine);
            CollectionArticles.Add(proteine2);
            CollectionArticles.Add(proteine4);
            CollectionArticles.Add(proteine3);
        }
    }
}
