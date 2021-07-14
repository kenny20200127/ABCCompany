using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ABCCompany.Entities
{
    public class Master_Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
    }
}
