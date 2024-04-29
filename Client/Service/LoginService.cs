namespace BeleskeBlazor.Client.Service
{
    public class LoginService
    {
        private readonly HttpClient _httpClient;

        public static bool IsLoggedIn { get; set; }
        public static String User { get; set; }
        public static bool IsAboutToExpire { get; set; }

        public LoginService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            IsLoggedIn = false;
            User = "";
            IsAboutToExpire = false;
        }

        public async Task<String> RenewSession()
        {
            HttpResponseMessage data = await _httpClient.GetAsync("https://localhost:7241/api/auth/continueSess");
            if (data == null)
            {
                IsLoggedIn = false;
                User = "";
                return "Session expired";
            }
            else
            {
                if (data.IsSuccessStatusCode)
                {
                    IsLoggedIn = true;
                    IsAboutToExpire = false;
                    return await data.Content.ReadAsStringAsync();
                }
                else
                {
                    IsLoggedIn = false;
                    User = "";
                    return "Session expired";
                }
            }
        }

        public async Task<String?> LogIn(String username, String password)
        {
            String? data = "";

            // Make an HTTP GET request to fetch data from the server
            HttpResponseMessage response = await _httpClient.GetAsync("https://localhost:7241/api/auth/logIn?username=" + username + "&password=" + password);

            if (response.IsSuccessStatusCode)
            {
                IsLoggedIn = true;
                data = await response.Content.ReadAsStringAsync();
                User = username;
            }

            return data;
        }

        public async Task<String?> LogOut()
        {
            String? data = "";

            HttpResponseMessage response = await _httpClient.GetAsync("https://localhost:7241/api/auth/logOut");

            if (response.IsSuccessStatusCode)
            {
                IsLoggedIn = false;
                User = "";
                data = await response.Content.ReadAsStringAsync();
            }

            return data;
        }


    }
}
