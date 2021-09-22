using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommandLine;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AspNetSandbox
{
    public class Program
    {
        public class Options
        {
            [Option('v', "verbose", Required = false, HelpText = "Set output to verbose messages.")]
            public bool Verbose { get; set; }
            [Option('c', "ConnectionString", Required = false, HelpText = "Set connection String.")]
            public bool ConnectionString { get; set; }
            [Option('?', "HelpArgs", Required = false, HelpText = "Displays commandline arguments")]
            public bool HelpArgs { get; set; }
        }

        public static int Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                   .WithParsed<Options>(o =>
                   {
                       if (o.Verbose)
                       {
                           Console.WriteLine($"Verbose output enabled. Current Arguments: -v {o.Verbose}");
                           Console.WriteLine("Quick Start Example! App is in Verbose mode!");
                       }
                       else
                       {
                           Console.WriteLine($"Current Arguments: -v {o.Verbose}");
                           Console.WriteLine("Quick Start Example!");
                       }
                       if (o.ConnectionString)
                       {
                           Console.WriteLine($"ConnectionString output enabled. Current Arguments: -c {o.ConnectionString}");
                           Console.WriteLine("Quick Start Example! App is in Connection mode!");
                       }
                       else
                       {
                           Console.WriteLine($"Current Arguments: -c {o.ConnectionString}");
                           Console.WriteLine("Quick Start Example!");
                       }
                       if (o.HelpArgs)
                       {
                           Console.WriteLine($"Help output enabled. Current Arguments: -? {o.HelpArgs}");
                           Console.WriteLine("Quick Start Example! App is in Help mode!");
                       }
                       else
                       {
                           Console.WriteLine($"Current Arguments: -? {o.HelpArgs}");

                           Console.WriteLine("Quick Start Example!");
                       }
                   });
            if (args.Length > 0)
            {
                Console.WriteLine($"There are: {args.Length} args.");
            }
            else
            {
                Console.WriteLine($"There are no args.");
            }
            CreateHostBuilder(args).Build().Run();
            return 0;
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
