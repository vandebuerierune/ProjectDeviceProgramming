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
                SingleBeer everything = await PunkapiRepository.GetAllSingleBeersAsync(bearId);
                Debug.WriteLine(everything);
                Image.Source = ImageSource.FromStream(() => new HttpClient().GetStreamAsync(everything.Image).Result);
            Name.Text = everything.Name;
            Tagline.Text = everything.Tagline;
            Description.Text = everything.Description;
            Procent.Text = everything.procent + "%";
            Tip.Text = everything.Tip;
            Contributor.Text = everything.Contributor;
            FirstBrewed.Text = everything.FirstBrewed;


        }
    }
}