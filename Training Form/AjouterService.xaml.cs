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
using System.Windows.Shapes;

namespace Training_Form
{
    /// <summary>
    /// Logique d'interaction pour ajouterService.xaml
    /// </summary>
    public partial class ajouterService : Window
    {
        public bool Canceled = false;

        public ajouterService()
        {
            InitializeComponent();
        }

        private void annuler_Click(object sender, RoutedEventArgs e)
        {
            Canceled = true;
            Close();
        }

        private void valider_Click(object sender, RoutedEventArgs e)
        {
            Canceled = false;
            Close();
        }

        private void ajouterServiceWin_Loaded(object sender, RoutedEventArgs e)
        {
            dureeNUD.Value = 0;
            debutDTP.Value = DateTime.Now;
        }
    }
}
