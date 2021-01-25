using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesProject.Servicess;
using RazorPagesProject.Modelss;
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
        //�������� ��� ��������� 
        [BindProperty]
        public IFormFile Photo { get; set; }
        [BindProperty]
        public bool Notify { get; set; }
        public string Message { get; set; }
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
                //�������� ������ ���������� c �������
                if (employee.PhotoPath != null)
                {
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", employee.PhotoPath);
                    System.IO.File.Delete(filePath);
                }

                employee.PhotoPath = ProcessUploadFile();
            }
            Employee = _employeeRepository.Update(employee);
            TempData["SeccessMessage"] = $"Update {Employee.Name} successfull";
            return RedirectToPage("Employess");
        }
        //����� ��� ������ ���������
        public void OnPostUpdateNotificationPreferences(int id)
        {
            if (Notify)
                Message = "Thank you for turning on notifications";
            else
                Message = "You have turnet of email notifications";

            Employee = _employeeRepository.GetEmployee(id);
        }
        //����� ��� ���������� ���������� � ���������� ����������� ����� �� ���� � �������� �� null
        private string ProcessUploadFile()
        {
            string uniqueFileName = null;

            if (Photo != null)
            {
                //���� wwwroot images ��� ���������� ����������
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath,"images");
                //��������� ��� ����� �������������� � �������� ������ ������
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Photo.FileName;

                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                //  ���������� ���������� �� ������
                using (var fileStreem = new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(fileStreem);
                }
            }
            return uniqueFileName;
        }
    }
}
