using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Training_Form
{
    public class Article : Produit
    {
        private Image _imageProduit;

        public Image ImageProduit
        {
            get { return _imageProduit; }
            set
            {
                Image stock = _imageProduit;
                BetterNotifyPropertyChanging(stock, value);
                if (argsChanging == null || !argsChanging.Cancel)
                {
                    _imageProduit = value;
                    BetterNotifyPropertyChanging(stock, value);
                }
                _imageProduit = value;
            }
        }

        public Article(string codeProduit, string nom, string description)
            :base (codeProduit, nom, description)
        {

        }
    }
}
