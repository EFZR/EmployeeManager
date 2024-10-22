﻿using Domain.Entity;

namespace Infrastructure.Interface;

// Defines the contract for user-related operations in the Infrastructure layer.
public interface IUserRepository
{
    #region Asynchronous Methods
    Task<User> Authenticate(string email);
    Task<bool> CreateAccount(User user);
    #endregion
}
