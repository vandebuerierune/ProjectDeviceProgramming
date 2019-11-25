using punkapiBeers.Models;
using punkapiBeers.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace punkapiBeers.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllBeers : ContentPage
    {

        public AllBeers()
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
                SingleBeer singleBeer = await PunkapiRepository.GetAllSingleBeersAsync(selected.Id);
                PunkapiMainPage.SelectedItem = null;
            }

        }
    }
}