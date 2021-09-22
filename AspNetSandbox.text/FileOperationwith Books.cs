using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AspNetSandbox.text
{
    public class FileOperationwith_Books
    {
        [Fact]
        public void EnumerateFileTest()
        {
            System.IO.DirectoryInfo directoryInfo = new System.IO.DirectoryInfo(".");
            var files = directoryInfo.EnumerateFiles();
            foreach (var file in files)
            {
                Console.WriteLine(file.Name);
            }
        }
        [Fact]
        public void CreateFileTest()
        {
            File.WriteAllText("newSettings.json", @"{
  ""ConnectionStrings"": {
    ""DefaultConnection"": ""Database=dfmep9uk56m67r; Host=ec2-54-155-61-133.eu-west-1.compute.amazonaws.com; Port=5432; User Id=owbzprkracmbpm; Password=5525837926b7aa60ea650d77b3383ad07821403434984f78271db789e9bce9ce; SSL Mode=Require; Trust Server Certificate=true;"",
    ""PostgreConnection"": ""Server=127.0.0.1;Port=5432;Database=AspNetSandbox;User Id=postgres;Password=Ab3777;"",
    ""SqlConnection"": ""Server=(localdb)\\mssqllocaldb;Database=aspnet-AspNetSandbox-85C70D45-DDF9-493D-9954-3AEBB2AE1D1C;Trusted_Connection=True;MultipleActiveResultSets=true""
  },
  ""Logging"": {
    ""LogLevel"": {
      ""Default"": ""Information"",
      ""Microsoft"": ""Warning"",
      ""Microsoft.Hosting.Lifetime"": ""Information""
    }
  },
  ""AllowedHosts"": ""*""
}
");
        }
        /*
        [Fact]
        public void ReadFileTest()
        {
            using (var fs = File.OpenRead("newSettings.json"))
            {
                byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);

                while (fs.Read(b, 0, b.Length) > 0)
                {
                    var s = temp.GetString(b);
                    Console.WriteLine(s);
                }
            }
        }
        */
    }
}
