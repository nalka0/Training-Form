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
    /// Logique d'interaction pour PanelUserControlTrombi.xaml
    /// </summary>
    public partial class PanelUserControlTrombi : UserControl
    {
        public PanelUserControlTrombi()
        {
            InitializeComponent();
            //GridPanelUser.Children.Clear();
           // PanelUser.Children.Add(new UserControlTrombi());
           // PanelUser.Children.Add(new UserControlTrombi());
            //iconElement.Kind = MaterialDesignThemes.Wpf.PackIconKind.Worker;
            //textBlockTitre.Text = trombinoscopeText.Text;

            foreach (var item in JeuxTest.Clients)
            {
                PanelUser.Children.Add(new UserControlTrombi(item.Nom, item.Prenom, item.NumTelephone, item.Mail));
                
            }
        }
    }
}
