using Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Domain
{
    /// <summary>
    /// Class provides loading country info by name via API
    /// </summary>
    public class CountryLoader
    {
        private readonly string baseUrl = "https://restcountries.eu/rest/v2/name";
        private readonly HttpClient client;
        public CountryLoader()
        {
            client = new HttpClient();
        }

        /// <summary>
        /// Load country info by name
        /// </summary>
        /// <param name="countryName">country name</param>
        /// <returns>country or null</returns>
        public async Task<CountryDisplayModel> LoadInfo(string countryName)
        {

            var response = await client.GetAsync($"{baseUrl}/{countryName}");

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var streamTask = await response.Content.ReadAsStreamAsync();
                var repositories = await JsonSerializer.DeserializeAsync<List<CountryDisplayModel>>(streamTask,
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                return repositories.First();
            }

            return null;
        }
    }
}
