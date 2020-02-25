using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BikeWatcher;


namespace BikeWatcher.Models
{
    public static class Traitement
    {
        private static readonly HttpClient client = new HttpClient();
        public static async Task<List<Stations>> FindStation()
        {
            var streamTask = client.GetStreamAsync("https://download.data.grandlyon.com/ws/rdata/jcd_jcdecaux.jcdvelov/all.json");
            var traitement = await JsonSerializer.DeserializeAsync<Values>(await streamTask);
            var data = traitement.values;
            return data;

        }
    }
}
