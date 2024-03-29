USE [master]
GO
/****** Object:  Database [CarsDb]    Script Date: 27.05.2021 14:49:13 ******/
CREATE DATABASE [CarsDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CarsDb', FILENAME = N'C:\Users\dell\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\CarsDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CarsDb_log', FILENAME = N'C:\Users\dell\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\CarsDb.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [CarsDb] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CarsDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CarsDb] SET ANSI_NULL_DEFAULT ON 
GO
ALTER DATABASE [CarsDb] SET ANSI_NULLS ON 
GO
ALTER DATABASE [CarsDb] SET ANSI_PADDING ON 
GO
ALTER DATABASE [CarsDb] SET ANSI_WARNINGS ON 
GO
ALTER DATABASE [CarsDb] SET ARITHABORT ON 
GO
ALTER DATABASE [CarsDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CarsDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CarsDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CarsDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CarsDb] SET CURSOR_DEFAULT  LOCAL 
GO
ALTER DATABASE [CarsDb] SET CONCAT_NULL_YIELDS_NULL ON 
GO
ALTER DATABASE [CarsDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CarsDb] SET QUOTED_IDENTIFIER ON 
GO
ALTER DATABASE [CarsDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CarsDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CarsDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CarsDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CarsDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CarsDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CarsDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CarsDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CarsDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CarsDb] SET RECOVERY FULL 
GO
ALTER DATABASE [CarsDb] SET  MULTI_USER 
GO
ALTER DATABASE [CarsDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CarsDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CarsDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CarsDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CarsDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CarsDb] SET QUERY_STORE = OFF
GO
USE [CarsDb]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [CarsDb]
GO
/****** Object:  Table [dbo].[Brands]    Script Date: 27.05.2021 14:49:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brands](
	[BrandId] [int] IDENTITY(1,1) NOT NULL,
	[BrandName] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[BrandId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarImages]    Script Date: 27.05.2021 14:49:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarImages](
	[CarImageId] [int] IDENTITY(1,1) NOT NULL,
	[CarId] [int] NOT NULL,
	[ImagePath] [nvarchar](max) NULL,
	[ImageDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[CarImageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cars]    Script Date: 27.05.2021 14:49:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cars](
	[CarId] [int] IDENTITY(1,1) NOT NULL,
	[BrandId] [int] NULL,
	[ColorId] [int] NULL,
	[CarName] [nvarchar](50) NULL,
	[ModelYear] [datetime] NULL,
	[DailyPrice] [decimal](18, 0) NULL,
	[Description] [nvarchar](150) NULL,
	[FindeksNote] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CarId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Colors]    Script Date: 27.05.2021 14:49:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Colors](
	[ColorId] [int] IDENTITY(1,1) NOT NULL,
	[ColorName] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ColorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CreditCards]    Script Date: 27.05.2021 14:49:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CreditCards](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CardNumber] [nvarchar](50) NULL,
	[CardholderFirstName] [nvarchar](50) NULL,
	[CardholderLastName] [nvarchar](50) NULL,
	[Cvc] [nvarchar](5) NULL,
	[ExpirationDate] [datetime] NULL,
	[MoneyInCard] [decimal](18, 0) NULL,
	[FindeksNote] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 27.05.2021 14:49:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[CompanyName] [nvarchar](50) NOT NULL,
	[FindeksNote] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OperationClaims]    Script Date: 27.05.2021 14:49:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OperationClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rentals]    Script Date: 27.05.2021 14:49:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rentals](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CarId] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[RentDate] [datetime] NOT NULL,
	[ReturnDate] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserOperationClaims]    Script Date: 27.05.2021 14:49:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserOperationClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[OperationClaimId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 27.05.2021 14:49:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[PasswordSalt] [varbinary](500) NULL,
	[PasswordHash] [varbinary](500) NULL,
	[Status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Brands] ON 

INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (1, N'Wolkwagen')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (2, N'Audi')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (3, N'Ford')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (4, N'Ferrari')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (5, N'Peugeot')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (6, N'Citroen')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (7, N'Mercedes')
SET IDENTITY_INSERT [dbo].[Brands] OFF
GO
SET IDENTITY_INSERT [dbo].[CarImages] ON 

INSERT [dbo].[CarImages] ([CarImageId], [CarId], [ImagePath], [ImageDate]) VALUES (1002, 1, N'f47b52d6-da2f-4f68-9929-a412517e2b18_3_23_2021.jpg', CAST(N'2021-03-23T17:47:11.840' AS DateTime))
INSERT [dbo].[CarImages] ([CarImageId], [CarId], [ImagePath], [ImageDate]) VALUES (2002, 2, N'0aa7af0e-74a6-4e59-839f-b426e2c54019_3_23_2021.jpg', CAST(N'2021-03-23T20:30:05.490' AS DateTime))
INSERT [dbo].[CarImages] ([CarImageId], [CarId], [ImagePath], [ImageDate]) VALUES (2003, 3, N'768c287a-dd2c-47be-a774-49a18efb6a02_3_23_2021.jpg', CAST(N'2021-03-23T20:31:57.430' AS DateTime))
INSERT [dbo].[CarImages] ([CarImageId], [CarId], [ImagePath], [ImageDate]) VALUES (2004, 4, N'9806e3d1-c449-4f66-97ab-2e989d994add_3_23_2021.jpg', CAST(N'2021-03-23T20:32:01.210' AS DateTime))
INSERT [dbo].[CarImages] ([CarImageId], [CarId], [ImagePath], [ImageDate]) VALUES (2005, 5, N'67a839bb-9dd8-4dcf-a793-356e182e6b02_3_23_2021.jpg', CAST(N'2021-03-23T20:32:04.777' AS DateTime))
INSERT [dbo].[CarImages] ([CarImageId], [CarId], [ImagePath], [ImageDate]) VALUES (2006, 1005, N'292f7db6-c8dd-43e6-8177-30fa2a33458d_3_23_2021.jpg', CAST(N'2021-03-23T20:32:10.590' AS DateTime))
INSERT [dbo].[CarImages] ([CarImageId], [CarId], [ImagePath], [ImageDate]) VALUES (3002, 1, N'5b4adad1-e231-4a4d-99c4-0b28af55b95e_3_24_2021.jpg', CAST(N'2021-03-24T17:01:07.227' AS DateTime))
INSERT [dbo].[CarImages] ([CarImageId], [CarId], [ImagePath], [ImageDate]) VALUES (5004, 2005, N'581d7989-0a97-413f-91c7-ebbca6ce2b6f.jpg', CAST(N'2021-05-25T16:02:13.640' AS DateTime))
SET IDENTITY_INSERT [dbo].[CarImages] OFF
GO
SET IDENTITY_INSERT [dbo].[Cars] ON 

INSERT [dbo].[Cars] ([CarId], [BrandId], [ColorId], [CarName], [ModelYear], [DailyPrice], [Description], [FindeksNote]) VALUES (1, 1, 1, N'Konforlu aile dostu araba                         ', CAST(N'1999-01-15T00:00:00.000' AS DateTime), CAST(40000 AS Decimal(18, 0)), NULL, 300)
INSERT [dbo].[Cars] ([CarId], [BrandId], [ColorId], [CarName], [ModelYear], [DailyPrice], [Description], [FindeksNote]) VALUES (2, 3, 2, N'4X4 Dag araci                                     ', CAST(N'2014-05-20T00:00:00.000' AS DateTime), CAST(80000 AS Decimal(18, 0)), NULL, 550)
INSERT [dbo].[Cars] ([CarId], [BrandId], [ColorId], [CarName], [ModelYear], [DailyPrice], [Description], [FindeksNote]) VALUES (3, 4, 5, N'Hizli                                             ', CAST(N'2019-01-01T00:00:00.000' AS DateTime), CAST(990000 AS Decimal(18, 0)), NULL, 900)
INSERT [dbo].[Cars] ([CarId], [BrandId], [ColorId], [CarName], [ModelYear], [DailyPrice], [Description], [FindeksNote]) VALUES (4, 2, 4, N'araç                                              ', CAST(N'2020-01-01T00:00:00.000' AS DateTime), CAST(870000 AS Decimal(18, 0)), NULL, 250)
INSERT [dbo].[Cars] ([CarId], [BrandId], [ColorId], [CarName], [ModelYear], [DailyPrice], [Description], [FindeksNote]) VALUES (5, 4, 4, N'Model 7', CAST(N'2020-01-01T00:00:00.000' AS DateTime), CAST(99000 AS Decimal(18, 0)), NULL, 100)
INSERT [dbo].[Cars] ([CarId], [BrandId], [ColorId], [CarName], [ModelYear], [DailyPrice], [Description], [FindeksNote]) VALUES (1005, 4, 4, N'Model 9', CAST(N'2020-01-01T00:00:00.000' AS DateTime), CAST(99000 AS Decimal(18, 0)), NULL, 980)
INSERT [dbo].[Cars] ([CarId], [BrandId], [ColorId], [CarName], [ModelYear], [DailyPrice], [Description], [FindeksNote]) VALUES (2005, 1, 2, N'TESLA', CAST(N'2021-05-28T00:00:00.000' AS DateTime), CAST(450 AS Decimal(18, 0)), N'ELEKTRİKLİ', 80)
SET IDENTITY_INSERT [dbo].[Cars] OFF
GO
SET IDENTITY_INSERT [dbo].[Colors] ON 

INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (1, N'Beyaz')
INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (2, N'Siyah')
INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (3, N'Mavi')
INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (4, N'Yesil')
INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (5, N'Kirmizi')
INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (6, N'Sari')
INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (7, N'Turuncu')
INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (8, N'Mor')
INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (9, N'KoyuMavi')
INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (10, N'KoyuYesil')
INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (11, N'KahveRengi')
SET IDENTITY_INSERT [dbo].[Colors] OFF
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([CustomerId], [UserId], [CompanyName], [FindeksNote]) VALUES (1, 3003, N'Kadir Yazılım', NULL)
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[OperationClaims] ON 

INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (1, N'admin')
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (2, N'moderator')
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (3, N'car.add')
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (4, N'car.remove')
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (5, N'car.update')
SET IDENTITY_INSERT [dbo].[OperationClaims] OFF
GO
SET IDENTITY_INSERT [dbo].[Rentals] ON 

INSERT [dbo].[Rentals] ([Id], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (1, 1, 1, CAST(N'2020-01-15T00:00:00.000' AS DateTime), CAST(N'2020-01-20T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Rentals] OFF
GO
SET IDENTITY_INSERT [dbo].[UserOperationClaims] ON 

INSERT [dbo].[UserOperationClaims] ([Id], [UserId], [OperationClaimId]) VALUES (1, 3003, 1)
INSERT [dbo].[UserOperationClaims] ([Id], [UserId], [OperationClaimId]) VALUES (2, 3003, 3)
INSERT [dbo].[UserOperationClaims] ([Id], [UserId], [OperationClaimId]) VALUES (3, 3003, 4)
INSERT [dbo].[UserOperationClaims] ([Id], [UserId], [OperationClaimId]) VALUES (4, 3003, 5)
SET IDENTITY_INSERT [dbo].[UserOperationClaims] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [PasswordSalt], [PasswordHash], [Status]) VALUES (3003, N'selami', N'kaya', N'selami@selami', 0xF46E6B8442E1497362058A8C0E3655CB8377CBE5CC37BD79381CB2CDCFBB8F416F09C9E10487E0399B9D4DAFAAD382680FB63E61AB1BB20F63D95B1CBED6377B9DAC8573B8F8D48EA2199BD0362DDE7A41AA3C2C16B854D92F3660FA4B7A4E8DD3221C5490E3D51872DCEB994F331562F7C2AB916CCFF0339572B2B68F3AFF5E, 0x38A158F04F5DECEB165C419250AA813111BE4DB3BAA88CF9169D4A7CB48478B3894FA263A0AB1CE5B61BF508B2C3AACBD824538E4FC8DC5D5C64EF891410651C, 1)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [PasswordSalt], [PasswordHash], [Status]) VALUES (4003, N'kadir', N'kaya', N'kadir@kadir', 0x276BC61EF272AF9E656C1239273EF8605FCF75DB765D87BE8F364D5B138F01093080FF92E0ED4AEECF0F618B2CBF6C835111E126E69403FA92D40FE28C06224FB4E135775821DBAFA64487AC96F3CCDC6CDC7A2287A71E6441071F0A65EC466A45D7B7F561D411DA0C5D3276CBB72A030D6A8AEEB1F776C142BC46B73969AEAD, 0x442405D99F54BB9A82860B5CCF5AE353902F23739F6B18E239539D21789D3AFD5925A6748847D85CC2EEFEDD7DAA60B5BD091589D963E1F1D08813E664290568, 1)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [PasswordSalt], [PasswordHash], [Status]) VALUES (5003, N'Sansar', N'Salvo', N'sansar@salvo.com', 0x41628EC9A713B8298F85FFFED1FF0EA2ADA9B7A5644D3B4B3431DFBDC331A197394380BA2FEDB6DDF76ABE2B34A9298310D09D70198C7354960E8685E1FEF5F2DC7E17112719A9461991F020F10539B23AD2AB9A71179CFD51B19CA8C20C31EF3E4FE1D44DD13C77FF3A7708D2099571B256B8CEEF7D4A8409138D1CC9814A51, 0x23F8C550AB1CB7C1F21DA4E9EB2381335746854C4221950AD6A8A89E91B4DF737030BDF48FDE024827EEBC181C73D8CDBCB45B4BFC9AFBD3FB70198D0BF49C0C, 1)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[CarImages] ADD  DEFAULT (getdate()) FOR [ImageDate]
GO
USE [master]
GO
ALTER DATABASE [CarsDb] SET  READ_WRITE 
GO
