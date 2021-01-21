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
        //Поле для доступа базы данных
        private readonly IEmployeeRepository _db;
        //Конструктор класса
        public EmployessModel(IEmployeeRepository db)
        {
            _db = db;//Инициализация
        }
        //Свойства модели для использование в представлении
        public IEnumerable<Employee> Employess { get; set; }
        public void OnGet()
        {
            //Заполнение модели
            Employess = _db.GetAllEmployess();
        }
    }
}
