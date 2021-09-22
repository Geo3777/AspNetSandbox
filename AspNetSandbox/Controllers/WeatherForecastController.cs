using System;
using System.Collections.Generic;
using System.Linq;
using AspNetSandbox.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace AspNetSandbox.Controllers
{
    /// <summary>
    /// Controller that allows us to get  weather from openweather api.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private const float KELVINCONST = 273.15f;

        /// <summary>
        /// getswaether forecast for 5 days.
        /// </summary>
        /// <returns>
        /// Enurable of weatherforecast objects.
        /// </returns>
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var client = new RestClient("https://api.openweathermap.org/data/2.5/onecall?lat=35.652832&lon=139.839478&exclude=hourly,minutely&appid=b509889970fc2b771cf13e4dfde7d0ee");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            return ConvertResponseToWeatherForecast(response.Content);
        }

        /// <summary>Converts the response to weather forecast.</summary>
        /// <param name="content">The content.</param>
        /// <param name="days">The days.</param>
        /// <returns>
        ///   Date, Temperature, Summary.
        /// </returns>
        [NonAction]
        public IEnumerable<WeatherForecast> ConvertResponseToWeatherForecast(string content, int days = 5)
        {
            var json = JObject.Parse(content);
            return Enumerable.Range(1, days).Select(index =>
            {
                var jsonDailyForecast = json["daily"][index];
                var unixDateTime = jsonDailyForecast.Value<long>("dt");
                var weatherSummary = jsonDailyForecast["weather"][0].Value<string>("main");
                return new WeatherForecast
                {
                    Date = DateTimeOffset.FromUnixTimeSeconds(unixDateTime).Date,
                    TemperatureC = ExtractCelsiusFromWeather(jsonDailyForecast),
                    Summary = weatherSummary,
                };
            })
            .ToArray();
        }

        private static int ExtractCelsiusFromWeather(JToken jsonDaileyForecast)
        {
            return (int)Math.Round(jsonDaileyForecast["temp"].Value<float>("day") - KELVINCONST);
        }
    }
}