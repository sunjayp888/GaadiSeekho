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
        [StringLength(50)]
        public string Title { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(100)]
        public string Forenames { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string Surname { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "datetime2")]
        public DateTime DOB { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(100)]
        public string Address1 { get; set; }

        [StringLength(100)]
        public string Address2 { get; set; }

        [StringLength(100)]
        public string Address3 { get; set; }

        [StringLength(100)]
        public string Address4 { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(12)]
        public string Postcode { get; set; }

        [StringLength(15)]
        public string Telephone { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(15)]
        public string Mobile { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(256)]
        public string Email { get; set; }

        [Key]
        [Column(Order = 9, TypeName = "datetime2")]
        public DateTime CreatedDate { get; set; }

        [Key]
        [Column(Order = 10)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DrivingSchoolId { get; set; }

        [Key]
        [Column(Order = 11)]
        [StringLength(500)]
        public string DrivingSchoolName { get; set; }

        [Key]
        [Column(Order = 12)]
        [StringLength(638)]
        public string SearchField { get; set; }
    }
}
