USE [master]
GO
/****** Object:  Database [DotNet]    Script Date: 5/21/2024 11:40:10 PM ******/
CREATE DATABASE [DotNet] ON  PRIMARY 
( NAME = N'DotNet', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\DotNet.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DotNet_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\DotNet_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DotNet].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DotNet] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DotNet] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DotNet] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DotNet] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DotNet] SET ARITHABORT OFF 
GO
ALTER DATABASE [DotNet] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DotNet] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DotNet] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DotNet] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DotNet] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DotNet] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DotNet] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DotNet] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DotNet] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DotNet] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DotNet] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DotNet] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DotNet] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DotNet] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DotNet] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DotNet] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DotNet] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DotNet] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DotNet] SET  MULTI_USER 
GO
ALTER DATABASE [DotNet] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DotNet] SET DB_CHAINING OFF 
GO
USE [DotNet]
GO
/****** Object:  Table [dbo].[Tbl_Blog]    Script Date: 5/21/2024 11:40:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Blog](
	[BlogId] [int] IDENTITY(1,1) NOT NULL,
	[BlogTitle] [varchar](50) NOT NULL,
	[BlogAuthor] [varchar](50) NOT NULL,
	[BlogContent] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Tbl_Blog] PRIMARY KEY CLUSTERED 
(
	[BlogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Pizza]    Script Date: 5/21/2024 11:40:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Pizza](
	[PizzaId] [int] IDENTITY(1,1) NOT NULL,
	[Pizza] [varchar](50) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Tbl_Pizza] PRIMARY KEY CLUSTERED 
(
	[PizzaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_PizzaExtra]    Script Date: 5/21/2024 11:40:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_PizzaExtra](
	[PizzaExtraId] [int] NOT NULL,
	[PizzaExtraName] [varchar](50) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Tbl_PizzaExtra] PRIMARY KEY CLUSTERED 
(
	[PizzaExtraId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_PizzaOrder]    Script Date: 5/21/2024 11:40:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_PizzaOrder](
	[PizzaOrderId] [int] IDENTITY(1,1) NOT NULL,
	[PizzaOrderInvoiceNo] [varchar](50) NOT NULL,
	[PizzaId] [int] NOT NULL,
	[TotalAmount] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Tbl_PizzaOrder] PRIMARY KEY CLUSTERED 
(
	[PizzaOrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_PizzaOrderDetail]    Script Date: 5/21/2024 11:40:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_PizzaOrderDetail](
	[PizzaOrderDetailId] [int] IDENTITY(1,1) NOT NULL,
	[PizzaOrderInvoiceNo] [varchar](50) NOT NULL,
	[PizzaExtraId] [int] NOT NULL,
 CONSTRAINT [PK_Tbl_PizzaOrderDetail] PRIMARY KEY CLUSTERED 
(
	[PizzaOrderDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Tbl_Blog] ON 

INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (1, N'update title', N'update author', N'update refit content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (3, N'string', N'string', N'string')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (15, N'string', N'updated', N'updated service')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (16, N'string 1', N'string 1', N'string 1')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (17, N' updated', N' updated', N' updated')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (18, N'dapper title', N'dapper author', N'dapper content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (19, N'adoDotNet', N'adoDotNet', N'adoDotNet')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (20, N'service', N'service', N'service')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (21, N'bla updated', N'bla updated', N'string')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (22, N'nlayer', N'nlayer', N'nlayer')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (23, N'title bla', N'author  Updated', N'Content  Updated')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (24, N'refit title', N'refit author', N'refit content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (25, N'Test Win Title', N'Test Win Author', N'Test Win Content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (26, N'Hello Title', N'Hello Author', N'Hello Content')
SET IDENTITY_INSERT [dbo].[Tbl_Blog] OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_Pizza] ON 

INSERT [dbo].[Tbl_Pizza] ([PizzaId], [Pizza], [Price]) VALUES (1, N'Brick Oven Pizza', CAST(2.50 AS Decimal(18, 2)))
INSERT [dbo].[Tbl_Pizza] ([PizzaId], [Pizza], [Price]) VALUES (2, N'California', CAST(2.00 AS Decimal(18, 2)))
INSERT [dbo].[Tbl_Pizza] ([PizzaId], [Pizza], [Price]) VALUES (3, N'Greek', CAST(1.00 AS Decimal(18, 2)))
INSERT [dbo].[Tbl_Pizza] ([PizzaId], [Pizza], [Price]) VALUES (4, N'New York', CAST(5.90 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Tbl_Pizza] OFF
GO
INSERT [dbo].[Tbl_PizzaExtra] ([PizzaExtraId], [PizzaExtraName], [Price]) VALUES (1, N'Cheese', CAST(3.90 AS Decimal(18, 2)))
INSERT [dbo].[Tbl_PizzaExtra] ([PizzaExtraId], [PizzaExtraName], [Price]) VALUES (2, N'Code ', CAST(9.00 AS Decimal(18, 2)))
INSERT [dbo].[Tbl_PizzaExtra] ([PizzaExtraId], [PizzaExtraName], [Price]) VALUES (3, N'Water', CAST(3.00 AS Decimal(18, 2)))
INSERT [dbo].[Tbl_PizzaExtra] ([PizzaExtraId], [PizzaExtraName], [Price]) VALUES (4, N'Chicken', CAST(7.00 AS Decimal(18, 2)))
INSERT [dbo].[Tbl_PizzaExtra] ([PizzaExtraId], [PizzaExtraName], [Price]) VALUES (5, N'Peepers', CAST(4.00 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[Tbl_PizzaOrder] ON 

INSERT [dbo].[Tbl_PizzaOrder] ([PizzaOrderId], [PizzaOrderInvoiceNo], [PizzaId], [TotalAmount]) VALUES (1, N'20240516103133', 1, CAST(16.50 AS Decimal(18, 2)))
INSERT [dbo].[Tbl_PizzaOrder] ([PizzaOrderId], [PizzaOrderInvoiceNo], [PizzaId], [TotalAmount]) VALUES (2, N'20240516103707', 4, CAST(19.80 AS Decimal(18, 2)))
INSERT [dbo].[Tbl_PizzaOrder] ([PizzaOrderId], [PizzaOrderInvoiceNo], [PizzaId], [TotalAmount]) VALUES (3, N'20240521131859', 4, CAST(15.90 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Tbl_PizzaOrder] OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_PizzaOrderDetail] ON 

INSERT [dbo].[Tbl_PizzaOrderDetail] ([PizzaOrderDetailId], [PizzaOrderInvoiceNo], [PizzaExtraId]) VALUES (1, N'20240516103707', 3)
INSERT [dbo].[Tbl_PizzaOrderDetail] ([PizzaOrderDetailId], [PizzaOrderInvoiceNo], [PizzaExtraId]) VALUES (2, N'20240516103707', 4)
INSERT [dbo].[Tbl_PizzaOrderDetail] ([PizzaOrderDetailId], [PizzaOrderInvoiceNo], [PizzaExtraId]) VALUES (3, N'20240516103707', 1)
INSERT [dbo].[Tbl_PizzaOrderDetail] ([PizzaOrderDetailId], [PizzaOrderInvoiceNo], [PizzaExtraId]) VALUES (4, N'20240521131859', 3)
INSERT [dbo].[Tbl_PizzaOrderDetail] ([PizzaOrderDetailId], [PizzaOrderInvoiceNo], [PizzaExtraId]) VALUES (5, N'20240521131859', 4)
INSERT [dbo].[Tbl_PizzaOrderDetail] ([PizzaOrderDetailId], [PizzaOrderInvoiceNo], [PizzaExtraId]) VALUES (6, N'20240521131859', 3)
SET IDENTITY_INSERT [dbo].[Tbl_PizzaOrderDetail] OFF
GO
USE [master]
GO
ALTER DATABASE [DotNet] SET  READ_WRITE 
GO
