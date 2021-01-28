using RazorPagesProject.Modelss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RazorPagesProject.Servicess
{
    public class SqlEmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _dbContext;

        public SqlEmployeeRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Employee Add(Employee newEmployee)
        {
            _dbContext.Employees.Add(newEmployee);
            _dbContext.SaveChanges();
            return newEmployee;
        }

        public Employee Delete(int id)
        {
            var EmployeeToDelete = _dbContext.Employees.Find(id);

            if (EmployeeToDelete != null)
            {
                _dbContext.Employees.Remove(EmployeeToDelete);
                _dbContext.SaveChanges();
            }
            return EmployeeToDelete;
        }

        public IEnumerable<DepartmentHeadCount> EmployeeCountByDepartment(Department? department)
        {
            IEnumerable<Employee> query = _dbContext.Employees;
            if (department.HasValue)
                query = query.Where(x => x.Departmentt == department.Value);

            return query.GroupBy(x => x.Departmentt)
                                  .Select(x => new DepartmentHeadCount()
                                  {
                                      Department = x.Key.Value,
                                      Count = x.Count()
                                  }).ToList();

        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _dbContext.Employees;
        }

        public Employee GetEmployee(int id)
        {
            return _dbContext.Employees.Find(id);
        }

        public IEnumerable<Employee> Search(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return _dbContext.Employees;

            return _dbContext.Employees.Where(x => x.Name.ToLower().Contains(searchTerm.ToLower()) || x.Email.ToLower().Contains(searchTerm.ToLower()));

        }

        public Employee Update(Employee updateEmployee)
        {
            var UpEmployee = _dbContext.Employees.Attach(updateEmployee);
            UpEmployee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _dbContext.SaveChanges();

            return updateEmployee;

        }
    }
}
