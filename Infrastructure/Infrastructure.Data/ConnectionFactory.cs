using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

using Transversal.Common;

namespace Infrastructure.Data;

public class ConnectionFactory(IConfiguration configuration) : IConnectionFactory
{
    private readonly IConfiguration _configuration = configuration;
    public SqlConnection GetSqlConnection
    {
        get
        {
            var connectionString = _configuration.GetConnectionString("db_connection");
            var sqlConnection = new SqlConnection(connectionString) ?? throw new Exception("Connection Error.");
            sqlConnection.Open();
            return sqlConnection;
        }
    }
}
