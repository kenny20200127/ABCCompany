using ABCCompany.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABCCompany.Data
{
    public class UnitOfWorks : IUnitOfWorks
    {
        private readonly ApplicationDBContext _dbContext;

        public UnitOfWorks(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
             customer = new CustomerRepo(_dbContext);
         }

    public ICustomerRepo customer { get; }
    public async Task CompleteAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
