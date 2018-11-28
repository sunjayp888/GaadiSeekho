using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadi.Business.Models
{
    public class StudentDrivingDetail
    {
        public int StudentDrivingDetailId { get; set; }
        public int StudentId { get; set; }
        public int DrivingSchoolId { get; set; }
        public int DrivingSchoolCarId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public bool IsSunday { get; set; }
        public bool IsMonday { get; set; }
        public bool IsTuesday { get; set; }
        public bool IsWednesday { get; set; }
        public bool IsThursday { get; set; }
        public bool IsFriday { get; set; }
        public bool IsSaturday { get; set; }
        public virtual Student Student { get; set; }
        public virtual DrivingSchool DrivingSchool { get; set; }
        public virtual DrivingSchoolCar DrivingSchoolCar { get; set; }
    }
}
