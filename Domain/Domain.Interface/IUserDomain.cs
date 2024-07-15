using Domain.Entity;

namespace Domain.Interface;

// Defines the contract for user-related operations in the domain layer.
public interface IUserDomain
{
    #region Asynchronous Methods
    Task<User> Authenticate(string email, string password);
    Task<bool> CreateAccount(User user);
    #endregion

}
