using ABCCompany.Data;
using ABCCompany.Entities;
using ABCCompany.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABCCompany.Repository
{
    public class CustomerRepo : GenericRepo<CustomerTb>, ICustomerRepo
    {
        private readonly ApplicationDBContext context;
        public CustomerRepo(ApplicationDBContext context) : base(context)
        {
            this.context = context;
        }

        public List<CustomerModel> GetCustomerByFilter(CustomerFilter customerFilter)
        {
            var result= (from customer in context.CustomerTbs
                    join product in context.Master_Product on customer.Product equals product.ProductId.ToString()
                    join country in context.Master_Country on customer.Country equals country.CountryCode
                    join state in context.Master_Region on customer.State equals state.RegionCode
                    join city in context.Master_City on customer.City equals city.CityCode.ToString()
                    where /*(customer.DateOfSales.Date==customerFilter.DateOfSales.Date|| customerFilter.DateOfSales==null)&&*/
                    (customer.Country==customerFilter.Country && customerFilter.State == null && customerFilter.City == "0")||
                    (customer.State==customerFilter.State && customerFilter.Country == null && customerFilter.City == "0") ||
                    (customer.City == customerFilter.City && customerFilter.State == null && customerFilter.Country == null) ||
                    (customer.State == customerFilter.State && customer.Country==customerFilter.Country && customerFilter.City == "0") ||
                    (customer.City == customerFilter.City && customerFilter.State == customerFilter.State && customer.Country == customerFilter.Country)||
                    ((customer.City == customerFilter.City||customerFilter.City=="0") &&(customer.State == customerFilter.State|| customerFilter.State == null) && (customer.Country == customerFilter.Country||customerFilter.Country == null))

                         select new CustomerModel
                    {
                        CustomerName = customer.CustomerName,
                        CountryName=country.CountryName,
                        StateName=state.RegionName,
                        CityName=city.CityName,
                        DateOfSales=customer.DateOfSales,
                        ProductName=product.ProductName,
                        ProductPrice=Convert.ToDouble(product.Price),
                        Quntity=customer.Quntity


                    }).ToList();
            return result;
        }
        public List<CustomerModel> GetCustomer()
        {
            var result = (from customer in context.CustomerTbs
                          join product in context.Master_Product on customer.Product equals product.ProductId.ToString()
                          join country in context.Master_Country on customer.Country equals country.CountryCode
                          join state in context.Master_Region on customer.State equals state.RegionCode
                          join city in context.Master_City on customer.City equals city.CityCode.ToString()
                          where customer.DateOfSales.Date==DateTime.Now.Date
                          select new CustomerModel
                          {
                              CustomerName = customer.CustomerName,
                              CountryName = country.CountryName,
                              StateName = state.RegionName,
                              CityName = city.CityName,
                              DateOfSales = customer.DateOfSales,
                              ProductName = product.ProductName,
                              ProductPrice = Convert.ToDouble(product.Price),
                              Quntity = customer.Quntity


                          }).ToList();
            return result;
        }
    }
}
