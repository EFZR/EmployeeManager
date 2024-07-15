using Application.DTO;
using Transversal.Common;

namespace Application.Interface;

// Defines the contract for user-related operations in the application layer.
public interface IUserApplication
{
    #region Asynchronous Methods
    Task<Response<UserDTO>> Authenticate(string email, string password);
    Task<Response<bool>> CreateAccount(CreateUserDTO user);
    #endregion
}
