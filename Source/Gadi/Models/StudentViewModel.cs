using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gadi.Business.Models;

namespace Gadi.Models
{
    public class StudentViewModel : BaseViewModel
    {
        public Student Student { get; set; }
        public IEnumerable<SelectListItem> TitleList { get; set; }
        public List<TitleType> TitleType => new List<TitleType>()
        {
            new TitleType() {Name = "Mr.",Value = "Mr."},
            new TitleType() {Name = "Ms.",Value = "Ms."},
            new TitleType() {Name = "Mrs.",Value = "Mrs."}
        };
    }
    public class TitleType
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}