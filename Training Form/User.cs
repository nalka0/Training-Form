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
                if (value.Contains("@") && value.Contains("."))
                {
                    string stock = _mail;
                    BetterNotifyPropertyChanging(stock, value);
                    if (argsChanging == null || !argsChanging.Cancel)
                    {
                        _mail = value;
                        BetterNotifyPropertyChanged(stock, value);
                    }
                }
                else
                {
                    MessageBox.Show("Adresse e-mail invalide, veuillez recommencer", "Mauvaise adresse e-mail", MessageBoxButton.OK, MessageBoxImage.Error);
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
                if (value.CompareTo(new DateTime(DateTime.Now.Year - 100, DateTime.Now.Month, DateTime.Now.Day)) > 0)
                {
                    DateTime stock = _dateNaissance;
                    BetterNotifyPropertyChanging(stock, value);
                    if (argsChanging == null || !argsChanging.Cancel)
                    {
                        _dateNaissance = value;
                        BetterNotifyPropertyChanged(stock, value);
                    }
                }
                else
                {
                    MessageBox.Show("Date de naissance invalide, veuillez recommencer", "Mauvaise date de naissance", MessageBoxButton.OK, MessageBoxImage.Error);
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

        private int _identifiant;
        /// <summary>
        /// Identifiant du <see cref="User"/>
        /// </summary>
        public int Identifiant
        {
            get { return _identifiant; }
            set
            {
                int stock = _identifiant;
                BetterNotifyPropertyChanging(stock, value);
                if (argsChanging == null || argsChanging.Cancel)
                {
                    _identifiant = value;
                    BetterNotifyPropertyChanged(stock ,value);
                }
            }
        }
        #endregion

        private static int nombreUsers;
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

        /// <summary>
        /// Constructeur de <see cref="User"/>
        /// </summary>
        public User(string nom, string prenom, string mail, DateTime dateNaissance, Permissions permission)
        {
            Nom = nom;
            Prenom = prenom;
            Mail = mail;
            DateNaissance = dateNaissance;
            Permission = permission;
            _identifiant = nombreUsers;
            nombreUsers++;
        }

        /// <summary>
        /// Retourne l'âge du <see cref="User"/>
        /// </summary>
        public int getAge()
        {
            int modif = 0;
            if (DateTime.Now.Month <= DateNaissance.Month && DateTime.Now.Day < DateNaissance.Day)
            {
                modif--;
            }
            return DateTime.Now.Year - DateNaissance.Year + modif;
        }
    }
}
