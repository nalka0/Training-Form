﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ClassesRefaitesWpf;

namespace Training_Form
{
    public abstract class User : IBetterNotifyPropertyChanged, IBetterNotifyPropertyChanging
    {
        #region variables
        private string _nom;
        /// <summary>
        /// Nom du <see cref="User"/>
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

        private string _prenom;
        /// <summary>
        /// Prenom du <see cref="User"/>
        /// </summary>
        public string Prenom
        {
            get { return _prenom; }
            set
            {
                string stock = _nom;
                BetterNotifyPropertyChanging(stock, value);
                if (argsChanging == null || !argsChanging.Cancel)
                {
                    _prenom = value;
                    BetterNotifyPropertyChanged(stock, value);
                }
            }
        }

        private string _mail;
        /// <summary>
        /// Adresse mail du <see cref="User"/>
        /// </summary>
        public string Mail
        {
            get { return _mail; }
            set
            {
                string stock = _mail;
                BetterNotifyPropertyChanging(stock, value);
                if (argsChanging == null || !argsChanging.Cancel)
                {
                    _mail = value;
                    BetterNotifyPropertyChanged(stock, value);
                }
            }
        }

        private DateTime _dateNaissance;
        /// <summary>
        /// Date de naissance du <see cref="User"/>
        /// </summary>
        public DateTime DateNaissance
        {
            get { return _dateNaissance; }
            set
            {
                DateTime stock = _dateNaissance;
                BetterNotifyPropertyChanging(stock, value);
                if (argsChanging == null || !argsChanging.Cancel)
                {
                    _dateNaissance = value;
                    BetterNotifyPropertyChanged(stock, value);
                }
            }
        }

        private Permissions _permission;
        /// <summary>
        /// Permissions du <see cref="User"/>
        /// </summary>
        public Permissions Permission
        {
            get { return _permission; }
            set
            {
                Permissions stock = _permission;
                BetterNotifyPropertyChanging(stock, value);
                if (argsChanging == null || !argsChanging.Cancel)
                {
                    _permission = value;
                    BetterNotifyPropertyChanged(stock, value);
                }
            }
        }

        private string _identifiant;
        /// <summary>
        /// Identifiant du <see cref="User"/>
        /// </summary>
        public string Identifiant
        {
            get { return _identifiant; }
            set
            {
                string stock = _identifiant;
                BetterNotifyPropertyChanging(stock, value);
                if (argsChanging == null || argsChanging.Cancel)
                {
                    _identifiant = value;
                    BetterNotifyPropertyChanged(stock, value);
                }
            }
        }

        private string _adresse;
        /// <summary>
        /// Adresse du <see cref="User"/>
        /// </summary>
        public string Adresse
        {
            get { return _adresse; }
            set
            {
                string stock = _adresse;
                BetterNotifyPropertyChanging(stock, value);
                if (argsChanging == null || !argsChanging.Cancel)
                {
                    _adresse = value;
                    BetterNotifyPropertyChanged(stock, value);
                }
            }
        }

        private string _numTelephone;
        /// <summary>
        /// Numéro de téléphonne du <see cref="User"/>
        /// </summary>
        public string NumTelephone
        {
            get { return _numTelephone; }
            set
            {
                string stock = _numTelephone;
                BetterNotifyPropertyChanging(stock, value);
                if (argsChanging == null || !argsChanging.Cancel)
                {
                    _numTelephone = value;
                    BetterNotifyPropertyChanged(stock, value);
                }
            }
        }
        #endregion

        #region notify
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

        #region constructeurs
        /// <summary>
        /// Constructeur de <see cref="User"/>
        /// </summary>
        public User(string nom, string prenom, string mail, DateTime dateNaissance, Permissions permission, string numTelephonne, string adresse)
        {
            Nom = nom;
            Prenom = prenom;
            Mail = mail;
            DateNaissance = dateNaissance;
            Permission = permission;
            NumTelephone = numTelephonne;
            Adresse = adresse;
        }
        #endregion

        #region methodes
        /// <summary>
        /// Retourne l'âge du <see cref="User"/>
        /// </summary>
        public int getAge()
        {
            if (DateTime.Now.Month <= DateNaissance.Month && DateTime.Now.Day < DateNaissance.Day)
                return DateTime.Now.Year - DateNaissance.Year - 1;
            return DateTime.Now.Year - DateNaissance.Year;
        }
        #endregion
    }
}
