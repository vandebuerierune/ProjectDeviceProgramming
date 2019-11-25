using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace punkapiBeers.Models
{
    public class SingleBeer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tagline { get; set; }
        public string Description { get; set; }

        [JsonProperty(PropertyName = "abv")]
        public double procent { get; set; }

        [JsonProperty(PropertyName = "image_url")]
        public string Image { get; set; } 

        [JsonProperty(PropertyName = "brewers_tips")]
        public string Tip { get; set; }
        public List<string> food_pairing { get; set; }  

        [JsonProperty(PropertyName = "contributed_by")]
        public string Contributor { get; set; }
        [JsonProperty(PropertyName = "first_brewed")]
        public string FirstBrewed { get; set; }

    }
}
