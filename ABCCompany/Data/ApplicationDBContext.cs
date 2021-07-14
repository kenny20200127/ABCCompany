using ABCCompany.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ABCCompany.Data
{
    public class ApplicationDBContext : IdentityDbContext<User>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }
        public DbSet<CustomerTb> CustomerTbs { get; set;}
        public DbSet<Master_Product> Master_Product { get; set; }
        public DbSet<Master_Country> Master_Country { get; set; }
        public DbSet<Master_Region> Master_Region { get; set; }
        public DbSet<Master_City> Master_City { get; set; }
    }
}
