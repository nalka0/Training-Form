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
            TableauSalaries.ItemsSource = DataBase.Salaries;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Salarie sal = new Salarie() { NumSalarie = "1234", Nom = "toto", Prenom = "titi" };

            if (!DataBase.Salaries.Contains(sal))
                { DataBase.Salaries.Add(sal); }
        }
    }
}