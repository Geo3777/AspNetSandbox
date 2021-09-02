using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace AspNetSandbox.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var client = new RestClient("https://api.openweathermap.org/data/2.5/onecall?lat=35.652832&lon=139.839478&exclude=hourly,minutely&appid=b509889970fc2b771cf13e4dfde7d0ee");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            return ConvertResponseToWeatherForecast(response.Content);
        }

        public IEnumerable<WeatherForecast> ConvertResponseToWeatherForecast(string content, int days = 5)
        {

            var json = JObject.Parse(content);
            var rng = new Random();
            const float KELVIN_CONST = 273.15f;
            
            return Enumerable.Range(1, days).Select(index =>
            {
                var jsonDailyForecast = json["daily"][index];
                var unixDateTime = jsonDailyForecast.Value<long>("dt");
                var weatherSummary = jsonDailyForecast["weather"][0].Value<string>("main");
                return new WeatherForecast
                {
                    Date = DateTimeOffset.FromUnixTimeSeconds(unixDateTime).Date,
                    TemperatureC = (int)Math.Round(jsonDailyForecast["temp"].Value<float>("day") - KELVIN_CONST),
                    Summary = weatherSummary
                };
            })
            .ToArray();
        }
    }
}