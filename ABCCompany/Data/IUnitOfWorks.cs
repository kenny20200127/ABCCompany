using ABCCompany.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABCCompany.Data
{
    public interface IUnitOfWorks
    {
        ICustomerRepo customer { get; }

        Task CompleteAsync();
    }
}
