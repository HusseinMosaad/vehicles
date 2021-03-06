
/****** Object:  Table [dbo].[Customer]    Script Date: 09-30-2018 01:26:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Customer_Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Address] [nvarchar](500) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Customer_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vehicle]    Script Date: 09-30-2018 01:26:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehicle](
	[Vehicle_Id] [int] IDENTITY(1,1) NOT NULL,
	[VIN] [nvarchar](17) NULL,
	[Reg_No] [nvarchar](6) NULL,
	[Customer_Id] [int] NULL,
	[Status] [bit] NULL,
	[Last_Updated] [datetime] NULL,
 CONSTRAINT [PK_Vehicle] PRIMARY KEY CLUSTERED 
(
	[Vehicle_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([Customer_Id], [Name], [Address]) VALUES (1, N'Kalles Grustransporter AB', N'Cementvägen 8, 111 11 Södertälje')
INSERT [dbo].[Customer] ([Customer_Id], [Name], [Address]) VALUES (2, N'Johans Bulk AB', N'Johans Bulk AB')
INSERT [dbo].[Customer] ([Customer_Id], [Name], [Address]) VALUES (3, N'Haralds Värdetransporter AB', N'Haralds Värdetransporter AB')
SET IDENTITY_INSERT [dbo].[Customer] OFF
SET IDENTITY_INSERT [dbo].[Vehicle] ON 

INSERT [dbo].[Vehicle] ([Vehicle_Id], [VIN], [Reg_No], [Customer_Id], [Status], [Last_Updated]) VALUES (3, N'YS2R4X20005399401', N'ABC123', 1, 1, CAST(N'2018-09-29T19:56:39.203' AS DateTime))
INSERT [dbo].[Vehicle] ([Vehicle_Id], [VIN], [Reg_No], [Customer_Id], [Status], [Last_Updated]) VALUES (4, N'VLUR4X20009093588', N'DEF456', 1, 1, CAST(N'2018-09-29T19:56:38.863' AS DateTime))
INSERT [dbo].[Vehicle] ([Vehicle_Id], [VIN], [Reg_No], [Customer_Id], [Status], [Last_Updated]) VALUES (5, N'VLUR4X20009048066', N'GHI789', 1, 1, CAST(N'2018-09-29T19:56:38.617' AS DateTime))
INSERT [dbo].[Vehicle] ([Vehicle_Id], [VIN], [Reg_No], [Customer_Id], [Status], [Last_Updated]) VALUES (6, N'YS2R4X20005388011', N'JKL012', 2, 1, CAST(N'2018-09-29T19:44:03.123' AS DateTime))
INSERT [dbo].[Vehicle] ([Vehicle_Id], [VIN], [Reg_No], [Customer_Id], [Status], [Last_Updated]) VALUES (7, N'YS2R4X20005387949', N'MNO345', 2, 1, CAST(N'2018-09-29T08:23:39.403' AS DateTime))
INSERT [dbo].[Vehicle] ([Vehicle_Id], [VIN], [Reg_No], [Customer_Id], [Status], [Last_Updated]) VALUES (8, N'VLUR4X20009048066', N'PQR678', 3, 1, CAST(N'2018-09-29T08:12:01.710' AS DateTime))
INSERT [dbo].[Vehicle] ([Vehicle_Id], [VIN], [Reg_No], [Customer_Id], [Status], [Last_Updated]) VALUES (9, N'YS2R4X20005387055', N'STU901', 3, 1, CAST(N'2018-09-29T08:11:59.580' AS DateTime))
SET IDENTITY_INSERT [dbo].[Vehicle] OFF
