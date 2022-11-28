using EmployeestSeed.Data;
using Microsoft.Extensions.Configuration;

namespace EmployeestSeed
{
    public class Program
    {
        public static IConfigurationRoot Configuration { get; set; }

        public static void Run()
        {
            EmployeestSeedData.SeedData(50);
        }
    }
}


