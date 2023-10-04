using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_WebApp.Models
{
    public class Department : EntityBase
    {
        [Key]
        public int DeptNo { get; set; }
        [Required(ErrorMessage ="DeptName is required")]
        [StringLength(200)]
        public string DeptName { get; set; }
        [Required(ErrorMessage = "Location is required")]
        [StringLength(260)]
        public string Location { get; set; }
        [Required(ErrorMessage = "Capacity is require")]
        public int Capacity { get; set; }

        // One-to-many relationship with Employee
        public ICollection<Employee> Employees { get; set; }
    }
}