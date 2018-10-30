using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadi.Business.Models
{
    public class DriverCar
    {
        public int DriverCarId { get; set; }
        public int DriverId { get; set; }
        public int DrivingSchoolCarId { get; set; }
        public virtual Driver Driver { get; set; }
        public virtual DrivingSchoolCar DrivingSchoolCar { get; set; }
    }
}
