using System.Collections.Generic;
using RazorPagesProject.Modelss;
namespace RazorPagesProject.Servicess
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployee(int id);
        Employee Update(Employee updateEmployee);
        Employee Add(Employee newEmployee);
        Employee Delete(int id);
        IEnumerable<DepartmentHeadCount> EmployeeCountByDepartment(Department? department);
        IEnumerable<Employee> Search(string searchTerm);

    }
}
