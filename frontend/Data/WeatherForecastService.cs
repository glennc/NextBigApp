using System;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace frontend.Data
{
    public class WeatherForecastService
    {
        private HttpClient _client;
        private JsonSerializerOptions _serializationOptions;

        public WeatherForecastService(HttpClient client)
        {
            _client = client;
            _serializationOptions = new JsonSerializerOptions{ PropertyNameCaseInsensitive = true };
        }

        public async Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
        {
            var stream = await _client.GetStreamAsync("/WeatherForecast");
            return await JsonSerializer.DeserializeAsync<WeatherForecast[]>(stream, _serializationOptions);
        }
    }
}

