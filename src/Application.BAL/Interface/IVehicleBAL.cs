using Application.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.BAL.Interface
{
    public interface IVehicleBAL
    {
        List<Vehicle> GetVehicleByCustomerAndSatus(int? Customer_Id, bool? Status);
        bool VehicleStatusUpdate(int Vehicle_Id,bool Status);
        Vehicle GetVehicle(int p_Vehicle_id);
    }
}
