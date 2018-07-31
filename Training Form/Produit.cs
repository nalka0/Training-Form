using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_Form
{
    class Produit
    {
        private int _codeProduit;
        private string _nom;
        private string _description;

        public int CodeProduit
        {
            get { return _codeProduit; }
            set
            {
                _codeProduit = value;
            }
        }
        public string Nom
        {
            get { return _nom; } 
            set
            {
                _nom = value;
            }
        }
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
            }
        }
    }
}
