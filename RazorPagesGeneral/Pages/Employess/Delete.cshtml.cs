using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesProject.Modelss;
using RazorPagesProject.Servicess;

namespace RazorPagesGeneral.Pages.Employess
{
    public class DeleteModel : PageModel
    {
        private readonly IEmployeeRepository _employeeRepository;
        public readonly IWebHostEnvironment _webHostEnvironment;
        public DeleteModel(IEmployeeRepository employeeRepository, IWebHostEnvironment webHostEnvironment)
        {
            _employeeRepository = employeeRepository;
            _webHostEnvironment = webHostEnvironment;
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

            //Удаление старой фотографии c сервера
            if (deleteEmployee.PhotoPath != null)
            {
                string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", deleteEmployee.PhotoPath);

                if (deleteEmployee.PhotoPath != "noimage.png")
                    System.IO.File.Delete(filePath);

            }
            if (deleteEmployee == null)
                return RedirectToPage("/NotFound");

            return RedirectToPage("Employess");
        }
    }
}
