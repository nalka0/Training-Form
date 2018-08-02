﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ClassesRefaitesWpf;

namespace Training_Form
{
    public abstract class Produit : IBetterNotifyPropertyChanged, IBetterNotifyPropertyChanging
    {
        #region variables
        private string _codeProduit;
        private string _nom;
        private string _description;

        /// <summary>
        /// Code permettant d'identifier le produit
        /// </summary>
        public string CodeProduit
        {
            get { return _codeProduit; }
            set
            {
                string stock = _codeProduit;
                BetterNotifyPropertyChanging(stock, value);
                if (argsChanging == null || !argsChanging.Cancel)
                {
                    _codeProduit = value;
                    BetterNotifyPropertyChanged(stock, value);
                }

            }
        }
        /// <summary>
        /// Nom du produit
        /// </summary>
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
        /// <summary>
        /// Description du produit
        /// </summary>
        public string Description
        {
            get { return _description; }
            set
            {
                string stock = _description;
                BetterNotifyPropertyChanging(stock, value);
                if (argsChanging == null || !argsChanging.Cancel)
                {
                    _description = value;
                    BetterNotifyPropertyChanged(stock, value);
                }
            }
        }
        #endregion

        #region constructeurs
        /// <summary>
        /// Créé un nouveau produit.
        /// </summary>
        /// <param name="codeProduit">Code d'identification du produit. Sera peut-être supprimé dans des versions futures</param>
        /// <param name="nom">Nom du produit</param>
        /// <param name="description">Description du produit</param>
        public Produit(string codeProduit, string nom, string description)
        {
            CodeProduit = codeProduit;
            Nom = nom;
            Description = description;
        }
        #endregion

        #region methodes
        #endregion

        #region notify d'Alan
        public event BetterPropertyChangedEventHandler PropertyChanged;
        public event BetterPropertyChangingEventHandler PropertyChanging;
        internal BetterPropertyChangedEventArgs argsChanged;
        internal BetterPropertyChangingEventArgs argsChanging;

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
            if (PropertyChanging != null)
            {
                PropertyChanging(this, argsChanging);
            }
        }
        #endregion
    }
}