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
        public FormOneA FormOneA { get; set; }
        public FormFour FormFour { get; set; }
        public FormFive FormFive { get; set; }
        public FormEight FormEight { get; set; }
        public FormFourteen FormFourteen { get; set; }
        public List<Question> Questions { get; set; }
    }
}