using BeleskeBlazor.Shared.DTO;
using System.Net.Http.Json;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

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

        public async Task<List<SemestarDTO>?> GetAllSemestars()
        {
            List<SemestarDTO>? data = new List<SemestarDTO>();

            // Make an HTTP GET request to fetch data from the server
            HttpResponseMessage response = await _httpClient.GetAsync("https://localhost:7241/api/semestri/getAllSemestri");

            if (response.IsSuccessStatusCode)
            {

                await using Stream responseStream = await response.Content.ReadAsStreamAsync();
                data = await JsonSerializer.DeserializeAsync<List<SemestarDTO>?>(responseStream);

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

        public async Task<bool> SaveBeleska(String naslov, StudentDTO? idStudent, byte[] dokument, int redniBroj, CasDTO? idCas, TagDTO[]? tagovi)
        {
            bool saved = false;
            BeleskaDTO data = new BeleskaDTO(
                   0,
                   redniBroj,
                   naslov,
                   dokument,
                   idStudent,
                   idCas,
                   tagovi
               );
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("https://localhost:7241/api/beleske/addBeleska?jeUlogovan=false", data);

            if (response.IsSuccessStatusCode)
            {
                saved = true;
            }
            return saved;
        }

        public async Task<List<BeleskaDTO>?> GetAllNotesForLecture(int idCas)
        {
            List<BeleskaDTO?> data = new List<BeleskaDTO?>();
            HttpResponseMessage response = await _httpClient.GetAsync("https://localhost:7241/api/beleske/getBeleskeCasa?id=" + idCas);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Uspesno - " + response.ToString());
                await using Stream responseStream = await response.Content.ReadAsStreamAsync();
                data = await JsonSerializer.DeserializeAsync<List<BeleskaDTO>?>(responseStream);

                responseStream.Close();
            }

            return data;
        }

        public async Task<List<BeleskaDTO>?> FilterNotesBy(PredmetDTO? predmet, CasDTO? brCasa, SemestarDTO? semestar,
                                                            string? imeAutora, string? prezimeAutora,
                                                            DateOnly? datumOd, DateOnly? datumDo,
                                                            string? naslov, int[]? idTagovi)
        {
            List<BeleskaDTO?> data = new List<BeleskaDTO?>();
            String url = "https://localhost:7241/api/beleske/getBeleskeDinamicno?";
            if (predmet != null)
            {
                url += "predmet=" + UrlEncoder.Default.Encode("" + predmet.IdPredmet) + "&";
            }
            if (brCasa != null)
            {
                url += "brCasa=" + UrlEncoder.Default.Encode("" + brCasa.RedniBroj) + "&";
            }
            if (semestar != null)
            {
                url += "brCasa=" + UrlEncoder.Default.Encode("" + semestar.IdSemestar) + "&";
            }
            if (imeAutora != null)
            {
                url += "imeAutora=" + UrlEncoder.Default.Encode("" + imeAutora) + "&";
            }
            if (prezimeAutora != null)
            {
                url += "prezimeAutora=" + UrlEncoder.Default.Encode("" + prezimeAutora) + "&";
            }
            if (datumOd != null)
            {
                url += "datumOd=" + UrlEncoder.Default.Encode("" + datumOd) + "&";
            }
            if (datumDo != null)
            {
                url += "datumDo=" + UrlEncoder.Default.Encode("" + datumDo) + "&";
            }
            if (naslov != null)
            {
                url += "naslov=" + UrlEncoder.Default.Encode("" + naslov) + "&";
            }
            if (idTagovi != null)
            {
                url += "idTagovi=" + UrlEncoder.Default.Encode("" + idTagovi) + "&";
            }
            Console.WriteLine("URL: " + url);
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Uspesno - " + response.ToString());
                await using Stream responseStream = await response.Content.ReadAsStreamAsync();
                data = await JsonSerializer.DeserializeAsync<List<BeleskaDTO>?>(responseStream);

                responseStream.Close();
            }

            return data;
        }
    }
    record class SaveDTO(
        [property: JsonPropertyName("bdt")] BeleskaDTO bdt,
        [property: JsonPropertyName("jeUlogovan")] Boolean jeUlogovan
        );
}
