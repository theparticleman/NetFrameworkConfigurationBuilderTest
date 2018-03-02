using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace NetFrameworkConfigurationBuilderTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");

            var tempConfig = builder.Build();
            builder.AddJsonFile(tempConfig["CredsFilePath"]); //This part is a little different than .NET Core

            var config = builder.Build();
            foreach (var section in config.GetChildren())
            {
                Console.WriteLine($"{section.Key} : {section.Value}");
            }

            Console.ReadKey();
        }
    }
}
