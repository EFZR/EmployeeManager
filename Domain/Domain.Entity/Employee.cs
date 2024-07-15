namespace Domain.Entity;

// Represents the employee entity that maps to the columns in the repository database.
public class Employee
{
    public string? Emp_Id { get; set; }
    public string? Emp_Nombre { get; set; }
    public string? Emp_Puesto { get; set; }
    public string? Emp_Salario { get; set; }
    public string? Emp_FechaContratacion { get; set; }
}
