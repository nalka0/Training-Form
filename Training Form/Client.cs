using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassesRefaitesWpf;

namespace Training_Form
{
    public class Client : User
    {
        #region variables
        private string _interets;
        private string _justificatif;

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
        private Statuts _statut;
        public Statuts Statut
        {
            get { return _statut; }
            set
            {
                Statuts stock = _statut;
                BetterNotifyPropertyChanging(stock, value);
                if (argsChanging == null || !argsChanging.Cancel)
                {
                    _statut = value;
                    BetterNotifyPropertyChanged(stock, value);
                }
            }
        }
        #endregion

        #region constructeurs
        public Client(string nom, string prenom, string email, DateTime dateNaissance, string justificatif, string interets, string numTelephonne, string adresse,Statuts statuts)
            : base(nom, prenom, email, dateNaissance, Permissions.Client, numTelephonne, adresse)
        {
            this.Justificatif = justificatif;
            this.Interets = interets;
            Statut = statuts;
        }
        #endregion

        #region methodes
        public override string ToString()
        {
            return string.Format(Interets + ";" + Justificatif);
        }
        #endregion
    }
}
