using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ABCCompany.Entities
{
    public class Master_Country
    {
        [Key]
        [StringLength(3)]
        public string CountryCode { get; set; }
        [StringLength(255)]
        public string CountryName { get; set; }
    }
}
