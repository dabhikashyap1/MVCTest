using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestApp.Models
{
    public class EmployeeSalary
    { 
        [Key]
        public int Id { get; set; }
        //[Required(ErrorMessage = "Please select employee name.")]
        public int EmpId { get; set; }
        //[Required]
        //[RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Invalid price")]
        [Display(Name = "Salary:")]
        [Required(ErrorMessage = "Salary is required.")]
        [RegularExpression(@"^[0-9]+(\.[0-9]{1,2})$", ErrorMessage = "Valid Decimal number with maximum 2 decimal places.")]
        public string Salary { get; set; }

    }
}