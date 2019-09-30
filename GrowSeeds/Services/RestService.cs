namespace GrowSeeds.Services
{
    using Models;
    using System;
    using System.Diagnostics;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Xamarin.Essentials;
    using Xamarin.Forms;

    public class RestService
    {
        HttpClient _client;
        public RestService()
        {
            _client = new HttpClient();
        }

        public async Task<StrainsData> GetStrainsDataAsync(string uri)
        {
            StrainsData strainsData = null;
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    strainsData = StrainsData.FromJson(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }
            return strainsData;
        }


        //Internet Validation
        public static bool ConectivityStatus()
        {
            var current = Connectivity.NetworkAccess;
            if (current == NetworkAccess.Internet)
            {
                //Internet Connection is Ok
                return true;
            }
            else
            {
                Application.Current.MainPage.DisplayAlert(
                    "No Internet Connection",
                    "Please check your internet connection and try again",
                    "Ok");
                return false;
            }
        }
    }
}
        

                 
