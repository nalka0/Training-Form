using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_Form
{
    public class Salarie:User
    {
        private string _numSalarie;
        private string _role;
        private DateTime _dateEmbauche;
        private string _password;


        

        public Salarie(string nom, string prenom, string mail, DateTime dateNaissance, Permissions permission, string numSalarie, string role, DateTime dateEmbauche, string password)
           : base( nom, prenom, mail, dateEmbauche, permission)
        {
            NumSalarie = numSalarie;
            Role = role;
            DateEmbauche = dateEmbauche;
            Password = password;
        }

        public string NumSalarie
        {
            get { return _numSalarie; }
            set { _numSalarie = value; }
        }

        public string Role
        {
            get { return _role; }
            set { _role = value; }
        }

        public DateTime DateEmbauche
        {
            get { return _dateEmbauche; }
            set { _dateEmbauche = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
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

