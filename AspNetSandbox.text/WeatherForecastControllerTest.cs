using System;
using Xunit;
using AspNetSandbox.Controllers;

namespace AspNetSandbox.text
{
    public class WeatherForecastControllerTest
    {
        [Fact]
        public void ConvertResponseToWeatherForecastTest()
        {
            //Asume
            string content = "{\"coord\":{\"lon\":-0.1257,\"lat\":51.5085},\"weather\":[{\"id\":804,\"main\":\"Clouds\",\"description\":\"overcast clouds\",\"icon\":\"04d\"}],\"base\":\"stations\",\"main\":{\"temp\":288.05,\"feels_like\":287.82,\"temp_min\":286.86,\"temp_max\":288.86,\"pressure\":1029,\"humidity\":85},\"visibility\":10000,\"wind\":{\"speed\":4.12,\"deg\":50},\"clouds\":{\"all\":90},\"dt\":1630565913,\"sys\":{\"type\":2,\"id\":2006068,\"country\":\"GB\",\"sunrise\":1630559700,\"sunset\":1630608346},\"timezone\":3600,\"id\":2643743,\"name\":\"London\",\"cod\":200}";

            //Act
            var output = WeatherForecastController.ConvertResponseToWeatherForecast(content);

            //Assert
            Assert.Equal("Clouds", ((WeatherForecast[])output)[0].Summary);
        }

      
    }
}
