using Microsoft.AspNetCore.Mvc;
using RazorPagesProject.Modelss;
using RazorPagesProject.Servicess;

namespace RazorPagesGeneral.ViewComponents
{
    public class HeadCountViewComponent : ViewComponent
    {
        private readonly IEmployeeRepository _employeeRepository;

        public HeadCountViewComponent(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public IViewComponentResult Invoke(Department? department=null)
        {
            var result = _employeeRepository.EmployeeCountByDepartment(department);
            return View(result);
        }
    }
}
