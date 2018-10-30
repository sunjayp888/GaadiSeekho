using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadi.Business.Models
{
    public class DrivingSchoolCarGrid
    {
        public int DrivingSchoolId { get; set; }
        public string DrivingSchoolName { get; set; }
        public int DrivingSchoolCarId { get; set; }
        public string DrivingSchoolCarName { get; set; }
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
        public int DrivingSchoolCarFeeId { get; set; }
        public decimal WithLicenseFee { get; set; }
        public decimal WithoutLicenseFee { get; set; }
        public decimal? DiscountAmount { get; set; }
        public string SearchField { get; set; }
    }
}
