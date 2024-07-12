using Domain.Entity;

namespace Infrastructure.Interface;

public interface IEmployeeRepository
{
    #region Asynchronous Methods
    Task<bool> Insert(Employee employee);
    Task<bool> Update(Employee employee);
    Task<bool> Delete(string employeeId);
    Task<Employee> Get(string employeeId);
    Task<IEnumerable<Employee>> GetAll();
    #endregion
}
