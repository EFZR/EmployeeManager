﻿namespace Application.DTO;

public class EmployeeDTO
{
    public string? Id { get; set; }
    public string? Nombre { get; set; }
    public string? Puesto { get; set; }
    public string? Salario { get; set; }
    public string? FechaContratacion { get; set; }
}

public class CreateEmployeeDTO
{
    public string? Nombre { get; set; }
    public string? Puesto { get; set; }
    public string? Salario { get; set; }
    public string? FechaContratacion { get; set; }
}

public class UpdateEmployeeDTO
{
    public string? Id { get; set; }
    public string? Nombre { get; set; }
    public string? Puesto { get; set; }
    public string? Salario { get; set; }
    public string? FechaContratacion { get; set; }
}