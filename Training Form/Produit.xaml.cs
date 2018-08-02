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
        
        public ProduitWind()
        {
            InitializeComponent();
            this.DataContext = this;  
        }

        private void Valider_Click(object sender, RoutedEventArgs e)
        {

            Button but = sender as Button;
            if (but != null)
            {                
                if (but.Name == "Valider")
                {

                    Article article = new Article(RefTextBox.Text,NomTextBox.Text,descriptTextBox.Text);
                    JeuxTest.Articles.Add(article);
                }
            }
            

        }
    }
}
