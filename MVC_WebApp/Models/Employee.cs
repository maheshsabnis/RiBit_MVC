using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_WebApp.Models
{
    public class Employee : EntityBase
    {
        [Key]
        public int EmpNo { get; set; }
        [Required(ErrorMessage = "EmpName is rquired")]
        [StringLength(400)]
        public string EmpName { get; set; }
        [Required(ErrorMessage = "Designation is rquired")]
        [StringLength(40)]
        public string Designation { get; set; }
        [Required(ErrorMessage = "Salary is required")]
        public int Salary { get; set; }
        // Foreign Key
        [Required(ErrorMessage ="DeptNo is required")]
        public int DeptNo { get; set; }
        // Referential Integrity
        public Department Department { get; set; }
    }
}