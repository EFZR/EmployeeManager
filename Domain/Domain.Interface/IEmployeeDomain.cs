using Domain.Entity;

namespace Domain.Interface;

// Defines the contract for employee-related operations in the domain layer.
public interface IEmployeeDomain
{
    #region Asynchronous Methods
    Task<bool> Insert(Employee employee);
    Task<bool> Update(Employee employee);
    Task<bool> Delete(string employeeId);
    Task<Employee> Get(string employeeId);
    Task<IEnumerable<Employee>> GetAll();
    #endregion
}