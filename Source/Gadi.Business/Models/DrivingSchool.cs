using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadi.Business.Models
{
    public class DrivingSchool
    {
        public int DrivingSchoolId { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public int Pincode { get; set; }
        public long Mobile { get; set; }
        public string Telephone { get; set; }
        public string EmailId { get; set; }
        public DateTime CreatedDate { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public decimal? MinimumFeeWithLicense { get; set; }
        public decimal? MinimumFeeWithOutLicense { get; set; }
    }
}
