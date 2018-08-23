﻿using System;
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
        private static int nombreServices;
        private DateTime _debutAbo;
        private DateTime _finAbo;
        private bool _enMois;

        public bool enMois
        {
            get { return _enMois; }
            set
            {
                bool stock = _enMois;
                BetterNotifyPropertyChanging(stock, value);
                if (argsChanging == null || !argsChanging.Cancel)
                {
                    _enMois = value;
                    BetterNotifyPropertyChanged(stock, value);
                }
            }
        }
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
            set
            {
                if (_debutAbo == new DateTime() || DateTime.Compare(_debutAbo, value) <= 0)
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
                    MessageBox.Show("La date de fin ne peut pas être antérieure à la date de début", "Mauvaise date de fin", MessageBoxButton.OK, MessageBoxImage.Error);
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
        #endregion

        #region Constructeurs
        /// <summary>
        /// Créé un <see cref="Service"/> avec une durée en mois.
        /// </summary>
        /// <param name="dureeMois">Durée du service en mois</param>
        /// <param name="debut">Date de début du service</param>
        /// <param name="codeProduit">Code d'identification du produit, sera peut-être supprimé dans des versions futures</param>
        /// <param name="nom">Nom du service</param>
        /// <param name="description">Description du service</param>
        /// <param name="seances">Nombre de séances avant expiration</param>
        public Service(int dureeMois, decimal prixHT, decimal tauxTVA, DateTime debut, string nom, string description, int seances = 0)
            : base(nom, description, prixHT, tauxTVA)
        {
            Duree = dureeMois;
            DebutAbo = debut;
            Seances = seances;
            FinAbo = debut.AddMonths(dureeMois);
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
