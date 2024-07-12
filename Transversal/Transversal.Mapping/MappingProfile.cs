using AutoMapper;
using Application.DTO;
using Domain.Entity;

namespace Transversal.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Mapping User
        CreateMap<User, UserDTO>()
            .ForMember(destination => destination.Id, source => source.MapFrom(src => src.Usu_Id))
            .ForMember(destination => destination.NombreUsuario, source => source.MapFrom(src => src.Usu_NombreUsuario))
            .ForMember(destination => destination.Email, source => source.MapFrom(src => src.Usu_Email))
            .ForMember(destination => destination.Password, source => source.MapFrom(src => src.Usu_Password))
            .ReverseMap();

        // Mapping Employee
        CreateMap<Employee, EmployeeDTO>()
            .ForMember(destination => destination.Id, source => source.MapFrom(src => src.Emp_Id))
            .ForMember(destination => destination.Nombre, source => source.MapFrom(src => src.Emp_Nombre))
            .ForMember(destination => destination.Puesto, source => source.MapFrom(src => src.Emp_Puesto))
            .ForMember(destination => destination.Salario, source => source.MapFrom(src => src.Emp_Salario))
            .ForMember(destination => destination.FechaContratacion, source => source.MapFrom(src => src.Emp_FechaContratacion))
            .ReverseMap();
    }
}
