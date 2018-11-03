using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadi.Business.Dto
{
    public class Filter
    {
        public bool IsMondayFilter { get; set; }
        public bool IsTuesdayFilter { get; set; }
        public bool IsWednesdayFilter { get; set; }
        public bool IsThursdayFilter { get; set; }
        public bool IsFridayFilter { get; set; }
        public bool IsSaturdayFilter { get; set; }
        public bool IsSundayFilter { get; set; }
        public bool IsTwoWheelerFilter { get; set; }
        public bool IsFourWheelerFilter { get; set; }
        public bool IsWithLicenseFilter { get; set; }
        public bool IsWithoutLicenseFilter { get; set; }
        public bool IsNormalFilter { get; set; }
        public bool IsSuvFilter { get; set; }
        public bool IsMuvFilter { get; set; }
        public bool IsXuvFilter { get; set; }
        public bool IsMaruti800Filter { get; set; }
        public bool IsSantroFilter { get; set; }
        public bool IsIndicaFilter { get; set; }
        public bool IsQualisFilter { get; set; }
        public bool IsDrivingFeesFilter { get; set; }
        public bool IsFilter { get; set; }

        public string Monday { get; set; }
        public string Tuesday { get; set; }
        public string Wednesday { get; set; }
        public string Thursday { get; set; }
        public string Friday { get; set; }
        public string Saturday { get; set; }
        public string Sunday { get; set; }
        public string TwoWheeler { get; set; }
        public string FourWheeler { get; set; }
        public string WithLicense { get; set; }
        public string WithoutLicense { get; set; }
        public string Normal { get; set; }
        public string Suv { get; set; }
        public string Muv { get; set; }
        public string Xuv { get; set; }
        public decimal FromFees { get; set; }
        public decimal ToFees { get; set; }
        public string Maruti800 { get; set; }
        public string Santro { get; set; }
        public string Indica { get; set; }
        public string Qualis { get; set; }
    }
}
