using System;
using Newtonsoft.Json.Linq;

namespace AspNetSandbox.Models
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }

        public JToken Latitude { get; internal set; }

        public JToken Longitude { get; internal set; }

        public JToken Name { get; internal set; }
    }
}
