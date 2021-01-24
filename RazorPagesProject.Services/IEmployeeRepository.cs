using System;
using System.Collections.Generic;
using System.Text;
using RazorPagesProject.Models;

namespace RazorPagesProject.Services
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployess();
        Employee GetEmployee(int id);
        Employee Update(Employee updateEmployee);
    }
}
