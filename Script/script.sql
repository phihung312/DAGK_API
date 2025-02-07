USE [master]
GO
/****** Object:  Database [SprintRetrospective]    Script Date: 10/28/2020 4:58:25 PM ******/
CREATE DATABASE [SprintRetrospective]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SprintRetrospective', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\SprintRetrospective.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SprintRetrospective_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\SprintRetrospective_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SprintRetrospective] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SprintRetrospective].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SprintRetrospective] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SprintRetrospective] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SprintRetrospective] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SprintRetrospective] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SprintRetrospective] SET ARITHABORT OFF 
GO
ALTER DATABASE [SprintRetrospective] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SprintRetrospective] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SprintRetrospective] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SprintRetrospective] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SprintRetrospective] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SprintRetrospective] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SprintRetrospective] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SprintRetrospective] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SprintRetrospective] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SprintRetrospective] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SprintRetrospective] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SprintRetrospective] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SprintRetrospective] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SprintRetrospective] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SprintRetrospective] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SprintRetrospective] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SprintRetrospective] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SprintRetrospective] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SprintRetrospective] SET  MULTI_USER 
GO
ALTER DATABASE [SprintRetrospective] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SprintRetrospective] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SprintRetrospective] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SprintRetrospective] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [SprintRetrospective] SET DELAYED_DURABILITY = DISABLED 
GO
USE [SprintRetrospective]
GO
/****** Object:  Table [dbo].[Board]    Script Date: 10/28/2020 4:58:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Board](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Link] [nvarchar](500) NULL,
	[UserId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BoardDetail]    Script Date: 10/28/2020 4:58:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BoardDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Content] [nvarchar](1000) NULL,
	[ColumnId] [int] NULL,
	[BoardId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Column]    Script Date: 10/28/2020 4:58:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Column](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](1000) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FacebookAccount]    Script Date: 10/28/2020 4:58:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FacebookAccount](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[FacebookId] [int] NULL,
	[Token] [varchar](200) NULL,
 CONSTRAINT [PK_Facebook_Account] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GoogleAccount]    Script Date: 10/28/2020 4:58:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GoogleAccount](
	[Id] [int] NOT NULL,
	[GoogleId] [int] NULL,
	[Token] [varchar](200) NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_Google_Account] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 10/28/2020 4:58:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NULL,
	[PassWord] [varchar](200) NULL,
	[FullName] [nvarchar](200) NULL,
	[Email] [varchar](100) NULL,
	[Phone] [char](10) NULL,
 CONSTRAINT [PK_Users_Account] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Board] ON 

INSERT [dbo].[Board] ([Id], [Name], [Link], [UserId]) VALUES (1, N'Bảng 1', NULL, 3)
INSERT [dbo].[Board] ([Id], [Name], [Link], [UserId]) VALUES (2, N'bảng 2', NULL, 3)
INSERT [dbo].[Board] ([Id], [Name], [Link], [UserId]) VALUES (3, N'bảng 3', NULL, 3)
INSERT [dbo].[Board] ([Id], [Name], [Link], [UserId]) VALUES (4, N'bảng 4', NULL, 3)
INSERT [dbo].[Board] ([Id], [Name], [Link], [UserId]) VALUES (5, N'bảng 5', NULL, 3)
INSERT [dbo].[Board] ([Id], [Name], [Link], [UserId]) VALUES (6, N'bảng 6', NULL, 3)
INSERT [dbo].[Board] ([Id], [Name], [Link], [UserId]) VALUES (7, N'bảng 7', NULL, 3)
INSERT [dbo].[Board] ([Id], [Name], [Link], [UserId]) VALUES (8, N'bảng 8', NULL, 3)
INSERT [dbo].[Board] ([Id], [Name], [Link], [UserId]) VALUES (9, N'bảng 9', NULL, 3)
INSERT [dbo].[Board] ([Id], [Name], [Link], [UserId]) VALUES (10, N'bảng 10', NULL, 3)
INSERT [dbo].[Board] ([Id], [Name], [Link], [UserId]) VALUES (11, N'bảng 11', NULL, 3)
INSERT [dbo].[Board] ([Id], [Name], [Link], [UserId]) VALUES (12, N'bảng 12', NULL, 3)
INSERT [dbo].[Board] ([Id], [Name], [Link], [UserId]) VALUES (13, N'bảng 13', NULL, 3)
SET IDENTITY_INSERT [dbo].[Board] OFF
SET IDENTITY_INSERT [dbo].[Column] ON 

INSERT [dbo].[Column] ([Id], [Name]) VALUES (1, N'Went Well')
INSERT [dbo].[Column] ([Id], [Name]) VALUES (2, N'To Improve')
INSERT [dbo].[Column] ([Id], [Name]) VALUES (3, N'ActionItem')
SET IDENTITY_INSERT [dbo].[Column] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [UserName], [PassWord], [FullName], [Email], [Phone]) VALUES (3, N'admin@gmail.com', N'123456', N'Hung', N'admin@gmail.com', N'0123456789')
SET IDENTITY_INSERT [dbo].[User] OFF
ALTER TABLE [dbo].[BoardDetail]  WITH CHECK ADD  CONSTRAINT [FK_BoardDetail_Board] FOREIGN KEY([BoardId])
REFERENCES [dbo].[Board] ([Id])
GO
ALTER TABLE [dbo].[BoardDetail] CHECK CONSTRAINT [FK_BoardDetail_Board]
GO
ALTER TABLE [dbo].[BoardDetail]  WITH CHECK ADD  CONSTRAINT [FK_BoardDetail_Column] FOREIGN KEY([Id])
REFERENCES [dbo].[Column] ([Id])
GO
ALTER TABLE [dbo].[BoardDetail] CHECK CONSTRAINT [FK_BoardDetail_Column]
GO
USE [master]
GO
ALTER DATABASE [SprintRetrospective] SET  READ_WRITE 
GO
