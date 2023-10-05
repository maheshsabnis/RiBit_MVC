using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_WebApp.Models
{
    public class Customer
    {
        [Key]
        public int CustId { get; set; }
        [Required]
        [StringLength(400)]
        public string CustName { get; set; }
        [Required]
        [StringLength(1000)]
        public string Address { get; set; }
        // One-Customer-Has-Many-Orders
        public ICollection<Order> Orders { get; set; }
    }
}