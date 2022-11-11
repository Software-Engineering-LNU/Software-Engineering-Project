using EmployeestSeed.Data;
using Microsoft.Extensions.Configuration;

namespace EmployeestSeed
{
    public class Program
    {
        public static IConfigurationRoot Configuration { get; set; }

        public static void Run()
        {
            var builder = new ConfigurationBuilder()
                                    .SetBasePath(Directory.GetCurrentDirectory())
                                    .AddJsonFile("appsettings.json");
            Configuration = builder.Build();

            System.Diagnostics.Debug.WriteLine(Directory.GetCurrentDirectory());
            Console.WriteLine(Directory.GetCurrentDirectory());

            EmployeestSeedData.SeedData(50);
        }
    }
}


