using System;
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
using System.Windows.Shapes;
using LiveCharts;
using LiveCharts.Wpf;
using System.Collections;
using System.Collections.ObjectModel;
using LiveCharts.Defaults;

namespace Training_Form
{
    /// <summary>
    /// Logique d'interaction pour DashBoard.xaml
    /// </summary>
    public partial class DashBoard : Window
    {
        public SeriesCollection SeriesCollection { get; set; }
        public SeriesCollection SeriesCollection2 { get; set; }
        Activite bodyScultp = new Activite() { Title = "Body Scultp", Value = 80 };
        Activite stretch = new Activite() { Title = "Stretch", Value = 55 };
        Activite Cross = new Activite() { Title = "Cross", Value = 40 };
        Activite zumba = new Activite() { Title = "Zumba", Value = 140 };
        Activite yoga = new Activite() { Title = "Yoga", Value = 50 };
        Activite pilates = new Activite() { Title = "Pilates", Value = 60 };

        Abonnement abo1 = new Abonnement() { Mois = "janvier", Value = 10 };
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }



        public DashBoard()
        {
            InitializeComponent();

            SeriesCollection = new SeriesCollection           
            {
              
                
                new PieSeries
                    {
                         Title = bodyScultp.Title,
                         Values = new ChartValues<ObservableValue> { new ObservableValue(bodyScultp.Value) },
                         DataLabels = true
                    },
                new PieSeries
                    {
                         Title = stretch.Title,
                         Values = new ChartValues<ObservableValue> { new ObservableValue(stretch.Value) },
                         DataLabels = true
                    },
                new PieSeries
                    {
                         Title = Cross.Title,
                         Values = new ChartValues<ObservableValue> { new ObservableValue(Cross.Value) },
                         DataLabels = true
                    },
                new PieSeries
                    {
                         Title = zumba.Title,
                         Values = new ChartValues<ObservableValue> { new ObservableValue(zumba.Value) },
                         DataLabels = true
                    },
                new PieSeries
                    {
                         Title = yoga.Title,
                         Values = new ChartValues<ObservableValue> { new ObservableValue(yoga.Value) },
                         DataLabels = true
                    },
                new PieSeries
                    {
                         Title = pilates.Title,
                         Values = new ChartValues<ObservableValue> { new ObservableValue(pilates.Value) },
                         DataLabels = true
                    },




            };
            SeriesCollection2 = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "2017",
                    Values = new ChartValues<double> {5,8,6,5,6,4,2,11,12,1,5,2},
                    Fill = Brushes.LightSlateGray

                }

            };
            SeriesCollection2.Add (new ColumnSeries
            {
                    Title = "2018",
                    Values = new ChartValues<double> { 10, 5, 10, 7, 14, 20, 10, 11, 14, 5, 0, 10 },
                    Fill = Brushes.DarkTurquoise

            });

            Labels = new[] { "janvier", "fevrier", "mars", "avril","mai","juin","juillet","aout","septembre","octobre","novembre","decembre" };
            Formatter = value => value.ToString("N");
            DataContext = this;
        }
    }
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
