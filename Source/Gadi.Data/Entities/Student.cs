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

        [StringLength(15)]
        public string Mobile { get; set; }

        [StringLength(10)]
        public string NINumber { get; set; }

        [StringLength(10)]
        public string BankAccountNumber { get; set; }

        [StringLength(6)]
        public string BankSortCode { get; set; }

        [StringLength(100)]
        public string BankAccountName { get; set; }

        [StringLength(100)]
        public string BankAddress1 { get; set; }

        [StringLength(100)]
        public string BankAddress2 { get; set; }

        [StringLength(100)]
        public string BankAddress3 { get; set; }

        [StringLength(100)]
        public string BankAddress4 { get; set; }

        [StringLength(12)]
        public string BankPostcode { get; set; }

        [StringLength(15)]
        public string BankTelephone { get; set; }

        [Required]
        [StringLength(256)]
        public string Email { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedDate { get; set; }
    }
}
