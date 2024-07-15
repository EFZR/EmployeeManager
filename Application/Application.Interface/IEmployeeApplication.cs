using Application.DTO;
using Transversal.Common;

namespace Application.Interface;

public interface IEmployeeApplication
{
    #region Asynchronous Methods
    Task<Response<bool>> Insert(CreateEmployeeDTO employeeDTO);
    Task<Response<bool>> Update(UpdateEmployeeDTO employeeDTO);
    Task<Response<bool>> Delete(string employeeId);
    Task<Response<EmployeeDTO>> Get(string employeeId);
    Task<Response<IEnumerable<EmployeeDTO>>> GetAll();
    #endregion
}
