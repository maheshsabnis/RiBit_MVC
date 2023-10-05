using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_EF_Migrations.Models
{
    internal class Customer
    {
        [Key]
        public int CustId { get; set; }
        [Required]
        [StringLength(100)]
        public string CustName { get; set; }
        public ICollection<Order> Orders { get; set; }
    }

    internal class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        [StringLength(100)]
        public string OrderName { get; set; }
        public int Quatity { get; set; }
        public ICollection<Customer> Customers { get; set; }
    }
}
