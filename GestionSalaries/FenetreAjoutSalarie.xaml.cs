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

namespace GestionSalaries
{
    /// <summary>
    /// Logique d'interaction pour FenetreAjoutSalarie.xaml
    /// </summary>
    public partial class FenetreAjoutSalarie : Window
    {
        public FenetreAjoutSalarie()
        {
            InitializeComponent();
        }

        private void boutonAjouter_Click(object sender, RoutedEventArgs e)
        {
            Salarie sal = new Salarie() { NumSalarie = "7896", Nom = "coucou", Prenom = "test" };
            DataBase.Salaries.Add(sal);
        }

        private void boutonAnnuler_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
