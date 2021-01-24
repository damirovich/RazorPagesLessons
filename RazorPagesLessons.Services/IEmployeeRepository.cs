using System;
using System.Collections.Generic;
using System.Text;
using RazorPagesLessons.Models;

namespace RazorPagesLessons.Services
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployess();
        Employee GetEmployee(int id);
        Employee Update(Employee updateEmployee);
    }
}
