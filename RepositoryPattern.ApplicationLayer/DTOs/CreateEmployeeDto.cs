using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.ApplicationLayer.DTOs
{
    public class CreateEmployeeDto
    {
        [Required(ErrorMessage = "Employee name is required.")]
        [StringLength(100, ErrorMessage = "Employee name can't be longer than 100 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }= string.Empty;

        [Required(ErrorMessage = "Department is required.")]
        public int DepartmentId { get; set; }
        public DateTime HireDate { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        [RegularExpression("Active|Suspended", ErrorMessage = "Status must be either 'Active' or 'Suspended'.")]
        public string Status { get; set; } = string.Empty;

    }
}
