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
        private Client Cl1 = new Client("Pignon", "Jean", "JeanPignondeParis@gmail.com", new DateTime(2000,12,25), "gym tonic", "oui");
        private Client Cl2 = new Client("Lemon", "Bob", "Lemonbob@gmail.com", new DateTime(1975, 10, 20), "zumba", "non");
        private Client Cl3 = new Client("Freeze", "Mister", "MisterFreeze@gmail.com", new DateTime(1995, 02, 10), "Yoga", "non");

        public FenetreClients()
        {
            InitializeComponent();
            this.DataContext = this;
            listeClients = new ObservableCollection<Client>();
            Console.WriteLine(Cl1.getAge());
            Console.WriteLine(Cl2.getAge());
            Console.WriteLine(Cl3.getAge());
            listeClients.Add(Cl1);
            listeClients.Add(Cl2);
            listeClients.Add(Cl3);
        }
    }
}
