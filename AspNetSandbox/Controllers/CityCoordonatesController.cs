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
    public class CityCoordonatesController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<CityCoordonates> Get()
        {
            var client = new RestClient("api.openweathermap.org/data/2.5/weather?lat=-0.1257&lon=51.5085&q=London&appid=b509889970fc2b771cf13e4dfde7d0ee");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            return ConvertResponseToWeatherForecastCityCoord(response.Content);
        }
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
