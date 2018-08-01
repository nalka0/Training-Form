using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using ClassesRefaitesWpf;

namespace Training_Form
{
    class Services : Produit
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
        /// <summary>
        /// Date de début de l'abonement.
        /// </summary>
        public DateTime DebutAbo
        {
            get { return _debutAbo; }
            set
            {
                if (_finAbo == null || _finAbo.CompareTo(value) < 0)
                {
                    DateTime stock = _debutAbo;
                    BetterNotifyPropertyChanging(stock, value);
                    if (argsChanging == null || !argsChanging.Cancel)
                    {
                        _debutAbo = value;
                        BetterNotifyPropertyChanging(stock, value);
                    }
                }
                else
                {
                    MessageBox.Show("La date de début ne peut pas être ultérieure à la date de fin", "Mauvaise date de début");
                }
            }
        }
        /// <summary>
        /// Date de fin de l'abonnement.
        /// </summary>
        public DateTime FinAbo
        {
            get { return _finAbo; }
            set
            {
                if (_debutAbo == null || _debutAbo.CompareTo(value) > 0)
                {
                    DateTime stock = _finAbo;
                    BetterNotifyPropertyChanging(stock, value);
                    if (argsChanging == null || !argsChanging.Cancel)
                    {
                        _finAbo = value;
                        BetterNotifyPropertyChanging(stock, value);
                    }
                }
                else
                {
                    MessageBox.Show("La date de fin ne peut pas être antérieure à la date de début", "Mauvaise date de fin");
                }
            }
        }

        public DateTime Valid
        {
            get { return _valid; }
            set
            {
                DateTime stock = _valid;
                BetterNotifyPropertyChanging(stock, value);
                if (argsChanging == null||!argsChanging.Cancel)
                {
                    _valid = value;
                    BetterNotifyPropertyChanging(stock, value);
                }
            }
        }

        private int Seances
        {
            get { return _seances; }
            set
            {
                int stock = _seances;
                BetterNotifyPropertyChanged(stock, value);
                if (argsChanging == null || !argsChanging.Cancel)
                {
                    _seances = value;
                    BetterNotifyPropertyChanged(stock, value);
                }
            }
        }

    }
}
