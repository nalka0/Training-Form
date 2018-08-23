using System;
using System.Windows.Controls;
using System.Windows.Media;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Defaults;
using System.Collections.ObjectModel;

namespace Training_Form
{
    /// <summary>
    /// Logique d'interaction pour UserControlHome.xaml
    /// </summary>
    public partial class UserControlHome : UserControl
    {
        public UserControlHome()
        {
            InitializeComponent();
            DataContext = this;
            Chart.Series = JeuxTest.SeriesCollection;
            Charts2.Series = JeuxTest.SeriesCollection2;
            dataDerniersClients.ItemsSource = afficherDeniersClients();
            DashBoard();
        }

        public ObservableCollection<Client> afficherDeniersClients()
        {
            ObservableCollection<Client> listeClient = new ObservableCollection<Client>();
            int i = JeuxTest.Clients.Count - 1;

            while (i >= JeuxTest.Clients.Count - 5)
            {
                listeClient.Add(JeuxTest.Clients[i]);
                i--;
            }
            return listeClient;
        }

        #region DashBoard
        Activite bodyScultp = new Activite() { Title = "Body Scultp", Value = 80 };
        Activite stretch = new Activite() { Title = "Stretch", Value = 55 };
        Activite Cross = new Activite() { Title = "Cross", Value = 40 };
        Activite zumba = new Activite() { Title = "Zumba", Value = 140 };
        Activite yoga = new Activite() { Title = "Yoga", Value = 50 };
        Activite pilates = new Activite() { Title = "Pilates", Value = 60 };

        Abonnement abo1 = new Abonnement() { Mois = "janvier", Value = 10 };
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }

        public void DashBoard()
        {
            if (JeuxTest.SeriesCollection.Count == 0)
            {
                JeuxTest.SeriesCollection.Add(
                    new PieSeries
                    {
                        Title = bodyScultp.Title,
                        Values = new ChartValues<ObservableValue> { new ObservableValue(bodyScultp.Value) },
                        DataLabels = true
                    });
                JeuxTest.SeriesCollection.Add(
                    new PieSeries
                    {
                        Title = stretch.Title,
                        Values = new ChartValues<ObservableValue> { new ObservableValue(stretch.Value) },
                        DataLabels = true
                    });
                JeuxTest.SeriesCollection.Add(
                    new PieSeries
                    {
                        Title = Cross.Title,
                        Values = new ChartValues<ObservableValue> { new ObservableValue(Cross.Value) },
                        DataLabels = true

                    });
                JeuxTest.SeriesCollection.Add(
                    new PieSeries
                    {
                        Title = zumba.Title,
                        Values = new ChartValues<ObservableValue> { new ObservableValue(zumba.Value) },
                        DataLabels = true
                    });
                JeuxTest.SeriesCollection.Add(
                    new PieSeries
                    {
                        Title = yoga.Title,
                        Values = new ChartValues<ObservableValue> { new ObservableValue(yoga.Value) },
                        DataLabels = true
                    });
                JeuxTest.SeriesCollection.Add(
                    new PieSeries
                    {
                        Title = pilates.Title,
                        Values = new ChartValues<ObservableValue> { new ObservableValue(pilates.Value) },
                        DataLabels = true,
                    });
            }
            else
            {
                Chart.Update(true, false);
            }
            if (JeuxTest.SeriesCollection2.Count == 0)
            {
                JeuxTest.SeriesCollection2.Add(
                new ColumnSeries
                {
                    Title = "2017",
                    Values = new ChartValues<double> { 5, 8, 6, 5, 6, 4, 2, 11, 12, 1, 5, 2 },
                    Fill = Brushes.LightSlateGray
                }
                );
                JeuxTest.SeriesCollection2.Add(new ColumnSeries
                {
                    Title = "2018",
                    Values = new ChartValues<double> { 10, 5, 10, 7, 14, 20, 10, 11, 14, 5, 0, 10 },
                    Fill = Brushes.DarkTurquoise
                }
                );
                Labels = new[] { "janvier", "fevrier", "mars", "avril", "mai", "juin", "juillet", "aout", "septembre", "octobre", "novembre", "decembre" };
                Formatter = value => value.ToString("N");
                Charts2.DataContext = this;
            }
            else
            {
                Charts2.Update(true, false);
                Labels = new[] { "janvier", "fevrier", "mars", "avril", "mai", "juin", "juillet", "aout", "septembre", "octobre", "novembre", "decembre" };
            }
        }
        #endregion
        public class Activite
        {
            public string Title;
            public int Value;
        }
        public class Abonnement
        {
            public string Mois;
            public int Value;
        }
    }
}
