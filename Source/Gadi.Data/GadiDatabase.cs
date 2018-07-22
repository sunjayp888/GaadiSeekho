using Gadi.Data.Entity;

namespace Gadi.Data
{
    using System.Data.Entity;
    public partial class GadiDatabase : DbContext
    {
        public GadiDatabase()
            : base("name=GadiDatabase")
        {
        }
        public virtual DbSet<Alert> Alerts { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsersAlertSchedule> AspNetUsersAlertSchedules { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<CarType> CarTypes { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<DocumentType> DocumentTypes { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<DriverFeedback> DriverFeedbacks { get; set; }
        public virtual DbSet<DrivingSchool> DrivingSchools { get; set; }
        public virtual DbSet<DrivingSchoolCar> DrivingSchoolCars { get; set; }
        public virtual DbSet<Organisation> Organisations { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Template> Templates { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alert>()
                .HasMany(e => e.AspNetUsersAlertSchedules)
                .WithRequired(e => e.Alert)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Car>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Car>()
                .Property(e => e.CityMileage)
                .IsUnicode(false);

            modelBuilder.Entity<Car>()
                .Property(e => e.ARAIMileage)
                .IsUnicode(false);

            modelBuilder.Entity<Car>()
                .Property(e => e.FuelType)
                .IsUnicode(false);

            modelBuilder.Entity<Car>()
                .Property(e => e.MaxPower)
                .IsUnicode(false);

            modelBuilder.Entity<Car>()
                .Property(e => e.MaxTorque)
                .IsUnicode(false);

            modelBuilder.Entity<Car>()
                .Property(e => e.EngineDescription)
                .IsUnicode(false);

            modelBuilder.Entity<Car>()
                .Property(e => e.TransmissionType)
                .IsUnicode(false);

            modelBuilder.Entity<Car>()
                .Property(e => e.CargoVolume)
                .IsUnicode(false);

            modelBuilder.Entity<Car>()
                .HasMany(e => e.DrivingSchoolCars)
                .WithRequired(e => e.Car)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CarType>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Document>()
                .Property(e => e.StudentCode)
                .IsUnicode(false);

            modelBuilder.Entity<Document>()
                .Property(e => e.StudentName)
                .IsUnicode(false);

            modelBuilder.Entity<Document>()
                .Property(e => e.FileName)
                .IsUnicode(false);

            modelBuilder.Entity<Document>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Document>()
                .Property(e => e.Location)
                .IsUnicode(false);

            modelBuilder.Entity<DocumentType>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<DocumentType>()
                .Property(e => e.BasePath)
                .IsUnicode(false);

            modelBuilder.Entity<DocumentType>()
                .HasMany(e => e.Documents)
                .WithRequired(e => e.DocumentType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Driver>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Driver>()
                .Property(e => e.DrivingLicenceNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Driver>()
                .Property(e => e.Address1)
                .IsUnicode(false);

            modelBuilder.Entity<Driver>()
                .Property(e => e.Address2)
                .IsUnicode(false);

            modelBuilder.Entity<Driver>()
                .Property(e => e.Address3)
                .IsUnicode(false);

            modelBuilder.Entity<Driver>()
                .Property(e => e.Address4)
                .IsUnicode(false);

            modelBuilder.Entity<Driver>()
                .HasMany(e => e.DriverFeedbacks)
                .WithRequired(e => e.Driver)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DriverFeedback>()
                .Property(e => e.HasYourDrivingInstructorEverBeenLateForALesson)
                .IsUnicode(false);

            modelBuilder.Entity<DriverFeedback>()
                .Property(e => e.HasYourDrivingInstructorEverMadeYouFeelUncomfortable)
                .IsUnicode(false);

            modelBuilder.Entity<DriverFeedback>()
                .Property(e => e.WouldYouRecommendThisDrivingSchoolToFriends)
                .IsUnicode(false);

            modelBuilder.Entity<DriverFeedback>()
                .Property(e => e.DoYouThinkThisSyllabusWillMakeYouASaferDriver)
                .IsUnicode(false);

            modelBuilder.Entity<DriverFeedback>()
                .Property(e => e.Comment)
                .IsUnicode(false);

            //modelBuilder.Entity<DriverFeedback>()
            //    .HasOptional(e => e.DriverFeedback1)
            //    .WithRequired(e => e.DriverFeedback2);

            modelBuilder.Entity<DrivingSchool>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<DrivingSchool>()
                .Property(e => e.Address1)
                .IsUnicode(false);

            modelBuilder.Entity<DrivingSchool>()
                .Property(e => e.Address2)
                .IsUnicode(false);

            modelBuilder.Entity<DrivingSchool>()
                .Property(e => e.Address3)
                .IsUnicode(false);

            modelBuilder.Entity<DrivingSchool>()
                .Property(e => e.Address4)
                .IsUnicode(false);

            modelBuilder.Entity<DrivingSchool>()
                .Property(e => e.Telephone)
                .IsUnicode(false);

            modelBuilder.Entity<DrivingSchool>()
                .Property(e => e.EmailId)
                .IsUnicode(false);

            modelBuilder.Entity<DrivingSchool>()
                .HasMany(e => e.DrivingSchoolCars)
                .WithRequired(e => e.DrivingSchool)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Organisation>()
                .HasMany(e => e.AspNetRoles)
                .WithRequired(e => e.Organisation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Organisation>()
                .HasMany(e => e.Cars)
                .WithRequired(e => e.Organisation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Organisation>()
                .HasMany(e => e.CarTypes)
                .WithRequired(e => e.Organisation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Organisation>()
                .HasMany(e => e.Documents)
                .WithRequired(e => e.Organisation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Organisation>()
                .HasMany(e => e.DriverFeedbacks)
                .WithRequired(e => e.Organisation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Organisation>()
                .HasMany(e => e.DrivingSchools)
                .WithRequired(e => e.Organisation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Organisation>()
                .HasMany(e => e.DrivingSchoolCars)
                .WithRequired(e => e.Organisation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Organisation>()
                .HasMany(e => e.Students)
                .WithRequired(e => e.Organisation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Telephone)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Mobile)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.NINumber)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.BankAccountNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.BankSortCode)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.BankTelephone)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Email)
                .IsUnicode(false);
        }
    }
}
