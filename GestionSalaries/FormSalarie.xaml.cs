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
    /// Logique d'interaction pour FormSalarie.xaml
    /// </summary>
    public partial class FormSalarie : Window
    {
        public FormSalarie()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
             //MaListSalaries.Add(new Salarie("aa123aa", "anthony", "arena", "gerant", new DateTime(2000, 10, 23), "azerty", "mail@domaine.fr"));


        }
    }
}
