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
    public partial class AjouterArticle : Window
    {
        public bool Canceled = true;

        public AjouterArticle()
        {
            InitializeComponent();
            DataContext = this;
            Closing += ProduitWind_Closing;
        }
        
        private void ProduitWind_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //ajouter une verification pour s'assurer que les textBox on été remplies
        }

        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            Close();
            Canceled = false;
        }

        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            Canceled = true;
        }
    }
}