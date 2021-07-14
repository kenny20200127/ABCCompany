using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABCCompany.Models
{
    public class CustomerModel
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CountryName { get; set; }
        public string StateName { get; set; }
        public string CityName { get; set; }
        public DateTime DateOfSales { get; set; }
        public string ProductName { get; set; }
        public Double ProductPrice { get; set; }
        public int Quntity { get; set; }
    }
    public class CustomerFilter
    {
       
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public DateTime DateOfSales
        {
            get
            {
                return this.dateOfSales.HasValue
                   ? this.dateOfSales.Value
                   : DateTime.Now;
            }

            set { this.dateOfSales = value; }
        }

        private DateTime? dateOfSales = null;
      
        
    }
}
