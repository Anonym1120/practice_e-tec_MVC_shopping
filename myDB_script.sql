USE [master]
GO
/****** Object:  Database [myDB]    Script Date: 2021/3/10 下午 03:02:02 ******/
CREATE DATABASE [myDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'myDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\myDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'myDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\myDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [myDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [myDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [myDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [myDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [myDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [myDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [myDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [myDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [myDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [myDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [myDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [myDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [myDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [myDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [myDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [myDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [myDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [myDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [myDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [myDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [myDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [myDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [myDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [myDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [myDB] SET RECOVERY FULL 
GO
ALTER DATABASE [myDB] SET  MULTI_USER 
GO
ALTER DATABASE [myDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [myDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [myDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [myDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [myDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [myDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'myDB', N'ON'
GO
ALTER DATABASE [myDB] SET QUERY_STORE = OFF
GO
USE [myDB]
GO
/****** Object:  Table [dbo].[tMember]    Script Date: 2021/3/10 下午 03:02:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tMember](
	[fId] [int] IDENTITY(1,1) NOT NULL,
	[fUserId] [nvarchar](50) NULL,
	[fPassword] [nvarchar](50) NULL,
	[fName] [nvarchar](50) NULL,
	[fEmail] [nvarchar](50) NULL,
	[fLevel] [nvarchar](50) NULL,
 CONSTRAINT [PK_tMember] PRIMARY KEY CLUSTERED 
(
	[fId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tOrder]    Script Date: 2021/3/10 下午 03:02:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tOrder](
	[fId] [int] IDENTITY(1,1) NOT NULL,
	[fOrderId] [nvarchar](50) NULL,
	[fUserId] [nvarchar](50) NULL,
	[fReceiver] [nvarchar](50) NULL,
	[fAddress] [nvarchar](50) NULL,
	[fDate] [datetime] NULL,
 CONSTRAINT [PK_tOrder] PRIMARY KEY CLUSTERED 
(
	[fId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tOrderDetail]    Script Date: 2021/3/10 下午 03:02:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tOrderDetail](
	[fId] [int] IDENTITY(1,1) NOT NULL,
	[fOrderId] [nvarchar](50) NULL,
	[fUserId] [nvarchar](50) NULL,
	[fPId] [nvarchar](50) NULL,
	[fName] [nvarchar](50) NULL,
	[fPrice] [int] NULL,
	[fQty] [int] NULL,
	[fIsApproved] [nvarchar](50) NULL,
 CONSTRAINT [PK_fOrderDetail] PRIMARY KEY CLUSTERED 
(
	[fId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tProduct]    Script Date: 2021/3/10 下午 03:02:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tProduct](
	[fId] [int] IDENTITY(1,1) NOT NULL,
	[fPId] [nvarchar](50) NULL,
	[fName] [nvarchar](50) NULL,
	[fPrice] [int] NULL,
	[fImg] [nvarchar](50) NULL,
 CONSTRAINT [PK_tProduct] PRIMARY KEY CLUSTERED 
(
	[fId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tMember] ON 

INSERT [dbo].[tMember] ([fId], [fUserId], [fPassword], [fName], [fEmail], [fLevel]) VALUES (1, N'user', N'123', N'user', N'user@gmail.com', N'1')
INSERT [dbo].[tMember] ([fId], [fUserId], [fPassword], [fName], [fEmail], [fLevel]) VALUES (2, N'user1', N'123', N'user1', N'user1@gmail.com', N'1')
INSERT [dbo].[tMember] ([fId], [fUserId], [fPassword], [fName], [fEmail], [fLevel]) VALUES (3, N'user2', N'123', N'user2', N'user2@gmail.com', N'1')
INSERT [dbo].[tMember] ([fId], [fUserId], [fPassword], [fName], [fEmail], [fLevel]) VALUES (4, N'root', N'123', N'root', N'root@gmail.com', N'2')
INSERT [dbo].[tMember] ([fId], [fUserId], [fPassword], [fName], [fEmail], [fLevel]) VALUES (5, N'root1', N'123', N'root1', N'root1@gmail.com', N'2')
INSERT [dbo].[tMember] ([fId], [fUserId], [fPassword], [fName], [fEmail], [fLevel]) VALUES (6, N'root2', N'123', N'root2', N'root2@gmail.com', N'2')
INSERT [dbo].[tMember] ([fId], [fUserId], [fPassword], [fName], [fEmail], [fLevel]) VALUES (7, N'TIAN', N'1120', N'TIAN', N'TIAN@gmail.com', N'2')
INSERT [dbo].[tMember] ([fId], [fUserId], [fPassword], [fName], [fEmail], [fLevel]) VALUES (8, N'XIN', N'0422', N'XIN', N'XIN@gmail.com', N'2')
SET IDENTITY_INSERT [dbo].[tMember] OFF
GO
SET IDENTITY_INSERT [dbo].[tProduct] ON 

INSERT [dbo].[tProduct] ([fId], [fPId], [fName], [fPrice], [fImg]) VALUES (1, N'001', N'UX393EA', 55000, N'UX393EA.jpg')
INSERT [dbo].[tProduct] ([fId], [fPId], [fName], [fPrice], [fImg]) VALUES (2, N'002', N'UX425EA', 39000, N'UX425EA.jpg')
INSERT [dbo].[tProduct] ([fId], [fPId], [fName], [fPrice], [fImg]) VALUES (3, N'003', N'UX463FL', 33000, N'UX463FL.jpg')
INSERT [dbo].[tProduct] ([fId], [fPId], [fName], [fPrice], [fImg]) VALUES (5, N'004', N'S531FL', 27903, N'../Content/.jpg')
INSERT [dbo].[tProduct] ([fId], [fPId], [fName], [fPrice], [fImg]) VALUES (6, N'004', N'S531FL', 27900, N'../Content/004.jpg')
SET IDENTITY_INSERT [dbo].[tProduct] OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自動編號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tMember', @level2type=N'COLUMN',@level2name=N'fId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'會員帳號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tMember', @level2type=N'COLUMN',@level2name=N'fUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'會員密碼' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tMember', @level2type=N'COLUMN',@level2name=N'fPassword'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'會員姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tMember', @level2type=N'COLUMN',@level2name=N'fName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'會員信箱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tMember', @level2type=N'COLUMN',@level2name=N'fEmail'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'權限' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tMember', @level2type=N'COLUMN',@level2name=N'fLevel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自動編號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tOrder', @level2type=N'COLUMN',@level2name=N'fId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'訂單編號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tOrder', @level2type=N'COLUMN',@level2name=N'fOrderId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'會員帳號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tOrder', @level2type=N'COLUMN',@level2name=N'fUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收件人姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tOrder', @level2type=N'COLUMN',@level2name=N'fReceiver'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收件人地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tOrder', @level2type=N'COLUMN',@level2name=N'fAddress'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'訂單日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tOrder', @level2type=N'COLUMN',@level2name=N'fDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自動編號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tOrderDetail', @level2type=N'COLUMN',@level2name=N'fId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'訂單編號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tOrderDetail', @level2type=N'COLUMN',@level2name=N'fOrderId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'會員帳號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tOrderDetail', @level2type=N'COLUMN',@level2name=N'fUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'產品編號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tOrderDetail', @level2type=N'COLUMN',@level2name=N'fPId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'產品名稱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tOrderDetail', @level2type=N'COLUMN',@level2name=N'fName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'產品價格' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tOrderDetail', @level2type=N'COLUMN',@level2name=N'fPrice'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'產品數量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tOrderDetail', @level2type=N'COLUMN',@level2name=N'fQty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自動編號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tProduct', @level2type=N'COLUMN',@level2name=N'fId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'產品編號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tProduct', @level2type=N'COLUMN',@level2name=N'fPId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'產品名稱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tProduct', @level2type=N'COLUMN',@level2name=N'fName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'產品價格' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tProduct', @level2type=N'COLUMN',@level2name=N'fPrice'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'產品圖片' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tProduct', @level2type=N'COLUMN',@level2name=N'fImg'
GO
USE [master]
GO
ALTER DATABASE [myDB] SET  READ_WRITE 
GO
