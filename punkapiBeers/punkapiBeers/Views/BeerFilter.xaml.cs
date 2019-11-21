using punkapiBeers.Models;
using punkapiBeers.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace punkapiBeers.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BeerFilter : ContentPage
    {
        public BeerFilter()
        {
            InitializeComponent();
            GetFIlteredBeers();
        }

        private async Task GetFIlteredBeers()
        {
            List<Beers> filteredBeers = await PunkapiRepository.GetAllfilteredAsync("04/2007");
            PunkapiMainPage.ItemsSource = filteredBeers;

        }
    }
}