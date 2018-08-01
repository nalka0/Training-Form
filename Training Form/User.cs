using System;
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
                    MessageBox.Show("Adresse e-mail invalide, veuillez recommencer", "Mauvaise adresse e-mail");
                }
            }
        }

        private DateTime _dateNaissance;
        public DateTime DateNaissance
        {
            get { return _dateNaissance; }
            set
            {
                if (value.CompareTo(new DateTime(DateTime.Now.Year - 100, DateTime.Now.Month, DateTime.Now.Day)) < 0)
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
                    MessageBox.Show("Date de naissance invalide, veuillez recommencer", "Mauvaise date de naissance");
                }
                
            }
        }

        private Permissions _permission;
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
    }
}
