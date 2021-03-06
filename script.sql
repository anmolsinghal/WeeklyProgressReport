USE [master]
GO
/****** Object:  Database [WPRDB]    Script Date: 6/20/2017 10:39:44 AM ******/
CREATE DATABASE [WPRDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'WPRDB', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\WPRDB.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'WPRDB_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\WPRDB_log.ldf' , SIZE = 784KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [WPRDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WPRDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WPRDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WPRDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WPRDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WPRDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WPRDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [WPRDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [WPRDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WPRDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WPRDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WPRDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [WPRDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WPRDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WPRDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WPRDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WPRDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [WPRDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WPRDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WPRDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WPRDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WPRDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WPRDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [WPRDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WPRDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [WPRDB] SET  MULTI_USER 
GO
ALTER DATABASE [WPRDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WPRDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [WPRDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [WPRDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [WPRDB]
GO
/****** Object:  Table [dbo].[Configurations]    Script Date: 6/20/2017 10:39:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Configurations](
	[ConfigurationId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](250) NULL,
 CONSTRAINT [PK_Configuration] PRIMARY KEY CLUSTERED 
(
	[ConfigurationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ConfigurationValues]    Script Date: 6/20/2017 10:39:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ConfigurationValues](
	[ConfigurationValueId] [int] IDENTITY(1,1) NOT NULL,
	[ConfigurationId] [int] NULL,
	[ValueId] [int] NULL,
	[Value] [varchar](100) NULL,
 CONSTRAINT [PK_ConfigurationValues] PRIMARY KEY CLUSTERED 
(
	[ConfigurationValueId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 6/20/2017 10:39:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [varchar](250) NULL,
	[ContactNumber] [varchar](50) NULL,
	[Fax] [varchar](50) NULL,
	[EmailId] [varchar](250) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[LastUpdate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Issues]    Script Date: 6/20/2017 10:39:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Issues](
	[IssueId] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](200) NULL,
	[IssueTypeId] [int] NULL,
	[IssueSeverityId] [int] NULL,
	[IssueRaisedDate] [datetime] NULL,
	[AssignedTo] [int] NULL,
	[AssignedDate] [datetime] NULL,
	[PlannedClosureDate] [datetime] NULL,
	[ActualClosureDate] [datetime] NULL,
	[IssueStatus] [int] NULL,
	[Remarks] [varchar](500) NULL,
	[WeeklyProjectReportId] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[LastUpdated] [datetime] NULL,
	[UpdatedBy] [int] NULL,
 CONSTRAINT [PK_Issues] PRIMARY KEY CLUSTERED 
(
	[IssueId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LeavePlans]    Script Date: 6/20/2017 10:39:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LeavePlans](
	[LeavePlanId] [int] NOT NULL,
	[UserId] [int] NULL,
	[LeavePurpose] [varchar](250) NULL,
	[WeeklyProjectReportId] [int] NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[LastUpdated] [datetime] NULL,
	[UpdatedBy] [int] NULL,
 CONSTRAINT [PK_LeavePlans] PRIMARY KEY CLUSTERED 
(
	[LeavePlanId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NextWeekPlan]    Script Date: 6/20/2017 10:39:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NextWeekPlan](
	[NextWeekPlanId] [int] NOT NULL,
	[Task] [varchar](200) NULL,
	[WeeklyProjectReportId] [int] NULL,
	[Remarks] [varchar](500) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[LastUpdated] [datetime] NULL,
	[UpdatedBy] [int] NULL,
 CONSTRAINT [PK_NextWeekPlan] PRIMARY KEY CLUSTERED 
(
	[NextWeekPlanId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProjectAccomplishments]    Script Date: 6/20/2017 10:39:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProjectAccomplishments](
	[ProjectAccomplishmentId] [int] NOT NULL,
	[WeeklyProjectReportId] [int] NULL,
	[Accomplishment] [varchar](500) NULL,
	[Remarks] [varchar](500) NULL,
	[UserId] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[LastUpdated] [datetime] NULL,
	[UpdatedBy] [int] NULL,
 CONSTRAINT [PK_ProjectAccomplishments] PRIMARY KEY CLUSTERED 
(
	[ProjectAccomplishmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProjectMilestones]    Script Date: 6/20/2017 10:39:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProjectMilestones](
	[Id] [int] NOT NULL,
	[Milestone] [varchar](200) NULL,
	[StatusId] [int] NULL,
	[WeeklyProjectReportId] [int] NULL,
	[PlannedDate] [datetime] NULL,
	[ActualCompleteDate] [datetime] NULL,
 CONSTRAINT [PK_ProjectMilestones] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Projects]    Script Date: 6/20/2017 10:39:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Projects](
	[ProjectId] [int] IDENTITY(1,1) NOT NULL,
	[ProjectName] [varchar](250) NULL,
	[UserId] [int] NULL,
	[ProjectCode] [varchar](250) NULL,
	[CustomerId] [int] NULL,
	[TeamSize] [int] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[LastUpdated] [datetime] NULL,
	[UpdatedBy] [int] NULL,
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProjectTeamMembers]    Script Date: 6/20/2017 10:39:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectTeamMembers](
	[ProjectTeamMemberId] [int] IDENTITY(1,1) NOT NULL,
	[ProjectId] [int] NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_ProjectTeamMembers] PRIMARY KEY CLUSTERED 
(
	[ProjectTeamMemberId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Risks]    Script Date: 6/20/2017 10:39:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Risks](
	[RiskId] [int] IDENTITY(1,1) NOT NULL,
	[RiskDescription] [varchar](200) NULL,
	[MitigationPlan] [varchar](200) NULL,
	[PlannedMitigationPlanDate] [datetime] NULL,
	[ActualMitigationPlanDate] [datetime] NULL,
	[RiskStatusId] [int] NULL,
	[StatusLastUpdated] [datetime] NULL,
	[ConfigurationPlan] [varchar](150) NULL,
	[ActualConfigurationDate] [datetime] NULL,
	[Remarks] [varchar](500) NULL,
	[WeeklyProjectReportId] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[LastUpdated] [datetime] NULL,
	[UpdatedBy] [int] NULL,
 CONSTRAINT [PK_Risks] PRIMARY KEY CLUSTERED 
(
	[RiskId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 6/20/2017 10:39:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 6/20/2017 10:39:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](250) NULL,
	[EmailId] [nvarchar](250) NULL,
	[FirstName] [nvarchar](250) NULL,
	[LastName] [nvarchar](250) NULL,
	[RoleId] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[LastUpdated] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WeeklyProjectReports]    Script Date: 6/20/2017 10:39:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WeeklyProjectReports](
	[Id] [int] NOT NULL,
	[ProjectId] [int] NULL,
	[ProjectCurrentPhaseId] [int] NULL,
	[ReviewDate] [datetime] NULL,
	[ProjectHealthByScheduleStatusId] [int] NULL,
	[ScheduleRemarks] [varchar](250) NULL,
	[ProjectHealthByEffortStatusId] [int] NULL,
	[EffortRemarks] [varchar](200) NULL,
	[ProjectHealthByQualityStatusId] [int] NULL,
	[QualityRemarks] [varchar](500) NULL,
	[ProjectProgressUpdate] [varchar](500) NULL,
	[ProjectImpedimentDetails] [varchar](500) NULL,
	[ExecuteSummary] [varchar](500) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[LastUpdated] [datetime] NULL,
	[UpdatedBy] [int] NULL,
 CONSTRAINT [PK_WeekLogProjectReport] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Configurations] ON 

INSERT [dbo].[Configurations] ([ConfigurationId], [Name]) VALUES (1, N'Project Current Phase')
INSERT [dbo].[Configurations] ([ConfigurationId], [Name]) VALUES (2, N'Risk Status')
INSERT [dbo].[Configurations] ([ConfigurationId], [Name]) VALUES (3, N'Project Health Parameters Status')
INSERT [dbo].[Configurations] ([ConfigurationId], [Name]) VALUES (4, N'Milestone Status')
INSERT [dbo].[Configurations] ([ConfigurationId], [Name]) VALUES (5, N'Issue Status')
INSERT [dbo].[Configurations] ([ConfigurationId], [Name]) VALUES (6, N'Issue Type')
INSERT [dbo].[Configurations] ([ConfigurationId], [Name]) VALUES (7, N'Issue Severity')
SET IDENTITY_INSERT [dbo].[Configurations] OFF
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([CustomerId], [CustomerName], [ContactNumber], [Fax], [EmailId], [IsActive], [IsDeleted], [CreatedDate], [CreatedBy], [LastUpdate], [UpdatedBy]) VALUES (1, N'Abc', N'9876543210', N'+919784596321', N'abc@ids.com', 1, 0, CAST(N'2017-06-19 15:07:46.273' AS DateTime), 1, CAST(N'2017-06-19 15:07:46.273' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Customers] OFF
SET IDENTITY_INSERT [dbo].[Projects] ON 

INSERT [dbo].[Projects] ([ProjectId], [ProjectName], [UserId], [ProjectCode], [CustomerId], [TeamSize], [IsActive], [IsDeleted], [CreatedDate], [CreatedBy], [LastUpdated], [UpdatedBy]) VALUES (1, N'Test Project', NULL, N'1234', 1, 4, 1, 0, CAST(N'2017-06-19 15:07:46.273' AS DateTime), 1, CAST(N'2017-06-19 15:07:46.273' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Projects] OFF
ALTER TABLE [dbo].[ConfigurationValues]  WITH CHECK ADD  CONSTRAINT [FK_ConfigurationValues_Configuration] FOREIGN KEY([ConfigurationId])
REFERENCES [dbo].[Configurations] ([ConfigurationId])
GO
ALTER TABLE [dbo].[ConfigurationValues] CHECK CONSTRAINT [FK_ConfigurationValues_Configuration]
GO
ALTER TABLE [dbo].[Issues]  WITH CHECK ADD  CONSTRAINT [FK_Issues_WeeklyProjectReport] FOREIGN KEY([WeeklyProjectReportId])
REFERENCES [dbo].[WeeklyProjectReports] ([Id])
GO
ALTER TABLE [dbo].[Issues] CHECK CONSTRAINT [FK_Issues_WeeklyProjectReport]
GO
ALTER TABLE [dbo].[LeavePlans]  WITH CHECK ADD  CONSTRAINT [FK_LeavePlans_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[LeavePlans] CHECK CONSTRAINT [FK_LeavePlans_Users]
GO
ALTER TABLE [dbo].[LeavePlans]  WITH CHECK ADD  CONSTRAINT [FK_LeavePlans_WeeklyProjectReport] FOREIGN KEY([WeeklyProjectReportId])
REFERENCES [dbo].[WeeklyProjectReports] ([Id])
GO
ALTER TABLE [dbo].[LeavePlans] CHECK CONSTRAINT [FK_LeavePlans_WeeklyProjectReport]
GO
ALTER TABLE [dbo].[NextWeekPlan]  WITH CHECK ADD  CONSTRAINT [FK_NextWeekPlan_WeeklyProjectReport] FOREIGN KEY([WeeklyProjectReportId])
REFERENCES [dbo].[WeeklyProjectReports] ([Id])
GO
ALTER TABLE [dbo].[NextWeekPlan] CHECK CONSTRAINT [FK_NextWeekPlan_WeeklyProjectReport]
GO
ALTER TABLE [dbo].[ProjectAccomplishments]  WITH CHECK ADD  CONSTRAINT [FK_ProjectAccomplishments_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[ProjectAccomplishments] CHECK CONSTRAINT [FK_ProjectAccomplishments_Users]
GO
ALTER TABLE [dbo].[ProjectAccomplishments]  WITH CHECK ADD  CONSTRAINT [FK_ProjectAccomplishments_WeeklyProjectReport] FOREIGN KEY([WeeklyProjectReportId])
REFERENCES [dbo].[WeeklyProjectReports] ([Id])
GO
ALTER TABLE [dbo].[ProjectAccomplishments] CHECK CONSTRAINT [FK_ProjectAccomplishments_WeeklyProjectReport]
GO
ALTER TABLE [dbo].[ProjectMilestones]  WITH CHECK ADD  CONSTRAINT [FK_ProjectMilestones_WeeklyProjectReport] FOREIGN KEY([WeeklyProjectReportId])
REFERENCES [dbo].[WeeklyProjectReports] ([Id])
GO
ALTER TABLE [dbo].[ProjectMilestones] CHECK CONSTRAINT [FK_ProjectMilestones_WeeklyProjectReport]
GO
ALTER TABLE [dbo].[Projects]  WITH CHECK ADD  CONSTRAINT [FK_Project_Customers] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([CustomerId])
GO
ALTER TABLE [dbo].[Projects] CHECK CONSTRAINT [FK_Project_Customers]
GO
ALTER TABLE [dbo].[Projects]  WITH CHECK ADD  CONSTRAINT [FK_Project_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Projects] CHECK CONSTRAINT [FK_Project_Users]
GO
ALTER TABLE [dbo].[ProjectTeamMembers]  WITH CHECK ADD  CONSTRAINT [FK_ProjectTeamMembers_Project] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Projects] ([ProjectId])
GO
ALTER TABLE [dbo].[ProjectTeamMembers] CHECK CONSTRAINT [FK_ProjectTeamMembers_Project]
GO
ALTER TABLE [dbo].[ProjectTeamMembers]  WITH CHECK ADD  CONSTRAINT [FK_ProjectTeamMembers_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[ProjectTeamMembers] CHECK CONSTRAINT [FK_ProjectTeamMembers_Users]
GO
ALTER TABLE [dbo].[Risks]  WITH CHECK ADD  CONSTRAINT [FK_Risks_WeeklyProjectReport] FOREIGN KEY([WeeklyProjectReportId])
REFERENCES [dbo].[WeeklyProjectReports] ([Id])
GO
ALTER TABLE [dbo].[Risks] CHECK CONSTRAINT [FK_Risks_WeeklyProjectReport]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([RoleId])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles]
GO
ALTER TABLE [dbo].[WeeklyProjectReports]  WITH CHECK ADD  CONSTRAINT [FK_WeeklyProjectReport_Project] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Projects] ([ProjectId])
GO
ALTER TABLE [dbo].[WeeklyProjectReports] CHECK CONSTRAINT [FK_WeeklyProjectReport_Project]
GO
USE [master]
GO
ALTER DATABASE [WPRDB] SET  READ_WRITE 
GO
