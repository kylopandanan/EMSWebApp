using EMSWebApp.Models;

namespace EMSWebApp.Repository
{
    public interface IEMSRepo
    {
        //Employee
        List<Employee> GetAllEmployees();

        Employee GetEmployeeById(int Id);

        Employee AddEmployee(Employee newEmployee);

        Employee UpdateEmployee(int employeeId, Employee newEmployee);

        Employee DeleteEmployee(int employeeId);

        //Dept
        List<Department> GetAllDepartments();


        Department GetDepartmentById(int Id);


        Department AddDepartment(Department newDepartment);

        Department UpdateDepartment(int departmentId, Department newDepartment);


        Department DeleteDepartment(int departmentId);
    }
}
