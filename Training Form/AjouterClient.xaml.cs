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
                    e.Cancel = true;
                if (!tbMail.Text.Contains("@") && !tbMail.Text.Contains("."))
                    e.Cancel = true;
                foreach (char character in tbTelephone.Text)
                {
                    if (!Char.IsDigit(character))
                        e.Cancel = true;
                }
                if (tbTelephone.Text.Length != 10 || tbTelephone.Text[0] != '0')
                    e.Cancel = true;
            }
        }

        public void boutonAnnuler_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            Canceled = true;
        }

        public void boutonValider_Click(object sender, RoutedEventArgs e)
        {
            Close();
            Canceled = false;
        }
    }
}