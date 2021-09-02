using AspNetSandbox.Controllers;
using System;
using System.IO;
using Xunit;

namespace AspNetSandbox.Tests
{
    public class WeatherForecastCityCoordTest
    {
        [Fact]
        public void ConvertResponseToWeatherForecastLatitudeTest()
        {
            //Asume
            string content = LoadJsonFromResource1();
            var controller = new WeatherForecastControllerCityCoord();

            // Act
            var output = controller.ConvertResponseToWeatherForecastCityCoord(content);
           
            // Assert
            var weatherForecastForTomorrow = ((WeatherForecast[])output)[0];
            Assert.Equal("51.5085", weatherForecastForTomorrow.Latitude);
        }
        [Fact]
        public void ConvertResponseToWeatherForecastLongitudeTest()
        {
            //Asume
            string content = LoadJsonFromResource1();
            var controller = new WeatherForecastControllerCityCoord();

            // Act
            var output = controller.ConvertResponseToWeatherForecastCityCoord(content);

            // Assert
            var weatherForecastForTomorrow = ((WeatherForecast[])output)[0];
            Assert.Equal("-0.1257", weatherForecastForTomorrow.Longitude);
        }
        [Fact]
        public void ConvertResponseToWeatherForecastCityNameTest()
        {
            //Asume
            string content = LoadJsonFromResource1();
            var controller = new WeatherForecastControllerCityCoord();

            // Act
            var output = controller.ConvertResponseToWeatherForecastCityCoord(content);

            // Assert
            var weatherForecastForTomorrow = ((WeatherForecast[])output)[0];
            Assert.Equal("London", weatherForecastForTomorrow.Name);
        }

        private string LoadJsonFromResource1()
        {
            var assembly = this.GetType().Assembly;
            var assemblyName = assembly.GetName().Name;
            var resourceName = $"{assemblyName}.DataFromOpenWeatherCityCoordApi.json";
            var resourceStream = assembly.GetManifestResourceStream(resourceName);
            using (var tr = new StreamReader(resourceStream))
            {
                return tr.ReadToEnd();
            }
        }

    }
}