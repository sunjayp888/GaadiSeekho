using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadi.Business.Models
{
    public class StudentGrid
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
        public string DrivingSchoolName { get; set; }
        public string SearchField { get; set; }
    }
}
