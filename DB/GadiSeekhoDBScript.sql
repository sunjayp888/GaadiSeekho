USE [master]
GO
/****** Object:  Database [GadiSeekho]    Script Date: 22-07-2018 06:43:35 PM ******/
CREATE DATABASE [GadiSeekho]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GadiSeekho', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\GadiSeekho.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'GadiSeekho_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\GadiSeekho_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [GadiSeekho] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GadiSeekho].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GadiSeekho] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GadiSeekho] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GadiSeekho] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GadiSeekho] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GadiSeekho] SET ARITHABORT OFF 
GO
ALTER DATABASE [GadiSeekho] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [GadiSeekho] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GadiSeekho] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GadiSeekho] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GadiSeekho] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GadiSeekho] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GadiSeekho] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GadiSeekho] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GadiSeekho] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GadiSeekho] SET  ENABLE_BROKER 
GO
ALTER DATABASE [GadiSeekho] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GadiSeekho] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GadiSeekho] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GadiSeekho] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GadiSeekho] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GadiSeekho] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GadiSeekho] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GadiSeekho] SET RECOVERY FULL 
GO
ALTER DATABASE [GadiSeekho] SET  MULTI_USER 
GO
ALTER DATABASE [GadiSeekho] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GadiSeekho] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GadiSeekho] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GadiSeekho] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [GadiSeekho] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'GadiSeekho', N'ON'
GO
USE [GadiSeekho]
GO
/****** Object:  Table [dbo].[Alert]    Script Date: 22-07-2018 06:43:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alert](
	[AlertId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](1000) NULL,
	[OrganisationId] [int] NOT NULL,
 CONSTRAINT [PK_Alert] PRIMARY KEY CLUSTERED 
(
	[AlertId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 22-07-2018 06:43:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[Discriminator] [nvarchar](128) NOT NULL,
	[OrganisationId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 22-07-2018 06:43:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 22-07-2018 06:43:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 22-07-2018 06:43:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 22-07-2018 06:43:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
	[OrganisationId] [int] NULL,
	[PersonnelId] [int] NULL,
	[CentreId] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsersAlertSchedule]    Script Date: 22-07-2018 06:43:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsersAlertSchedule](
	[AspnetUsersAlertScheduleId] [int] IDENTITY(1,1) NOT NULL,
	[AspNetUsersId] [nvarchar](128) NOT NULL,
	[AlertId] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsersAlertSchedule] PRIMARY KEY CLUSTERED 
(
	[AspnetUsersAlertScheduleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Car]    Script Date: 22-07-2018 06:43:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Car](
	[CarId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](500) NOT NULL,
	[CityMileage] [varchar](100) NULL,
	[ARAIMileage] [varchar](100) NULL,
	[FuelType] [varchar](100) NOT NULL,
	[Engine] [int] NOT NULL,
	[MaxPower] [varchar](100) NULL,
	[MaxTorque] [varchar](100) NULL,
	[Seating] [int] NULL,
	[EngineDescription] [varchar](500) NOT NULL,
	[TransmissionType] [varchar](100) NULL,
	[CargoVolume] [varchar](100) NULL,
	[OrganisationId] [int] NOT NULL,
 CONSTRAINT [PK_Car] PRIMARY KEY CLUSTERED 
(
	[CarId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CarType]    Script Date: 22-07-2018 06:43:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CarType](
	[CarTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](500) NOT NULL,
	[OrganisationId] [int] NOT NULL,
 CONSTRAINT [PK_CarType] PRIMARY KEY CLUSTERED 
(
	[CarTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Document]    Script Date: 22-07-2018 06:43:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Document](
	[DocumentId] [int] IDENTITY(1,1) NOT NULL,
	[StudentCode] [varchar](100) NOT NULL,
	[StudentName] [varchar](500) NULL,
	[FileName] [varchar](4000) NOT NULL,
	[Description] [varchar](1000) NULL,
	[Location] [varchar](max) NOT NULL,
	[DocumentTypeId] [int] NOT NULL,
	[Guid] [uniqueidentifier] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[DownloadedDateTime] [datetime] NULL,
	[OrganisationId] [int] NOT NULL,
	[CentreId] [int] NULL,
 CONSTRAINT [PK_Document] PRIMARY KEY CLUSTERED 
(
	[DocumentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DocumentType]    Script Date: 22-07-2018 06:43:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DocumentType](
	[DocumentTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[BasePath] [varchar](1000) NOT NULL,
	[OrganisationId] [int] NOT NULL,
	[IsEnquiry] [bit] NOT NULL,
	[IsCounselling] [bit] NOT NULL,
	[IsAdmission] [bit] NOT NULL,
	[IsExpense] [bit] NOT NULL,
	[IsTrainer] [bit] NOT NULL,
	[IsFixAsset] [bit] NOT NULL,
	[IsBankDepositeDocument] [bit] NOT NULL,
 CONSTRAINT [PK_DocumentType] PRIMARY KEY CLUSTERED 
(
	[DocumentTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Driver]    Script Date: 22-07-2018 06:43:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Driver](
	[DriverId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](500) NOT NULL,
	[DrivingLicenceNumber] [varchar](500) NOT NULL,
	[IssuedDate] [date] NOT NULL,
	[ValidTill] [date] NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[Mobile] [bigint] NOT NULL,
	[Address1] [varchar](500) NOT NULL,
	[Address2] [varchar](500) NOT NULL,
	[Address3] [varchar](500) NULL,
	[Address4] [varchar](500) NULL,
	[Pincode] [int] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [date] NOT NULL,
	[OrganisationId] [int] NOT NULL,
 CONSTRAINT [PK_Driver] PRIMARY KEY CLUSTERED 
(
	[DriverId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DriverFeedback]    Script Date: 22-07-2018 06:43:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DriverFeedback](
	[DriverFeedBackId] [int] IDENTITY(1,1) NOT NULL,
	[DriverId] [int] NOT NULL,
	[HasYourDrivingInstructorEverBeenLateForALesson] [varchar](100) NULL,
	[HasYourDrivingInstructorEverMadeYouFeelUncomfortable] [varchar](100) NULL,
	[WouldYouRecommendThisDrivingSchoolToFriends] [varchar](100) NULL,
	[DoYouThinkThisSyllabusWillMakeYouASaferDriver] [varchar](100) NULL,
	[Comment] [varchar](max) NULL,
	[Rating] [int] NOT NULL,
	[CreatedDate] [date] NOT NULL,
	[CreatedBy] [int] NULL,
	[OrganisationId] [int] NOT NULL,
 CONSTRAINT [PK_DriverFeedback] PRIMARY KEY CLUSTERED 
(
	[DriverFeedBackId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DrivingSchool]    Script Date: 22-07-2018 06:43:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DrivingSchool](
	[DrivingSchoolId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](500) NOT NULL,
	[Address1] [varchar](500) NOT NULL,
	[Address2] [varchar](500) NULL,
	[Address3] [varchar](500) NULL,
	[Address4] [varchar](500) NULL,
	[Pincode] [int] NOT NULL,
	[Mobile] [bigint] NOT NULL,
	[Telephone] [varchar](100) NULL,
	[EmailId] [varchar](100) NULL,
	[OrganisationId] [int] NOT NULL,
 CONSTRAINT [PK_DrivingSchool] PRIMARY KEY CLUSTERED 
(
	[DrivingSchoolId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DrivingSchoolCar]    Script Date: 22-07-2018 06:43:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DrivingSchoolCar](
	[DrivingSchoolCarId] [int] NOT NULL,
	[DrivingSchoolId] [int] IDENTITY(1,1) NOT NULL,
	[CarId] [int] NOT NULL,
	[OrganisationId] [int] NOT NULL,
 CONSTRAINT [PK_DrivingSchoolCar] PRIMARY KEY CLUSTERED 
(
	[DrivingSchoolCarId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Organisation]    Script Date: 22-07-2018 06:43:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Organisation](
	[OrganisationId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Organisation_1] PRIMARY KEY CLUSTERED 
(
	[OrganisationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Student]    Script Date: 22-07-2018 06:43:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Student](
	[StudentId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Forenames] [nvarchar](100) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[DOB] [datetime2](7) NOT NULL,
	[Address1] [nvarchar](100) NOT NULL,
	[Address2] [nvarchar](100) NULL,
	[Address3] [nvarchar](100) NULL,
	[Address4] [nvarchar](100) NULL,
	[Postcode] [nvarchar](12) NOT NULL,
	[Telephone] [varchar](15) NULL,
	[Mobile] [varchar](15) NULL,
	[NINumber] [varchar](10) NULL,
	[BankAccountNumber] [varchar](10) NULL,
	[BankSortCode] [varchar](6) NULL,
	[BankAccountName] [nvarchar](100) NULL,
	[BankAddress1] [nvarchar](100) NULL,
	[BankAddress2] [nvarchar](100) NULL,
	[BankAddress3] [nvarchar](100) NULL,
	[BankAddress4] [nvarchar](100) NULL,
	[BankPostcode] [nvarchar](12) NULL,
	[BankTelephone] [varchar](15) NULL,
	[Email] [varchar](256) NOT NULL,
	[OrganisationId] [int] NOT NULL,
 CONSTRAINT [PK_[Student] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Template]    Script Date: 22-07-2018 06:43:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Template](
	[TemplateId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[FileName] [nvarchar](50) NOT NULL,
	[Type] [nvarchar](20) NOT NULL,
	[OrganisationId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Template] PRIMARY KEY CLUSTERED 
(
	[TemplateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[AspNetRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoles_Organisation] FOREIGN KEY([OrganisationId])
REFERENCES [dbo].[Organisation] ([OrganisationId])
GO
ALTER TABLE [dbo].[AspNetRoles] CHECK CONSTRAINT [FK_AspNetRoles_Organisation]
GO
ALTER TABLE [dbo].[AspNetUsersAlertSchedule]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUsersAlertSchedule_Alert1] FOREIGN KEY([AlertId])
REFERENCES [dbo].[Alert] ([AlertId])
GO
ALTER TABLE [dbo].[AspNetUsersAlertSchedule] CHECK CONSTRAINT [FK_AspNetUsersAlertSchedule_Alert1]
GO
ALTER TABLE [dbo].[Car]  WITH CHECK ADD  CONSTRAINT [FK_Car_Organisation] FOREIGN KEY([OrganisationId])
REFERENCES [dbo].[Organisation] ([OrganisationId])
GO
ALTER TABLE [dbo].[Car] CHECK CONSTRAINT [FK_Car_Organisation]
GO
ALTER TABLE [dbo].[CarType]  WITH CHECK ADD  CONSTRAINT [FK_CarType_Organisation] FOREIGN KEY([OrganisationId])
REFERENCES [dbo].[Organisation] ([OrganisationId])
GO
ALTER TABLE [dbo].[CarType] CHECK CONSTRAINT [FK_CarType_Organisation]
GO
ALTER TABLE [dbo].[Document]  WITH CHECK ADD  CONSTRAINT [FK_Document_DocumentType] FOREIGN KEY([DocumentTypeId])
REFERENCES [dbo].[DocumentType] ([DocumentTypeId])
GO
ALTER TABLE [dbo].[Document] CHECK CONSTRAINT [FK_Document_DocumentType]
GO
ALTER TABLE [dbo].[Document]  WITH CHECK ADD  CONSTRAINT [FK_Document_Organisation] FOREIGN KEY([OrganisationId])
REFERENCES [dbo].[Organisation] ([OrganisationId])
GO
ALTER TABLE [dbo].[Document] CHECK CONSTRAINT [FK_Document_Organisation]
GO
ALTER TABLE [dbo].[Driver]  WITH CHECK ADD  CONSTRAINT [FK_Driver_Organisation] FOREIGN KEY([OrganisationId])
REFERENCES [dbo].[Organisation] ([OrganisationId])
GO
ALTER TABLE [dbo].[Driver] CHECK CONSTRAINT [FK_Driver_Organisation]
GO
ALTER TABLE [dbo].[DriverFeedback]  WITH CHECK ADD  CONSTRAINT [FK_DriverFeedback_Driver] FOREIGN KEY([DriverId])
REFERENCES [dbo].[Driver] ([DriverId])
GO
ALTER TABLE [dbo].[DriverFeedback] CHECK CONSTRAINT [FK_DriverFeedback_Driver]
GO
ALTER TABLE [dbo].[DriverFeedback]  WITH CHECK ADD  CONSTRAINT [FK_DriverFeedback_DriverFeedback] FOREIGN KEY([DriverFeedBackId])
REFERENCES [dbo].[DriverFeedback] ([DriverFeedBackId])
GO
ALTER TABLE [dbo].[DriverFeedback] CHECK CONSTRAINT [FK_DriverFeedback_DriverFeedback]
GO
ALTER TABLE [dbo].[DriverFeedback]  WITH CHECK ADD  CONSTRAINT [FK_DriverFeedback_Organisation] FOREIGN KEY([OrganisationId])
REFERENCES [dbo].[Organisation] ([OrganisationId])
GO
ALTER TABLE [dbo].[DriverFeedback] CHECK CONSTRAINT [FK_DriverFeedback_Organisation]
GO
ALTER TABLE [dbo].[DrivingSchool]  WITH CHECK ADD  CONSTRAINT [FK_DrivingSchool_Organisation] FOREIGN KEY([OrganisationId])
REFERENCES [dbo].[Organisation] ([OrganisationId])
GO
ALTER TABLE [dbo].[DrivingSchool] CHECK CONSTRAINT [FK_DrivingSchool_Organisation]
GO
ALTER TABLE [dbo].[DrivingSchoolCar]  WITH CHECK ADD  CONSTRAINT [FK_DrivingSchoolCar_Car] FOREIGN KEY([CarId])
REFERENCES [dbo].[Car] ([CarId])
GO
ALTER TABLE [dbo].[DrivingSchoolCar] CHECK CONSTRAINT [FK_DrivingSchoolCar_Car]
GO
ALTER TABLE [dbo].[DrivingSchoolCar]  WITH CHECK ADD  CONSTRAINT [FK_DrivingSchoolCar_DrivingSchool] FOREIGN KEY([DrivingSchoolId])
REFERENCES [dbo].[DrivingSchool] ([DrivingSchoolId])
GO
ALTER TABLE [dbo].[DrivingSchoolCar] CHECK CONSTRAINT [FK_DrivingSchoolCar_DrivingSchool]
GO
ALTER TABLE [dbo].[DrivingSchoolCar]  WITH CHECK ADD  CONSTRAINT [FK_DrivingSchoolCar_Organisation] FOREIGN KEY([OrganisationId])
REFERENCES [dbo].[Organisation] ([OrganisationId])
GO
ALTER TABLE [dbo].[DrivingSchoolCar] CHECK CONSTRAINT [FK_DrivingSchoolCar_Organisation]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Organisation] FOREIGN KEY([OrganisationId])
REFERENCES [dbo].[Organisation] ([OrganisationId])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Organisation]
GO
USE [master]
GO
ALTER DATABASE [GadiSeekho] SET  READ_WRITE 
GO
