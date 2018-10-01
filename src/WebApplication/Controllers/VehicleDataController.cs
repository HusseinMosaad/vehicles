using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.BAL;
using Application.BAL.Interface;
using Application.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    public class VehicleDataController : Controller
    {
        private IVehicleBAL _vehicleBAL;
        IHubContext<VLogHub> _hub;
        public VehicleDataController(IHubContext<VLogHub> hub,IVehicleBAL vehicleBAL)
        {
            this._vehicleBAL = vehicleBAL;
            _hub = hub;
        }

        [HttpGet("[action]")]
        public IEnumerable<Vehicle> Vehicles(int? Customer_Id, bool? Status)
        {
            List<Vehicle> _ListOfVehicle = _vehicleBAL.GetVehicleByCustomerAndSatus(Customer_Id, Status);
            return _ListOfVehicle;
        }
        [HttpGet("[action]")]
        public bool VehicleStatusUpdate(int Vehicle_Id, bool Status)
        {
            
            bool result = _vehicleBAL.VehicleStatusUpdate(Vehicle_Id, Status);
            if (_hub != null)
            {
                _hub.Clients.All.SendAsync("ReceiveMessage", "", Vehicle_Id + "," + Status);
            }
            return result;

        }
    
        [HttpGet("[action]")]
        public Vehicle VehiclesById(int Vehicle_Id)
        { 
            Vehicle _Vehicle = _vehicleBAL.GetVehicle(Vehicle_Id);
            return _Vehicle;
        }

}
}
