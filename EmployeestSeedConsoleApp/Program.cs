using Npgsql;


string? dbUsername = Environment.GetEnvironmentVariable("DbUsername", EnvironmentVariableTarget.User);
string? dbPassword = Environment.GetEnvironmentVariable("DbPassword", EnvironmentVariableTarget.User);

string connectionString = $"Host=localhost;Port=5432;Database=CommentsDb;Username={dbUsername};Password={dbPassword}";


using (NpgsqlConnection sqlConnection = new NpgsqlConnection(connectionString))
{
    await sqlConnection.OpenAsync();
    Console.WriteLine("Connection Info:");
    Console.WriteLine($"Connection string: {sqlConnection.ConnectionString}");
    Console.WriteLine($"Database: {sqlConnection.Database}");
    Console.WriteLine($"Username: {sqlConnection.UserName}");
    Console.WriteLine($"Server: {sqlConnection.DataSource}");
    Console.WriteLine($"Server Version: {sqlConnection.ServerVersion}");
    Console.WriteLine($"State: {sqlConnection.State}");
}