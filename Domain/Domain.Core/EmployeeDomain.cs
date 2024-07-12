using Domain.Entity;
using Domain.Interface;
using Infrastructure.Interface;

namespace Domain.Core;

public class EmployeeDomain : IEmployeeDomain
{
    private readonly IEmployeeRepository _employeeRepository;
    public EmployeeDomain(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }
    public async Task<bool> Delete(string employeeId)
    {
        return await _employeeRepository.Delete(employeeId);
    }

    public async Task<Employee> Get(string employeeId)
    {
        return await _employeeRepository.Get(employeeId);
    }

    public async Task<IEnumerable<Employee>> GetAll()
    {
        return await _employeeRepository.GetAll();
    }

    public async Task<bool> Insert(Employee employee)
    {
        return await _employeeRepository.Insert(employee);
    }

    public async Task<bool> Update(Employee employee)
    {
        return await _employeeRepository.Update(employee);
    }
}
