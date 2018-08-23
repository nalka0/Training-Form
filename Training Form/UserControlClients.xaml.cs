﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Training_Form
{
    /// <summary>
    /// Logique d'interaction pour UserControlClients.xaml
    /// </summary>
    public partial class UserControlClients : UserControl
    {
        public UserControlClients()
        {
            InitializeComponent();
            DataContext = this;
            dataClients.ItemsSource = JeuxTest.Clients;

        }
        private void supprimerClient_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Voulez-vous vraiment supprimer ce client ?", "Supprimer", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.OK) { JeuxTest.Clients.RemoveAt(dataClients.SelectedIndex); }
        }
        private void editerClient_Click(object sender, RoutedEventArgs e)
        {
            AjoutClient editerClient = new AjoutClient();
            editerClient.Loaded -= editerClient.AjoutClient_Loaded;
            editerClient.tbNom.Text = JeuxTest.Clients[dataClients.SelectedIndex].Nom;
            editerClient.tbPrenom.Text = JeuxTest.Clients[dataClients.SelectedIndex].Prenom;
            editerClient.tbDateNaissance.SelectedDate = JeuxTest.Clients[dataClients.SelectedIndex].DateNaissance;
            editerClient.tbMail.Text = JeuxTest.Clients[dataClients.SelectedIndex].Mail;
            editerClient.tbTelephone.Text = JeuxTest.Clients[dataClients.SelectedIndex].NumTelephone;
            editerClient.tbAdresse.Text = JeuxTest.Clients[dataClients.SelectedIndex].Adresse;
            //Si la liste des interets contient l'interet, alors la checkBox qui y correspond devient checkée, sinon elle est pas checkée
            editerClient.cbCardio.IsChecked = JeuxTest.Clients[dataClients.SelectedIndex].Interets.Contains("Cardio");
            editerClient.cbFitness.IsChecked = JeuxTest.Clients[dataClients.SelectedIndex].Interets.Contains("Fitness");
            editerClient.cbMuscu.IsChecked = JeuxTest.Clients[dataClients.SelectedIndex].Interets.Contains("Muscu");
            editerClient.cbPilate.IsChecked = JeuxTest.Clients[dataClients.SelectedIndex].Interets.Contains("Pilate");
            editerClient.cbZumba.IsChecked = JeuxTest.Clients[dataClients.SelectedIndex].Interets.Contains("Zumba");
            switch (JeuxTest.Clients[dataClients.SelectedIndex].Statut)
            {
                case Statuts.Couple:
                    editerClient.rbCouple.IsChecked = true;
                    break;
                case Statuts.Etudiant:
                    editerClient.rbEtudiant.IsChecked = true;
                    break;
                default:
                    editerClient.rbAdulte.IsChecked = true;
                    break;
            }
            editerClient.ShowDialog();
            JeuxTest.Clients[dataClients.SelectedIndex].Nom = editerClient.tbNom.Text;
            JeuxTest.Clients[dataClients.SelectedIndex].Prenom = editerClient.tbPrenom.Text;
            JeuxTest.Clients[dataClients.SelectedIndex].DateNaissance = (DateTime)editerClient.tbDateNaissance.SelectedDate;
            JeuxTest.Clients[dataClients.SelectedIndex].Mail = editerClient.tbMail.Text;
            JeuxTest.Clients[dataClients.SelectedIndex].NumTelephone = editerClient.tbTelephone.Text;
            JeuxTest.Clients[dataClients.SelectedIndex].Adresse = editerClient.tbAdresse.Text;
            //Si la checkbox est cochée, on ajoute l'interet concerné dans la liste des interets, sinon on y ajoute rien
            JeuxTest.Clients[dataClients.SelectedIndex].Interets += (bool)editerClient.cbCardio.IsChecked ? "Cardio, " : "";
            JeuxTest.Clients[dataClients.SelectedIndex].Interets += (bool)editerClient.cbFitness.IsChecked ? "Fitness, " : "";
            JeuxTest.Clients[dataClients.SelectedIndex].Interets += (bool)editerClient.cbMuscu.IsChecked ? "Muscu, " : "";
            JeuxTest.Clients[dataClients.SelectedIndex].Interets += (bool)editerClient.cbPilate.IsChecked ? "Pilate ," : "";
            JeuxTest.Clients[dataClients.SelectedIndex].Interets += (bool)editerClient.cbZumba.IsChecked ? "Zumba, " : "";
            //Si le radioButton est sur couple alors le statut devient Couple sinon si le radioButton est sur Etudiant le statut devient étudiant sinon il devient adulte.
            JeuxTest.Clients[dataClients.SelectedIndex].Statut = (bool)editerClient.rbCouple.IsChecked ? Statuts.Couple : (bool)editerClient.rbEtudiant.IsChecked ? Statuts.Etudiant : Statuts.Adulte;
            //sert à actualiser l'affichage
            JeuxTest.Clients.Add(JeuxTest.Clients[dataClients.SelectedIndex]);
            JeuxTest.Clients.Move(JeuxTest.Clients.Count - 1, dataClients.SelectedIndex);
            JeuxTest.Clients.RemoveAt(dataClients.SelectedIndex);
        }

    }
}
