using ABCCompany.Entities;
using ABCCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABCCompany.Services
{
    public interface ICustomerService
    {

        List<CustomerModel> GetCustomerByFilter(CustomerFilter customerFilter);
        List<CustomerModel> GetCustomer();
 
    }
}
