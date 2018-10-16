namespace Gadi.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DrivingSchoolCarFee")]
    public partial class DrivingSchoolCarFee
    {
        public int DrivingSchoolCarFeeId { get; set; }

        public int DrivingSchoolCarId { get; set; }

        public decimal WithLicenseFee { get; set; }

        public decimal WithoutLicenseFee { get; set; }

        public decimal? DiscountAmount { get; set; }

        public virtual DrivingSchoolCar DrivingSchoolCar { get; set; }
    }
}
