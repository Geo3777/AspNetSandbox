using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AspNetSandbox.text
{
    public class StartupTest
    {

        [Fact]
        public void CheckConversionToEfConnectionString()
        {
            //Assum
            string databaseUrl = "postgres://owbzprkracmbpm:5525837926b7aa60ea650d77b3383ad07821403434984f78271db789e9bce9ce@ec2-54-155-61-133.eu-west-1.compute.amazonaws.com:5432/dfmep9uk56m67r";

            //Act
            string convertedConnectionString = Startup.ConvertConnextioSring(databaseUrl);

            //Assert
            Assert.Equal("Database=dfmep9uk56m67r; Host=ec2-54-155-61-133.eu-west-1.compute.amazonaws.com; Port=5432; User Id=owbzprkracmbpm; Password=5525837926b7aa60ea650d77b3383ad07821403434984f78271db789e9bce9ce; SSL Mode=Require; Trust Server Certificate=true;", convertedConnectionString);
        }
    }
}
