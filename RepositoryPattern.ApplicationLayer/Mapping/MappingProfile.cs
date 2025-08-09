using AutoMapper;
using RepositoryPattern.ApplicationLayer.DTOs;
using RepositoryPattern.DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RepositoryPattern.ApplicationLayer.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDto>()
            .ForMember(dest => dest.DepartmentName,
                       opt => opt.MapFrom(src => src.Department.Name));
            CreateMap<CreateEmployeeDto, Employee>();
            CreateMap<DepartmentDto, Department>().ReverseMap();
            CreateMap<LogHistoryDto, LogHistory>().ReverseMap();
        }
    }

}
