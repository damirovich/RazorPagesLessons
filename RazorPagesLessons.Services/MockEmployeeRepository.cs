using RazorPagesLessons.Models;
using System;
using System.Collections.Generic;
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
                    PhotoPath = "zuko.jpg",
                    Department = Department.IT
                },
                new Employee()
                {
                    Id = 1,
                    Name = "Samat",
                    Email = "samatmuratov@gmail.com",
                    PhotoPath = "sokko.jpg",
                    Department = Department.HR
                },
                new Employee()
                {
                    Id = 2,
                    Name = "Klara",
                    Email = "klarasaryeva@gmail.com",
                    PhotoPath = "azulla.jpg",
                    Department = Department.IT
                },
                new Employee()
                {
                    Id = 3,
                    Name = "Suban",
                    Email = "subanlord@gmail.com",
                    PhotoPath = "maska.jpg",
                    Department = Department.Mone
                },
                new Employee()
                {
                    Id = 4,
                    Name = "Azim",
                    Email = "azimturdumambetov@gmail.com",
                    PhotoPath = "aang.jpg",
                    Department = Department.Payroll
                },
                new Employee()
                {
                    Id = 5,
                    Name = "Diana",
                    Email = "dianamelisbekova@gmail.com",
                    PhotoPath = "katara.jpg",
                    Department = Department.Payroll
                },
                new Employee()
                {
                    Id = 0,
                    Name = "Nursultan",
                    Email = "nursultanmamytbekov@gmail.com",
                    Department = Department.HR
                },

            };
        }
        public IEnumerable<Employee> GetAllEmployess()
        {
            return _employeesList;
        }
    }
}
