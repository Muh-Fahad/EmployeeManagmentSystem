using RepositoryPattern.DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.DomainLayer.Entities
{
    public class Employee
    {
            public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
            public string Email { get; set; } = string.Empty;
            public DateTime HireDate { get; set; }   
            public EmployeeStatus Status { get; set; } 
            public int DepartmentId { get; set; }
            public Department Department { get; set; }
        }

    }

