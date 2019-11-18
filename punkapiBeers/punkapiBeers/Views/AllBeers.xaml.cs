using punkapiBeers.Models;
using punkapiBeers.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
           // List<SingleBeer> singleBeer = await PunkapiRepository.GetAllSingleBeersAsync();
            PunkapiMainPage.ItemsSource = beerList;

        }
    }
}