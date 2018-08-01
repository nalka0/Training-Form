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


        private string _interets;
        private string _justificatif;
        public Client()
        {
            
        }
        public Client(string nom, string prenom, string email, DateTime dateNaissance, string interets, string justificatif)
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
                string stock = _interets;
                BetterNotifyPropertyChanging(stock, value);
                if (argsChanging != null && !argsChanging.Cancel)
                {
                    _interets = value;
                    BetterNotifyPropertyChanged(stock, value);
                }

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
                if (getAge() < 25)
                {
                    string stock = _justificatif;
                    BetterNotifyPropertyChanging(stock, value);
                    if (argsChanging == null || argsChanging.Cancel)
                    {
                        _justificatif = value;
                        BetterNotifyPropertyChanged(stock, value);
                    }
                }
               
            }
        }
      
        public override string ToString()
        {
            return string.Format(Interets + ";" + Justificatif);
        }
    }
}
