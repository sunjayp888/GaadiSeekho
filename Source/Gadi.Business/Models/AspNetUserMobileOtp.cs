using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadi.Business.Models
{
    public class AspNetUserMobileOtp
    {
        public int AspNetUserMobileOtpId { get; set; }
        public decimal MobileNumber { get; set; }
        public string UserId { get; set; }
        public int OTP { get; set; }
        public DateTime OTPCreatedDateTime { get; set; }
        public int? OTPRequestedCount { get; set; }
        public int OTPReasonId { get; set; }
        public DateTime OTPValidDateTime { get; set; }
        public string IPAddress { get; set; }
    }
}
