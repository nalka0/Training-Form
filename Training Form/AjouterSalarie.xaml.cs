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
    public partial class AjouterSalarie : Window
    {
        public bool Canceled = true;

        public AjouterSalarie()
        {
            InitializeComponent();
            Loaded += AjoutUser_Loaded;
            Closing += AjoutUser_Closing;
        }

        private void AjoutUser_Loaded(object sender, RoutedEventArgs e)
        {
            textBoxDateNaissance.SelectedDate = DateTime.Now;
            textBoxDateEmbauche.SelectedDate = DateTime.Now;
        }

        private void AjoutUser_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (DateTime.Compare((DateTime)textBoxDateNaissance.SelectedDate, DateTime.Now) >= 0)
                e.Cancel = true;
            if (!textBoxEmail.Text.Contains("@") && !textBoxEmail.Text.Contains("."))
                e.Cancel = true;
            foreach (char character in numTelephonneTB.Text)
                if (!Char.IsDigit(character))
                    e.Cancel = true;
            if (numTelephonneTB.Text.Length != 10 || numTelephonneTB.Text[0] != '0')
                e.Cancel = true;
            if (DateTime.Compare((DateTime)textBoxDateEmbauche.SelectedDate, DateTime.Now) >= 0)
                e.Cancel = true;
        }

        private void boutonValider_Click(object sender, RoutedEventArgs e)
        {
            Close();
            Canceled = false;
        }

        private void boutonAnnuler_Click(object sender, RoutedEventArgs e)
        {
            Close();
            Canceled = true;
        }
    }
}