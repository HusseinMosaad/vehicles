using Application.BAL.Interface;
using Application.DLL;
using Application.DLL.Interface;
using Application.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.BAL
{
    public class CustomerBAL: ICustomerBAL
    {
        private ICustomerRepository _customerRepository;
        public CustomerBAL(ICustomerRepository customerRepository)
        {
            this._customerRepository = customerRepository;
        }

        public List<Customer> GetList()
        {
            try
            {
                List<Customer> _ListOfCustomer = _customerRepository.GetList();
                return _ListOfCustomer;
            }
            catch (Exception ex)
            {
                return new List<Customer>();
            }
        }
    }
}
