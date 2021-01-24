using RazorPagesLessons.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RazorPagesLessons.Services
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeesList;

        public MockEmployeeRepository()
        {
            _employeesList = new List<Employee>()
            {
                new Employee()
                {
                    Id = 0,
                    Name = "Batilek",
                    Email = "baktilekashyrov8@gmail.com",
                    PhotoPath = "avatar.png",
                    Department = Department.IT
                },
                new Employee()
                {
                    Id = 1,
                    Name = "Samat",
                    Email = "samatmuratov@gmail.com",
                    PhotoPath = "avatar3.png",
                    Department = Department.HR
                },
                new Employee()
                {
                    Id = 2,
                    Name = "Klara",
                    Email = "klarasaryeva@gmail.com",
                    PhotoPath = "avatar2.png",
                    Department = Department.IT
                },
                new Employee()
                {
                    Id = 3,
                    Name = "Suban",
                    Email = "subanlord@gmail.com",
                    PhotoPath = "avatar4.png",
                    Department = Department.Mone
                },
                new Employee()
                {
                    Id = 4,
                    Name = "Azim",
                    Email = "azimturdumambetov@gmail.com",
                    PhotoPath = "avatar5.png",
                    Department = Department.Payroll
                },
                new Employee()
                {
                    Id = 5,
                    Name = "Diana",
                    Email = "dianamelisbekova@gmail.com",
                    Department = Department.Payroll
                },

            };
        } 
        //Метод для возвращение только одного запися по id 
        public Employee GetEmployee(int id)
        {
            return _employeesList.FirstOrDefault(x => x.Id == id);
        } 
        public IEnumerable<Employee> GetAllEmployess()
        {
            return _employeesList;
        }
    }
}
