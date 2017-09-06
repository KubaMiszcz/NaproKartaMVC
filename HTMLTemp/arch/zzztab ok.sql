<TABLE BORDER="0"  CELLPADDING="0" CELLSPACING="0" style="border: 1px solid black;">
<Td>
<TABLE BORDER="1" CELLPADDING="0" CELLSPACING="0" style="border: 1px solid black;">
           <tr><TD><img src="http://kubamiszcz.hekko24.pl/Naprokarta/img/markerGreenBaby.jpg" style="width:75px;"></TD></tr>
           <tr><TD>2nd Table</TD></tr>
           <tr><TD>2nd Table</TD></tr>
           <tr><TD>2nd Table</TD></tr>
           </TABLE>
</Td>
<Td>
<TABLE BORDER="1" CELLPADDING="0" CELLSPACING="0" style="border: 1px solid black;">
           <tr><TD><img src="http://kubamiszcz.hekko24.pl/Naprokarta/img/markerGreenBaby.jpg" style="width:75px;"></TD></tr>
           <tr><TD>2nd Table</TD></tr>
           <tr><TD>2nd Table</TD></tr>
           <tr><TD>2nd Table</TD></tr>
           </TABLE>
</Td>
</TABLE>
<TABLE BORDER="0"  CELLPADDING="0" CELLSPACING="0" style="border: 1px solid black;">
<Td>
<TABLE BORDER="1" CELLPADDING="0" CELLSPACING="0" style="border: 1px solid black;">
           <tr><TD><img src="http://kubamiszcz.hekko24.pl/Naprokarta/img/markerGreenBaby.jpg" style="width:75px;"></TD></tr>
           <tr><TD>2nd Table</TD></tr>
           <tr><TD>2nd Table</TD></tr>
           <tr><TD>2nd Table</TD></tr>
           </TABLE>
</Td>
<Td>
<TABLE BORDER="1" CELLPADDING="0" CELLSPACING="0" style="border: 1px solid black;">
           <tr><TD><img src="http://kubamiszcz.hekko24.pl/Naprokarta/img/markerGreenBaby.jpg" style="width:75px;"></TD></tr>
           <tr><TD>2nd Table</TD></tr>
           <tr><TD>2nd Table</TD></tr>
           <tr><TD>2nd Table</TD></tr>
           </TABLE>
</Td>
</TABLE>


INSERT INTO [dbo].[Markers]
           ([Name]
           ,[Address])
     VALUES
           ('red','http://kubamiszcz.hekko24.pl/Naprokarta/img/markerRed.jpg'),
		   ('green','http://kubamiszcz.hekko24.pl/Naprokarta/img/markerGreen.jpg'),
		   ('yellow','http://kubamiszcz.hekko24.pl/Naprokarta/img/markerYellow.jpg'),
		   ('whitebaby','http://kubamiszcz.hekko24.pl/Naprokarta/img/markerWhiteBaby.jpg'),
		   ('greenbaby','http://kubamiszcz.hekko24.pl/Naprokarta/img/markerGreenBaby.jpg'),
		   ('yellowbaby','http://kubamiszcz.hekko24.pl/Naprokarta/img/markerYellowBaby.jpg'),
		   ('grey','http://kubamiszcz.hekko24.pl/Naprokarta/img/markerGrey.jpg')

INSERT INTO [dbo].[CipherCDs]
           ([CipherName])
     VALUES
		   (''),
           ('B'),
		   ('C'),
		   ('C/K'),
		   ('G'),
		   ('K'),
		   ('L'),
		   ('P'),
		   ('Y'),
		   ('"L"')

INSERT INTO [dbo].[Ciphers]
           ([CipherName])
     VALUES
           ('0'),
		   ('2'),
		   ('2W'),
		   ('4'),
		   ('6'),
		   ('8'),
		   ('10'),
		   ('10DL'),
		   ('10SL'),
		   ('10WL')

INSERT INTO [dbo].[LetterValues]
           ([Value])
     VALUES
           ('M'),
		   ('H'),
		   ('L'),
		   ('VL'),
		   ('VVL')

INSERT INTO [dbo].[NumTimes]
           ([NumTimesSymbol])
     VALUES
           ('X1'),
		   ('X2'),
		   ('X3'),
		   ('AD')
		   
-- INSERT INTO [dbo].[Comments]
           -- ([Content]
           -- ,[Value]
           -- ,[Observation_ID])
     -- VALUES
           -- (<Content, nvarchar(max),>
           -- ,<Value, bit,>
           -- ,<Observation_ID, int,>)

INSERT INTO [dbo].[Roles]
           ([Name])
     VALUES
           ('admin'),
		   ('user'),
		   ('instructor')

INSERT INTO [dbo].[Users]
           ([UserName]
           ,[Email]
           ,[RegisterDate]
           ,[LastLoginDate]
           ,[Role_ID])
     VALUES
           ('admin','email@email.com','1999-01-01','1999-01-01',1),
		   ('Ula Slodziuchna','ula@slodziuchna.com','1999-01-01','1999-01-01',2),
		   ('Insztruktori Numero Uno','instructor@numerouno.com','1999-01-01','1999-01-01',3)
