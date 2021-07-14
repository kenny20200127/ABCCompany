using ABCCompany.Entities;
using ABCCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABCCompany.Repository
{
    public interface ICustomerRepo: IGenericRepo<CustomerTb>
    {
       List<CustomerModel> GetCustomerByFilter(CustomerFilter customerFilter);
        List<CustomerModel> GetCustomer();
    }
}
