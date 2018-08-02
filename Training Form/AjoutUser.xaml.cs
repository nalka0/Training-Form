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
    /// Logique d'interaction pour AjoutUser.xaml
    /// </summary>
    public partial class AjoutUser : Window
    {
        public AjoutUser()
        {
            InitializeComponent();
        }

        string nom;
        string prenom;
        DateTime dateNaissance;
        string adresse;
        string email;
        string telephone;
        string mobile;
        string role;
        string password;
        DateTime dateEmbauche;

        private void boutonValider_Click(object sender, RoutedEventArgs e)
        {
            nom = textBoxNom.Text;
            prenom = textBoxPrenom.Text;
            dateNaissance = textBoxDateNaissance.DisplayDate;
            adresse = textBoxAdresse1.Text + textBoxAdresse2.Text;
            email = textBoxEmail.Text;
            telephone = textBoxTelephone.Text;
            mobile = textBoxMobile.Text;
            role = textBoxRole.Text;
            password = textBoxPassword.Text;
            dateEmbauche = textBoxDateEmbauche.DisplayDate;
        }

        private void boutonAnnuler_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}