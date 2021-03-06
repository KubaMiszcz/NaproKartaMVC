CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
 /****** Object:  Table [dbo].[Charts]    Script Date: 2017-09-08 12:25:49 ******/
SET ANSI_NULLS ON
 SET QUOTED_IDENTIFIER ON
 CREATE TABLE [dbo].[Charts](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[UserID] [int] NOT NULL,
	[Note] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Charts] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
 /****** Object:  Table [dbo].[CipherCDs]    Script Date: 2017-09-08 12:25:49 ******/
SET ANSI_NULLS ON
 SET QUOTED_IDENTIFIER ON
 CREATE TABLE [dbo].[CipherCDs](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.CipherCDs] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
 /****** Object:  Table [dbo].[Ciphers]    Script Date: 2017-09-08 12:25:49 ******/
SET ANSI_NULLS ON
 SET QUOTED_IDENTIFIER ON
 CREATE TABLE [dbo].[Ciphers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Ciphers] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
 /****** Object:  Table [dbo].[Cycles]    Script Date: 2017-09-08 12:25:49 ******/
SET ANSI_NULLS ON
 SET QUOTED_IDENTIFIER ON
 CREATE TABLE [dbo].[Cycles](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Note] [nvarchar](max) NULL,
	[MCS] [real] NOT NULL,
	[ChartID] [int] NOT NULL,
	[RowNumber] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Cycles] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
 /****** Object:  Table [dbo].[Letters]    Script Date: 2017-09-08 12:25:49 ******/
SET ANSI_NULLS ON
 SET QUOTED_IDENTIFIER ON
 CREATE TABLE [dbo].[Letters](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Letters] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
 /****** Object:  Table [dbo].[Markers]    Script Date: 2017-09-08 12:25:49 ******/
SET ANSI_NULLS ON
 SET QUOTED_IDENTIFIER ON
 CREATE TABLE [dbo].[Markers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[MarkerUrl] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Markers] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
 /****** Object:  Table [dbo].[Notes]    Script Date: 2017-09-08 12:25:49 ******/
SET ANSI_NULLS ON
 SET QUOTED_IDENTIFIER ON
 CREATE TABLE [dbo].[Notes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Content] [nvarchar](max) NULL,
	[IsImportant] [bit] NOT NULL,
	[ObservationID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Notes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
 /****** Object:  Table [dbo].[NumTimes]    Script Date: 2017-09-08 12:25:49 ******/
SET ANSI_NULLS ON
 SET QUOTED_IDENTIFIER ON
 CREATE TABLE [dbo].[NumTimes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.NumTimes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
 /****** Object:  Table [dbo].[Observations]    Script Date: 2017-09-08 12:25:49 ******/
SET ANSI_NULLS ON
 SET QUOTED_IDENTIFIER ON
 CREATE TABLE [dbo].[Observations](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CycleID] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[MarkerID] [int] NULL,
	[LetterID] [int] NULL,
	[LetterIsB] [bit] NOT NULL,
	[CipherID] [int] NULL,
	[CipherCDID] [int] NULL,
	[NumTimesID] [int] NULL,
	[CommentVisit] [bit] NOT NULL,
	[CommentMedicalTest] [bit] NOT NULL,
	[CommentLupucupu] [bit] NOT NULL,
	[ColNumber] [int] NOT NULL,
	[PeakNum] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Observations] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
 /****** Object:  Table [dbo].[Pictures]    Script Date: 2017-09-08 12:25:49 ******/
SET ANSI_NULLS ON
 SET QUOTED_IDENTIFIER ON
 CREATE TABLE [dbo].[Pictures](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[PictureUrl] [nvarchar](max) NULL,
	[ObservationID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Pictures] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
 /****** Object:  Table [dbo].[Roles]    Script Date: 2017-09-08 12:25:49 ******/
SET ANSI_NULLS ON
 SET QUOTED_IDENTIFIER ON
 CREATE TABLE [dbo].[Roles](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.Roles] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
 /****** Object:  Table [dbo].[Users]    Script Date: 2017-09-08 12:25:49 ******/
SET ANSI_NULLS ON
 SET QUOTED_IDENTIFIER ON
 CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[UserName] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[RegisterDate] [datetime] NOT NULL,
	[LastLoginDate] [datetime] NOT NULL,
	[Note] [nvarchar](max) NULL,
	[RoleID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
 
SET IDENTITY_INSERT [dbo].[Charts] ON 

INSERT [dbo].[Charts] ([ID], [Name], [UserID], [Note]) VALUES (1, N'chart1', 2, N'chart1note')
INSERT [dbo].[Charts] ([ID], [Name], [UserID], [Note]) VALUES (3, N'444xx', 2, N'4444xx')
SET IDENTITY_INSERT [dbo].[Charts] OFF
SET IDENTITY_INSERT [dbo].[CipherCDs] ON 

INSERT [dbo].[CipherCDs] ([ID], [Value]) VALUES (1, N'B')
INSERT [dbo].[CipherCDs] ([ID], [Value]) VALUES (2, N'C')
INSERT [dbo].[CipherCDs] ([ID], [Value]) VALUES (3, N'C/K')
INSERT [dbo].[CipherCDs] ([ID], [Value]) VALUES (4, N'G')
INSERT [dbo].[CipherCDs] ([ID], [Value]) VALUES (5, N'K')
INSERT [dbo].[CipherCDs] ([ID], [Value]) VALUES (6, N'L')
INSERT [dbo].[CipherCDs] ([ID], [Value]) VALUES (7, N'P')
INSERT [dbo].[CipherCDs] ([ID], [Value]) VALUES (8, N'Y')
INSERT [dbo].[CipherCDs] ([ID], [Value]) VALUES (9, N'"L"')
SET IDENTITY_INSERT [dbo].[CipherCDs] OFF
SET IDENTITY_INSERT [dbo].[Ciphers] ON 

INSERT [dbo].[Ciphers] ([ID], [Value]) VALUES (1, N'0')
INSERT [dbo].[Ciphers] ([ID], [Value]) VALUES (2, N'2')
INSERT [dbo].[Ciphers] ([ID], [Value]) VALUES (3, N'2W')
INSERT [dbo].[Ciphers] ([ID], [Value]) VALUES (4, N'4')
INSERT [dbo].[Ciphers] ([ID], [Value]) VALUES (5, N'6')
INSERT [dbo].[Ciphers] ([ID], [Value]) VALUES (6, N'8')
INSERT [dbo].[Ciphers] ([ID], [Value]) VALUES (7, N'10')
INSERT [dbo].[Ciphers] ([ID], [Value]) VALUES (8, N'10DL')
INSERT [dbo].[Ciphers] ([ID], [Value]) VALUES (9, N'10SL')
INSERT [dbo].[Ciphers] ([ID], [Value]) VALUES (10, N'10WL')
SET IDENTITY_INSERT [dbo].[Ciphers] OFF
SET IDENTITY_INSERT [dbo].[Cycles] ON 

INSERT [dbo].[Cycles] ([ID], [Note], [MCS], [ChartID], [RowNumber]) VALUES (1, N'&nbsp;', 0, 1, 0)
INSERT [dbo].[Cycles] ([ID], [Note], [MCS], [ChartID], [RowNumber]) VALUES (2, N'&nbsp;', 0, 1, 1)
SET IDENTITY_INSERT [dbo].[Cycles] OFF
SET IDENTITY_INSERT [dbo].[Letters] ON 

INSERT [dbo].[Letters] ([ID], [Value]) VALUES (1, N'M')
INSERT [dbo].[Letters] ([ID], [Value]) VALUES (2, N'H')
INSERT [dbo].[Letters] ([ID], [Value]) VALUES (3, N'L')
INSERT [dbo].[Letters] ([ID], [Value]) VALUES (4, N'VL')
INSERT [dbo].[Letters] ([ID], [Value]) VALUES (8, N'VVL')
SET IDENTITY_INSERT [dbo].[Letters] OFF
SET IDENTITY_INSERT [dbo].[Markers] ON 

INSERT [dbo].[Markers] ([ID], [Name], [MarkerUrl]) VALUES (1, N'red', N'http://kubamiszcz.hekko24.pl/Naprokarta/img/markerRed.jpg')
INSERT [dbo].[Markers] ([ID], [Name], [MarkerUrl]) VALUES (2, N'green', N'http://kubamiszcz.hekko24.pl/Naprokarta/img/markerGreen.jpg')
INSERT [dbo].[Markers] ([ID], [Name], [MarkerUrl]) VALUES (3, N'yellow', N'http://kubamiszcz.hekko24.pl/Naprokarta/img/markerYellow.jpg')
INSERT [dbo].[Markers] ([ID], [Name], [MarkerUrl]) VALUES (4, N'whitebaby', N'http://kubamiszcz.hekko24.pl/Naprokarta/img/markerWhiteBaby.jpg')
INSERT [dbo].[Markers] ([ID], [Name], [MarkerUrl]) VALUES (5, N'greenbaby', N'http://kubamiszcz.hekko24.pl/Naprokarta/img/markerGreenBaby.jpg')
INSERT [dbo].[Markers] ([ID], [Name], [MarkerUrl]) VALUES (6, N'yellowbaby', N'http://kubamiszcz.hekko24.pl/Naprokarta/img/markerYellowBaby.jpg')
INSERT [dbo].[Markers] ([ID], [Name], [MarkerUrl]) VALUES (7, N'grey', N'http://kubamiszcz.hekko24.pl/Naprokarta/img/markerGrey.jpg')
SET IDENTITY_INSERT [dbo].[Markers] OFF
SET IDENTITY_INSERT [dbo].[Notes] ON 

INSERT [dbo].[Notes] ([ID], [Content], [IsImportant], [ObservationID]) VALUES (29, N'sad', 0, 43)
INSERT [dbo].[Notes] ([ID], [Content], [IsImportant], [ObservationID]) VALUES (30, N'ret', 1, 42)
INSERT [dbo].[Notes] ([ID], [Content], [IsImportant], [ObservationID]) VALUES (37, N'asd', 0, 41)
INSERT [dbo].[Notes] ([ID], [Content], [IsImportant], [ObservationID]) VALUES (38, N'asd', 0, 45)
INSERT [dbo].[Notes] ([ID], [Content], [IsImportant], [ObservationID]) VALUES (39, N'asd', 0, 47)
SET IDENTITY_INSERT [dbo].[Notes] OFF
SET IDENTITY_INSERT [dbo].[NumTimes] ON 

INSERT [dbo].[NumTimes] ([ID], [Value]) VALUES (1, N'X1')
INSERT [dbo].[NumTimes] ([ID], [Value]) VALUES (2, N'X2')
INSERT [dbo].[NumTimes] ([ID], [Value]) VALUES (3, N'X3')
INSERT [dbo].[NumTimes] ([ID], [Value]) VALUES (4, N'AD')
SET IDENTITY_INSERT [dbo].[NumTimes] OFF
SET IDENTITY_INSERT [dbo].[Observations] ON 

INSERT [dbo].[Observations] ([ID], [CycleID], [Date], [MarkerID], [LetterID], [LetterIsB], [CipherID], [CipherCDID], [NumTimesID], [CommentVisit], [CommentMedicalTest], [CommentLupucupu], [ColNumber], [PeakNum]) VALUES (41, 1, CAST(N'2017-09-08T00:00:00.000' AS DateTime), 6, 8, 1, 7, 4, 2, 1, 0, 1, 4, -1)
INSERT [dbo].[Observations] ([ID], [CycleID], [Date], [MarkerID], [LetterID], [LetterIsB], [CipherID], [CipherCDID], [NumTimesID], [CommentVisit], [CommentMedicalTest], [CommentLupucupu], [ColNumber], [PeakNum]) VALUES (42, 1, CAST(N'2017-09-08T00:00:00.000' AS DateTime), 4, NULL, 0, NULL, 2, NULL, 0, 0, 0, 3, -1)
INSERT [dbo].[Observations] ([ID], [CycleID], [Date], [MarkerID], [LetterID], [LetterIsB], [CipherID], [CipherCDID], [NumTimesID], [CommentVisit], [CommentMedicalTest], [CommentLupucupu], [ColNumber], [PeakNum]) VALUES (43, 1, CAST(N'2017-09-08T00:00:00.000' AS DateTime), NULL, NULL, 0, 3, NULL, NULL, 0, 1, 0, 2, -1)
INSERT [dbo].[Observations] ([ID], [CycleID], [Date], [MarkerID], [LetterID], [LetterIsB], [CipherID], [CipherCDID], [NumTimesID], [CommentVisit], [CommentMedicalTest], [CommentLupucupu], [ColNumber], [PeakNum]) VALUES (44, 1, CAST(N'2017-09-08T00:00:00.000' AS DateTime), 5, NULL, 0, NULL, NULL, NULL, 0, 0, 0, 5, -1)
INSERT [dbo].[Observations] ([ID], [CycleID], [Date], [MarkerID], [LetterID], [LetterIsB], [CipherID], [CipherCDID], [NumTimesID], [CommentVisit], [CommentMedicalTest], [CommentLupucupu], [ColNumber], [PeakNum]) VALUES (45, 1, CAST(N'2017-09-08T00:00:00.000' AS DateTime), 6, NULL, 0, NULL, NULL, 2, 0, 1, 0, 7, -1)
INSERT [dbo].[Observations] ([ID], [CycleID], [Date], [MarkerID], [LetterID], [LetterIsB], [CipherID], [CipherCDID], [NumTimesID], [CommentVisit], [CommentMedicalTest], [CommentLupucupu], [ColNumber], [PeakNum]) VALUES (46, 2, CAST(N'2017-09-08T00:00:00.000' AS DateTime), 3, NULL, 1, 7, NULL, NULL, 0, 0, 0, 6, -1)
INSERT [dbo].[Observations] ([ID], [CycleID], [Date], [MarkerID], [LetterID], [LetterIsB], [CipherID], [CipherCDID], [NumTimesID], [CommentVisit], [CommentMedicalTest], [CommentLupucupu], [ColNumber], [PeakNum]) VALUES (47, 2, CAST(N'2017-09-08T00:00:00.000' AS DateTime), 7, NULL, 0, 9, NULL, NULL, 0, 0, 0, 4, -1)
SET IDENTITY_INSERT [dbo].[Observations] OFF
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([ID], [Name]) VALUES (1, N'admin')
INSERT [dbo].[Roles] ([ID], [Name]) VALUES (2, N'user')
INSERT [dbo].[Roles] ([ID], [Name]) VALUES (3, N'instructor')
SET IDENTITY_INSERT [dbo].[Roles] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([ID], [Login], [Password], [UserName], [Email], [RegisterDate], [LastLoginDate], [Note], [RoleID]) VALUES (1, N'admin', N'p', N'AdminName', N'admin@email.com', CAST(N'1999-01-01T00:00:00.000' AS DateTime), CAST(N'1999-01-01T00:00:00.000' AS DateTime), N'asd', 1)
INSERT [dbo].[Users] ([ID], [Login], [Password], [UserName], [Email], [RegisterDate], [LastLoginDate], [Note], [RoleID]) VALUES (2, N'ula', N'p', N'Ula Slodziuchna', N'ula@slodziuchna.com', CAST(N'1999-01-01T00:00:00.000' AS DateTime), CAST(N'1999-01-01T00:00:00.000' AS DateTime), N'qe', 2)
INSERT [dbo].[Users] ([ID], [Login], [Password], [UserName], [Email], [RegisterDate], [LastLoginDate], [Note], [RoleID]) VALUES (3, N'instr1', N'p', N'Insztruktori Numero Uno', N'instr1@numerouno.com', CAST(N'1999-01-01T00:00:00.000' AS DateTime), CAST(N'1999-01-01T00:00:00.000' AS DateTime), N'wqe', 3)
INSERT [dbo].[Users] ([ID], [Login], [Password], [UserName], [Email], [RegisterDate], [LastLoginDate], [Note], [RoleID]) VALUES (5, N'id5', N'p', N'id5sss', N'ula@slodziuchna.com', CAST(N'1999-01-01T00:00:00.000' AS DateTime), CAST(N'1999-01-01T00:00:00.000' AS DateTime), N'xxx', 2)
SET IDENTITY_INSERT [dbo].[Users] OFF
/****** Object:  Index [IX_UserID]    Script Date: 2017-09-08 12:25:49 ******/
CREATE NONCLUSTERED INDEX [IX_UserID] ON [dbo].[Charts]
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
 /****** Object:  Index [IX_ChartID]    Script Date: 2017-09-08 12:25:49 ******/
CREATE NONCLUSTERED INDEX [IX_ChartID] ON [dbo].[Cycles]
(
	[ChartID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
 /****** Object:  Index [IX_ObservationID]    Script Date: 2017-09-08 12:25:49 ******/
CREATE NONCLUSTERED INDEX [IX_ObservationID] ON [dbo].[Notes]
(
	[ObservationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
 /****** Object:  Index [IX_CipherCDID]    Script Date: 2017-09-08 12:25:49 ******/
CREATE NONCLUSTERED INDEX [IX_CipherCDID] ON [dbo].[Observations]
(
	[CipherCDID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
 /****** Object:  Index [IX_CipherID]    Script Date: 2017-09-08 12:25:49 ******/
CREATE NONCLUSTERED INDEX [IX_CipherID] ON [dbo].[Observations]
(
	[CipherID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
 /****** Object:  Index [IX_CycleID]    Script Date: 2017-09-08 12:25:49 ******/
CREATE NONCLUSTERED INDEX [IX_CycleID] ON [dbo].[Observations]
(
	[CycleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
 /****** Object:  Index [IX_LetterID]    Script Date: 2017-09-08 12:25:49 ******/
CREATE NONCLUSTERED INDEX [IX_LetterID] ON [dbo].[Observations]
(
	[LetterID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
 /****** Object:  Index [IX_MarkerID]    Script Date: 2017-09-08 12:25:49 ******/
CREATE NONCLUSTERED INDEX [IX_MarkerID] ON [dbo].[Observations]
(
	[MarkerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
 /****** Object:  Index [IX_NumTimesID]    Script Date: 2017-09-08 12:25:49 ******/
CREATE NONCLUSTERED INDEX [IX_NumTimesID] ON [dbo].[Observations]
(
	[NumTimesID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
 /****** Object:  Index [IX_ObservationID]    Script Date: 2017-09-08 12:25:49 ******/
CREATE NONCLUSTERED INDEX [IX_ObservationID] ON [dbo].[Pictures]
(
	[ObservationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
 /****** Object:  Index [IX_RoleID]    Script Date: 2017-09-08 12:25:49 ******/
CREATE NONCLUSTERED INDEX [IX_RoleID] ON [dbo].[Users]
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
 ALTER TABLE [dbo].[Charts]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Charts_dbo.Users_UserID] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([ID])
ON DELETE CASCADE
 ALTER TABLE [dbo].[Charts] CHECK CONSTRAINT [FK_dbo.Charts_dbo.Users_UserID]
 ALTER TABLE [dbo].[Cycles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Cycles_dbo.Charts_ChartID] FOREIGN KEY([ChartID])
REFERENCES [dbo].[Charts] ([ID])
ON DELETE CASCADE
 ALTER TABLE [dbo].[Cycles] CHECK CONSTRAINT [FK_dbo.Cycles_dbo.Charts_ChartID]
 ALTER TABLE [dbo].[Notes]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Notes_dbo.Observations_ObservationID] FOREIGN KEY([ObservationID])
REFERENCES [dbo].[Observations] ([ID])
ON DELETE CASCADE
 ALTER TABLE [dbo].[Notes] CHECK CONSTRAINT [FK_dbo.Notes_dbo.Observations_ObservationID]
 ALTER TABLE [dbo].[Observations]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Observations_dbo.CipherCDs_CipherCDID] FOREIGN KEY([CipherCDID])
REFERENCES [dbo].[CipherCDs] ([ID])
 ALTER TABLE [dbo].[Observations] CHECK CONSTRAINT [FK_dbo.Observations_dbo.CipherCDs_CipherCDID]
 ALTER TABLE [dbo].[Observations]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Observations_dbo.Ciphers_CipherID] FOREIGN KEY([CipherID])
REFERENCES [dbo].[Ciphers] ([ID])
 ALTER TABLE [dbo].[Observations] CHECK CONSTRAINT [FK_dbo.Observations_dbo.Ciphers_CipherID]
 ALTER TABLE [dbo].[Observations]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Observations_dbo.Cycles_CycleID] FOREIGN KEY([CycleID])
REFERENCES [dbo].[Cycles] ([ID])
ON DELETE CASCADE
 ALTER TABLE [dbo].[Observations] CHECK CONSTRAINT [FK_dbo.Observations_dbo.Cycles_CycleID]
 ALTER TABLE [dbo].[Observations]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Observations_dbo.Letters_LetterID] FOREIGN KEY([LetterID])
REFERENCES [dbo].[Letters] ([ID])
 ALTER TABLE [dbo].[Observations] CHECK CONSTRAINT [FK_dbo.Observations_dbo.Letters_LetterID]
 ALTER TABLE [dbo].[Observations]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Observations_dbo.Markers_MarkerID] FOREIGN KEY([MarkerID])
REFERENCES [dbo].[Markers] ([ID])
 ALTER TABLE [dbo].[Observations] CHECK CONSTRAINT [FK_dbo.Observations_dbo.Markers_MarkerID]
 ALTER TABLE [dbo].[Observations]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Observations_dbo.NumTimes_NumTimesID] FOREIGN KEY([NumTimesID])
REFERENCES [dbo].[NumTimes] ([ID])
 ALTER TABLE [dbo].[Observations] CHECK CONSTRAINT [FK_dbo.Observations_dbo.NumTimes_NumTimesID]
 ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Users_dbo.Roles_RoleID] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([ID])
ON DELETE CASCADE
 ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_dbo.Users_dbo.Roles_RoleID]
