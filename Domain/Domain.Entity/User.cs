namespace Domain.Entity;

// Represents the user entity that maps to the columns in the repository database.
public class User
{
    public string? Usu_Id { get; set; }
    public string? Usu_NombreUsuario { get; set; }
    public string? Usu_Email { get; set; }
    public string? Usu_Password { get; set; }
}
