﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RazorPagesProject.Modelss
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="The name field cannot be null! Please, write the name")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$",ErrorMessage ="Please, enter a Valid Email (format: exampl@exem.com")]
        public string Email { get; set; }
        public string PhotoPath { get; set; }
        public Department? Departmentt { get; set; }
    }
}
