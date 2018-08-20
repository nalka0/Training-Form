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
        public bool Canceled = true;

        public AjoutClient()
        {
            InitializeComponent();
            Title = "Ajouter un client";
            Loaded += AjoutClient_Loaded;
            Closing += AjoutClient_Closing;
        }

        public void AjoutClient_Loaded(object sender, RoutedEventArgs e)
        {
            tbDateNaissance.SelectedDate = DateTime.Now;
        }

        public void AjoutClient_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!Canceled)
            {
                if (DateTime.Compare((DateTime)tbDateNaissance.SelectedDate, DateTime.Now) >= 0)
                {
                    MessageBox.Show("Erreur dans la date", "Erreur date", MessageBoxButton.OK, MessageBoxImage.Error);
                    e.Cancel = true;
                }
                if (!tbMail.Text.Contains("@") && !tbMail.Text.Contains("."))
                {
                    MessageBox.Show("Le mail n'est pas conforme", "Erreur mail", MessageBoxButton.OK, MessageBoxImage.Error);
                    e.Cancel = true;
                }
                foreach (char character in tbTelephone.Text)
                {
                    if (!Char.IsDigit(character))
                        e.Cancel = true;
                }
                if (tbTelephone.Text.Length != 10 || tbTelephone.Text[0] != '0')
                {
                    MessageBox.Show("Le numéro de téléphone n'est pas conforme", "Erreur téléphone", MessageBoxButton.OK, MessageBoxImage.Error);
                    e.Cancel = true;
                }
            }
        }

        public void boutonAnnuler_Click(object sender, RoutedEventArgs e)
        {
            Canceled = true;
            Close();
        }

        public void boutonValider_Click(object sender, RoutedEventArgs e)
        {
            Canceled = false;
            Close();
        }
    }
}