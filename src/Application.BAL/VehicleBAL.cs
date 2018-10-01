using Application.BAL.Interface;
using Application.DLL;
using Application.DLL.Interface;
using Application.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.BAL
{
    public class VehicleBAL: IVehicleBAL
    {
        private IVehicleRepository _vehicleRepository;
        public VehicleBAL(IVehicleRepository vehicleRepository)
        {
            this._vehicleRepository = vehicleRepository;
        }
        public List<Vehicle> GetVehicleByCustomerAndSatus(int? Customer_Id, bool? Status)
        {
            try
            {
                List<Vehicle> _ListOfVehicle = _vehicleRepository.GetVehicleByCustomerAndSatus(Customer_Id, Status);
                return _ListOfVehicle;
            }
            catch (Exception ex)
            {
                return new List<Vehicle>();
            }
        }
        public bool VehicleStatusUpdate(int Vehicle_Id, bool Status)
        {
            try
            {
                return _vehicleRepository.Update(Vehicle_Id, Status);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public Vehicle GetVehicle(int p_Vehicle_id)
        {
            try
            {
                return _vehicleRepository.GetVehicle(p_Vehicle_id);
            }
            catch (Exception ex)
            {
                return new Vehicle();
            }
        }
    }
}
