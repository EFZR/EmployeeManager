using Domain.Entity;
using Domain.Interface;
using Infrastructure.Interface;

namespace Domain.Core;

public class UserDomain : IUserDomain
{
    private readonly IUserRepository _userRepository;
    public UserDomain(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> Authenticate(string email, string password)
    {
        var user = await _userRepository.Authenticate(email) ?? throw new Exception("No user was found with that email.");

        if (user.Usu_Password != password)
        {
            throw new Exception("Incorrect Password.");
        }
        return user;
    }

    public async Task<bool> CreateAccount(User user)
    {
        return await _userRepository.CreateAccount(user);
    }
}
