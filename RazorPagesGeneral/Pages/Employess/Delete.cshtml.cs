using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesProject.Modelss;
using RazorPagesProject.Servicess;

namespace RazorPagesGeneral.Pages.Employess
{
    public class DeleteModel : PageModel
    {
        private readonly IEmployeeRepository _employeeRepository;
        public DeleteModel(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;   
        }
        [BindProperty]
        public Employee Employee { get; set; }
        public IActionResult OnGet(int id)
        {
            Employee = _employeeRepository.GetEmployee(id);

            if (Employee == null)
                return RedirectToPage("/NotFound");

            return Page();
        }
        public IActionResult OnPost()
        {
            Employee deleteEmployee = _employeeRepository.Delete(Employee.Id);
            if (deleteEmployee == null)
                return RedirectToPage("/NotFound");

            return RedirectToPage("Employess");
        }
    }
}
