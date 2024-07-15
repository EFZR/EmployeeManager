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
        var response = new Response<bool>();
        try
        {
            response.Data = await _employeeDomain.Delete(employeeId);
            if (response.Data == true)
            {
                response.IsSuccess = true;
                response.Message = "Employee deleted Succesfully.";
                _logger.LogInformation("Employee deleted Succesfully.");
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
        var response = new Response<EmployeeDTO>();
        try
        {
            var employee = await _employeeDomain.Get(employeeId);
            response.Data = _mapper.Map<EmployeeDTO>(employee);
            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Employee Query Succesfully.";
                _logger.LogInformation("Employee Query Succesfully.");
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
        var response = new Response<IEnumerable<EmployeeDTO>>();
        try
        {
            var employees = await _employeeDomain.GetAll();
            response.Data = _mapper.Map<IEnumerable<EmployeeDTO>>(employees);
            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Employee Query Succesfully.";
                _logger.LogInformation("Employee Query Succesfully.");
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
        var response = new Response<bool>();
        try
        {
            var employee = _mapper.Map<Employee>(employeeDTO);
            response.Data = await _employeeDomain.Insert(employee);
            if (response.Data == true)
            {
                response.IsSuccess = true;
                response.Message = "Employee created Succesfully.";
                _logger.LogInformation("Employee created Succesfully.");
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
        var response = new Response<bool>();
        try
        {
            var employee = _mapper.Map<Employee>(employeeDTO);
            response.Data = await _employeeDomain.Update(employee);
            if (response.Data == true)
            {
                response.IsSuccess = true;
                response.Message = "Employee updated Succesfully.";
                _logger.LogInformation("Employee updated Succesfully.");
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
