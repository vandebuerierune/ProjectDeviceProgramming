using Newtonsoft.Json.Linq;
using punkapiBeers.Models;
using punkapiBeers.Repositories;
using punkapiBeers.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace punkapiBeers
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            FilterItems();
        }

        private void FilterItems()
        {
            List<String> Year = new List<string> { "12-2007", "12-2008", "12-2009", "12-2010", "12-2011", "12-2012", "12-2013", "12-2014", "12-2015", "12-2016" };
            PunkapiMainPage.ItemsSource = Year;
        }

        private async void PunkapiMainPage_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            string selected = PunkapiMainPage.SelectedItem as String;
            if (selected != null)
            {                
                Navigation.PushAsync(new AllBeers());
                List<Beers> YearUrl = await PunkapiRepository.GetAllfilteredAsync(selected);
                PunkapiMainPage.SelectedItem = null;

            }
        }
    }
}
