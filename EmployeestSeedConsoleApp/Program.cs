using Npgsql;
using Microsoft.Extensions.Configuration;


var builder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json");

string connectionString = builder.Build()["ConnectionStrings:connectionString"];


using (NpgsqlConnection sqlConnection = new NpgsqlConnection(connectionString))
{
    await sqlConnection.OpenAsync();
}