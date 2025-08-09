using Microsoft.EntityFrameworkCore;
using RepositoryPattern.DomainLayer.Entities;
using RepositoryPattern.DomainLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace RepositoryPattern.InfrastructureLayer.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Employee>> GetAllWithDepartmentAsync(string? name = null,
                                                                            int? departmentId = null,
                                                                            string? status = null,
                                                                            DateTime? hireDateFrom = null,
                                                                            DateTime? hireDateTo = null,
                                                                            string? sortBy = null,        // "name" or "hiredate"
                                                                             bool isDescending = false)
        {
            var employees = _context.Employees.Include(e => e.Department).AsQueryable();

            if (!string.IsNullOrEmpty(name))
                employees = employees.Where(e => e.Name.Contains(name));

            if (departmentId.HasValue)
                employees = employees.Where(e => e.DepartmentId == departmentId.Value);

            if (!string.IsNullOrEmpty(status))
                employees = employees.Where(e => e.Status.Equals(status));

            if (hireDateFrom.HasValue)
                employees = employees.Where(e => e.HireDate >= hireDateFrom.Value);

            if (hireDateTo.HasValue)
                employees = employees.Where(e => e.HireDate <= hireDateTo.Value);

            if (!string.IsNullOrEmpty(sortBy))
            {
                if (sortBy.Equals("name", StringComparison.OrdinalIgnoreCase))
                    employees = isDescending ? employees.OrderByDescending(e => e.Name) : employees.OrderBy(e => e.Name);
                else if (sortBy.Equals("hiredate", StringComparison.OrdinalIgnoreCase))
                    employees = isDescending ? employees.OrderByDescending(e => e.HireDate) : employees.OrderBy(e => e.HireDate);
            }

            return await employees.ToListAsync();
        }
        public async Task<Employee> GetByIdWithDepartmentAsync(int id)
        {
            return await _context.Employees.Include(e => e.Department).FirstOrDefaultAsync(e => e.Id == id);
        }

    }
}
