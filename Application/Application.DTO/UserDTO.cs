namespace Application.DTO;

// Represents the user entity returned by the API in JSON format.
public class UserDTO
{
    public string? Id { get; set; }
    public string? NombreUsuario { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Token { get; set; }
}

// Represents the data required for user authentication, to be received via the API in JSON format.
public class AuthenticateUserDTO
{
    public string? Email { get; set; }
    public string? Password { get; set; }
}

// Represents the data required to create a new user, to be received via the API in JSON format.
public class CreateUserDTO
{
    public string? NombreUsuario { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Token { get; set; }
}
