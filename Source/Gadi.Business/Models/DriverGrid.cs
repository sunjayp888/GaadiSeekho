using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadi.Business.Models
{
    public class DriverGrid
    {
        public int DriverId { get; set; }
        public string Name { get; set; }
        public string DrivingLicenceNumber { get; set; }
        public DateTime IssuedDate { get; set; }
        public DateTime ValidTill { get; set; }
        public DateTime DateOfBirth { get; set; }
        public long Mobile { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public int Pincode { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string SearchField { get; set; }
    }
}
