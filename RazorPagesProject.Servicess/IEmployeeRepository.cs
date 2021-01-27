using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
