using System;
using System.Collections.Generic;
using System.Linq;
using AspNetSandbox.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace AspNetSandbox.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CityCoordonatesController : ControllerBase
    {
        /// <summary>Gets this instance.</summary>
        /// <returns>
        ///   ConvertResponseToWeatherForecastCityCoord.
        /// </returns>
        [HttpGet]
        public IEnumerable<CityCoordonates> Get()
        {
            var client = new RestClient("https://api.openweathermap.org/data/2.5/weather?lat=-0.1257&lon=51.5085&q=London&appid=b509889970fc2b771cf13e4dfde7d0ee");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            return ConvertResponseToWeatherForecastCityCoord(response.Content);
        }

        /// <summary>Converts the response to weather forecast city coord.</summary>
        /// <param name="content">The content.</param>
        /// <param name="days">The days.</param>
        /// <returns>
        ///   Latitude, Longitude, Name.
        /// </returns>
        [NonAction]
        public IEnumerable<CityCoordonates> ConvertResponseToWeatherForecastCityCoord(string content, int days = 5)
        {
            var jsonCity = JObject.Parse(content);
            return Enumerable.Range(1, days).Select(index =>
            {
                var lat = jsonCity["coord"]["lat"];
                var lon = jsonCity["coord"]["lon"];
                var name = jsonCity["name"];
                return new CityCoordonates
                {
                    Latitude = lat,
                    Longitude = lon,
                    Name = name,
                };
            })
            .ToArray();
        }
    }
}
