using Microsoft.Extensions.Configuration;

namespace EmployeestSeedConsoleApp 
{
    public class Program
    {
        public static IConfigurationRoot Configuration { get; set; }

        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

            Configuration = builder.Build();  

            //string connectionString = Configuration["ConnectionStrings:connectionString"];


            //using (NpgsqlConnection sqlConnection = new NpgsqlConnection(connectionString))
            //{
            //    await sqlConnection.OpenAsync();
            //}
        }
    }
}


