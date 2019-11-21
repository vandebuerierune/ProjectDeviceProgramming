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
    public partial class OneBeer : ContentPage
    {
        internal int bearId;
        public OneBeer(int beerId)
        {
            InitializeComponent();
            bearId = beerId;
            GetSingleBeer();
        }
        
        private async Task GetSingleBeer()
        {
                List<SingleBeer> everything = await PunkapiRepository.GetAllSingleBeersAsync(bearId);
                Debug.WriteLine(everything);
            PunkapiMainPage.ItemsSource = everything;

        }
    }
}