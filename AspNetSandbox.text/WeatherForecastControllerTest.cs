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
            string content = "";
           

            //Act
            var output = WeatherForecastController.ConvertResponseToWeatherForecast(content);

            //Assert
            Assert.Equal("rainy", ((WeatherForecast[])output)[0].Summary);
        }

      
    }
}
