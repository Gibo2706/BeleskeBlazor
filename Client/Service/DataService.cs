using System.Net.Http.Json;
using System.Text.Json;
using BeleskeBlazor.Shared;

namespace BeleskeBlazor.Client.Service
{
    
    public class DataService
    {
        private readonly HttpClient _httpClient;

        public DataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<PredmetDTO>?> GetMyData()
        {
            List<PredmetDTO>? data = new List<PredmetDTO>();

            // Make an HTTP GET request to fetch data from the server
            HttpResponseMessage response = await _httpClient.GetAsync("https://localhost:7241/api/predmet");

            if (response.IsSuccessStatusCode)
            {
                await using Stream responseStream = await response.Content.ReadAsStreamAsync();
                data = await JsonSerializer.DeserializeAsync<List<PredmetDTO>?>(responseStream);
                Console.WriteLine(await response.Content.ReadAsStringAsync());
                Console.WriteLine("ID: " + data.First().IdPredmet + " NAZIV:" + data.First().Naziv);
                responseStream.Close();
            }

            return data;
        }
    }
}
