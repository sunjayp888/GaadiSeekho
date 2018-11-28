using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadi.Business.Models
{
    public class FormFourGrid
    {
        public int FormFourId { get; set; }
        public int DrivingSchoolId { get; set; }
        public int StudentId { get; set; }
        public bool IsLMVNT { get; set; }
        public bool IsMCWG { get; set; }
        public bool IsMCWOG { get; set; }
        public bool IsLMVTR { get; set; }
        public bool IsARTR { get; set; }
        public bool IsARNT { get; set; }
        public string DurationOfStayAtPresentAddress { get; set; }
        public string MigratedToIndia { get; set; }
        public DateTime CreatedDate { get; set; }
        public string StudentName { get; set; }
        public string SonWifeDaughterOf { get; set; }
        public string PermanantAddress { get; set; }
        public string PresentAddress { get; set; }
        public string OfficialAddress { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string BloodGroup { get; set; }
        public string RHFactor { get; set; }
        public string PlaceOfBirth { get; set; }
        public string Education { get; set; }
        public string Nationality { get; set; }
        public string DrivingSchoolName { get; set; }
        public string DrivingSchoolAddress1 { get; set; }
        public string DrivingSchoolAddress2 { get; set; }
        public string DrivingSchoolAddress3 { get; set; }
        public string DrivingSchoolAddress4 { get; set; }
        public int? DrivingSchoolPincode { get; set; }
        public long? DrivingSchoolMobile { get; set; }
        public string DrivingSchoolTelephone { get; set; }
        public string DrivingSchoolEmail { get; set; }
        public string RelativePath { get; set; }
    }
}
