using BeleskeBlazor.Shared.DTO;
using System.Text.Json;

namespace BeleskeBlazor.Client.Service
{

    public class DataService
    {
        private readonly HttpClient _httpClient;

        public DataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<PredmetDTO>?> GetAllSubjects()
        {
            List<PredmetDTO>? data = new List<PredmetDTO>();

            // Make an HTTP GET request to fetch data from the server
            HttpResponseMessage response = await _httpClient.GetAsync("https://localhost:7241/api/predmeti");

            if (response.IsSuccessStatusCode)
            {

                await using Stream responseStream = await response.Content.ReadAsStreamAsync();
                data = await JsonSerializer.DeserializeAsync<List<PredmetDTO>?>(responseStream);

                responseStream.Close();
            }

            return data;
        }

        public async Task<List<SemestarDTO>?> GetAllSemestarsForSubject(int id)
        {
            List<SemestarDTO?> data = new List<SemestarDTO?>();
            HttpResponseMessage response = await _httpClient.GetAsync("https://localhost:7241/api/semestri/getSemestriPredmeta?id=" + id);

            if (response.IsSuccessStatusCode)
            {

                await using Stream responseStream = await response.Content.ReadAsStreamAsync();
                data = await JsonSerializer.DeserializeAsync<List<SemestarDTO>?>(responseStream);

                responseStream.Close();
            }
            return data;
        }

        public async Task<List<CasDTO>?> GetAllLecturesForSubjectSemestar(int idSubject, int idSemestar)
        {
            List<CasDTO?> data = new List<CasDTO?>();
            HttpResponseMessage response = await _httpClient.GetAsync("https://localhost:7241/api/cas/getCasoviPredmetaUSemestru?semId=" + idSemestar + "&predId=" + idSubject);

            if (response.IsSuccessStatusCode)
            {
                await using Stream responseStream = await response.Content.ReadAsStreamAsync();
                data = await JsonSerializer.DeserializeAsync<List<CasDTO>?>(responseStream);

                responseStream.Close();
            }

            return data;
        }
    }
}
