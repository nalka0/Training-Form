using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionSalaries
{
    public class Salarie
    {
        private string _numClient;
        private string _nom;
        private string _prenom;
        private string _role;
        private DateTime _dateNaissance;
        private string _password;
        private string _mail;

        
       //rivate List<Salarie> MalisteSalaries { get ; set };


        public Salarie()
        {
        }

        public Salarie (string numClient, string nom, string prenom, string role, DateTime dateNaissance, string password, string mail)
            :this()
        {
            NumClient = numClient;
            Nom = nom;
            Prenom = prenom;
            Role = role;
            DateNaissance = dateNaissance;
            Password = password;
            Mail = mail;
        }


        public string NumClient { get => _numClient; set => _numClient = value; }
        public string Nom { get => _nom; set => _nom = value; }
        public string Prenom { get => _prenom; set => _prenom = value; }
        public string Role { get => _role; set => _role = value; }
        public DateTime DateNaissance { get => _dateNaissance; set => _dateNaissance = value; }
        public string Password { get => _password; set => _password = value; }
        public string Mail { get => _mail; set => _mail = value; }


        

        
    }
    public class MalisteSalaries : List<Salarie> { }

}

