using System.IO;
using AspNetSandbox.Controllers;
using AspNetSandbox.Models;
using Xunit;

namespace AspNetSandbox.Tests
{
    /// <summary>
    /// this is test suit for city coordonates.
    /// </summary>
    public class CityCoordTest
    {
        [Fact]
        public void ConvertResponseToWeatherForecastLatitudeTest()
        {
            // Asume
            string content = LoadJsonFromResource1();
            var controller = new CityCoordonatesController();

            // Act
            var output = controller.ConvertResponseToWeatherForecastCityCoord(content);

            // Assert
            var weatherForecastForTomorrow = ((CityCoordonates[])output)[0];
            Assert.Equal("51.5085", weatherForecastForTomorrow.Latitude);
        }

        [Fact]
        public void ConvertResponseToWeatherForecastLongitudeTest()
        {
            // Asume
            string content = LoadJsonFromResource1();
            var controller = new CityCoordonatesController();

            // Act
            var output = controller.ConvertResponseToWeatherForecastCityCoord(content);

            // Assert
            var weatherForecastForTomorrow = ((CityCoordonates[])output)[0];
            Assert.Equal("-0.1257", weatherForecastForTomorrow.Longitude);
        }

        [Fact]
        public void ConvertResponseToWeatherForecastCityNameTest()
        {
            // Asume
            string content = LoadJsonFromResource1();
            var controller = new CityCoordonatesController();

            // Act
            var output = controller.ConvertResponseToWeatherForecastCityCoord(content);

            // Assert
            var weatherForecastForTomorrow = ((CityCoordonates[])output)[0];
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