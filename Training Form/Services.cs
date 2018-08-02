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
        private int _seances;
        private DateTime _debutAbo;
        private DateTime _finAbo;
        /// <summary>
        /// Durée en mois du service.
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
                if (_finAbo == new DateTime() && DateTime.Now.CompareTo(value) < 0 || _finAbo.CompareTo(value) > 0)
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
                    if (DateTime.Now.CompareTo(value) < 0)
                    {
                        MessageBox.Show("La date de début ne peut pas être avant aujourd'hui", "Mauvaise date de début", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else if (_finAbo.CompareTo(value) > 0)
                    {
                        MessageBox.Show("La date de début ne peut pas être ultérieure à la date de fin", "Mauvaise date de début", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
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
                if (_debutAbo == new DateTime() || _debutAbo.CompareTo(value) < 0)
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
                    MessageBox.Show("La date de fin ne peut pas être antérieure à la date de début", "Mauvaise date de fin", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        /// <summary>
        /// Nombre de séances restantes avant expiration.
        /// </summary>
        public int Seances
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

        /// <summary>
        /// Créé un nouveau service.
        /// </summary>
        /// <param name="duree">Durée du service en mois</param>
        /// <param name="debut">Date de début du service</param>
        /// <param name="codeProduit">Code d'identification du produit, sera peut-être supprimé dans des versions futures</param>
        /// <param name="nom">Nom du service.</param>
        /// <param name="description">Description du service</param>
        /// <param name="seances">Nombre de séances avant expiration. Ce paramètre est optionnel et sera défini à 0 s'il n'est pas renseigné</param>
        public Services(int duree, DateTime debut, string codeProduit, string nom, string description, int seances = 0)
            : base(codeProduit, nom, description)
        {
            _duree = duree;
            DebutAbo = debut;
            _seances = seances;
            FinAbo = _debutAbo.AddMonths(duree);
        }
    }
}
