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
        public string Title { get; set; }
        public string Forenames { get; set; }
        public string Surname { get; set; }
        public string FullName => Forenames + " " + Surname;
        public DateTime DOB { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public string Postcode { get; set; }
        public string Telephone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public int DrivingSchoolId { get; set; }
        public virtual DrivingSchool DrivingSchool { get; set; }
    }
}
