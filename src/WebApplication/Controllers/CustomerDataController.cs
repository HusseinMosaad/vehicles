using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.BAL;
using Application.BAL.Interface;
using Application.Model;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    public class CustomerDataController : Controller
    {
        private ICustomerBAL _customerBAL;
        public CustomerDataController(ICustomerBAL customerBAL)
        {
            this._customerBAL = customerBAL;
        }
        [HttpGet("[action]")]
        public IEnumerable<Customer> Customers()
        {
            List<Customer> _ListOfCustomer = _customerBAL.GetList();
            return _ListOfCustomer;
        }
    }
}
