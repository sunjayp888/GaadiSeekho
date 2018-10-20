using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadi.Business.Models
{
    public class Personnel
    {
        public int PersonnelId { get; set; }
        public string Title { get; set; }
        public string Forenames { get; set; }
        public string Surname { get; set; }
        public DateTime? DOB { get; set; }
        public int? CountryId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public string Postcode { get; set; }
        public string Telephone { get; set; }
        public string Mobile { get; set; }
        public string PANNumber { get; set; }
        public string BankTelephone { get; set; }
        public string Email { get; set; }
        public string UserId { get; set; }
        public string FullName => Forenames + " " + Surname;
    }
}
