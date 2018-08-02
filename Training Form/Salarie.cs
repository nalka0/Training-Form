using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_Form
{
    public class Salarie : User
    {
        #region variables
        private DateTime _dateEmbauche;
        private string _password;

        public DateTime DateEmbauche
        {
            get { return _dateEmbauche; }
            set
            {
                DateTime stock = _dateEmbauche;
                BetterNotifyPropertyChanging(stock, value);
                if (argsChanging == null || !argsChanging.Cancel)
                {
                    _dateEmbauche = value;
                    BetterNotifyPropertyChanged(stock, value);
                }
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                string stock = _password;
                BetterNotifyPropertyChanging(stock, value);
                if (argsChanging == null || !argsChanging.Cancel)
                {
                    _password = value;
                    BetterNotifyPropertyChanged(stock, value);
                }
            }
        }
        #endregion

        #region constructeurs
        public Salarie(string nom, string prenom, string mail, DateTime dateNaissance, Permissions permission, DateTime dateEmbauche, string password, string numTelephonne)
           : base(nom, prenom, mail, dateEmbauche, permission, numTelephonne)
        {
            DateEmbauche = dateEmbauche;
            Password = password;
        }
        #endregion

        #region methodes
        public override bool Equals(object obj)
        {
            Salarie sal = obj as Salarie;
            if (sal == null)
            {
                return false;
            }
            else
            {
                return Equals(sal);
            } 
        }

        public bool Equals(Salarie sal)
        {
            return base.Identifiant == sal.Identifiant;
        }

        public override int GetHashCode()
        {
            return Identifiant.GetHashCode();
        }
        #endregion
    }
}

