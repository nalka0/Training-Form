using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionSalaries
{
    public static class Demarrage
    {
        public static void Initialiser()
        {
            DataBase.Salaries.Add(new Salarie() { NumSalarie = "120145", Nom = "Bost", Prenom = "vincent", DateNaissance = new DateTime(1962, 01, 13) });
            DataBase.Salaries.Add(new Salarie() { NumSalarie = "120146", Nom = "Merino", Prenom = "Théo", DateNaissance = new DateTime(1989, 04, 01) });
            DataBase.Salaries.Add(new Salarie() { NumSalarie = "120147", Nom = "Carrey", Prenom = "Florian", DateNaissance = new DateTime(1995, 11, 01) });
        }
    }
    
}
