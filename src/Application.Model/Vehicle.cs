using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Model
{
    public class Vehicle
    {
        public int Vehicle_Id { get; set; }
        public string VIN { get; set; }
        public string Reg_No { get; set; }
        public int Customer_Id { get; set; }
        public bool Status { get; set; }
        public string Name { get; set; }
        public DateTime Last_Updated { get; set; }
    }
}
