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
            testRepository();
            GetAllBeers();
        }

        private async Task GetAllBeers()
        {
            List<Beers> everything = await PunkapiRepository.GetAllBeersAsync();
            Debug.WriteLine(everything);
        }

        private async Task testRepository()
        {
            List<Beers> beerList = await PunkapiRepository.GetAllBeersAsync();


            PunkapiMainPage.ItemsSource = beerList;

        }
  

        private async void PunkapiMainPage_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Beers selected = PunkapiMainPage.SelectedItem as Beers;
            if (selected != null)
            {
                Navigation.PushAsync(new OneBeer(selected.Id));
                List<SingleBeer> singleBeer = await PunkapiRepository.GetAllSingleBeersAsync(selected.Id);
                PunkapiMainPage.SelectedItem = null;
            }

        }
    }
}
