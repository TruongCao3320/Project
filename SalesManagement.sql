USE [master]
GO
/****** Object:  Database [SalesManagement]    Script Date: 23/10/2021 22:37:51 ******/
CREATE DATABASE [SalesManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SalesManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\SalesManagement.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SalesManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\SalesManagement_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [SalesManagement] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SalesManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SalesManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SalesManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SalesManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SalesManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SalesManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [SalesManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SalesManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SalesManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SalesManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SalesManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SalesManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SalesManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SalesManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SalesManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SalesManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SalesManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SalesManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SalesManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SalesManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SalesManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SalesManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SalesManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SalesManagement] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SalesManagement] SET  MULTI_USER 
GO
ALTER DATABASE [SalesManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SalesManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SalesManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SalesManagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SalesManagement] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SalesManagement] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [SalesManagement] SET QUERY_STORE = OFF
GO
USE [SalesManagement]
GO
/****** Object:  Table [dbo].[Member]    Script Date: 23/10/2021 22:37:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Member](
	[MemberID] [int] NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[CompanyName] [varchar](50) NOT NULL,
	[City] [varchar](15) NOT NULL,
	[Country] [varchar](15) NOT NULL,
	[Password] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Member] PRIMARY KEY CLUSTERED 
(
	[MemberID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Oder]    Script Date: 23/10/2021 22:37:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Oder](
	[OrderID] [int] NOT NULL,
	[MemberID] [int] NOT NULL,
	[OrderDate] [datetime] NOT NULL,
	[RequiredDate] [datetime] NULL,
	[ShippedDate] [datetime] NULL,
	[Freight] [money] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 23/10/2021 22:37:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[OrderID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[UnitPrice] [money] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Discount] [float] NOT NULL,
 CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC,
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 23/10/2021 22:37:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductID] [int] NOT NULL,
	[CategoryID] [int] NOT NULL,
	[ProductName] [varchar](40) NOT NULL,
	[Weight] [varchar](20) NOT NULL,
	[UnitPrice] [money] NOT NULL,
	[UnitsInStock] [int] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Member] ([MemberID], [Email], [CompanyName], [City], [Country], [Password]) VALUES (1, N'truongcv@gmail.com', N'SPS', N'Ho Chi Minh', N'Viet Nam', N'123')
INSERT [dbo].[Member] ([MemberID], [Email], [CompanyName], [City], [Country], [Password]) VALUES (2, N'minhthu@gmail.com', N'SMEntertainment', N'Seoul', N'Korean', N'aaa')
INSERT [dbo].[Member] ([MemberID], [Email], [CompanyName], [City], [Country], [Password]) VALUES (3, N'trantuan@gmail.com', N'SamSung', N'Sa Pa', N'Viet Nam', N'456')
INSERT [dbo].[Member] ([MemberID], [Email], [CompanyName], [City], [Country], [Password]) VALUES (4, N'tranthanh1@gmail.com', N'DienQuanEntertaiment', N'Ho Chi Minh', N'Ustralia', N'789')
INSERT [dbo].[Member] ([MemberID], [Email], [CompanyName], [City], [Country], [Password]) VALUES (5, N'admin@fstore.com', N'FPTShop', N'Da Nang', N'Viet Nam', N'123')
GO
INSERT [dbo].[Oder] ([OrderID], [MemberID], [OrderDate], [RequiredDate], [ShippedDate], [Freight]) VALUES (2, 1, CAST(N'2021-10-25T00:00:00.000' AS DateTime), CAST(N'2021-10-27T00:00:00.000' AS DateTime), CAST(N'2021-10-29T00:00:00.000' AS DateTime), 25.0000)
INSERT [dbo].[Oder] ([OrderID], [MemberID], [OrderDate], [RequiredDate], [ShippedDate], [Freight]) VALUES (5, 2, CAST(N'2000-03-03T00:00:00.000' AS DateTime), CAST(N'2000-04-03T00:00:00.000' AS DateTime), CAST(N'2000-02-25T00:00:00.000' AS DateTime), 24000.0000)
INSERT [dbo].[Oder] ([OrderID], [MemberID], [OrderDate], [RequiredDate], [ShippedDate], [Freight]) VALUES (7, 4, CAST(N'2021-07-19T16:12:34.000' AS DateTime), CAST(N'2021-08-22T16:12:34.000' AS DateTime), CAST(N'2021-10-22T16:12:34.617' AS DateTime), 15000.0000)
INSERT [dbo].[Oder] ([OrderID], [MemberID], [OrderDate], [RequiredDate], [ShippedDate], [Freight]) VALUES (9, 2, CAST(N'2021-10-23T22:07:31.133' AS DateTime), CAST(N'2021-10-23T22:07:31.130' AS DateTime), CAST(N'2021-10-23T22:07:31.123' AS DateTime), 123.0000)
GO
INSERT [dbo].[OrderDetail] ([OrderID], [ProductID], [UnitPrice], [Quantity], [Discount]) VALUES (2, 1, 7500.0000, 2, 6300)
INSERT [dbo].[OrderDetail] ([OrderID], [ProductID], [UnitPrice], [Quantity], [Discount]) VALUES (7, 2, 3200.0000, 5, 7800)
GO
INSERT [dbo].[Product] ([ProductID], [CategoryID], [ProductName], [Weight], [UnitPrice], [UnitsInStock]) VALUES (1, 2, N'Sung Luc', N'25', 25000.0000, 25)
INSERT [dbo].[Product] ([ProductID], [CategoryID], [ProductName], [Weight], [UnitPrice], [UnitsInStock]) VALUES (2, 5, N'ShotGun', N'75', 35000.0000, 12)
GO
ALTER TABLE [dbo].[Oder]  WITH CHECK ADD  CONSTRAINT [FK_Order_Member] FOREIGN KEY([MemberID])
REFERENCES [dbo].[Member] ([MemberID])
GO
ALTER TABLE [dbo].[Oder] CHECK CONSTRAINT [FK_Order_Member]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Order] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Oder] ([OrderID])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Order]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Product]
GO
USE [master]
GO
ALTER DATABASE [SalesManagement] SET  READ_WRITE 
GO
