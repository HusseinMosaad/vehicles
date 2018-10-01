using Application.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.BAL.Interface
{
    public interface ICustomerBAL
    {
        List<Customer> GetList();
    }

}
