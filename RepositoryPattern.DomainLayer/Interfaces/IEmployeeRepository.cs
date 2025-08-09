using RepositoryPattern.DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.DomainLayer.Interfaces
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task<IEnumerable<Employee>> GetAllWithDepartmentAsync(string? name = null, int? departmentId = null,string? status = null,DateTime? hireDateFrom = null,DateTime? hireDateTo = null, string? sortBy = null, bool isDescending = false);
        Task<Employee> GetByIdWithDepartmentAsync(int id);
    }
}
