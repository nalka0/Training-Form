using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace GestionSalaries
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        public new void Run()
        {
            Demarrage.Initialiser();

            // Call the base method
            base.Run();
        }
    }
}
