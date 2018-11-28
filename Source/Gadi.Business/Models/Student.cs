using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadi.Business.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string SonWifeDaughterOf { get; set; }
        public string PresentAddress { get; set; }
        public string PermanantAddress { get; set; }
        public string OfficialAddress { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public string Education { get; set; }
        public string BloodGroup { get; set; }
        public string RHFactor { get; set; }
        public long? Mobile { get; set; }
        public long? ResidentialPhone { get; set; }
        public long? OfficialPhone { get; set; }
        public string Email { get; set; }
        public string Nationality { get; set; }
        public int DrivingSchoolId { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual DrivingSchool DrivingSchool { get; set; }
        public virtual ICollection<StudentDrivingDetail> StudentDrivingDetails { get; set; }
        public virtual ICollection<FormFour> FormFours { get; set; }
        public virtual ICollection<FormFive> FormFives { get; set; }
        public virtual ICollection<FormEight> FormEights { get; set; }
        public virtual ICollection<StudentFee> StudentFees { get; set; }
        public virtual ICollection<FormFourteen> FormFourteens { get; set; }
        public virtual ICollection<StudentQuestionResponse> StudentQuestionResponses { get; set; }
        public virtual ICollection<FormOneA> FormOneAs { get; set; }
    }
}
