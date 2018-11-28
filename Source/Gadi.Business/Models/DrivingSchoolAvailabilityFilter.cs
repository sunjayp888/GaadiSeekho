using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadi.Business.Models
{
    public class DrivingSchoolAvailabilityFilter
    {
        public DateTime StartDate { get; set; }
        public int StartTime { get; set; }
        public bool IsMonday { get; set; }
        public bool IsTuesday { get; set; }
        public bool IsWednesday { get; set; }
        public bool IsThursday { get; set; }
        public bool IsFriday { get; set; }
        public bool IsSaturday { get; set; }
        public bool IsSunday { get; set; }
        public bool IsTwoWheelerLicense { get; set; }
        public bool IsFourWheelerLicense { get; set; }
        public int DrivingSchoolCarId { get; set; }
    }
}
