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
        #region Poubelle

        private String _nom;
        private String _prenom;
        private String _telephone;
        private String _email;
        private String _dateNaissance;

        public string Nom
        {
            get
            {
               return  _nom;
            }
            set
            {
                _nom = value;
            }

        }

        public string Prenom
        {
            get
            {
                return _prenom;
            }

            set
            {
                _prenom = value;
            }
        }

        public string Telephone
        {
            get
            {
                return _telephone;
            }
            set
            {
                _telephone = value;
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }

        public string DateNaissance
        {
            get {
                return _dateNaissance;
            }
            set {
                _dateNaissance = value;
            }
        }
        #endregion

        private String _interets;
        private String _justificatif;
        public Client()
        {
            
        }
        public Client(string nom,string prenom,string telephone,string email, string datenaissance,string interets,string justificatif)
        {
            this.Nom = nom;
            this.Prenom = prenom;
            this.Telephone = telephone;
            this.Email = email;
            this.DateNaissance = datenaissance;
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
                _justificatif = value;
            }
        }
      
        public override String ToString()
        {
            return String.Format(Nom + ";" + Prenom + ";" + DateNaissance + ";" + Telephone + ";" + Email + ";" + Interets + ";" + Justificatif) ;
        }
    }
}
