namespace Gadi.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Student")]
    public partial class Student
    {
        public Student()
        {
            CreatedDate = DateTime.UtcNow.Date;
        }

        [NotMapped]
        public string FullName => Forenames + " " + Surname;

        public int StudentId { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        [StringLength(100)]
        public string Forenames { get; set; }

        [Required]
        [StringLength(50)]
        public string Surname { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DOB { get; set; }

        [Required]
        [StringLength(100)]
        public string Address1 { get; set; }

        [StringLength(100)]
        public string Address2 { get; set; }

        [StringLength(100)]
        public string Address3 { get; set; }

        [StringLength(100)]
        public string Address4 { get; set; }

        [Required]
        [StringLength(12)]
        public string Postcode { get; set; }

        [StringLength(15)]
        public string Telephone { get; set; }

        [Required]
        [StringLength(15)]
        public string Mobile { get; set; }

        [Required]
        [StringLength(256)]
        public string Email { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedDate { get; set; }

        public int DrivingSchoolId { get; set; }

        public virtual DrivingSchool DrivingSchool { get; set; }
    }
}
