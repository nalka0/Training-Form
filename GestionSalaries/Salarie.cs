using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionSalaries
{
    public class Salarie
    {
        private string _numSalarie;
        private string _nom;
        private string _prenom;
        private string _role;
        private DateTime _dateNaissance;
        private string _password;
        private string _mail;


        public Salarie()
        {
        }
        
        public Salarie (string numSalarie, string nom, string prenom, string role, DateTime dateNaissance, string password, string mail)
            :this()
        {
            NumSalarie = numSalarie;
            Nom = nom;
            Prenom = prenom;
            Role = role;
            DateNaissance = dateNaissance;
            Password = password;
            Mail = mail;
        }

        public string NumSalarie
        {
            get { return _numSalarie; }
            set { _numSalarie = value; }
        }

        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        public string Prenom
        {
            get { return _prenom; }
            set { _prenom = value; }
        }

        public string Role
        {
            get { return _role; }
            set { _role = value; }
        }

        public DateTime DateNaissance
        {
            get { return _dateNaissance; }
            set { _dateNaissance = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string Mail
        {
            get { return _mail; }
            set { _mail = value; }
        }

        public override bool Equals(object obj)
        {
            Salarie sal = obj as Salarie;
            if (sal==null)
            {
                return false;
            }
            else
            {
                return Equals(sal);
            } 
        }

        public  bool Equals(Salarie sal)
        {
            return this.NumSalarie == sal.NumSalarie;
        }
        public override int GetHashCode()
        {
            return NumSalarie.GetHashCode();
        }

    }
    public class MalisteSalaries : List<Salarie> { }

}

