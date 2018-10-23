using Gadi.Data.Entities;


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
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<DriverFeedback> DriverFeedbacks { get; set; }
        public virtual DbSet<DrivingSchool> DrivingSchools { get; set; }
        public virtual DbSet<DrivingSchoolCar> DrivingSchoolCars { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Template> Templates { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetPermission> AspNetPermissions { get; set; }
        public virtual DbSet<AspNetRolePermission> AspNetRolePermissions { get; set; }
        public virtual DbSet<AspNetUserPermission> AspNetUserPermissions { get; set; }
        public virtual DbSet<CarGrid> CarGrids { get; set; }
        public virtual DbSet<DriverGrid> DriverGrids { get; set; }
        public virtual DbSet<DrivingSchoolGrid> DrivingSchoolGrids { get; set; }
        public virtual DbSet<StudentGrid> StudentGrids { get; set; }
        public virtual DbSet<DriverFeedbackGrid> DriverFeedbackGrids { get; set; }
        public virtual DbSet<AspNetUserMobileOtp> AspNetUserMobileOtps { get; set; }
        public virtual DbSet<Personnel> Personnels { get; set; }
        public virtual DbSet<PersonnelDocument> PersonnelDocuments { get; set; }
        public virtual DbSet<DrivingSchoolCarGrid> DrivingSchoolCarGrids { get; set; }
        public virtual DbSet<DrivingSchoolCarFee> DrivingSchoolCarFees { get; set; }
        public virtual DbSet<DrivingSchoolRatingAndReview> DrivingSchoolRatingAndReviews { get; set; }
        public virtual DbSet<DocumentCategory> DocumentCategories { get; set; }
        public virtual DbSet<DocumentDetail> DocumentDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alert>()
                .HasMany(e => e.AspNetUsersAlertSchedules)
                .WithRequired(e => e.Alert)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetPermission>()
                .HasMany(e => e.AspNetRoles)
                .WithMany(e => e.AspNetPermissions)
                .Map(m => m.ToTable("AspNetRolePermissions").MapLeftKey("PermissionId").MapRightKey("RoleId"));

            modelBuilder.Entity<AspNetPermission>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetPermissions)
                .Map(m => m.ToTable("AspNetUserPermissions").MapLeftKey("PermissionId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .Property(e => e.Name)
                .IsUnicode(false);

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

            modelBuilder.Entity<DriverGrid>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<DriverGrid>()
                .Property(e => e.DrivingLicenceNumber)
                .IsUnicode(false);

            modelBuilder.Entity<DriverGrid>()
                .Property(e => e.Address1)
                .IsUnicode(false);

            modelBuilder.Entity<DriverGrid>()
                .Property(e => e.Address2)
                .IsUnicode(false);

            modelBuilder.Entity<DriverGrid>()
                .Property(e => e.Address3)
                .IsUnicode(false);

            modelBuilder.Entity<DriverGrid>()
                .Property(e => e.Address4)
                .IsUnicode(false);

            modelBuilder.Entity<DriverGrid>()
                .Property(e => e.SearchField)
                .IsUnicode(false);

            modelBuilder.Entity<StudentGrid>()
                .Property(e => e.Telephone)
                .IsUnicode(false);

            modelBuilder.Entity<StudentGrid>()
                .Property(e => e.Mobile)
                .IsUnicode(false);

            modelBuilder.Entity<StudentGrid>()
                .Property(e => e.NINumber)
                .IsUnicode(false);

            modelBuilder.Entity<StudentGrid>()
                .Property(e => e.BankAccountNumber)
                .IsUnicode(false);

            modelBuilder.Entity<StudentGrid>()
                .Property(e => e.BankSortCode)
                .IsUnicode(false);

            modelBuilder.Entity<StudentGrid>()
                .Property(e => e.BankTelephone)
                .IsUnicode(false);

            modelBuilder.Entity<StudentGrid>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<CarGrid>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<CarGrid>()
                .Property(e => e.CityMileage)
                .IsUnicode(false);

            modelBuilder.Entity<CarGrid>()
                .Property(e => e.ARAIMileage)
                .IsUnicode(false);

            modelBuilder.Entity<CarGrid>()
                .Property(e => e.FuelType)
                .IsUnicode(false);

            modelBuilder.Entity<CarGrid>()
                .Property(e => e.MaxPower)
                .IsUnicode(false);

            modelBuilder.Entity<CarGrid>()
                .Property(e => e.MaxTorque)
                .IsUnicode(false);

            modelBuilder.Entity<CarGrid>()
                .Property(e => e.EngineDescription)
                .IsUnicode(false);

            modelBuilder.Entity<CarGrid>()
                .Property(e => e.TransmissionType)
                .IsUnicode(false);

            modelBuilder.Entity<CarGrid>()
                .Property(e => e.CargoVolume)
                .IsUnicode(false);

            modelBuilder.Entity<CarGrid>()
                .Property(e => e.SearchField)
                .IsUnicode(false);

            modelBuilder.Entity<DriverFeedbackGrid>()
                .Property(e => e.DriverName)
                .IsUnicode(false);

            modelBuilder.Entity<DriverFeedbackGrid>()
                .Property(e => e.HasYourDrivingInstructorEverBeenLateForALesson)
                .IsUnicode(false);

            modelBuilder.Entity<DriverFeedbackGrid>()
                .Property(e => e.HasYourDrivingInstructorEverMadeYouFeelUncomfortable)
                .IsUnicode(false);

            modelBuilder.Entity<DriverFeedbackGrid>()
                .Property(e => e.WouldYouRecommendThisDrivingSchoolToFriends)
                .IsUnicode(false);

            modelBuilder.Entity<DriverFeedbackGrid>()
                .Property(e => e.DoYouThinkThisSyllabusWillMakeYouASaferDriver)
                .IsUnicode(false);

            modelBuilder.Entity<DriverFeedbackGrid>()
                .Property(e => e.Comment)
                .IsUnicode(false);

            modelBuilder.Entity<AspNetUserMobileOtp>()
                .Property(e => e.MobileNumber)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Personnel>()
                .Property(e => e.Telephone)
                .IsUnicode(false);

            modelBuilder.Entity<Personnel>()
                .Property(e => e.Mobile)
                .IsUnicode(false);

            modelBuilder.Entity<Personnel>()
                .Property(e => e.PANNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Personnel>()
                .Property(e => e.BankTelephone)
                .IsUnicode(false);

            modelBuilder.Entity<Personnel>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<DrivingSchoolRatingAndReview>()
               .Property(e => e.Rating)
               .HasPrecision(18, 0);

            modelBuilder.Entity<DrivingSchoolRatingAndReview>()
                .Property(e => e.Review)
                .IsUnicode(false);

            modelBuilder.Entity<DrivingSchoolCarFee>()
               .Property(e => e.WithLicenseFee)
               .HasPrecision(18, 0);

            modelBuilder.Entity<DrivingSchoolCarFee>()
                .Property(e => e.WithoutLicenseFee)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DrivingSchoolCarFee>()
                .Property(e => e.DiscountAmount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DrivingSchoolCarGrid>()
                .Property(e => e.DrivingSchoolName)
                .IsUnicode(false);

            modelBuilder.Entity<DrivingSchoolCarGrid>()
                .Property(e => e.CarName)
                .IsUnicode(false);

            modelBuilder.Entity<DrivingSchoolCarGrid>()
                .Property(e => e.TransmissionType)
                .IsUnicode(false);

            modelBuilder.Entity<DrivingSchoolCarGrid>()
                .Property(e => e.WithLicenseFee)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DrivingSchoolCarGrid>()
                .Property(e => e.WithoutLicenseFee)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DrivingSchoolCarGrid>()
                .Property(e => e.DiscountAmount)
                .HasPrecision(18, 0);

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
                .Property(e => e.MinimumFeeWithLicense)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DrivingSchool>()
                .Property(e => e.MinimumFeeWithOutLicense)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DrivingSchool>()
               .HasMany(e => e.DrivingSchoolCars)
               .WithRequired(e => e.DrivingSchool)
               .WillCascadeOnDelete(false);

            modelBuilder.Entity<DocumentCategory>()
                .HasMany(e => e.DocumentDetails)
                .WithRequired(e => e.DocumentCategory)
                .HasForeignKey(e => e.CategoryId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DocumentDetail>()
                .Property(e => e.FileName)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.DocumentDetails)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DrivingSchoolGrid>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<DrivingSchoolGrid>()
                .Property(e => e.Address1)
                .IsUnicode(false);

            modelBuilder.Entity<DrivingSchoolGrid>()
                .Property(e => e.Address2)
                .IsUnicode(false);

            modelBuilder.Entity<DrivingSchoolGrid>()
                .Property(e => e.Address3)
                .IsUnicode(false);

            modelBuilder.Entity<DrivingSchoolGrid>()
                .Property(e => e.Address4)
                .IsUnicode(false);

            modelBuilder.Entity<DrivingSchoolGrid>()
                .Property(e => e.Telephone)
                .IsUnicode(false);

            modelBuilder.Entity<DrivingSchoolGrid>()
                .Property(e => e.EmailId)
                .IsUnicode(false);

            modelBuilder.Entity<DrivingSchoolGrid>()
                .Property(e => e.MinimumFeeWithLicense)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DrivingSchoolGrid>()
                .Property(e => e.MinimumFeeWithOutLicense)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DrivingSchoolGrid>()
                .Property(e => e.SearchField)
                .IsUnicode(false);
        }
    }
}
