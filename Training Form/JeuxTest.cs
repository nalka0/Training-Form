using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveCharts;
using LiveCharts.Wpf;
using System.Collections;
using LiveCharts.Defaults;

namespace Training_Form
{
    public static class  JeuxTest
    {
        public static ObservableCollection<Article> Articles = new ObservableCollection<Article>();
        public static ObservableCollection<Client> Clients = new ObservableCollection<Client>();
        public static ObservableCollection<Salarie> Salaries = new ObservableCollection<Salarie>();
        public static ObservableCollection<Service> Services = new ObservableCollection<Service>();
        public static SeriesCollection SeriesCollection = new SeriesCollection();
        public static SeriesCollection SeriesCollection2 = new SeriesCollection();

    }
}
