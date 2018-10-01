using Application.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DLL.Interface
{
   
    public interface ICustomerRepository
    {
        List<Customer> GetList();
    }
}
