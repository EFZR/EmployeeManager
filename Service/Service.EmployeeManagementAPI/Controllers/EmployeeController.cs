using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Application.Interface;
using Application.DTO;

namespace Service.EmployeeManagementAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
[Authorize]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeApplication _employeeApplication;
    public EmployeeController(IEmployeeApplication employeeApplication)
    {
        _employeeApplication = employeeApplication;
    }

    #region Asynchronous Methods

    [HttpPost]
    public async Task<IActionResult> Insert([FromBody] EmployeeDTO employeeDTO)
    {
        if (employeeDTO == null)
        {
            return BadRequest(new { error = "All fields are required." });
        }

        var response = await _employeeApplication.Insert(employeeDTO);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to insert employee." });
    }

    [HttpGet("employeeId")]
    public async Task<IActionResult> Get(string employeeId)
    {
        if (string.IsNullOrEmpty(employeeId))
        {
            return BadRequest(new { error = "employeeId is required." });
        }

        var response = await _employeeApplication.Get(employeeId);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to retrieve employee." });
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = await _employeeApplication.GetAll();
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to retrieve employees." });
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] EmployeeDTO employeeDTO)
    {
        if (employeeDTO == null)
        {
            return BadRequest(new { error = "All fields are required." });
        }

        var response = await _employeeApplication.Update(employeeDTO);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to update employee." });
    }

    [HttpDelete("employeeId")]
    public async Task<IActionResult> Delete(string employeeId)
    {
        if (string.IsNullOrEmpty(employeeId))
        {
            return BadRequest(new { error = "employeeId is required." });
        }

        var response = await _employeeApplication.Delete(employeeId);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(new { error = "Failed to delete employee." });
    }

    #endregion

}