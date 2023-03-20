using EMSWebApp.Models;

namespace EMSWebApp.Repository.InMemory
{
    public class EMSInMemory : IEMSRepo// Datastore
    {
        // it will hold the data in runtime and allow to perfrom crud operations

        static List<Employee> employeeList = new List<Employee>();
        static List<Department> departmentList = new List<Department>();

        static EMSInMemory()
        {
            //employeeList.Add(new Employee(1, "Shopping", DateTime.Now.AddDays(2),"jhan@mail.com","2145343");
            departmentList.Add(new Department(1,"Repository"));    
        }
        public List<Employee> GetAllEmployees()
        {
            return employeeList;
        }

        public Employee GetEmployeeById(int Id)
        {
            return employeeList.FirstOrDefault(x => x.Id == Id);
        }

        // add todo into the list
        public Employee AddEmployee(Employee newEmployee)
        {
            newEmployee.Id = employeeList.Max(x => x.Id) + 1; // max id of your list
            employeeList.Add(newEmployee);
            return newEmployee;
        }

        public Employee UpdateEmployee(int employeeId, Employee newEmployee)
        {
            var oldEmployee = employeeList.Find(x => x.Id == employeeId);
            if (oldEmployee == null)
                return null;
            employeeList.Remove(oldEmployee);
            employeeList.Add(newEmployee);
            return newEmployee;
        }

        public Employee DeleteEmployee(int employeeId)
        {
            var oldEmployee = employeeList.Find(x => x.Id == employeeId);
            if (oldEmployee == null)
                return null;
            employeeList.Remove(oldEmployee);
            return oldEmployee;
        }

        //Department
        public List<Department> GetAllDepartments()
        {
            return departmentList;
        }

        public Department GetDepartmentById(int Id)
        {
            return departmentList.FirstOrDefault(x => x.DepartmentId == Id);
        }

        public Department AddDepartment(Department newDepartment)
        {
            newDepartment.DepartmentId = departmentList.Max(x => x.DepartmentId) + 1; // max id of your list
            departmentList.Add(newDepartment);
            return newDepartment;
        }

        public Department UpdateDepartment(int departmentId, Department newDepartment)
        {
            var oldDepartment = departmentList.Find(x => x.DepartmentId == departmentId);
            if (oldDepartment == null)
                return null;
            departmentList.Remove(oldDepartment);
            departmentList.Add(newDepartment);
            return newDepartment;
        }

        public Department DeleteDepartment(int departmentId)
        {
            var oldDepartment = departmentList.Find(x => x.DepartmentId == departmentId);
            if (oldDepartment == null)
                return null;
            departmentList.Remove(oldDepartment);
            return oldDepartment;
        }
    }
}