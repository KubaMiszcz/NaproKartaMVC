use [NaproKartaDB] 
GO
--drop table dbo.Notes
--drop table dbo.Comments
--drop table dbo.Charts
--drop table dbo.Cycles 
--drop table dbo.Observations
/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2012 (11.0.2100)
    Source Database Engine Edition : Microsoft SQL Server Express Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2017
    Target Database Engine Edition : Microsoft SQL Server Standard Edition
    Target Database Engine Type : Standalone SQL Server
*/

USE [NaproKartaDB]
GO
/****** Object:  Table [dbo].[Charts]    Script Date: 2017-08-28 09:47:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Charts](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Note] [nvarchar](max) NULL,
	[User_ID] [int] NULL,
 CONSTRAINT [PK_dbo.Charts] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CipherCDs]    Script Date: 2017-08-28 09:47:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CipherCDs](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.CipherCDs] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ciphers]    Script Date: 2017-08-28 09:47:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ciphers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Ciphers] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comments]    Script Date: 2017-08-28 09:47:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Visit] [bit] NOT NULL,
	[MedicalTest] [bit] NOT NULL,
	[Lupucupu] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Comments] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cycles]    Script Date: 2017-08-28 09:47:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cycles](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Note] [nvarchar](max) NULL,
	[MCS] [real] NOT NULL,
	[Chart_ID] [int] NULL,
 CONSTRAINT [PK_dbo.Cycles] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Letters]    Script Date: 2017-08-28 09:47:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Letters](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IsB] [bit] NOT NULL,
	[LetterValue_ID] [int] NULL,
 CONSTRAINT [PK_dbo.Letters] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LetterValues]    Script Date: 2017-08-28 09:47:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LetterValues](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.LetterValues] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Markers]    Script Date: 2017-08-28 09:47:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Markers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[ImageUrl] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Markers] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notes]    Script Date: 2017-08-28 09:47:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Content] [nvarchar](max) NULL,
	[IsImportant] [bit] NOT NULL,
	[Observation_ID] [int] NULL,
 CONSTRAINT [PK_dbo.Notes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NumTimes]    Script Date: 2017-08-28 09:47:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NumTimes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.NumTimes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Observations]    Script Date: 2017-08-28 09:47:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Observations](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[PeakNum] [int] NOT NULL,
	[Cipher_ID] [int] NULL,
	[CipherCD_ID] [int] NULL,
	[Comment_ID] [int] NULL,
	[Letter_ID] [int] NULL,
	[Marker_ID] [int] NULL,
	[NumTimes_ID] [int] NULL,
	[Cycle_ID] [int] NULL,
 CONSTRAINT [PK_dbo.Observations] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 2017-08-28 09:47:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.Roles] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2017-08-28 09:47:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[UserName] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[RegisterDate] [datetime] NOT NULL,
	[LastLoginDate] [datetime] NOT NULL,
	[Note] [nvarchar](max) NULL,
	[Role_ID] [int] NULL,
 CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Charts] ON 
GO
INSERT [dbo].[Charts] ([ID], [Name], [Note], [User_ID]) VALUES (1, N'chart1name', N'ch1note', 2)
GO
INSERT [dbo].[Charts] ([ID], [Name], [Note], [User_ID]) VALUES (2, N'chart2name', N'ch2note', 2)
GO
INSERT [dbo].[Charts] ([ID], [Name], [Note], [User_ID]) VALUES (3, N'chart3name', N'ch3note', 5)
GO
SET IDENTITY_INSERT [dbo].[Charts] OFF
GO
SET IDENTITY_INSERT [dbo].[CipherCDs] ON 
GO
INSERT [dbo].[CipherCDs] ([ID], [Value]) VALUES (1, N'B')
GO
INSERT [dbo].[CipherCDs] ([ID], [Value]) VALUES (2, N'C')
GO
INSERT [dbo].[CipherCDs] ([ID], [Value]) VALUES (3, N'C/K')
GO
INSERT [dbo].[CipherCDs] ([ID], [Value]) VALUES (4, N'G')
GO
INSERT [dbo].[CipherCDs] ([ID], [Value]) VALUES (5, N'L')
GO
INSERT [dbo].[CipherCDs] ([ID], [Value]) VALUES (6, N'P')
GO
INSERT [dbo].[CipherCDs] ([ID], [Value]) VALUES (7, N'Y')
GO
INSERT [dbo].[CipherCDs] ([ID], [Value]) VALUES (8, N'"L"')
GO
INSERT [dbo].[CipherCDs] ([ID], [Value]) VALUES (9, N'"P"')
GO
SET IDENTITY_INSERT [dbo].[CipherCDs] OFF
GO
SET IDENTITY_INSERT [dbo].[Ciphers] ON 
GO
INSERT [dbo].[Ciphers] ([ID], [Value]) VALUES (1, N'0')
GO
INSERT [dbo].[Ciphers] ([ID], [Value]) VALUES (2, N'2')
GO
INSERT [dbo].[Ciphers] ([ID], [Value]) VALUES (3, N'2W')
GO
INSERT [dbo].[Ciphers] ([ID], [Value]) VALUES (4, N'4')
GO
INSERT [dbo].[Ciphers] ([ID], [Value]) VALUES (5, N'6')
GO
INSERT [dbo].[Ciphers] ([ID], [Value]) VALUES (6, N'8')
GO
INSERT [dbo].[Ciphers] ([ID], [Value]) VALUES (7, N'10')
GO
INSERT [dbo].[Ciphers] ([ID], [Value]) VALUES (8, N'10DL')
GO
INSERT [dbo].[Ciphers] ([ID], [Value]) VALUES (9, N'10SL')
GO
INSERT [dbo].[Ciphers] ([ID], [Value]) VALUES (10, N'10WL')
GO
SET IDENTITY_INSERT [dbo].[Ciphers] OFF
GO
SET IDENTITY_INSERT [dbo].[Comments] ON 
GO
INSERT [dbo].[Comments] ([ID], [Visit], [MedicalTest], [Lupucupu]) VALUES (2, 0, 1, 1)
GO
INSERT [dbo].[Comments] ([ID], [Visit], [MedicalTest], [Lupucupu]) VALUES (3, 1, 0, 0)
GO
INSERT [dbo].[Comments] ([ID], [Visit], [MedicalTest], [Lupucupu]) VALUES (4, 1, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Comments] OFF
GO
SET IDENTITY_INSERT [dbo].[Cycles] ON 
GO
INSERT [dbo].[Cycles] ([ID], [Note], [MCS], [Chart_ID]) VALUES (1, N'zxc', 4, 1)
GO
INSERT [dbo].[Cycles] ([ID], [Note], [MCS], [Chart_ID]) VALUES (2, N'zxc', 4, 1)
GO
INSERT [dbo].[Cycles] ([ID], [Note], [MCS], [Chart_ID]) VALUES (3, N'zxc', 4, 1)
GO
INSERT [dbo].[Cycles] ([ID], [Note], [MCS], [Chart_ID]) VALUES (4, N'zxc', 4, 1)
GO
INSERT [dbo].[Cycles] ([ID], [Note], [MCS], [Chart_ID]) VALUES (5, N'zxc', 4, 1)
GO
INSERT [dbo].[Cycles] ([ID], [Note], [MCS], [Chart_ID]) VALUES (6, N'zxc', 4, 2)
GO
INSERT [dbo].[Cycles] ([ID], [Note], [MCS], [Chart_ID]) VALUES (7, N'zxc', 4, 2)
GO
INSERT [dbo].[Cycles] ([ID], [Note], [MCS], [Chart_ID]) VALUES (8, N'zxc', 4, 3)
GO
INSERT [dbo].[Cycles] ([ID], [Note], [MCS], [Chart_ID]) VALUES (9, N'zxc', 4, 3)
GO
SET IDENTITY_INSERT [dbo].[Cycles] OFF
GO
SET IDENTITY_INSERT [dbo].[Letters] ON 
GO
INSERT [dbo].[Letters] ([ID], [IsB], [LetterValue_ID]) VALUES (1, 0, 5)
GO
INSERT [dbo].[Letters] ([ID], [IsB], [LetterValue_ID]) VALUES (2, 1, 2)
GO
SET IDENTITY_INSERT [dbo].[Letters] OFF
GO
SET IDENTITY_INSERT [dbo].[LetterValues] ON 
GO
INSERT [dbo].[LetterValues] ([ID], [Value]) VALUES (1, N'M')
GO
INSERT [dbo].[LetterValues] ([ID], [Value]) VALUES (2, N'H')
GO
INSERT [dbo].[LetterValues] ([ID], [Value]) VALUES (3, N'L')
GO
INSERT [dbo].[LetterValues] ([ID], [Value]) VALUES (4, N'VL')
GO
INSERT [dbo].[LetterValues] ([ID], [Value]) VALUES (5, N'VVL')
GO
SET IDENTITY_INSERT [dbo].[LetterValues] OFF
GO
SET IDENTITY_INSERT [dbo].[Markers] ON 
GO
INSERT [dbo].[Markers] ([ID], [Name], [ImageUrl]) VALUES (1, N'red', N'http://kubamiszcz.hekko24.pl/Naprokarta/img/markerRed.jpg')
GO
INSERT [dbo].[Markers] ([ID], [Name], [ImageUrl]) VALUES (2, N'green', N'http://kubamiszcz.hekko24.pl/Naprokarta/img/markerGreen.jpg')
GO
INSERT [dbo].[Markers] ([ID], [Name], [ImageUrl]) VALUES (3, N'yellow', N'http://kubamiszcz.hekko24.pl/Naprokarta/img/markerYellow.jpg')
GO
INSERT [dbo].[Markers] ([ID], [Name], [ImageUrl]) VALUES (4, N'whitebaby', N'http://kubamiszcz.hekko24.pl/Naprokarta/img/markerWhiteBaby.jpg')
GO
INSERT [dbo].[Markers] ([ID], [Name], [ImageUrl]) VALUES (5, N'greenbaby', N'http://kubamiszcz.hekko24.pl/Naprokarta/img/markerGreenBaby.jpg')
GO
INSERT [dbo].[Markers] ([ID], [Name], [ImageUrl]) VALUES (6, N'yellowbaby', N'http://kubamiszcz.hekko24.pl/Naprokarta/img/markerYellowBaby.jpg')
GO
INSERT [dbo].[Markers] ([ID], [Name], [ImageUrl]) VALUES (7, N'grey', N'http://kubamiszcz.hekko24.pl/Naprokarta/img/markerGrey.jpg')
GO
SET IDENTITY_INSERT [dbo].[Markers] OFF
GO
SET IDENTITY_INSERT [dbo].[Notes] ON 
GO
INSERT [dbo].[Notes] ([ID], [Content], [IsImportant], [Observation_ID]) VALUES (1, N'gjjhhyihoiuhjoi', 0, 4)
GO
INSERT [dbo].[Notes] ([ID], [Content], [IsImportant], [Observation_ID]) VALUES (2, N'hhhhhh', 1, 4)
GO
INSERT [dbo].[Notes] ([ID], [Content], [IsImportant], [Observation_ID]) VALUES (4, N'uyvvn', 1, 4)
GO
SET IDENTITY_INSERT [dbo].[Notes] OFF
GO
SET IDENTITY_INSERT [dbo].[NumTimes] ON 
GO
INSERT [dbo].[NumTimes] ([ID], [Value]) VALUES (1, N'X1')
GO
INSERT [dbo].[NumTimes] ([ID], [Value]) VALUES (2, N'X2')
GO
INSERT [dbo].[NumTimes] ([ID], [Value]) VALUES (3, N'X3')
GO
INSERT [dbo].[NumTimes] ([ID], [Value]) VALUES (4, N'AD')
GO
SET IDENTITY_INSERT [dbo].[NumTimes] OFF
GO
SET IDENTITY_INSERT [dbo].[Observations] ON 
GO
INSERT [dbo].[Observations] ([ID], [Date], [PeakNum], [Cipher_ID], [CipherCD_ID], [Comment_ID], [Letter_ID], [Marker_ID], [NumTimes_ID], [Cycle_ID]) VALUES (4, CAST(N'2000-01-01T00:00:00.000' AS DateTime), -1, 10, NULL, 2, 1, 1, 1, 1)
GO
INSERT [dbo].[Observations] ([ID], [Date], [PeakNum], [Cipher_ID], [CipherCD_ID], [Comment_ID], [Letter_ID], [Marker_ID], [NumTimes_ID], [Cycle_ID]) VALUES (5, CAST(N'1999-11-11T00:00:00.000' AS DateTime), 1, NULL, 1, 3, 1, 2, 1, 1)
GO
INSERT [dbo].[Observations] ([ID], [Date], [PeakNum], [Cipher_ID], [CipherCD_ID], [Comment_ID], [Letter_ID], [Marker_ID], [NumTimes_ID], [Cycle_ID]) VALUES (6, CAST(N'1999-01-21T00:00:00.000' AS DateTime), 1, 1, 1, 4, 1, 4, 1, 1)
GO
INSERT [dbo].[Observations] ([ID], [Date], [PeakNum], [Cipher_ID], [CipherCD_ID], [Comment_ID], [Letter_ID], [Marker_ID], [NumTimes_ID], [Cycle_ID]) VALUES (7, CAST(N'1999-10-09T00:00:00.000' AS DateTime), 1, 1, 1, 4, 1, 5, 1, 1)
GO
INSERT [dbo].[Observations] ([ID], [Date], [PeakNum], [Cipher_ID], [CipherCD_ID], [Comment_ID], [Letter_ID], [Marker_ID], [NumTimes_ID], [Cycle_ID]) VALUES (8, CAST(N'1999-01-01T00:00:00.000' AS DateTime), 1, 1, 1, 4, 1, 4, 1, 1)
GO
INSERT [dbo].[Observations] ([ID], [Date], [PeakNum], [Cipher_ID], [CipherCD_ID], [Comment_ID], [Letter_ID], [Marker_ID], [NumTimes_ID], [Cycle_ID]) VALUES (49, CAST(N'1999-01-01T00:00:00.000' AS DateTime), 1, 1, 1, 2, 1, 3, 1, 2)
GO
INSERT [dbo].[Observations] ([ID], [Date], [PeakNum], [Cipher_ID], [CipherCD_ID], [Comment_ID], [Letter_ID], [Marker_ID], [NumTimes_ID], [Cycle_ID]) VALUES (50, CAST(N'1999-01-01T00:00:00.000' AS DateTime), 1, 1, 1, 2, 1, 4, 1, 2)
GO
INSERT [dbo].[Observations] ([ID], [Date], [PeakNum], [Cipher_ID], [CipherCD_ID], [Comment_ID], [Letter_ID], [Marker_ID], [NumTimes_ID], [Cycle_ID]) VALUES (51, CAST(N'1999-01-01T00:00:00.000' AS DateTime), 1, 1, 1, 2, 1, 4, 1, 2)
GO
INSERT [dbo].[Observations] ([ID], [Date], [PeakNum], [Cipher_ID], [CipherCD_ID], [Comment_ID], [Letter_ID], [Marker_ID], [NumTimes_ID], [Cycle_ID]) VALUES (52, CAST(N'1999-01-01T00:00:00.000' AS DateTime), 1, 1, 1, 2, 1, 4, 1, 2)
GO
INSERT [dbo].[Observations] ([ID], [Date], [PeakNum], [Cipher_ID], [CipherCD_ID], [Comment_ID], [Letter_ID], [Marker_ID], [NumTimes_ID], [Cycle_ID]) VALUES (61, CAST(N'1999-01-01T00:00:00.000' AS DateTime), 1, 1, 1, 3, 1, 1, 1, 3)
GO
INSERT [dbo].[Observations] ([ID], [Date], [PeakNum], [Cipher_ID], [CipherCD_ID], [Comment_ID], [Letter_ID], [Marker_ID], [NumTimes_ID], [Cycle_ID]) VALUES (62, CAST(N'1999-01-01T00:00:00.000' AS DateTime), 1, 1, 1, 3, 1, 4, 1, 3)
GO
INSERT [dbo].[Observations] ([ID], [Date], [PeakNum], [Cipher_ID], [CipherCD_ID], [Comment_ID], [Letter_ID], [Marker_ID], [NumTimes_ID], [Cycle_ID]) VALUES (69, CAST(N'1999-01-01T00:00:00.000' AS DateTime), 1, 1, 1, 4, 1, 4, 1, 3)
GO
INSERT [dbo].[Observations] ([ID], [Date], [PeakNum], [Cipher_ID], [CipherCD_ID], [Comment_ID], [Letter_ID], [Marker_ID], [NumTimes_ID], [Cycle_ID]) VALUES (70, CAST(N'1999-01-01T00:00:00.000' AS DateTime), 1, 1, 1, 4, 1, 4, 1, 4)
GO
INSERT [dbo].[Observations] ([ID], [Date], [PeakNum], [Cipher_ID], [CipherCD_ID], [Comment_ID], [Letter_ID], [Marker_ID], [NumTimes_ID], [Cycle_ID]) VALUES (71, CAST(N'1999-01-01T00:00:00.000' AS DateTime), 1, 1, 1, 2, 1, 4, 1, 4)
GO
INSERT [dbo].[Observations] ([ID], [Date], [PeakNum], [Cipher_ID], [CipherCD_ID], [Comment_ID], [Letter_ID], [Marker_ID], [NumTimes_ID], [Cycle_ID]) VALUES (72, CAST(N'1999-01-01T00:00:00.000' AS DateTime), 1, 1, 1, 4, 1, 4, 1, 4)
GO
INSERT [dbo].[Observations] ([ID], [Date], [PeakNum], [Cipher_ID], [CipherCD_ID], [Comment_ID], [Letter_ID], [Marker_ID], [NumTimes_ID], [Cycle_ID]) VALUES (80, CAST(N'1999-01-01T00:00:00.000' AS DateTime), 1, 1, 1, 3, 1, 4, 1, 5)
GO
INSERT [dbo].[Observations] ([ID], [Date], [PeakNum], [Cipher_ID], [CipherCD_ID], [Comment_ID], [Letter_ID], [Marker_ID], [NumTimes_ID], [Cycle_ID]) VALUES (81, CAST(N'1999-01-01T00:00:00.000' AS DateTime), 1, 1, 1, 2, 1, 4, 1, 5)
GO
INSERT [dbo].[Observations] ([ID], [Date], [PeakNum], [Cipher_ID], [CipherCD_ID], [Comment_ID], [Letter_ID], [Marker_ID], [NumTimes_ID], [Cycle_ID]) VALUES (82, CAST(N'1999-01-01T00:00:00.000' AS DateTime), 1, 1, 1, 2, 1, 4, 1, 5)
GO
INSERT [dbo].[Observations] ([ID], [Date], [PeakNum], [Cipher_ID], [CipherCD_ID], [Comment_ID], [Letter_ID], [Marker_ID], [NumTimes_ID], [Cycle_ID]) VALUES (83, CAST(N'1999-01-01T00:00:00.000' AS DateTime), 1, 1, 1, NULL, 1, 4, 1, 5)
GO
INSERT [dbo].[Observations] ([ID], [Date], [PeakNum], [Cipher_ID], [CipherCD_ID], [Comment_ID], [Letter_ID], [Marker_ID], [NumTimes_ID], [Cycle_ID]) VALUES (89, CAST(N'1999-01-01T00:00:00.000' AS DateTime), 1, 1, 1, NULL, 1, 4, 1, 6)
GO
INSERT [dbo].[Observations] ([ID], [Date], [PeakNum], [Cipher_ID], [CipherCD_ID], [Comment_ID], [Letter_ID], [Marker_ID], [NumTimes_ID], [Cycle_ID]) VALUES (97, CAST(N'1999-01-01T00:00:00.000' AS DateTime), 1, 1, 1, NULL, 1, 4, 1, 6)
GO
INSERT [dbo].[Observations] ([ID], [Date], [PeakNum], [Cipher_ID], [CipherCD_ID], [Comment_ID], [Letter_ID], [Marker_ID], [NumTimes_ID], [Cycle_ID]) VALUES (98, CAST(N'1999-01-01T00:00:00.000' AS DateTime), 1, 1, 1, NULL, 1, 4, 1, 7)
GO
INSERT [dbo].[Observations] ([ID], [Date], [PeakNum], [Cipher_ID], [CipherCD_ID], [Comment_ID], [Letter_ID], [Marker_ID], [NumTimes_ID], [Cycle_ID]) VALUES (99, CAST(N'1999-01-01T00:00:00.000' AS DateTime), 1, 1, 1, NULL, 1, 4, 1, 7)
GO
SET IDENTITY_INSERT [dbo].[Observations] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 
GO
INSERT [dbo].[Roles] ([ID], [Name]) VALUES (1, N'admin')
GO
INSERT [dbo].[Roles] ([ID], [Name]) VALUES (2, N'user')
GO
INSERT [dbo].[Roles] ([ID], [Name]) VALUES (3, N'instructor')
GO
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([ID], [Login], [Password], [UserName], [Email], [RegisterDate], [LastLoginDate], [Note], [Role_ID]) VALUES (1, N'admin', N'p', N'AdminName', N'admin@email.com', CAST(N'1999-01-01T00:00:00.000' AS DateTime), CAST(N'1999-01-01T00:00:00.000' AS DateTime), N'asd', 1)
GO
INSERT [dbo].[Users] ([ID], [Login], [Password], [UserName], [Email], [RegisterDate], [LastLoginDate], [Note], [Role_ID]) VALUES (2, N'ula', N'p', N'Ula Slodziuchna', N'ula@slodziuchna.com', CAST(N'1999-01-01T00:00:00.000' AS DateTime), CAST(N'1999-01-01T00:00:00.000' AS DateTime), N'qe', 2)
GO
INSERT [dbo].[Users] ([ID], [Login], [Password], [UserName], [Email], [RegisterDate], [LastLoginDate], [Note], [Role_ID]) VALUES (3, N'instr1', N'p', N'Insztruktori Numero Uno', N'instr1@numerouno.com', CAST(N'1999-01-01T00:00:00.000' AS DateTime), CAST(N'1999-01-01T00:00:00.000' AS DateTime), N'wqe', 3)
GO
INSERT [dbo].[Users] ([ID], [Login], [Password], [UserName], [Email], [RegisterDate], [LastLoginDate], [Note], [Role_ID]) VALUES (5, N'id5', N'p', N'id5sss', N'ula@slodziuchna.com', CAST(N'1999-01-01T00:00:00.000' AS DateTime), CAST(N'1999-01-01T00:00:00.000' AS DateTime), N'xxx', 2)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Charts]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Charts_dbo.Users_User_ID] FOREIGN KEY([User_ID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[Charts] CHECK CONSTRAINT [FK_dbo.Charts_dbo.Users_User_ID]
GO
ALTER TABLE [dbo].[Cycles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Cycles_dbo.Charts_Chart_ID] FOREIGN KEY([Chart_ID])
REFERENCES [dbo].[Charts] ([ID])
GO
ALTER TABLE [dbo].[Cycles] CHECK CONSTRAINT [FK_dbo.Cycles_dbo.Charts_Chart_ID]
GO
ALTER TABLE [dbo].[Letters]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Letters_dbo.LetterValues_LetterValue_ID] FOREIGN KEY([LetterValue_ID])
REFERENCES [dbo].[LetterValues] ([ID])
GO
ALTER TABLE [dbo].[Letters] CHECK CONSTRAINT [FK_dbo.Letters_dbo.LetterValues_LetterValue_ID]
GO
ALTER TABLE [dbo].[Notes]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Notes_dbo.Observations_Observation_ID] FOREIGN KEY([Observation_ID])
REFERENCES [dbo].[Observations] ([ID])
GO
ALTER TABLE [dbo].[Notes] CHECK CONSTRAINT [FK_dbo.Notes_dbo.Observations_Observation_ID]
GO
ALTER TABLE [dbo].[Observations]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Observations_dbo.CipherCDs_CipherCD_ID] FOREIGN KEY([CipherCD_ID])
REFERENCES [dbo].[CipherCDs] ([ID])
GO
ALTER TABLE [dbo].[Observations] CHECK CONSTRAINT [FK_dbo.Observations_dbo.CipherCDs_CipherCD_ID]
GO
ALTER TABLE [dbo].[Observations]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Observations_dbo.Ciphers_Cipher_ID] FOREIGN KEY([Cipher_ID])
REFERENCES [dbo].[Ciphers] ([ID])
GO
ALTER TABLE [dbo].[Observations] CHECK CONSTRAINT [FK_dbo.Observations_dbo.Ciphers_Cipher_ID]
GO
ALTER TABLE [dbo].[Observations]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Observations_dbo.Comments_Comment_ID] FOREIGN KEY([Comment_ID])
REFERENCES [dbo].[Comments] ([ID])
GO
ALTER TABLE [dbo].[Observations] CHECK CONSTRAINT [FK_dbo.Observations_dbo.Comments_Comment_ID]
GO
ALTER TABLE [dbo].[Observations]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Observations_dbo.Cycles_Cycle_ID] FOREIGN KEY([Cycle_ID])
REFERENCES [dbo].[Cycles] ([ID])
GO
ALTER TABLE [dbo].[Observations] CHECK CONSTRAINT [FK_dbo.Observations_dbo.Cycles_Cycle_ID]
GO
ALTER TABLE [dbo].[Observations]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Observations_dbo.Letters_Letter_ID] FOREIGN KEY([Letter_ID])
REFERENCES [dbo].[Letters] ([ID])
GO
ALTER TABLE [dbo].[Observations] CHECK CONSTRAINT [FK_dbo.Observations_dbo.Letters_Letter_ID]
GO
ALTER TABLE [dbo].[Observations]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Observations_dbo.Markers_Marker_ID] FOREIGN KEY([Marker_ID])
REFERENCES [dbo].[Markers] ([ID])
GO
ALTER TABLE [dbo].[Observations] CHECK CONSTRAINT [FK_dbo.Observations_dbo.Markers_Marker_ID]
GO
ALTER TABLE [dbo].[Observations]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Observations_dbo.NumTimes_NumTimes_ID] FOREIGN KEY([NumTimes_ID])
REFERENCES [dbo].[NumTimes] ([ID])
GO
ALTER TABLE [dbo].[Observations] CHECK CONSTRAINT [FK_dbo.Observations_dbo.NumTimes_NumTimes_ID]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Users_dbo.Roles_Role_ID] FOREIGN KEY([Role_ID])
REFERENCES [dbo].[Roles] ([ID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_dbo.Users_dbo.Roles_Role_ID]
GO
