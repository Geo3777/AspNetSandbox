using Newtonsoft.Json.Linq;

namespace AspNetSandbox.Models
{
    public class CityCoordonates
    {
        public JToken Latitude { get; internal set; }

        public JToken Longitude { get; internal set; }

        public JToken Name { get; internal set; }
    }
}