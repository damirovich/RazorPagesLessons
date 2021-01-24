using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesProject.Services;
using RazorPagesProject.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace RazorPagesGeneral.Pages.Employess
{
    public class EditModel : PageModel
    {
        public readonly IEmployeeRepository _employeeRepository;
        public readonly IWebHostEnvironment _webHostEnvironment;
        public EditModel(IEmployeeRepository employeeRepository,IWebHostEnvironment webHostEnvironment)
        {
            _employeeRepository = employeeRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public Employee Employee { get; set; }
        //Свойство для оброботки 
        [BindProperty]
        public IFormFile Photo { get; set; }
        public IActionResult OnGet(int id)
        {
            Employee = _employeeRepository.GetEmployee(id);
            if (Employee == null)
                return RedirectToPage("/NotFound");

            return Page();
        }

        public IActionResult OnPost(Employee employee)
        {
            if (Photo != null)
            {
                //Удаление старой фотографии c сервера
                if (employee.PhotoPath != null)
                {
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", employee.PhotoPath);
                    System.IO.File.Delete(filePath);
                }

                employee.PhotoPath = ProcessUploadFile();
            }
            Employee = _employeeRepository.Update(employee);
            return RedirectToPage("Employess");
        }
        //Метод для сохранение фотографии и добавление уникального имени и проверка на null
        private string ProcessUploadFile()
        {
            string uniqueFileName = null;

            if (Photo != null)
            {
                //Путь wwwroot images для сохранение фотографии
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath,"images");
                //Уникально имя будет генерироваться и добавлят нижный пробел
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Photo.FileName;

                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                //  Сохранение фотографии на сервер
                using (var fileStreem = new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(fileStreem);
                }
            }
            return uniqueFileName;
        }
    }
}
