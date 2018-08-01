using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ClassesRefaitesWpf;

namespace Training_Form
{
    class Formule : IBetterNotifyPropertyChanged, IBetterNotifyPropertyChanging
    {
        private int _duree;
        public int Duree
        {
            get { return _duree; }
            set
            {
                int stock = _duree;
                BetterNotifyPropertyChanging(stock, value);
                if (argsChanging == null || !argsChanging.Cancel)
                {
                    _duree = value;
                    BetterNotifyPropertyChanged(stock, value);
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

        private bool _cours;
        public bool Cours
        {
            get { return _cours; }
            set
            {
                bool stock = _cours;
                BetterNotifyPropertyChanging(stock, value);
                if (argsChanging == null || !argsChanging.Cancel)
                {
                    _cours = value;
                    BetterNotifyPropertyChanged(stock, value);
                }
            }
        }

        private string _nom;
        public string Nom
        {
            get { return _nom; }
            set
            {
                string stock = _nom;
                BetterNotifyPropertyChanging(stock, value);
                if (argsChanging == null || !argsChanging.Cancel)
                {
                    _nom = value;
                    BetterNotifyPropertyChanged(stock, value);
                }
            }
        }

        private int _identifiant;
        public int Identifiant
        {
            get { return _identifiant; }
            set
            {
                int stock = _identifiant;
                BetterNotifyPropertyChanging(stock, value);
                if (argsChanging == null || !argsChanging.Cancel)
                {
                    _identifiant = value;
                    BetterNotifyPropertyChanged(stock, value);
                }
            }
        }

        private float _prix;
        public float Prix
        {
            get { return _prix; }
            set
            {
                float stock = _prix;
                BetterNotifyPropertyChanging(stock, value);
                if (argsChanging == null || !argsChanging.Cancel)
                {
                    _prix = value;
                    BetterNotifyPropertyChanged(stock, value);
                }
            }
        }

        private static int nombreFormules = 0;
        /// <summary>
        /// Créé une nouvelle formule avec la durée, le statut et le nom specifié.
        /// </summary>
        /// <param name="duree">Durée en mois de la formule</param>
        /// <param name="statut">Définit si le bénéficiaire de la formule est un Adulte, un Etudiant ou un Couple</param>
        /// <param name="avecCours">Définit si le bénéficiaire de la formule a des cours ou non</param>
        /// <param name="nom">Nom de la formule</param>
        public Formule( int duree, Statuts statut, bool avecCours, string nom, float prix)
        {
            _duree = duree;
            _statut = statut;
            _cours = avecCours;
            _nom = nom;
            _identifiant = nombreFormules;
            _prix = prix;
            nombreFormules++;
        }
        #region notify
        public event BetterPropertyChangedEventHandler PropertyChanged;
        public event BetterPropertyChangingEventHandler PropertyChaning;
        internal BetterPropertyChangingEventArgs argsChanging;
        internal BetterPropertyChangedEventArgs argsChanged;

        public void BetterNotifyPropertyChanged(object oldValue, object newValue, [CallerMemberName] string propertyName = "")
        {
            argsChanged = new BetterPropertyChangedEventArgs(propertyName, oldValue, newValue);
            if (PropertyChanged != null)
            {
                PropertyChanged(this, argsChanged);
            }
        }

        public void BetterNotifyPropertyChanging(object oldValue, object newValue, [CallerMemberName] string propertyName = "")
        {
            argsChanging = new BetterPropertyChangingEventArgs(propertyName, oldValue, newValue);
            if (PropertyChaning != null)
            {
                PropertyChaning(this, argsChanging);
            }
        }
        #endregion
    }
}
