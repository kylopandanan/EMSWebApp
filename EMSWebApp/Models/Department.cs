using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EMSWebApp.Models
{
    public class Department
    {
        [DisplayName("Department ID")]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Please Input Department Name")]
        [DisplayName("Department Name")]
        public string DepartmentName { get; set; }
        [ValidateNever]
        public ICollection<Employee> Employees { get; set; }

        public Department()
        {

        }

        public Department(int departmentId, string departmentName)
        {
            DepartmentId = departmentId;
            DepartmentName = departmentName;
        }
    }




}
