using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABCCompany.Data;
using ABCCompany.Entities;
using ABCCompany.Models;
using ABCCompany.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ABCCompany.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDBContext _context;
        private readonly ICustomerService _customerservice;
        public CustomerController(ApplicationDBContext context, ICustomerService customerservice)
        {
            this._context = context;
            _customerservice = customerservice;
        }
        // GET: CustomerController
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult GetGustomerByProduct(int customerid,DateTime DateOfSales)
        {

            return View();
        }

        // GET: CustomerController/Details/5
        public  ActionResult GetCustomers(CustomerFilter customerFilter, int? pageNumber)
        {

            if (pageNumber == null)
            {
                pageNumber = 1;
            }
            ViewBag.ProductList = GetProduct();

            ViewBag.CountryList = GetCountry();
            var customerlist = _customerservice.GetCustomerByFilter(customerFilter).AsQueryable();
            var m = PaginatedList<CustomerModel>.Create(customerlist, (int)pageNumber, 10);
            return View(m);
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            ViewBag.ProductList = GetProduct();

            ViewBag.CountryList = GetCountry();
            return View();
        }
        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CustomerTb customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   await _customerservice.CreateAsync(customer);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public List<SelectListItem> GetProduct()
        {
            var productList = (from rk in _context.Master_Product
                             select new SelectListItem()
                             {
                                 Text = rk.ProductName,
                                 Value = rk.ProductId.ToString()
                             }).ToList();

            productList.Insert(0, new SelectListItem()
            {
                Text = "----Select----",
                Value = string.Empty
            });
            return productList;
        }
        public List<SelectListItem> GetCountry()
        {
            var countryList = (from rk in _context.Master_Country
                               select new SelectListItem()
                               {
                                   Text = rk.CountryName,
                                   Value = rk.CountryCode.ToString()
                               }).ToList();

            countryList.Insert(0, new SelectListItem()
            {
                Text = "----Select----",
                Value = string.Empty
            });
            return countryList;
        }
        public JsonResult GetRegion(string CountryCode)
        {
            List<Master_Region> region = new List<Master_Region>();
            region = (from rg in _context.Master_Region
                      where rg.CountryCode == CountryCode
                      select rg).ToList();
            region.Insert(0, new Master_Region { RegionCode = "", RegionName = "Select region" });
            return Json(new SelectList(region, "RegionCode", "RegionName"));

        }
        public JsonResult GetCity(string RegionId)
        {
            List<Master_City> city = new List<Master_City>();
            city = (from cty in _context.Master_City
                    where cty.RegionCode == RegionId
                    select cty).ToList();
            city.Insert(0, new Master_City { CityCode = 0, CityName = "select City" });
            return Json(new SelectList(city, "CityCode", "CityName"));
        }
       

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
