using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadi.Business.Models
{
    public class DrivingSchoolCarFee
    {
        public int DrivingSchoolCarFeeId { get; set; }
        public int DrivingSchoolCarId { get; set; }
        public decimal WithLicenseFee { get; set; }
        public decimal WithoutLicenseFee { get; set; }
        public decimal? DiscountAmount { get; set; }
        public virtual DrivingSchoolCar DrivingSchoolCar { get; set; }
    }
}
