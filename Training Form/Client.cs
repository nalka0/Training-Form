using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassesRefaitesWpf;

namespace Training_Form
{
    class Client : User
    {


        private String _interets;
        private String _justificatif;
        public Client()
        {
            
        }
        public Client(string nom,string prenom,string email, DateTime dateNaissance,string interets,string justificatif)
        {
            base.Nom = nom;
            base.Prenom = prenom;
            base.Mail = email;
            base.DateNaissance = dateNaissance;
            base.Permission = Permissions.Client;
            this.Interets = interets;
            this.Justificatif = justificatif;

        }
        public string Interets
        {
            get
            {
                return _interets;
            }
            set
            {
                _interets = value;
            }
        }

        public string Justificatif
        {
            get
            {
                return _justificatif;
            }
            set
            {
                if ((DateTime.Now.Year - DateNaissance.Year) < 25)
                {
                    _justificatif = value;
                }
               
            }
        }
      
        public override String ToString()
        {
            return String.Format(Interets + ";" + Justificatif) ;
        }
    }
}
