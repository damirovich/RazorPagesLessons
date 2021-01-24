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
    public class EditModel : PageModel
    {
        public readonly IEmployeeRepository _employeeRepository;
        public EditModel(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public Employee Employee { get; set; }
        public IActionResult OnGet(int id)
        {
            Employee = _employeeRepository.GetEmployee(id);
            if (Employee == null)
                return RedirectToPage("/NotFound");

            return Page();
        }
    }
}
