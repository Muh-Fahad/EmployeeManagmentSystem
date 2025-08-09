using RepositoryPattern.ApplicationLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.ApplicationLayer.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetAllAsync(string? name = null, int? departmentId = null,string? status = null,DateTime? hireDateFrom = null,DateTime? hireDateTo = null,string? sortBy = null,bool isDescending = false);
        Task<EmployeeDto> GetByIdAsync(int id);
        Task<EmployeeDto> AddAsync(CreateEmployeeDto dto);
        Task<EmployeeDto> UpdateAsync(int id, CreateEmployeeDto dto);
        Task<bool> DeleteAsync(int id);

    }
}
