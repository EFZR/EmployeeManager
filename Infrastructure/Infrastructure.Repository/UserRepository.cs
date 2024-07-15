using System.Data;
using Dapper;
using Domain.Entity;
using Infrastructure.Interface;
using Transversal.Common;

namespace Infrastructure.Repository;

public class UserRepository(IConnectionFactory connectionFactory) : IUserRepository
{
    private readonly IConnectionFactory _connectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));

    public async Task<User> Authenticate(string email)
    {
        using var connection = _connectionFactory.GetSqlConnection;
        var parameters = new DynamicParameters();
        parameters.Add("usu_email", email);
        var user = await connection.QuerySingleAsync<User>("Authenticate", parameters, commandType: CommandType.StoredProcedure);
        return user;
    }

    public async Task<bool> CreateAccount(User user)
    {
        using var connection = _connectionFactory.GetSqlConnection;
        var parameters = new DynamicParameters();
        parameters.Add("usu_nombreUsuario", user.Usu_NombreUsuario);
        parameters.Add("usu_email", user.Usu_Email);
        parameters.Add("usu_password", user.Usu_Password);
        var result = await connection.ExecuteAsync("CreateAccount", parameters, commandType: CommandType.StoredProcedure);
        return result > 0;
    }
}
