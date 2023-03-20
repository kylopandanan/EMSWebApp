using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMSWebApp.Models
{
    public class Employee
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Name")]
        [DisplayName("Employee Name")]
        public string Name { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }
        [Display(Name = "Department Name")]
        [Required(ErrorMessage = "Department Required")]
        public int DepartmentId { get; set; }
        [ValidateNever]
        [Required(ErrorMessage = "Please Enter Department")]
        public Department Department { get; set; }

        /*[NotMapped]
        public string DepartmentName { get; set; }*/

        public Employee()
        {

        }

        public Employee(int id, string name, DateTime birthday, string email, string phone, int departmentId)
        {
            Id = id;
            Name = name;
            Birthday = birthday;
            Email = email;
            Phone = phone;
            DepartmentId = departmentId;
        }
    }
}
