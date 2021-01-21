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
    public class EmployessModel : PageModel
    {
        //���� ��� ������� ���� ������
        private readonly IEmployeeRepository _db;
        //����������� ������
        public EmployessModel(IEmployeeRepository db)
        {
            _db = db;//�������������
        }
        //�������� ������ ��� ������������� � �������������
        public IEnumerable<Employee> Employess { get; set; }
        public void OnGet()
        {
            //���������� ������
            Employess = _db.GetAllEmployess();
        }
    }
}
