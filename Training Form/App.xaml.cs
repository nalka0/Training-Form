using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using LiveCharts;
using LiveCharts.Wpf;
using System.Collections;
using System.Collections.ObjectModel;
using LiveCharts.Defaults;

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
            Article proteine = new Article("prot200", "La meilleur du marché de tibo inshape", 15, 7);
            Article proteine2 = new Article("prot2000", "La meilleur du marché de tibo inshape", 20, 7);
            Article proteine3 = new Article("prot20000", "La meilleur du marché de tibo inshape", 10, 7);
            Article proteine4 = new Article("prot200000", "La meilleur du marché de tibo inshape", 5, 7);

            JeuxTest.Articles.Add(proteine);
            JeuxTest.Articles.Add(proteine2);
            JeuxTest.Articles.Add(proteine4);
            JeuxTest.Articles.Add(proteine3);

            Client Cl1 = new Client("Pignon", "Jean", "JeanPignondeParis@gmail.com", new DateTime(2000, 12, 25), "oui", "Zumba", "0123456789", "adresse de jean michel pierre paul", Statuts.Etudiant);
            Client Cl2 = new Client("Lemon", "Bob", "Lemonbob@gmail.com", new DateTime(1975, 10, 20), "Non", "Pilate,Zumba", "9876543210", "adresse de jean michel pierre paul", Statuts.Couple);
            Client Cl3 = new Client("Freeze", "Mister", "MisterFreeze@gmail.com", new DateTime(1995, 02, 10), "non", "Cardio", "1357902468", "adresse de jean michel pierre paul", Statuts.Adulte);
            Client Cl4 = new Client("aveugle", "Jean", "JeanPignondeParis@gmail.com", new DateTime(2000, 12, 25), "oui", "Zumba", "0123456789", "adresse de jean michel pierre paul", Statuts.Etudiant);
            Client Cl5 = new Client("poignar", "Bob", "Lemonbob@gmail.com", new DateTime(1975, 10, 20), "Non", "Pilate,Zumba", "9876543210", "adresse de jean michel pierre paul", Statuts.Couple);
            Client Cl6 = new Client("cell", "Mister", "MisterFreeze@gmail.com", new DateTime(1995, 02, 10), "non", "Cardio", "1357902468", "adresse de jean michel pierre paul", Statuts.Adulte);
            Client Cl7 = new Client("Goku", "Jean", "JeanPignondeParis@gmail.com", new DateTime(2000, 12, 25), "oui", "Zumba", "0123456789", "adresse de jean michel pierre paul", Statuts.Etudiant);
            Client Cl8 = new Client("Gohan", "Bob", "Lemonbob@gmail.com", new DateTime(1975, 10, 20), "Non", "Pilate,Zumba", "9876543210", "adresse de jean michel pierre paul", Statuts.Couple);
            Client Cl9 = new Client("C18", "Mister", "MisterFreeze@gmail.com", new DateTime(1995, 02, 10), "non", "Cardio", "1357902468", "adresse de jean michel pierre paul", Statuts.Adulte);

            JeuxTest.Clients.Add(Cl1);
            JeuxTest.Clients.Add(Cl2);
            JeuxTest.Clients.Add(Cl3);
            JeuxTest.Clients.Add(Cl4);
            JeuxTest.Clients.Add(Cl5);
            JeuxTest.Clients.Add(Cl6);
            JeuxTest.Clients.Add(Cl7);
            JeuxTest.Clients.Add(Cl8);
            JeuxTest.Clients.Add(Cl9);

            Service AboDouzeMoisCours = new Service(12, new DateTime(2019, 08, 02), "12 mois avec Cours", "Abonnement Cardio Training 12 Mois avec Cours collectif", 0, 300, 15);
            Service AboDouzeMois = new Service(12, new DateTime(2017, 09, 06), "12 mois sans Cours", "Abonnement Cardio Training 12 Mois sans Cours colledtif", 0, 270, 15);
            Service AboSixMoisCours = new Service(6, new DateTime(2018, 05, 15), "6 mois avec Cours", "Abonnement Cardio Training 6 Mois avec Cours colledtif", 0, 200, 15);
            Service AboSixMois = new Service(6, new DateTime(2017, 01, 02), "6 mois sans Cours", "Abonnement Cardio Training 6 Mois sans Cours colledtif", 0, 150, 15);
            Service SeanceDecouverte = new Service(0, new DateTime(2018, 08, 02), "Seance Decouverte", "Seance de décourverte de la salle", 1, 10, 15);
            Service Semaine = new Service(0, new DateTime(2018, 07, 25), "Decouverte 1 semaine", "Semaine de découverte de la salle",0, 50, 15);
            Service DeuxSemaines = new Service(0, new DateTime(2018, 07, 02), "Decouverte 2 semaines", "Deux semaines de découverte de la salle", 0, 100, 15);
            Service UnMois = new Service(1, new DateTime(2018, 08, 02), "Découverte Abonnement 1 Mois", "Abonnement découverte de la salle d'un mois", 0, 150, 15);
            Service TroisMois = new Service(3, new DateTime(2018, 08, 01), "Découverte Abonnement 3 Mois", "Abonnement découverte de la salle de 3 mois", 0, 200, 15);
            Service CarteVingtQuatre = new Service(12, new DateTime(2018, 06, 19), "Cartes 24 Séances", "Cartes découverte 24 séances valide 1 an", 24, 200, 15);

            JeuxTest.Services.Add(AboDouzeMoisCours);
            JeuxTest.Services.Add(AboDouzeMois);
            JeuxTest.Services.Add(AboSixMoisCours);
            JeuxTest.Services.Add(AboSixMois);
            JeuxTest.Services.Add(SeanceDecouverte);
            JeuxTest.Services.Add(Semaine);
            JeuxTest.Services.Add(DeuxSemaines);
            JeuxTest.Services.Add(UnMois);
            JeuxTest.Services.Add(TroisMois);
            JeuxTest.Services.Add(CarteVingtQuatre);

            Salarie Sal1 = new Salarie("carrey", "florian", "flo@mail.fr", new DateTime(1995, 11, 01), Permissions.Salarie, new DateTime(2018, 06, 19), "test", "0123456789", "adresse de jean michel pierre paul");
            Salarie Sal2 = new Salarie("martin", "toto", "toto@mail.fr", new DateTime(2000, 11, 01), Permissions.Salarie, new DateTime(2018, 06, 19), "test1", "9876543210", "adresse de jean michel pierre paul");
            Salarie Sal3 = new Salarie("machin", "marc", "marc@mail.fr", new DateTime(1993, 02, 08), Permissions.Salarie, new DateTime(2018, 06, 19), "test2", "0246813579", "adresse de jean michel pierre paul");
            JeuxTest.Salaries.Add(Sal1);
            JeuxTest.Salaries.Add(Sal2);
            JeuxTest.Salaries.Add(Sal3);
            base.Run();
        }
    }
    
}
