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
    public async Task CreateAsync(CustomerTb customer)
    {
        await _dbcontext.CustomerTbs.AddAsync(customer);
        await _uow.CompleteAsync();
    }

    public async Task<IEnumerable<CustomerTb>> GetAll()
    {
        return await _dbcontext.CustomerTbs.ToListAsync();
    }

    public CustomerTb GetByCustomer(string customer)
    {
        return _dbcontext.CustomerTbs.Where(x => x.CustomerName == customer).FirstOrDefault();
    }

    public async Task UpdateAsync(CustomerTb customer)
    {
        _dbcontext.Update(customer);
        await _uow.CompleteAsync();
    }

    public async Task UpdateAsync(string customer)
    {
        var customer1 = GetByCustomer(customer);
        _dbcontext.Update(customer1);
        await _uow.CompleteAsync();
    }
    public async Task DeleteAsync(string customer)
    {
        var customer1 = GetByCustomer(customer);
        _dbcontext.Remove(customer1);
        await _uow.CompleteAsync();
    }

        public List<CustomerModel> GetCustomerByFilter(CustomerFilter customerFilter)
        {
           return _uow.customer.GetCustomerByFilter(customerFilter);
        }
    }
}
