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
            this.Loaded += AjoutUser_Loaded;
            this.Closing += AjoutUser_Closing;
        }

        private void AjoutUser_Loaded(object sender, RoutedEventArgs e)
        {
            textBoxDateNaissance.SelectedDate = DateTime.Now;
        }

        private void AjoutUser_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (DateTime.Compare((DateTime)textBoxDateNaissance.SelectedDate, DateTime.Now) >= 0)
                e.Cancel = true;
        }

        string nom;
        string prenom;
        DateTime dateNaissance;
        string adresse;
        string email;
        string password;
        DateTime dateEmbauche;
        string numTelephonne;
        private void boutonValider_Click(object sender, RoutedEventArgs e)
        {
            nom = textBoxNom.Text;
            prenom = textBoxPrenom.Text;
            dateNaissance = textBoxDateNaissance.DisplayDate;
            adresse = textBoxAdresse1.Text + textBoxAdresse2.Text;
            email = textBoxEmail.Text;
            password = textBoxPassword.Text;
            dateEmbauche = textBoxDateEmbauche.DisplayDate;
            numTelephonne = numTelephonneTB.Text;
            Salarie salarie = new Salarie(nom, prenom, email, dateNaissance, Permissions.Salarie, dateEmbauche, password, numTelephonne);
            JeuxTest.Salaries.Add(salarie);
            Close();
        }

        private void boutonAnnuler_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }
    }
}