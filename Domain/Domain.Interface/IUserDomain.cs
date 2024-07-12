using Domain.Entity;

namespace Domain.Interface;

public interface IUserDomain
{
    #region Asynchronous Methods
    Task<User> Authenticate(string email, string password);
    Task<bool> CreateAccount(User user);
    #endregion

}
