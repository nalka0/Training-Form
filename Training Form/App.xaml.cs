﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Training_Form
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        ///  initialisation des jeux de tests
        /// </summary>

        public new void Run()
        {
            Article proteine = new Article("prot200", "00014184789", "La meilleur du marché de tibo inshape");
            Article proteine2 = new Article("prot2000", "00014256656", "La meilleur du marché de tibo inshape");
            Article proteine3 = new Article("prot20000", "00014696594", "La meilleur du marché de tibo inshape");
            Article proteine4 = new Article("prot200000", "00014654954", "La meilleur du marché de tibo inshape");
            
            JeuxTest.Articles.Add(proteine);
            JeuxTest.Articles.Add(proteine2);
            JeuxTest.Articles.Add(proteine4);
            JeuxTest.Articles.Add(proteine3);

            Client Cl1 = new Client("Pignon", "Jean", "JeanPignondeParis@gmail.com", new DateTime(2000, 12, 25), "gym tonic", "oui");
            Client Cl2 = new Client("Lemon", "Bob", "Lemonbob@gmail.com", new DateTime(1975, 10, 20), "zumba", "non");
            Client Cl3 = new Client("Freeze", "Mister", "MisterFreeze@gmail.com", new DateTime(1995, 02, 10), "Yoga", "non");

            JeuxTest.Clients.Add(Cl1);
            JeuxTest.Clients.Add(Cl2);
            JeuxTest.Clients.Add(Cl3);
            base.Run();
        }
    }
    
}
