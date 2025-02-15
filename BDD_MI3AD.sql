﻿
create database USERSDB
GO
USE [USERSDB]
GO
/****** Object:  Table [dbo].[Admins]    Script Date: 8/6/2020 5:19:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admins](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[A_LOGIN] [varchar](100) NULL,
	[A_MDP] [varchar](100) NULL,
	[A_EMAIL] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Aviss]    Script Date: 8/6/2020 5:19:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Aviss](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ID_RDV] [int] NULL,
	[NOTE_FACIL] [int] NULL,
	[NOTE_ACCUEIL] [int] NULL,
	[NOTE_PROMPATITUDE] [int] NULL,
	[NOTE_DIAG] [int] NULL,
	[NOTE_RECOM] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Doctors]    Script Date: 8/6/2020 5:19:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doctors](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NOM] [nvarchar](50) NULL,
	[PRENOM] [nvarchar](100) NULL,
	[MDP] [nvarchar](100) NULL,
	[EMAIL] [nvarchar](100) NULL,
	[TEL] [nvarchar](100) NULL,
	[SPECIALITE] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RDVs]    Script Date: 8/6/2020 5:19:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RDVs](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ID_User] [int] NULL,
	[ID_Doctor] [int] NULL,
	[ETAT] [nvarchar](100) NULL,
	[DATER] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 8/6/2020 5:19:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NOM] [nvarchar](50) NULL,
	[EMAIL] [nvarchar](100) NULL,
	[PHONE] [nvarchar](100) NULL,
	[PRENOM] [varchar](255) NULL,
	[MDP] [varchar](255) NULL,
	[TEL] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


set identity_insert Doctors ON

Insert into Doctors (ID , NOM , PRENOM , MDP , EMAIL, TEL , SPECIALITE ) 
	values (1 , 'WAHABI' , 'Akram' , '1234', 'wahabbi.dr@gmail.com', '0539896694','general')
Insert into Doctors (ID , NOM , PRENOM , MDP , EMAIL, TEL , SPECIALITE ) 
	values (2 , 'Benanni' , 'Ayoub' , '1447', 'bennani.dr@gmail.com', '0539896694', 'Pediatre')
Insert into Doctors (ID , NOM , PRENOM , MDP , EMAIL, TEL , SPECIALITE ) 
	values (3 , 'Fennan' , 'Asame' , '1998', 'fennan.dr@gmail.com', '0539854194', 'Gynecologue')

set identity_insert Doctors OFF
set identity_insert Users ON

Insert into Users (ID , NOM , PRENOM , MDP , EMAIL, TEL ) 
	values (1 , 'ABOUJID' , 'Asmae' , '5597', 'aboujid@gmail.com', '0600854194')
Insert into Users (ID , NOM , PRENOM , MDP , EMAIL, TEL ) 
	values (2 , 'WAHABI' , 'Ayman' , '1234', 'wahabbi@gmail.com', '0600854194')
Insert into Users (ID , NOM , PRENOM , MDP , EMAIL, TEL ) 
	values (3 , 'ALAOUI' , 'Fatima' , '9887', 'alaoui@gmail.com', '0600854194')


set identity_insert Users OFF
set identity_insert Admins ON

Insert into Admins (ID , A_LOGIN , A_MDP , A_EMAIL ) 
	values (1 , 'admin' ,'admin' , 'admin@gmail.com')

set identity_insert Admins OFF
set identity_insert RDVs ON

Insert into RDVs (ID , ID_USER , ID_Doctor , ETAT , DATER ) 
	values (1 , 3 , 1 , 'En cours de traitement ', '10-07-2020 15:00')
Insert into RDVs (ID , ID_USER , ID_Doctor , ETAT , DATER ) 
	values (2 , 4 , 1  , 'En cours de traitement ', '12-07-2020 14:00')
Insert into RDVs (ID , ID_USER , ID_Doctor , ETAT , DATER ) 
	values (3 , 5 , 3  , 'En cours de traitement ', '05-07-2020 09:00')

set identity_insert RDVs OFF
set identity_insert Aviss ON

Insert into Aviss(ID , ID_RDV, NOTE_FACIL , NOTE_ACCUEIL , NOTE_DIAG, NOTE_PROMPATITUDE , NOTE_RECOM ) 
	values (1 , 2 , 3 , 2 , 3 , 2 ,4 )
Insert into Aviss(ID , ID_RDV, NOTE_FACIL , NOTE_ACCUEIL , NOTE_DIAG, NOTE_PROMPATITUDE , NOTE_RECOM ) 
	values (2 , 1 , 3 , 4 , 4 , 2 ,4 )
Insert into Aviss(ID , ID_RDV, NOTE_FACIL , NOTE_ACCUEIL , NOTE_DIAG, NOTE_PROMPATITUDE , NOTE_RECOM ) 
	values (3 , 3 ,3 , 3 , 2 , 2 ,4 )
