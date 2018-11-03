using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gadi.Data.Entities;

namespace Gadi.Business.Models
{
    public class DrivingSchoolCar
    {
        public int DrivingSchoolCarId { get; set; }
        public int DrivingSchoolId { get; set; }
        public string Name { get; set; }
        public int CarTypeId { get; set; }
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
        public string WheelType { get; set; }
        public virtual DrivingSchool DrivingSchool { get; set; }
        public virtual CarType CarType { get; set; }
        public virtual ICollection<DrivingSchoolCarFee> DrivingSchoolCarFees { get; set; }
        public virtual ICollection<DriverCar> DriverCars { get; set; }
    }
}
