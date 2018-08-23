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

namespace Training_Form
{
    /// <summary>
    /// Logique d'interaction pour UserControlSalarie.xaml
    /// </summary>
    public partial class UserControlSalarie : UserControl
    {
        public UserControlSalarie()
        {
            InitializeComponent();
            DataContext = this;
            dataSalaries.ItemsSource = JeuxTest.Salaries;
        }

        private void editerSalarie_Click(object sender, RoutedEventArgs e)
        {
            AjouterSalarie editerSalarie = new AjouterSalarie();
            editerSalarie.Owner = Application.Current.MainWindow;
            editerSalarie.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            editerSalarie.Loaded -= editerSalarie.AjoutUser_Loaded;
            editerSalarie.textBoxNom.Text = JeuxTest.Salaries[dataSalaries.SelectedIndex].Nom;
            editerSalarie.textBoxPrenom.Text = JeuxTest.Salaries[dataSalaries.SelectedIndex].Prenom;
            editerSalarie.textBoxEmail.Text = JeuxTest.Salaries[dataSalaries.SelectedIndex].Mail;
            editerSalarie.textBoxDateNaissance.SelectedDate = JeuxTest.Salaries[dataSalaries.SelectedIndex].DateNaissance;
            editerSalarie.textBoxDateEmbauche.SelectedDate = JeuxTest.Salaries[dataSalaries.SelectedIndex].DateEmbauche;
            editerSalarie.textBoxAdresse.Text = JeuxTest.Salaries[dataSalaries.SelectedIndex].Adresse;
            editerSalarie.numTelephonneTB.Text = JeuxTest.Salaries[dataSalaries.SelectedIndex].NumTelephone;
            editerSalarie.textBoxPassword.Text = JeuxTest.Salaries[dataSalaries.SelectedIndex].Password;
            editerSalarie.ShowDialog();
            JeuxTest.Salaries[dataSalaries.SelectedIndex].Nom = editerSalarie.textBoxNom.Text;
            JeuxTest.Salaries[dataSalaries.SelectedIndex].Prenom = editerSalarie.textBoxPrenom.Text;
            JeuxTest.Salaries[dataSalaries.SelectedIndex].Mail = editerSalarie.textBoxEmail.Text;
            JeuxTest.Salaries[dataSalaries.SelectedIndex].Adresse = editerSalarie.textBoxAdresse.Text;
            JeuxTest.Salaries[dataSalaries.SelectedIndex].DateNaissance = (DateTime)editerSalarie.textBoxDateNaissance.SelectedDate;
            JeuxTest.Salaries[dataSalaries.SelectedIndex].DateEmbauche = (DateTime)editerSalarie.textBoxDateEmbauche.SelectedDate;
            JeuxTest.Salaries[dataSalaries.SelectedIndex].NumTelephone = editerSalarie.numTelephonneTB.Text;
            JeuxTest.Salaries[dataSalaries.SelectedIndex].Password = editerSalarie.textBoxPassword.Text;
            //sert à actualiser l'affichage
            JeuxTest.Salaries.Add(JeuxTest.Salaries[dataSalaries.SelectedIndex]);
            JeuxTest.Salaries.Move(JeuxTest.Salaries.Count - 1, dataSalaries.SelectedIndex);
            JeuxTest.Salaries.RemoveAt(dataSalaries.SelectedIndex);
        }

        private void supprimerSalarie_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Voulez-vous vraiment supprimer ce salarié ?", "Supprimer", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.OK) { JeuxTest.Salaries.RemoveAt(dataSalaries.SelectedIndex); }
        }
        public void addSalarie()
        {
            AjouterSalarie fenetreAjout = new AjouterSalarie();
            fenetreAjout.Owner = Application.Current.MainWindow;
            fenetreAjout.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            fenetreAjout.ShowDialog();
            if (!fenetreAjout.Canceled)
            {
                string nom = fenetreAjout.textBoxNom.Text;
                string prenom = fenetreAjout.textBoxPrenom.Text;
                DateTime dateNaissance = (DateTime)fenetreAjout.textBoxDateNaissance.SelectedDate;
                string adresse = fenetreAjout.textBoxAdresse.Text;
                string email = fenetreAjout.textBoxEmail.Text;
                string password = fenetreAjout.textBoxPassword.Text;
                DateTime dateEmbauche = (DateTime)fenetreAjout.textBoxDateEmbauche.SelectedDate;
                string numTelephonne = fenetreAjout.numTelephonneTB.Text;
                JeuxTest.Salaries.Add(new Salarie(nom, prenom, email, dateNaissance, Permissions.Salarie, dateEmbauche, password, numTelephonne, adresse));
            }
        }

    }
}
