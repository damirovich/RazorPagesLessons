using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesLessons.Services;
using RazorPagesLessons.Models;
namespace RazorPagesGeneral.Pages.Employess
{
    public class DetailsModel : PageModel
    {
        private readonly IEmployeeRepository _employeeRepository;
        public DetailsModel(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public Employee Employee { get; private set; }
        //Метод для получение данных 
        public IActionResult OnGet(int id)
        {
            Employee = _employeeRepository.GetEmployee(id);
            //Обработка исключение 
            if (Employee == null) 
                return RedirectToPage("/NotFound");
            return Page();
        }
    }
}
