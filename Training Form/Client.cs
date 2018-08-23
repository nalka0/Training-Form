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
        private static int nombreClients;
        private DateTime _debutAbo;
        private int _codeAbo;

        public string Interets
        {
            get { return _interets; }
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
            get { return _justificatif; }
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

        public DateTime DebutAbo
        {
            get
            {
                return _debutAbo;
            }
            set
            {
                DateTime stock =_debutAbo;
                BetterNotifyPropertyChanging(stock, value);
                if (argsChanging == null || !argsChanging.Cancel)
                {
                    _debutAbo = value;
                    BetterNotifyPropertyChanged(stock, value);
                }
            }
        }
        public int CodeAbo {
            get
            {
                return _codeAbo;
            }
            set
            {
                int stock = _codeAbo;
                BetterNotifyPropertyChanging(stock, value);
                if (argsChanging == null || !argsChanging.Cancel)
                {
                    _codeAbo = value;
                    BetterNotifyPropertyChanged(stock, value);
                }
            }
        }
        #endregion

        #region constructeurs
        public Client(string nom, string prenom, string email, DateTime dateNaissance, string justificatif, string interets, string numTelephonne, string adresse, DateTime debutAbo, int codeAbo, Statuts statuts)
            : base(nom, prenom, email, dateNaissance, Permissions.Client, numTelephonne, adresse)
        {
            Justificatif = justificatif;
            Identifiant = genererIdentifiant();
            Interets = interets;
            Statut = statuts;
            this.DebutAbo = debutAbo;
            this.CodeAbo = codeAbo;
            nombreClients++;
        }
        #endregion

        #region methodes
        public override string ToString()
        {
            return string.Format(Interets + ";" + Justificatif);
        }

        private string genererIdentifiant()
        {
            string ret = "";
            int position = 0;
            while (position < 6)
            {
                ret = ((nombreClients / (int)Math.Pow(10, position)) % (int)Math.Pow(10, position + 1)).ToString() + ret;
                position++;
            }
            return ret;
        }
        #endregion
    }
}
