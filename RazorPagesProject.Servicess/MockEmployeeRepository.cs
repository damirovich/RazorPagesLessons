using RazorPagesProject.Modelss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RazorPagesProject.Servicess
{
    public class MockEmployeeRepository: IEmployeeRepository
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
                    Departmentt = Department.IT
                },
                new Employee()
                {
                    Id = 1,
                    Name = "Samat",
                    Email = "samatmuratov@gmail.com",
                    PhotoPath = "299d8574-0246-41d4-94ea-67453dcdd6b0_avatar3.png",
                    Departmentt = Department.HR
                },
                new Employee()
                {
                    Id = 2,
                    Name = "Klara",
                    Email = "klarasaryeva@gmail.com",
                    PhotoPath = "avatar2.png",
                    Departmentt = Department.IT
                },
                new Employee()
                {
                    Id = 3,
                    Name = "Suban",
                    Email = "subanlord@gmail.com",
                    PhotoPath = "avatar4.png",
                    Departmentt = Department.Mone
                },
                new Employee()
                {
                    Id = 4,
                    Name = "Azim",
                    Email = "azimturdumambetov@gmail.com",
                    PhotoPath = "avatar5.png",
                    Departmentt = Department.Payroll
                },
                new Employee()
                {
                    Id = 5,
                    Name = "Diana",
                    Email = "dianamelisbekova@gmail.com",
                    Departmentt = Department.Payroll
                },

            };
        }
        //Метод для добавления Employee
        public Employee Add(Employee newEmployee)
        {
            newEmployee.Id = _employeesList.Max(x => x.Id) + 1;
            _employeesList.Add(newEmployee);
            return newEmployee;
        }
        //Метод для возвращение только одного запися по id 
        public Employee GetEmployee(int id)
        {
            return _employeesList.FirstOrDefault(x => x.Id == id);
        }
        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeesList;
        }
        //Метод для обновление данных   
        public Employee Update(Employee updateEmployee)
        {
            Employee employee = _employeesList.FirstOrDefault(x => x.Id == updateEmployee.Id);
            if (employee != null)
            {
                employee.Name = updateEmployee.Name;
                employee.Email = updateEmployee.Email;
                employee.Departmentt = updateEmployee.Departmentt;
                employee.PhotoPath = updateEmployee.PhotoPath;
            }
            return employee;
        }
    }
}

