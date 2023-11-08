using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConvertorApp.Data
{
    public class HttpManager
    {
        private HttpClient Client = new HttpClient();

		private string BaseApiUrl = @"https://currency-conversion-and-exchange-rates.p.rapidapi.com/";

		private HttpRequestMessage Message(string options)
		{
            return new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(this.BaseApiUrl + options),
                Headers =
                {
                    { "X-RapidAPI-Key", "6f56ddc39emshe2b2a554aae57c5p16439ajsn87a50c97d645" },
                    { "X-RapidAPI-Host", "currency-conversion-and-exchange-rates.p.rapidapi.com" },
                },
            };
        }
        public async Task<T> GetDataFromApi<T>(string requestOptions)
        {
            using (var response = await this.Client.SendAsync(this.Message(requestOptions)))
            {
                response.EnsureSuccessStatusCode();
                string jsonString = await response.Content.ReadAsStringAsync();
                var s = JsonSerializer.Deserialize<T>(jsonString);

                return s;

            }
        }
    }
}