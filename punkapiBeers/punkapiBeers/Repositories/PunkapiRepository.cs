using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;



using System.Net;
using System.Data;
using Newtonsoft.Json;
using System.Net.Http;
using punkapiBeers.Models;

namespace punkapiBeers.Repositories
{
    public static class PunkapiRepository
    {
        private const string basUri = "https://api.punkapi.com/v2/";
    
    private static HttpClient GetHttpClient()
    {

        HttpClient client = new HttpClient();
        client.DefaultRequestHeaders.Add("accept", "application/json");//its a json file

        return client;

    }
    public static async Task<List<Beers>> GetAllBeersAsync()
    {
        string url = "https://api.punkapi.com/v2/beers";

        using (HttpClient client = GetHttpClient())
        {
            try
            {
                string json = await client.GetStringAsync(url);
                List<Beers> beers = JsonConvert.DeserializeObject<List<Beers>>(json);
                return beers;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
        public static async Task<List<Beers>> GetAllfilteredAsync(string date)
        {
            string url = $"https://api.punkapi.com/v2/beers?brewed_before={date}";

            using (HttpClient client = GetHttpClient())
            {
                try
                {
                    string json = await client.GetStringAsync(url);
                    List<Beers> beers = JsonConvert.DeserializeObject<List<Beers>>(json);
                    return beers;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }

        }
        public static async Task <SingleBeer> GetAllSingleBeersAsync(int BeerId)
        {
            string url = $"https://api.punkapi.com/v2/beers/{BeerId}";

            using (HttpClient client = GetHttpClient())
            {
                try
                {

                    string json = await client.GetStringAsync(url);
                    List<SingleBeer> singleBeers = JsonConvert.DeserializeObject<List<SingleBeer>>(json);
                    return singleBeers[0];
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }

        }
    }
}