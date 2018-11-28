namespace Gadi.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StudentGrid")]
    public partial class StudentGrid
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StudentId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(500)]
        public string Name { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(500)]
        public string SonWifeDaughterOf { get; set; }

        [StringLength(500)]
        public string PresentAddress { get; set; }

        [StringLength(500)]
        public string PermanantAddress { get; set; }

        [StringLength(500)]
        public string OfficialAddress { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DateOfBirth { get; set; }

        [StringLength(200)]
        public string PlaceOfBirth { get; set; }

        [StringLength(100)]
        public string Education { get; set; }

        [StringLength(50)]
        public string BloodGroup { get; set; }

        [StringLength(50)]
        public string RHFactor { get; set; }

        public long? Mobile { get; set; }

        public long? ResidentialPhone { get; set; }

        public long? OfficialPhone { get; set; }

        [StringLength(256)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Nationality { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DrivingSchoolId { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "datetime2")]
        public DateTime CreatedDate { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(500)]
        public string DrivingSchoolName { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(1376)]
        public string SearchField { get; set; }
    }
}
