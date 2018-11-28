using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadi.Business.Models
{
    public class DrivingSchoolPackage
    {
        public int DrivingSchoolPackageId { get; set; }
        public string Name { get; set; }
        public int DrivingSchoolCarId { get; set; }
        public int NumberOfDays { get; set; }
        public decimal Fee { get; set; }
        public decimal Downpayment { get; set; }
        public decimal LumpsumAmount { get; set; }
        public int NumberOfInstallment { get; set; }
        public int DrivingSchoolId { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual DrivingSchool DrivingSchool { get; set; }
        public virtual DrivingSchoolCar DrivingSchoolCar { get; set; }
        public virtual ICollection<StudentFee> StudentFees { get; set; }
    }
}
