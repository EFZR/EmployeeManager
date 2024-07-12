using Application.DTO;
using Transversal.Common;

namespace Application.Interface;

public interface IUserApplication
{
    #region Asynchronous Methods
    Task<Response<UserDTO>> Authenticate(string email, string password);
    Task<Response<bool>> CreateAccount(UserDTO user);
    #endregion
}
