using Application.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DLL.Interface
{
 
    public interface IVehicleRepository
    {
        List<Vehicle> GetVehicleByCustomerAndSatus(int? Customer_Id, bool? Status);
        bool Update(int Vehicle_Id, bool Status);
        Vehicle GetVehicle(int p_Vehicle_id);

    }
}
