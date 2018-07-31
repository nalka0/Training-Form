using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Training_Form
{
    class Article : Produit
    {
        private Image _imageProduit;

        public Image ImageProduit
        {
            get { return _imageProduit; }
            set
            {
                _imageProduit = value;
            }
        }
    }
}
