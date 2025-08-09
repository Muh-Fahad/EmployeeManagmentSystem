using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.ApplicationLayer.DTOs
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public string Email { get; set; } = string.Empty;
        public string DepartmentName { get; set; } =string.Empty;
        public DateTime HireDate { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
