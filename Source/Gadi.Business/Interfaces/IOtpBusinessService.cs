using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gadi.Business.Models;

namespace Gadi.Business.Interfaces
{
    public interface IOtpBusinessService
    {
        //Retrieve
        Task<ValidationResult<AspNetUserMobileOtp>> RetrieveOtp(decimal mobileNumber, int reasonId);

        //Create
        Task<ValidationResult<AspNetUserMobileOtp>> CreateLoginOtp(decimal mobileNumber, string ipAddress);
        Task<ValidationResult<AspNetUserMobileOtp>> CreateMobileRepairOtp(decimal mobileNumber, string ipAddress);
        Task<ValidationResult<AspNetUserMobileOtp>> CreateMobileRepairPaymentOtp(decimal mobileNumber, string ipAddress, decimal amount);
        Task<ValidationResult<AspNetUserMobileOtp>> CreateForgetPasswordOtp(decimal mobileNumber, string ipAddress);

        //Validate
        Task<ValidationResult<AspNetUserMobileOtp>> IsValidOtp(int otpNumber, decimal mobileNumber, int reasonId, DateTime? validityDateTime);
    }
}
