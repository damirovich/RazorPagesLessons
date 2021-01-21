using RazorPagesLessons.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RazorPagesLessons.Services
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> employeesList;

        public MockEmployeeRepository()
        {
            employeesList = new List<Employee>();
            {
                new Employee()
                {
                    Id = 0,
                    Name = "Batilek",
                    Email = "baktilekashyrov8@gmail.com",
                    PhotoPath = "zuko.jpg",
                    Department = Department.IT
                };
                new Employee()
                {
                    Id = 0,
                    Name = "Samat",
                    Email = "samatmuratov@gmail.com",
                    PhotoPath = "sokko.jpg",
                    Department = Department.HR
                };
                new Employee()
                {
                    Id = 0,
                    Name = "Klara",
                    Email = "klarasaryeva@gmail.com",
                    PhotoPath = "azulla.jpg",
                    Department = Department.IT
                };
                new Employee()
                {
                    Id = 0,
                    Name = "Suban",
                    Email = "subanlord@gmail.com",
                    PhotoPath = "maska.jpg",
                    Department = Department.Mone
                };
                new Employee()
                {
                    Id = 0,
                    Name = "Azim",
                    Email = "azimturdumambetov@gmail.com",
                    PhotoPath = "aang.jpg",
                    Department = Department.Payroll
                };
                new Employee()
                {
                    Id = 0,
                    Name = "Diana",
                    Email = "dianamelisbekova@gmail.com",
                    PhotoPath = "katara.jpg",
                    Department = Department.Payroll
                };
                new Employee()
                {
                    Id = 0,
                    Name = "Nursultan",
                    Email = "nursultanmamytbekov@gmail.com",
                    Department = Department.HR
                };

            }
        }
        public IEnumerable<Employee> GetAllEmployess()
        {
            return employeesList;
        }
    }
}
