namespace Gadi.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FormFourGrid")]
    public partial class FormFourGrid
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FormFourId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DrivingSchoolId { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StudentId { get; set; }

        [Key]
        [Column(Order = 3)]
        public bool IsLMVNT { get; set; }

        [Key]
        [Column(Order = 4)]
        public bool IsMCWG { get; set; }

        [Key]
        [Column(Order = 5)]
        public bool IsMCWOG { get; set; }

        [Key]
        [Column(Order = 6)]
        public bool IsLMVTR { get; set; }

        [Key]
        [Column(Order = 7)]
        public bool IsARTR { get; set; }

        [Key]
        [Column(Order = 8)]
        public bool IsARNT { get; set; }

        [StringLength(100)]
        public string DurationOfStayAtPresentAddress { get; set; }

        [StringLength(100)]
        public string MigratedToIndia { get; set; }

        [Key]
        [Column(Order = 9)]
        public DateTime CreatedDate { get; set; }

        [StringLength(500)]
        public string StudentName { get; set; }

        [StringLength(500)]
        public string SonWifeDaughterOf { get; set; }

        [StringLength(500)]
        public string PermanantAddress { get; set; }

        [StringLength(500)]
        public string PresentAddress { get; set; }

        [StringLength(500)]
        public string OfficialAddress { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DateOfBirth { get; set; }

        [StringLength(50)]
        public string BloodGroup { get; set; }

        [StringLength(50)]
        public string RHFactor { get; set; }

        [StringLength(200)]
        public string PlaceOfBirth { get; set; }

        [StringLength(100)]
        public string Education { get; set; }

        [StringLength(50)]
        public string Nationality { get; set; }

        [StringLength(500)]
        public string DrivingSchoolName { get; set; }

        [StringLength(500)]
        public string DrivingSchoolAddress1 { get; set; }

        [StringLength(500)]
        public string DrivingSchoolAddress2 { get; set; }

        [StringLength(500)]
        public string DrivingSchoolAddress3 { get; set; }

        [StringLength(500)]
        public string DrivingSchoolAddress4 { get; set; }

        public int? DrivingSchoolPincode { get; set; }

        public long? DrivingSchoolMobile { get; set; }

        [StringLength(100)]
        public string DrivingSchoolTelephone { get; set; }

        [StringLength(100)]
        public string DrivingSchoolEmail { get; set; }

        public string RelativePath { get; set; }
    }
}
