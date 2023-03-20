using EMSWebApp.Data;
using EMSWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EMSWebApp.Repository.MySQL
{
    public class EMSDbRepo : IEMSRepo
    {
        EMSDbContext _dbContext;

        public EMSDbRepo(EMSDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Employee AddEmployee(Employee newEmployee)
        {
            _dbContext.Add(newEmployee);
            _dbContext.SaveChanges();
            return newEmployee;
        }
        public Employee DeleteEmployee(int employeeId)
        {
            var employee = GetEmployeeById(employeeId);
            if (employee != null)
            {
                _dbContext.Employees.Remove(employee);
                _dbContext.SaveChanges();
            }
            return employee;
        }

        public List<Employee> GetAllEmployees()
        {
            return _dbContext.Employees.ToList<Employee>();
        }

        public Employee GetEmployeeById(int Id)
        {
            return _dbContext.Employees.AsNoTracking().ToList().FirstOrDefault(t => t.Id == Id);
        }

        public Employee UpdateEmployee(int employeeId, Employee newEmployee)
        {
            _dbContext.Employees.Update(newEmployee);
            _dbContext.SaveChanges();
            return newEmployee;
        }

        //Department

        public Department AddDepartment(Department newDepartment)
        {

            _dbContext.Add(newDepartment);
            _dbContext.SaveChanges();
            return newDepartment;
        }

        public Department DeleteDepartment(int departmentId)
        {
            var department = GetDepartmentById(departmentId);
            if (department != null)
            {
                _dbContext.Departments.Remove(department);
                _dbContext.SaveChanges();
            }
            return department;
        }

        public List<Department> GetAllDepartments()
        {
            return _dbContext.Departments.ToList<Department>();
        }

        public Department GetDepartmentById(int Id)
        {
            return _dbContext.Departments.AsNoTracking().ToList().FirstOrDefault(t => t.DepartmentId == Id);
        }

        public Department UpdateDepartment(int departmentId, Department newDepartment)
        {
            _dbContext.Departments.Update(newDepartment);
            _dbContext.SaveChanges();
            return newDepartment;
        }
    }
}
