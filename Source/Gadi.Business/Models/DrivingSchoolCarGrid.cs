using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadi.Business.Models
{
    public class DrivingSchoolCarGrid
    {
        public int DrivingSchoolCarId { get; set; }
        public int DrivingSchoolId { get; set; }
        public string DrivingSchoolName { get; set; }
        public int CarId { get; set; }
        public string CarName { get; set; }
        public string TransmissionType { get; set; }
        public decimal WithLicenseFee { get; set; }
        public decimal WithoutLicenseFee { get; set; }
        public decimal? DiscountAmount { get; set; }
    }
}
