using AutoMapper;
using Transversal.Common;
using Application.DTO;
using Application.Interface;
using Domain.Interface;
using Domain.Entity;

namespace Application.Main;

public class EmployeeApplication(IMapper mapper, IEmployeeDomain employeeDomain, IAppLogger<EmployeeApplication> logger) : IEmployeeApplication
{
    private readonly IMapper _mapper = mapper;
    private readonly IEmployeeDomain _employeeDomain = employeeDomain;
    private readonly IAppLogger<EmployeeApplication> _logger = logger;

    public async Task<Response<bool>> Delete(string employeeId)
    {
        // Deletes an employee identified by the given employeeId.
        var response = new Response<bool>();
        try
        {
            response.Data = await _employeeDomain.Delete(employeeId);
            if (response.Data == true)
            {
                response.IsSuccess = true;
                response.Message = "Employee deleted successfully.";
                _logger.LogInformation("Employee deleted successfully.");
            }
        }
        catch (Exception ex)
        {
            response.Data = false;
            response.Message = ex.Message;
            _logger.LogError(ex.Message);
        }
        return response;
    }

    public async Task<Response<EmployeeDTO>> Get(string employeeId)
    {
        // Retrieves the details of a specific employee identified by employeeId.
        var response = new Response<EmployeeDTO>();
        try
        {
            var employee = await _employeeDomain.Get(employeeId);
            response.Data = _mapper.Map<EmployeeDTO>(employee);
            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Employee queried successfully.";
                _logger.LogInformation("Employee queried successfully.");
            }
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Message = ex.Message;
            _logger.LogError(ex.Message);
        }
        return response;
    }

    public async Task<Response<IEnumerable<EmployeeDTO>>> GetAll()
    {
        // Retrieves a list of all employees.
        var response = new Response<IEnumerable<EmployeeDTO>>();
        try
        {
            var employees = await _employeeDomain.GetAll();
            response.Data = _mapper.Map<IEnumerable<EmployeeDTO>>(employees);
            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Employees queried successfully.";
                _logger.LogInformation("Employees queried successfully.");
            }
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Message = ex.Message;
            _logger.LogError(ex.Message);
        }
        return response;
    }

    public async Task<Response<bool>> Insert(CreateEmployeeDTO employeeDTO)
    {
        // Inserts a new employee using the provided employeeDTO data.
        var response = new Response<bool>();
        try
        {
            var employee = _mapper.Map<Employee>(employeeDTO);
            response.Data = await _employeeDomain.Insert(employee);
            if (response.Data == true)
            {
                response.IsSuccess = true;
                response.Message = "Employee created successfully.";
                _logger.LogInformation("Employee created successfully.");
            }
        }
        catch (Exception ex)
        {
            response.Data = false;
            response.Message = ex.Message;
            _logger.LogError(ex.Message);
        }
        return response;
    }

    public async Task<Response<bool>> Update(UpdateEmployeeDTO employeeDTO)
    {
        // Updates an existing employee using the provided employeeDTO data.
        var response = new Response<bool>();
        try
        {
            var employee = _mapper.Map<Employee>(employeeDTO);
            response.Data = await _employeeDomain.Update(employee);
            if (response.Data == true)
            {
                response.IsSuccess = true;
                response.Message = "Employee updated successfully.";
                _logger.LogInformation("Employee updated successfully.");
            }
        }
        catch (Exception ex)
        {
            response.Data = false;
            response.Message = ex.Message;
            _logger.LogError(ex.Message);
        }
        return response;
    }

}
