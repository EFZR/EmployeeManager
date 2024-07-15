namespace Application.DTO;

// Represents the employee entity returned by the API in JSON format.
public class EmployeeDTO
{
    public string? Id { get; set; }
    public string? Nombre { get; set; }
    public string? Puesto { get; set; }
    public string? Salario { get; set; }
    public string? FechaContratacion { get; set; }
}

// Represents the data required to create a new employee, to be received via the API in JSON format.
public class CreateEmployeeDTO
{
    public string? Nombre { get; set; }
    public string? Puesto { get; set; }
    public string? Salario { get; set; }
    public string? FechaContratacion { get; set; }
}

// Represents the data required to update an existing employee, to be received via the API in JSON format.
public class UpdateEmployeeDTO
{
    public string? Id { get; set; }
    public string? Nombre { get; set; }
    public string? Puesto { get; set; }
    public string? Salario { get; set; }
    public string? FechaContratacion { get; set; }
}
