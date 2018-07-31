using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using ClassesRefaitesWpf;

namespace Training_Form
{
    class Services : Produit, IBetterNotifyPropertyChanged, IBetterNotifyPropertyChanging
    {
        private int _duree;
        private DateTime _debutAbo, _finAbo, _valid;
        private int _seances;
        /// <summary>
        /// Ceci est un commentaire pour la durée.
        /// </summary>
        public int Duree
        {
            get { return _duree; }
            set { _duree = value; }
        }
        /// <summary>
        /// Bonjour. Ça va ?
        /// </summary>
        public DateTime DebutAbo
        {
            get { return _debutAbo; }
            set
            {
                DateTime stock = _debutAbo;
                BetterNotifyPropertyChanging(stock, value);
                if (argsChanging==null||!argsChanging.Cancel)
                {
                    _debutAbo = value;
                    BetterNotifyPropertyChanging(stock, value);
                }
                _debutAbo = value;
            }
        }
        /// <summary>
        /// Moi ça va pas trop mal.
        /// </summary>
        public DateTime FinAbo
        {
            get { return _finAbo; }
            set
            {
                DateTime stock = _finAbo;
                BetterNotifyPropertyChanging(stock, value);
                if (argsChanging == null || !argsChanging.Cancel)
                {
                    _finAbo = value;
                    BetterNotifyPropertyChanging(stock, value);
                }
                _finAbo = value;
            }
        }
        public DateTime Valid
        {
            get { return _valid; }
            set
            {
                DateTime stock = _valid;
                BetterNotifyPropertyChanging(stock, value);
                if (argsChanging==null||!argsChanging.Cancel)
                {
                    _valid = value;
                    BetterNotifyPropertyChanging(stock, value);
                }
                _valid = value;
            }
        }
        private int Seance
        {
            get { return _seances; }
            set { _seances = value; }
        }

    }
}
