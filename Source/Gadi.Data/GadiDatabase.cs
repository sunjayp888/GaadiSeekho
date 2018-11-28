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
        public virtual DbSet<DrivingSchoolFilterGrid> DrivingSchoolFilterGrids { get; set; }
        public virtual DbSet<StudentDrivingDetail> StudentDrivingDetails { get; set; }
        public virtual DbSet<FormFour> FormFours { get; set; }
        public virtual DbSet<FormFourGrid> FormFourGrids { get; set; }
        public virtual DbSet<FormEight> FormEights { get; set; }
        public virtual DbSet<FormFive> FormFives { get; set; }
        public virtual DbSet<DrivingSchoolPackage> DrivingSchoolPackages { get; set; }
        public virtual DbSet<FormFourteen> FormFourteens { get; set; }
        public virtual DbSet<StudentFee> StudentFees { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<StudentQuestionResponse> StudentQuestionResponses { get; set; }
        public virtual DbSet<StudentQuestionGrid> StudentQuestionGrids { get; set; }
        public virtual DbSet<FormOneA> FormOneAs { get; set; }

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

            modelBuilder.Entity<DrivingSchoolCar>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<DrivingSchoolCar>()
                .Property(e => e.CityMileage)
                .IsUnicode(false);

            modelBuilder.Entity<DrivingSchoolCar>()
                .Property(e => e.ARAIMileage)
                .IsUnicode(false);

            modelBuilder.Entity<DrivingSchoolCar>()
                .Property(e => e.FuelType)
                .IsUnicode(false);

            modelBuilder.Entity<DrivingSchoolCar>()
                .Property(e => e.MaxPower)
                .IsUnicode(false);

            modelBuilder.Entity<DrivingSchoolCar>()
                .Property(e => e.MaxTorque)
                .IsUnicode(false);

            modelBuilder.Entity<DrivingSchoolCar>()
                .Property(e => e.EngineDescription)
                .IsUnicode(false);

            modelBuilder.Entity<DrivingSchoolCar>()
                .Property(e => e.TransmissionType)
                .IsUnicode(false);

            modelBuilder.Entity<DrivingSchoolCar>()
                .Property(e => e.CargoVolume)
                .IsUnicode(false);

            modelBuilder.Entity<DrivingSchoolCar>()
                .Property(e => e.WheelType)
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
                .Property(e => e.DrivingSchoolName)
                .IsUnicode(false);

            modelBuilder.Entity<DriverGrid>()
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

            modelBuilder.Entity<DriverFeedbackGrid>()
                .Property(e => e.DrivingSchoolName)
                .IsUnicode(false);

            modelBuilder.Entity<DrivingSchoolCarGrid>()
                .Property(e => e.DrivingSchoolName)
                .IsUnicode(false);

            modelBuilder.Entity<DrivingSchoolCarGrid>()
                .Property(e => e.DrivingSchoolCarName)
                .IsUnicode(false);

            modelBuilder.Entity<DrivingSchoolCarGrid>()
                .Property(e => e.CarTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<DrivingSchoolCarGrid>()
                .Property(e => e.CityMileage)
                .IsUnicode(false);

            modelBuilder.Entity<DrivingSchoolCarGrid>()
                .Property(e => e.ARAIMileage)
                .IsUnicode(false);

            modelBuilder.Entity<DrivingSchoolCarGrid>()
                .Property(e => e.FuelType)
                .IsUnicode(false);

            modelBuilder.Entity<DrivingSchoolCarGrid>()
                .Property(e => e.MaxPower)
                .IsUnicode(false);

            modelBuilder.Entity<DrivingSchoolCarGrid>()
                .Property(e => e.MaxTorque)
                .IsUnicode(false);

            modelBuilder.Entity<DrivingSchoolCarGrid>()
                .Property(e => e.EngineDescription)
                .IsUnicode(false);

            modelBuilder.Entity<DrivingSchoolCarGrid>()
                .Property(e => e.TransmissionType)
                .IsUnicode(false);

            modelBuilder.Entity<DrivingSchoolCarGrid>()
                .Property(e => e.CargoVolume)
                .IsUnicode(false);

            modelBuilder.Entity<DrivingSchoolCarGrid>()
                .Property(e => e.WheelType)
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

            modelBuilder.Entity<DrivingSchoolCarGrid>()
                .Property(e => e.SearchField)
                .IsUnicode(false);

            modelBuilder.Entity<DrivingSchoolFilterGrid>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<DrivingSchoolFilterGrid>()
                .Property(e => e.Address1)
                .IsUnicode(false);

            modelBuilder.Entity<DrivingSchoolFilterGrid>()
                .Property(e => e.Address2)
                .IsUnicode(false);

            modelBuilder.Entity<DrivingSchoolFilterGrid>()
                .Property(e => e.Address3)
                .IsUnicode(false);

            modelBuilder.Entity<DrivingSchoolFilterGrid>()
                .Property(e => e.Address4)
                .IsUnicode(false);

            modelBuilder.Entity<DrivingSchoolFilterGrid>()
                .Property(e => e.Telephone)
                .IsUnicode(false);

            modelBuilder.Entity<DrivingSchoolFilterGrid>()
                .Property(e => e.EmailId)
                .IsUnicode(false);

            modelBuilder.Entity<DrivingSchoolFilterGrid>()
                .Property(e => e.MinimumFeeWithLicense)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DrivingSchoolFilterGrid>()
                .Property(e => e.MinimumFeeWithOutLicense)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DrivingSchoolFilterGrid>()
                .Property(e => e.License)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Nationality)
                .IsUnicode(false);

            modelBuilder.Entity<FormFour>()
                .Property(e => e.DurationOfStayAtPresentAddress)
                .IsUnicode(false);

            modelBuilder.Entity<FormFour>()
                .Property(e => e.MigratedToIndia)
                .IsUnicode(false);

            modelBuilder.Entity<FormFourGrid>()
                .Property(e => e.DurationOfStayAtPresentAddress)
                .IsUnicode(false);

            modelBuilder.Entity<FormFourGrid>()
                .Property(e => e.MigratedToIndia)
                .IsUnicode(false);

            modelBuilder.Entity<FormFourGrid>()
                .Property(e => e.Nationality)
                .IsUnicode(false);

            modelBuilder.Entity<FormFourGrid>()
                .Property(e => e.DrivingSchoolName)
                .IsUnicode(false);

            modelBuilder.Entity<FormFourGrid>()
                .Property(e => e.DrivingSchoolAddress1)
                .IsUnicode(false);

            modelBuilder.Entity<FormFourGrid>()
                .Property(e => e.DrivingSchoolAddress2)
                .IsUnicode(false);

            modelBuilder.Entity<FormFourGrid>()
                .Property(e => e.DrivingSchoolAddress3)
                .IsUnicode(false);

            modelBuilder.Entity<FormFourGrid>()
                .Property(e => e.DrivingSchoolAddress4)
                .IsUnicode(false);

            modelBuilder.Entity<FormFourGrid>()
                .Property(e => e.DrivingSchoolTelephone)
                .IsUnicode(false);

            modelBuilder.Entity<FormFourGrid>()
                .Property(e => e.DrivingSchoolEmail)
                .IsUnicode(false);

            modelBuilder.Entity<StudentGrid>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<StudentGrid>()
                .Property(e => e.Nationality)
                .IsUnicode(false);

            modelBuilder.Entity<StudentGrid>()
                .Property(e => e.DrivingSchoolName)
                .IsUnicode(false);

            modelBuilder.Entity<FormEight>()
                .Property(e => e.MDLNo)
                .IsUnicode(false);

            modelBuilder.Entity<FormEight>()
                .Property(e => e.MDLFor)
                .IsUnicode(false);

            modelBuilder.Entity<FormEight>()
                .Property(e => e.ValidUpto)
                .IsUnicode(false);

            modelBuilder.Entity<FormEight>()
                .Property(e => e.Age)
                .IsUnicode(false);

            modelBuilder.Entity<FormEight>()
                .Property(e => e.RecommendedMDLNo)
                .IsUnicode(false);

            modelBuilder.Entity<FormEight>()
                .Property(e => e.ToEndrossmentFor)
                .IsUnicode(false);

            modelBuilder.Entity<FormEight>()
                .Property(e => e.PaidFee)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DrivingSchoolPackage>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<DrivingSchoolPackage>()
                .Property(e => e.Fee)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DrivingSchoolPackage>()
                .Property(e => e.Downpayment)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DrivingSchoolPackage>()
                .Property(e => e.LumpsumAmount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DrivingSchoolPackage>()
                .HasMany(e => e.StudentFees)
                .WithRequired(e => e.DrivingSchoolPackage)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FormFourteen>()
                .Property(e => e.LLRNumber)
                .IsUnicode(false);

            modelBuilder.Entity<FormFourteen>()
                .Property(e => e.DrivingLicenseNumber)
                .IsUnicode(false);

            modelBuilder.Entity<FormFourteen>()
                .Property(e => e.RNumber)
                .IsUnicode(false);

            modelBuilder.Entity<FormFourteen>()
                .Property(e => e.InwardNumber)
                .IsUnicode(false);

            modelBuilder.Entity<StudentFee>()
                .Property(e => e.TotalFees)
                .HasPrecision(18, 0);

            modelBuilder.Entity<StudentFee>()
                .Property(e => e.DiscountFees)
                .HasPrecision(18, 0);

            modelBuilder.Entity<StudentFee>()
                .Property(e => e.PaidAmount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<StudentFee>()
                .Property(e => e.BalanceFees)
                .HasPrecision(18, 0);

            modelBuilder.Entity<StudentFee>()
                .Property(e => e.ReceiptNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Question>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Question>()
                .HasMany(e => e.StudentQuestionResponses)
                .WithRequired(e => e.Question)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StudentQuestionResponse>()
                .Property(e => e.StudentResponse)
                .IsUnicode(false);

            modelBuilder.Entity<StudentQuestionResponse>()
                .Property(e => e.CreatedDate)
                .IsFixedLength();

            modelBuilder.Entity<StudentQuestionGrid>()
                .Property(e => e.QuestionName)
                .IsUnicode(false);

            modelBuilder.Entity<StudentQuestionGrid>()
                .Property(e => e.StudentResponse)
                .IsUnicode(false);

            modelBuilder.Entity<StudentQuestionGrid>()
                .Property(e => e.CreatedDate)
                .IsFixedLength();

            modelBuilder.Entity<FormOneA>()
                .Property(e => e.IdentificationMarks1)
                .IsUnicode(false);

            modelBuilder.Entity<FormOneA>()
                .Property(e => e.IdentificationMarks2)
                .IsUnicode(false);
        }
    }
}
