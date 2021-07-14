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
        Task CreateAsync(CustomerTb customer);
        CustomerTb GetByCustomer(string customer);
        Task UpdateAsync(CustomerTb customer);
        Task UpdateAsync(string customer);
        Task<IEnumerable<CustomerTb>> GetAll();
        List<CustomerModel> GetCustomerByFilter(CustomerFilter customerFilter);
        Task DeleteAsync(string customer);
    }
}
