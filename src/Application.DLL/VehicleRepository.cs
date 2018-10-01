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
    public class VehicleRepository : BaseRepository, IVehicleRepository
    {
        string Qry = string.Empty;
        /// <summary>
        ///  Search Vehicle
        ///  /// </summary>
        /// <returns></returns>
        public List<Vehicle> GetVehicleByCustomerAndSatus(int? Customer_Id, bool? Status)
        {
            try
            {
                connection();
                Qry = @"SELECT [Vehicle_Id],[VIN],[Reg_No],[Status],[Last_Updated],[Name] FROM [dbo].[Vehicle]
                        inner join [dbo].[Customer] on [Customer].[Customer_Id]=[Vehicle].[Customer_Id] where 1=1";
                var x_DynamicParameters = new DynamicParameters();
                if (Customer_Id != null)
                {
                    Qry = Qry + " and [Vehicle].[Customer_Id]=@Customer_Id";
                    x_DynamicParameters.Add("Customer_Id", Customer_Id);
                }

                if (Status != null)
                {
                    Qry = Qry + " and [Vehicle].[Status]=@Status";
                    x_DynamicParameters.Add("Status", Status);
                }



                return Conn.Query<Vehicle>(Qry, x_DynamicParameters).ToList();
            }
            catch (Exception ex)
            {
                return new List<Vehicle>();
            }
        }

        /// <summary>
        ///  Update Vehicle Details
        /// </summary>
        /// <param name="Vehicle"></param>
        /// <returns></returns>
        public bool Update(int Vehicle_Id, bool Status)
        {
            try
            {
                connection();

                var x_DynamicParameters = new DynamicParameters();
                x_DynamicParameters.Add("Status", Status);
                x_DynamicParameters.Add("Last_Updated", DateTime.Now);
                x_DynamicParameters.Add("Vehicle_Id", Vehicle_Id);
                Qry = @"UPDATE [dbo].[Vehicle] SET [Status] = @Status, [Last_Updated] = @Last_Updated WHERE Vehicle_Id=@Vehicle_Id";
                Conn.ExecuteScalar<int>(Qry, x_DynamicParameters);
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_Vehicle_id"></param>
        /// <returns></returns>
        public Vehicle GetVehicle(int p_Vehicle_id)
        {
            try
            {
                connection();
                Qry = @"SELECT [Vehicle_Id],[VIN],[Reg_No],[Customer_Id],[Status],[Last_Updated] FROM [dbo].[Vehicle] where Vehicle_Id=@Vehicle_Id";
                var x_DynamicParameters = new DynamicParameters();
                x_DynamicParameters.Add("Vehicle_Id", p_Vehicle_id);

                return Conn.Query<Vehicle>(Qry, x_DynamicParameters).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return new Vehicle();
            }
        }


    }
}