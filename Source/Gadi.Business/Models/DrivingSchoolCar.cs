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
        public int CarId { get; set; }
        public virtual Car Car { get; set; }
        public virtual DrivingSchool DrivingSchool { get; set; }
        public virtual ICollection<DrivingSchoolCarFee> DrivingSchoolCarFees { get; set; }
    }
}
