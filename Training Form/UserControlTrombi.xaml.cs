using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Logique d'interaction pour UserControlTrombi.xaml
    /// </summary>
    public partial class UserControlTrombi : UserControl
    {
        //private string _myUrlImage;
        //public string MyUrlImage
        //{
        //    get
        //    {
        //        return _myUrlImage;
        //    }
        //    set
        //    {
        //        _myUrlImage = value;
        //      // OnPropertyChanged("MyUrlImage");
        //    }
        //}


        public UserControlTrombi(string nom, string prenom, string tel, string email)
        {
            InitializeComponent();
           // DataContext = this;
           // MyUrlImage = "http://placeimg.com/640/480/people";
            Nom.Text = string.Format("{0} {1}",nom,prenom);
            DetailEmail.Text = email;
            DetailNom.Text = nom;
            DetailPrenom.Text = prenom;
            DetailTel.Text = tel;
        }


    }
}
