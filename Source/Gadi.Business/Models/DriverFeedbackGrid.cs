using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadi.Business.Models
{
    public class DriverFeedbackGrid
    {
        public int DriverFeedBackId { get; set; }
        public int DriverId { get; set; }
        public string DriverName { get; set; }
        public string HasYourDrivingInstructorEverBeenLateForALesson { get; set; }
        public string HasYourDrivingInstructorEverMadeYouFeelUncomfortable { get; set; }
        public string WouldYouRecommendThisDrivingSchoolToFriends { get; set; }
        public string DoYouThinkThisSyllabusWillMakeYouASaferDriver { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
    }
}
