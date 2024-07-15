namespace Application.DTO;

public class UserDTO
{
    public string? Id { get; set; }
    public string? NombreUsuario { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Token { get; set; }
}

public class AuthenticateUserDTO
{
    public string? Email { get; set; }
    public string? Password { get; set; }
}

public class CreateUserDTO
{
    public string? NombreUsuario { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Token { get; set; }
}
