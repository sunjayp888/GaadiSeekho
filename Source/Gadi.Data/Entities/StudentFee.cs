namespace Gadi.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StudentFee")]
    public partial class StudentFee
    {
        public int StudentFeeId { get; set; }

        public int StudentId { get; set; }

        public int DrivingSchoolPackageId { get; set; }

        public decimal TotalFees { get; set; }

        public decimal DiscountFees { get; set; }

        public decimal PaidAmount { get; set; }

        public DateTime PaymentDate { get; set; }

        public decimal BalanceFees { get; set; }

        [StringLength(100)]
        public string ReceiptNumber { get; set; }

        public int DrivingSchoolId { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual DrivingSchoolPackage DrivingSchoolPackage { get; set; }

        public virtual DrivingSchool DrivingSchool { get; set; }

        public virtual Student Student { get; set; }
    }
}
