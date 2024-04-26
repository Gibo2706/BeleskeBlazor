using System.Text.Json;

namespace BeleskeBlazor.Client.Service
{
    public class LoginService
    {
        private readonly HttpClient _httpClient;

        public LoginService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<String?> LogIn(String username, String password)
        {
            String? data = "";

            // Make an HTTP GET request to fetch data from the server
            HttpResponseMessage response = await _httpClient.GetAsync("https://localhost:7241/api/auth/logIn?username=" + username + "&password=" + password);

            if (response.IsSuccessStatusCode)
            {
                await using Stream responseStream = await response.Content.ReadAsStreamAsync();
                data = await JsonSerializer.DeserializeAsync<String>(responseStream);

                responseStream.Close();
            }

            return data;
        }
    }
}
