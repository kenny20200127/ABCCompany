using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ABCCompany.Entities
{
    public class Master_City
    {
        [Key]
        public int CityCode { get; set; }
        [StringLength(3)]
        public string RegionCode { get; set; }
        [StringLength(255)]
        public string CityName { get; set; }
    }
}
