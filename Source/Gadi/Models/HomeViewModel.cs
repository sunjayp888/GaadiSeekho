using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gadi.Business.Models;

namespace Gadi.Models
{
    public class HomeViewModel:BaseViewModel
    {
        public string SearchKeyword { get; set; }
        public bool IsDrivingSchoolApproved { get; set; }
        public DrivingSchoolAvailabilityFilter DrivingSchoolAvailabilityFilter { get; set; }
        public SelectList DrivingSchoolCars { get; set; }
    }
}