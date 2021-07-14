using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ABCCompany.Entities
{
    public class Master_Region
    {
      
        [StringLength(3), Key]
        public string RegionCode { get; set; }
        [StringLength(3)]
        public string CountryCode { get; set; }
        [StringLength(255)]
        public string RegionName { get; set; }
    }
}
