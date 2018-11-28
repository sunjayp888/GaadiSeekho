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
            StudentDrivingDetails = new HashSet<StudentDrivingDetail>();
            FormFours = new HashSet<FormFour>();
            FormFives=new HashSet<FormFive>();
            FormEights=new HashSet<FormEight>();
            StudentFees=new HashSet<StudentFee>();
            FormFourteens=new HashSet<FormFourteen>();
            StudentQuestionResponses=new HashSet<StudentQuestionResponse>();
            FormOneAs=new HashSet<FormOneA>();
        }

        public int StudentId { get; set; }

        [Required]
        [StringLength(500)]
        public string Name { get; set; }

        [Required]
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

        public int DrivingSchoolId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedDate { get; set; }

        public virtual DrivingSchool DrivingSchool { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentDrivingDetail> StudentDrivingDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FormFour> FormFours { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FormFive> FormFives { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FormEight> FormEights { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentFee> StudentFees { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FormFourteen> FormFourteens { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentQuestionResponse> StudentQuestionResponses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FormOneA> FormOneAs { get; set; }
    }
}
