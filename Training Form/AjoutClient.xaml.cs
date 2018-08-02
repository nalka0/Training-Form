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
    /// Logique d'interaction pour AjoutClient.xaml
    /// </summary>
    public partial class AjoutClient : Window
    {
        string nom;
        string prenom;
        DateTime dateNaissance;
        string adresse;
        string email;
        string tel;

        public AjoutClient()
        {
            InitializeComponent();
        }

        private void boutonAnnuler_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void boutonValider_Click(object sender, RoutedEventArgs e)
        {
            nom = tbNom.Text;
            prenom = tbPrenom.Text;
            dateNaissance = tbDateNaissance.DisplayDate;
            adresse = tbVille.Text + tbRue.Text;
            email = tbMail.Text;
            tel = tbTelephone.Text;

            Client client = new Client(nom, prenom, email, dateNaissance, "justificatif", "interets", tel);
            JeuxTest.Clients.Add(client);
            this.Close();
        }
    }
}
