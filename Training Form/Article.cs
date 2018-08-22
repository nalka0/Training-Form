﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Training_Form
{
    public class Article : Produit
    {
        #region variables
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
            }
        }
        private static int nombreArticle;
        #endregion

        #region constructeurs
        public Article(string nom, string description, decimal prixHT, decimal tauxTVA)
            :base (nom, description, prixHT, tauxTVA)
        {
            CodeProduit = genererCodeProduit();
            nombreArticle++;
        }
        #endregion

        #region methodes
        private string genererCodeProduit()
        {
            string ret = "";
            int position = 0;
            while (position < 6)
            {
                ret = ((nombreArticle / (int)Math.Pow(10, position)) % (int)Math.Pow(10, position + 1)).ToString() + ret;
                position++;
            }
            return ret;
        }
        #endregion
    }
}
