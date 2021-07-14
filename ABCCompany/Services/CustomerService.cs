using ABCCompany.Data;
using ABCCompany.Entities;
using ABCCompany.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABCCompany.Services
{
    public class CustomerService:ICustomerService
    {

    private readonly ApplicationDBContext _dbcontext;
    private readonly IUnitOfWorks _uow;

    public CustomerService(ApplicationDBContext dbcontext, IUnitOfWorks uow)
    {
        _dbcontext = dbcontext;
        _uow = uow;
    }
    
   

        public List<CustomerModel> GetCustomerByFilter(CustomerFilter customerFilter)
        {
           return _uow.customer.GetCustomerByFilter(customerFilter);
        }
        public List<CustomerModel> GetCustomer()
        {
            return _uow.customer.GetCustomer();
        }
    }
}
