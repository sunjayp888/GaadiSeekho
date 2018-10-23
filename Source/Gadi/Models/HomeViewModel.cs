using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gadi.Models
{
    public class HomeViewModel:BaseViewModel
    {
        public string SearchKeyword { get; set; }
        public bool IsDrivingSchoolApproved { get; set; }
    }
}