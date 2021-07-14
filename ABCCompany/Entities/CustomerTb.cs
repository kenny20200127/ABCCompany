using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ABCCompany.Entities
{
    public class CustomerTb
    {
        [Key]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public DateTime DateOfSales { get; set; }
        public string Product { get; set; }
        public int Quntity { get; set; }
        public DateTime datecreated { get; set; }
    }
}
