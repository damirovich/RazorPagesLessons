using System;
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
        [BindProperty]
        public Employee Employee { get; set; }
        //�������� ��� ��������� 
        [BindProperty]
        public IFormFile Photo { get; set; }
        [BindProperty]
        public bool Notify { get; set; }
        public string Message { get; set; }
        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
                Employee = _employeeRepository.GetEmployee(id.Value);
            else
                Employee = new Employee();

            if (Employee == null)
                return RedirectToPage("/NotFound");

            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Photo != null)
                {
                    //�������� ������ ���������� c �������
                    if (Employee.PhotoPath != null)
                    {
                        string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", Employee.PhotoPath);
                        
                        if(Employee.PhotoPath!="noimage.png")
                            System.IO.File.Delete(filePath);

                    }

                    Employee.PhotoPath = ProcessUploadFile();
                }
                //�������� �� 
                if (Employee.Id > 0)
                {
                    Employee = _employeeRepository.Update(Employee);
                    TempData["SeccessMessage"] = $"Update {Employee.Name} successfull";
                }
                else
                {
                    Employee = _employeeRepository.Add(Employee);
                    TempData["SeccessMessage"] = $"Adding {Employee.Name} successfull";
                }
                return RedirectToPage("Employess");
            }    
                return Page();
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
