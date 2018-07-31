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
    /// Logique d'interaction pour FenetreClients.xaml
    /// </summary>
    public partial class FenetreClients : Window
    {
        private ObservableCollection<Client> listeClients { get; set; }

        private Client Cl1 = new Client("Pignon", "Jean", "06888888", "JeanPignondeParis@gmail.com", "25.12.2000", "gym tonic", "oui");
        private Client Cl2 = new Client("Lemon", "Bob", "06777778", "Lemonbob@gmail.com", "20.10.1975", "zumba", "non");
        private Client Cl3 = new Client("Freeze", "Mister", "06555555", "MisterFreeze@gmail.com", "10.02.1995", "Yoga", "non");
        public FenetreClients()
        {
            InitializeComponent();
            this.DataContext = this;
            listeClients = new ObservableCollection<Client>();
            DonneesClients.ItemsSource = listeClients;


            listeClients.Add(Cl1);
            listeClients.Add(Cl2);
            listeClients.Add(Cl3);
        }


    }
}
