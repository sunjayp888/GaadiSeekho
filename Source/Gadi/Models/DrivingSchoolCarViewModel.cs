using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gadi.Business.Models;

namespace Gadi.Models
{
    public class DrivingSchoolCarViewModel:BaseViewModel
    {
        public DrivingSchoolCar DrivingSchoolCar { get; set; }
        public DrivingSchoolCarFee DrivingSchoolCarFee { get; set; }
    }
}