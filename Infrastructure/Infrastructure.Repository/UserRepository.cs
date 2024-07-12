using System.Data;
using Dapper;
using Domain.Entity;
using Infrastructure.Data;
using Infrastructure.Interface;
using Transversal.Common;

namespace Infrastructure.Repository;

public class UserRepository : IUserRepository
{
    private readonly IConnectionFactory _connectionFactory;
    public UserRepository(ConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }
    public async Task<User> Authenticate(string email)
    {
        using var connection = _connectionFactory.GetSqlConnection;
        var parameters = new DynamicParameters(connection);
        parameters.Add("usu_email", email);
        var user = await connection.QuerySingleAsync<User>("Authenticate", parameters, commandType: CommandType.StoredProcedure);
        return user;
    }

    public async Task<bool> CreateAccount(User user)
    {
        using var connection = _connectionFactory.GetSqlConnection;
        var parameters = new DynamicParameters(connection);
        parameters.Add("usu_nombre", user.Usu_NombreUsuario);
        parameters.Add("usu_email", user.Usu_Email);
        parameters.Add("usu_password", user.Usu_Password);
        var result = await connection.ExecuteAsync("Authenticate", parameters, commandType: CommandType.StoredProcedure);
        return result > 0;
    }
}
