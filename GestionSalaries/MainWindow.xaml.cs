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

namespace GestionSalaries
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MalisteSalaries maListeSalaries;
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            maListeSalaries = new MalisteSalaries();
            TableauSalaries.ItemsSource = maListeSalaries;

            maListeSalaries.Add(new Salarie("aa123aa", "toto", "martin", "coach", new DateTime(2000, 10, 23), "azerty", "mail@domaine.fr"));
            maListeSalaries.Add(new Salarie("aa123aa", "flo", "carrey", "coach", new DateTime(2000, 10, 23), "azerty", "mail@domaine.fr"));
            maListeSalaries.Add(new Salarie("aa123aa", "julien", "moreau", "coach", new DateTime(2000, 10, 23), "azerty", "mail@domaine.fr"));
            maListeSalaries.Add(new Salarie("aa123aa", "anthony", "arena", "gerant", new DateTime(2000, 10, 23), "azerty", "mail@domaine.fr"));
            

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BoutonAjouterSalarie_Click(object sender, RoutedEventArgs e)
        {
            FormSalarie formSalarie = new FormSalarie();
            formSalarie.ShowDialog();

        }
    }


}
