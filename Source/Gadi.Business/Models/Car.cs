using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadi.Business.Models
{
    public class Car
    {
        public int CarId { get; set; }
        public string Name { get; set; }
        public string CityMileage { get; set; }
        public string ARAIMileage { get; set; }
        public string FuelType { get; set; }
        public int Engine { get; set; }
        public string MaxPower { get; set; }
        public string MaxTorque { get; set; }
        public int? Seating { get; set; }
        public string EngineDescription { get; set; }
        public string TransmissionType { get; set; }
        public string CargoVolume { get; set; }
    }
}
