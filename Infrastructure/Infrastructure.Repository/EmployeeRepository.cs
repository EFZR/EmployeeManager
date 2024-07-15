using System.Data;
using Dapper;
using Domain.Entity;
using Infrastructure.Interface;
using Transversal.Common;

namespace Infrastructure.Repository;

public class EmployeeRepository(IConnectionFactory connectionFactory) : IEmployeeRepository
{
    private readonly IConnectionFactory _connectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));

    public async Task<bool> Delete(string employeeId)
    {
        using var connection = _connectionFactory.GetSqlConnection;
        var parameters = new DynamicParameters();
        parameters.Add("emp_id", employeeId);
        var result = await connection.ExecuteAsync("DeleteEmployees", parameters, commandType: CommandType.StoredProcedure);
        return result > 0;
    }

    public async Task<Employee> Get(string employeeId)
    {
        using var connection = _connectionFactory.GetSqlConnection;
        var parameters = new DynamicParameters();
        parameters.Add("emp_id", employeeId);
        var employee = await connection.QuerySingleAsync<Employee>("GetEmployeeById", parameters, commandType: CommandType.StoredProcedure);
        return employee;
    }

    public async Task<IEnumerable<Employee>> GetAll()
    {
        using var connection = _connectionFactory.GetSqlConnection;
        var parameters = new DynamicParameters();
        var employees = await connection.QueryAsync<Employee>("GetEmployees");
        return employees;
    }

    public async Task<bool> Insert(Employee employee)
    {
        using var connection = _connectionFactory.GetSqlConnection;
        var parameters = new DynamicParameters();
        parameters.Add("emp_nombre", employee.Emp_Nombre);
        parameters.Add("emp_puesto", employee.Emp_Puesto);
        parameters.Add("emp_salario", employee.Emp_Salario);
        parameters.Add("emp_fechaContratacion", employee.Emp_FechaContratacion);
        var result = await connection.ExecuteAsync("CreateEmployee", parameters, commandType: CommandType.StoredProcedure);
        return result > 0;
    }

    public async Task<bool> Update(Employee employee)
    {
        using var connection = _connectionFactory.GetSqlConnection;
        var parameters = new DynamicParameters();
        parameters.Add("emp_id", employee.Emp_Id);
        parameters.Add("emp_nombre", employee.Emp_Nombre);
        parameters.Add("emp_puesto", employee.Emp_Puesto);
        parameters.Add("emp_salario", employee.Emp_Salario);
        parameters.Add("emp_fechaContratacion", employee.Emp_FechaContratacion);
        var result = await connection.ExecuteAsync("UpdateEmployees", parameters, commandType: CommandType.StoredProcedure);
        return result > 0;
    }
}
