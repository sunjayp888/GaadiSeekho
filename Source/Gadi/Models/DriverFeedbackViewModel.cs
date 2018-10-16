using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gadi.Business.Models;

namespace Gadi.Models
{
    public class DriverFeedbackViewModel:BaseViewModel
    {
        public DriverFeedback DriverFeedback { get; set; }
        public SelectList Drivers { get; set; }
    }
}