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
    public class Service : Produit
    {
        #region variables
        private int _duree;
        private int _seances;
        private DateTime _debutAbo;
        private DateTime _finAbo;
        private bool _dureeMois;
        /// <summary>
        /// Si true alors la durée est en mois sinon si false la durée est en semaines
        /// </summary>
        public bool DureeMois
        {
            get { return _dureeMois; }
            set
            {
                bool stock = _dureeMois;
                BetterNotifyPropertyChanging(stock, value);
                if (argsChanging == null || !argsChanging.Cancel)
                {
                    _dureeMois = value;
                    BetterNotifyPropertyChanged(stock, value);
                }
            }
        }
        /// <summary>
        /// Durée du service.
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
                    FinAbo = DureeMois ? DebutAbo.AddMonths(Duree) : DebutAbo.AddDays(Duree * 7);
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
                        MessageBox.Show("La date de début ne peut pas être avant aujourd'hui", "Mauvaise date de début", MessageBoxButton.OK, MessageBoxImage.Error);
                    else if (_finAbo.CompareTo(value) > 0)
                        MessageBox.Show("La date de début ne peut pas être ultérieure à la date de fin", "Mauvaise date de début", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        /// <summary>
        /// Date de fin de l'abonnement.
        /// </summary>
        public DateTime FinAbo
        {
            get { return _finAbo; }
            private set
            {
                DateTime stock = _finAbo;
                BetterNotifyPropertyChanging(stock, value);
                if (argsChanging == null || !argsChanging.Cancel)
                {
                    _finAbo = value;
                    BetterNotifyPropertyChanging(stock, value);
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

        private static int nombreServices;
        #endregion

        #region Constructeurs
        /// <summary>
        /// Créé un <see cref="Service"/> avec une durée en semaines.
        /// </summary>
        /// <param name="debut">Date de début du service</param>
        /// <param name="duree">Durée du service en semaines</param>
        /// <param name="nom">Nom du service</param>
        /// <param name="description">Description du service</param>
        /// <param name="prixHT">Prix hors taxes du service</param>
        /// <param name="tauxTVA">Taux de TVA appliqué au service</param>
        /// <param name="dureeMois">Définit si la durée est en mois (true) ou si elle est en semaines (false)</param>
        /// <param name="seances">Nombre de séances restantes avant expiration de l'abonnement</param>
        public Service(DateTime debut, int duree, string nom, string description, decimal prixHT, decimal tauxTVA, bool dureeMois, int seances = 0)
            : base(nom, description, prixHT, tauxTVA)
        {
            Duree = duree;
            DebutAbo = debut;
            DureeMois = dureeMois;
            CodeProduit = genererCodeProduit();
            nombreServices++;
        }
        #endregion

        #region methodes
        private string genererCodeProduit()
        {
            string ret = "";
            int position = 0;
            while (position < 6)
            {
                ret = ((nombreServices / (int)Math.Pow(10, position)) % (int)Math.Pow(10, position + 1)).ToString() + ret;
                position++;
            }
            return ret;
        }
        #endregion
    }
}
