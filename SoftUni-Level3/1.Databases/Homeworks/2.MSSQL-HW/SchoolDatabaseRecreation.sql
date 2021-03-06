USE [master]
GO
/****** Object:  Database [School]    Script Date: 8.2.2015 г. 18:42:32 ч. ******/
CREATE DATABASE [School]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'School', FILENAME = N'C:\Users\adm-bgsstnv\School.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'School_log', FILENAME = N'C:\Users\adm-bgsstnv\School_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [School] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [School].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [School] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [School] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [School] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [School] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [School] SET ARITHABORT OFF 
GO
ALTER DATABASE [School] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [School] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [School] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [School] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [School] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [School] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [School] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [School] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [School] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [School] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [School] SET  DISABLE_BROKER 
GO
ALTER DATABASE [School] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [School] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [School] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [School] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [School] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [School] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [School] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [School] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [School] SET  MULTI_USER 
GO
ALTER DATABASE [School] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [School] SET DB_CHAINING OFF 
GO
ALTER DATABASE [School] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [School] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [School]
GO
/****** Object:  User [emz]    Script Date: 8.2.2015 г. 18:42:32 ч. ******/
CREATE USER [emz] FOR LOGIN [emz] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [emz]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [emz]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [emz]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [emz]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [emz]
GO
ALTER ROLE [db_datareader] ADD MEMBER [emz]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [emz]
GO
ALTER ROLE [db_denydatareader] ADD MEMBER [emz]
GO
ALTER ROLE [db_denydatawriter] ADD MEMBER [emz]
GO
/****** Object:  Table [dbo].[Classes]    Script Date: 8.2.2015 г. 18:42:32 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Classes](
	[ID] [int] NOT NULL,
	[Name] [nchar](50) NOT NULL,
	[MaxStudents] [int] NULL,
 CONSTRAINT [PK_Classes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Students]    Script Date: 8.2.2015 г. 18:42:32 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[ID] [int] NOT NULL,
	[Name] [nchar](50) NOT NULL,
	[Age] [int] NOT NULL,
	[PhoneNumber] [nchar](50) NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Classes] ([ID], [Name], [MaxStudents]) VALUES (1, N'C#                                                ', 250)
INSERT [dbo].[Classes] ([ID], [Name], [MaxStudents]) VALUES (2, N'Java                                              ', 250)
INSERT [dbo].[Classes] ([ID], [Name], [MaxStudents]) VALUES (3, N'JavaScript                                        ', 500)
INSERT [dbo].[Students] ([ID], [Name], [Age], [PhoneNumber]) VALUES (1, N'Stoyan                                            ', 28, N'359111111234                                      ')
INSERT [dbo].[Students] ([ID], [Name], [Age], [PhoneNumber]) VALUES (2, N'Petrov                                            ', 24, N'3591214154234                                     ')
INSERT [dbo].[Students] ([ID], [Name], [Age], [PhoneNumber]) VALUES (3, N'Ivanov                                            ', 13, N'001323829293                                      ')
ALTER TABLE [dbo].[Classes]  WITH CHECK ADD  CONSTRAINT [FK_Classes_Students] FOREIGN KEY([ID])
REFERENCES [dbo].[Students] ([ID])
GO
ALTER TABLE [dbo].[Classes] CHECK CONSTRAINT [FK_Classes_Students]
GO
USE [master]
GO
ALTER DATABASE [School] SET  READ_WRITE 
GO
