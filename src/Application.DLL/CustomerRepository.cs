using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Application.Model;
using Application.DLL.Interface;

namespace Application.DLL
{
    public class CustomerRepository : BaseRepository, ICustomerRepository
    {
        string Qry = string.Empty;
        /// <summary>
        ///  Customer List 
        /// </summary>
        /// <returns></returns>
        public List<Customer> GetList()
        {
            try
            {
                connection();
                Qry = @"SELECT [Customer_Id],[Name],[Address] FROM [dbo].[Customer]";
                return Conn.Query<Customer>(Qry).ToList();
            }
            catch (Exception ex)
            {
                return new List<Customer>();
            }
        }
       
    }
}
     
