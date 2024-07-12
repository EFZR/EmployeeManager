using Domain.Entity;

namespace Infrastructure.Interface;

public interface IUserRepository
{
    #region Asynchronous Methods
    Task<User> Authenticate(string email);
    Task<bool> CreateAccount(User user);
    #endregion
}
