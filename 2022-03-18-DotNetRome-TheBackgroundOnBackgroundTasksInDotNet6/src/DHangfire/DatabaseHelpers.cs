using System.Data;
using Microsoft.Data.SqlClient;

namespace DHangfire;

public static class DatabaseHelpers
{
    public static async Task CreateHangfireDatabaseIfItDoesntExistAsync(string connectionString)
    {
        var connection = new SqlConnection(connectionString.Replace("Database=Hangfire", "Database=master"));
        try
        {
            await connection.OpenAsync();
            var command = new SqlCommand(@"   
    IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'Hangfire')
    BEGIN
        CREATE DATABASE [Hangfire]
    END", connection);
            command.ExecuteNonQuery();
        }
        finally
        {
            if (connection.State != ConnectionState.Closed)
            {
                await connection.CloseAsync();
            }
        }
    }

}
