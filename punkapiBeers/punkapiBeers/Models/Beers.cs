using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;

namespace punkapiBeers.Models
{
    public class Beers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [JsonProperty(PropertyName = "image_url")]
        public string Image { get; set; }

        
    }
}
