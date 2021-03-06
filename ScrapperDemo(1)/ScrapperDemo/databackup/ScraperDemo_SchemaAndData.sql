USE [master]
GO
/****** Object:  Database [WebScraperDemo]    Script Date: 23/10/2015 15:09:44 ******/
CREATE DATABASE [WebScraperDemo] ON  PRIMARY 
( NAME = N'ScrapperDemo', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SATWADHIR\MSSQL\DATA\ScrapperDemo.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ScrapperDemo_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SATWADHIR\MSSQL\DATA\ScrapperDemo_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WebScraperDemo].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WebScraperDemo] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WebScraperDemo] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WebScraperDemo] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WebScraperDemo] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WebScraperDemo] SET ARITHABORT OFF 
GO
ALTER DATABASE [WebScraperDemo] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [WebScraperDemo] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WebScraperDemo] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WebScraperDemo] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WebScraperDemo] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [WebScraperDemo] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WebScraperDemo] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WebScraperDemo] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WebScraperDemo] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WebScraperDemo] SET  DISABLE_BROKER 
GO
ALTER DATABASE [WebScraperDemo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WebScraperDemo] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WebScraperDemo] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WebScraperDemo] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WebScraperDemo] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WebScraperDemo] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [WebScraperDemo] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WebScraperDemo] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [WebScraperDemo] SET  MULTI_USER 
GO
ALTER DATABASE [WebScraperDemo] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WebScraperDemo] SET DB_CHAINING OFF 
GO
USE [WebScraperDemo]
GO
/****** Object:  Table [dbo].[ScraperPageTextData]    Script Date: 23/10/2015 15:09:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ScraperPageTextData](
	[AWNO] [nchar](10) NOT NULL,
	[webURL] [varchar](50) NOT NULL,
	[web1URL] [varchar](50) NOT NULL,
	[web2URL] [varchar](50) NOT NULL,
	[isURLsimilar] [char](10) NOT NULL,
	[scrapDateTime] [datetime] NOT NULL,
	[pageContentText] [varchar](max) NULL,
	[SearchContentText] [varchar](max) NULL,
	[SearchDateTime] [datetime] NULL,
	[AnalyzeNo] [numeric](18, 0) NULL,
 CONSTRAINT [PK_ScraperPageTextData] PRIMARY KEY CLUSTERED 
(
	[AWNO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ScraperRecordMain]    Script Date: 23/10/2015 15:09:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ScraperRecordMain](
	[AWNO] [nchar](10) NOT NULL,
	[webURL] [varchar](50) NOT NULL,
	[web1URL] [varchar](50) NOT NULL,
	[web2URL] [varchar](50) NOT NULL,
	[scrapDateTime] [datetime] NOT NULL,
	[AnalyzeNo] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_ScraperRecordMain] PRIMARY KEY CLUSTERED 
(
	[AWNO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ScrapperRecordsPreviousOnly]    Script Date: 23/10/2015 15:09:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ScrapperRecordsPreviousOnly](
	[AWNO] [nchar](10) NULL,
	[webURL] [varchar](50) NULL,
	[web1URL] [varchar](50) NULL,
	[web2URL] [varchar](50) NULL,
	[scrapDateTime] [datetime] NULL,
	[AnalyzeNo] [numeric](18, 0) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[ScraperPageTextData] ([AWNO], [webURL], [web1URL], [web2URL], [isURLsimilar], [scrapDateTime], [pageContentText], [SearchContentText], [SearchDateTime], [AnalyzeNo]) VALUES (N'10        ', N'http://www.cadfolks.com', N'n/a', N'n/a', N'false     ', CAST(N'2015-10-23 00:00:00.000' AS DateTime), N'System.Windows.Controls.TextBox: +91 92-8989-4040 / 0124 400-1616 cadfolks@gmail.com / training@cadfolks.com Toggle navigation   HOME
 
SERVICES
 
TUTORIALS
 
COURSES
 
BOOKS 
NEW REGISTRATION 
CONTACT US
 
PARTNERS
 

 WELCOME TO CADFOLKS
CADFolks provides training on CAD/CAM/CAE Softwares such as AutoCAD, CATIA, SolidWorks, Autodesk Inventor, Solid Edge, Pro-Engineer/Creo, and Unigraphics/NX. It also provides consulting services in CAD/CAM/CAE domains. Our consulting services include CAD design, CAD drafting, CAD drawing conversion, assembly to detail drawings, and solid modeling.
We have our office in Gurgaon, Near New Delhi from where we can cater to the Engineering Design requirements of our global customers. Learn from Experts
Learn from our well experienced professionals who use CAD/CAM/CAE software’s daily. Free Support upto One year
Get free technical help upto 1 year on any topic related to your course. Free Course Workbook
Get a free course workbook designed by our experts. Valuable Tips and Tricks
Get valuable tips and tricks to save time and improve your productivity. 
Welcome to CADFolks Pvt. Ltd. 
Help You Design Better


SERVICES 


 WORKSHOPS 
New Batch Starts From 1st May 2015 onwards
We also provide short term course 
We Provide six months Industrial Training also

 UPCOMING EVENTS 
Summer Internship Programme - 2015
Two Hours Free WorkShop On AutoCad, Catia, SolidWorks and other CAD Softwares in Weekends.
We have published AutoCad, Catia, NX books. Other books we will publish very soon. 
We launch our new IT- web portal 

 PROJECT CONSULTANCY 
We are Providing Project Consultancy Services to our different clients from past few years 
Our Clients : Civil, Mechanical, Architectural, Electrical

 CONSULTANCY SERVICES Innovision consultants 
a leading recruitment firm 




VIDEO TUTORIALS 


  MECHANICAL CAD BASIC DRAWING TOOLS 1 IN AUTOCAD 
BASIC DRAWING TOOLS 2 IN AUTOCAD 
DIMENSIONING IN AUTOCAD
MODIFYING TOOLS IN AUTOCAD 
Working on Layers 
2D LAYOUT CREATING 3D OBJECTS 
SOLIDEDITING IN AUTOCAD 
Working on UCS 
SOLID EDITING SLICE AND SHELL 
  ELECTRICAL CAD 
REPORT GENERATION 
SOURCE ARROW 
COPY A COMPONENT 
CREATING 3 PHASE CIRCUIT 
DELETING COMPONENTS 
CREATING PANEL 
PLACING CONNECTORS 
RETAGGING COMPONENTS 
ARRANGMENT OF COMPONENTS 
PLACING MULTIPLE COMPONENTS 
MULTUPLE COMPONENT 
SAVING CIRCUIT TO ICON MENU 
MOVING AND ALIGNING COMPONENTS 
Placing wires on different angles 
PLC DESIGN SWAP A COMPONENT 
creating parent child relationship 
creating new project in autocad electrical
  CIVIL / ARCHITECTURE CAD 
BASIC DRAWING TOOLS 2 IN AUTOCAD
DIMENSIONING IN AUTOCAD
BASIC DRAWING TOOLS 2 IN AUTOCAD
DIMENSIONING IN AUTOCAD
AREA LEGEND (REVIT ARCHITECTURE)
CREATING FLAT ROOF (REVIT ARCHITECTURE)
CREATING LEVELS (REVIT ARCHITECTURE)
CREATING ROOF (REVIT ARCHITECTURE)
CREATING STAIRS (REVIT ARCHITECTURE)
CREATING WALLS (REVIT ARCHITECTURE)
DIMENSIONING (REVIT ARCHITECTURE)
DROMER OPENING (REVIT ARCHITECTURE)
EMBEDDED WALLS (REVIT ARCHITECTURE)
PLACING FLOOR (REVIT ARCHITECTURE)
PLACING TEXT IN REVIT ARCHITECTURE (REVIT ARCHITECTURE)
ROOM LEGEND (REVIT ARCHITECTURE)
WALL OPENING AND EDIDTING (REVIT ARCHITECTURE)
  STAAD PRO 
MODEL USING SNAP GRID 
SELECTION OF ELEMENTS 
DESIGN OF RCC STRUCTURE 
WIND LOAD ANALYSIS 
ASSIGNING DEAD AND LIVE LOADS 
CREATING LOAD COMBINATIONS 
IMPORTING AutoCAD FILE IN STAAD 
MODELING USING STRUCTURE WIZARD 
ANALYSIS OF A SIMPLE BEAM 
ASSIGINING MOVING LOADS 



TRAININGS & OUR COURSES 

Proper training is one of the most important factors in determining your success. With qualified trainers, we provide training for a variety of applications. Not only do our trainers have industry experience, but they continue to use the software we support in real-world applications. Whether manufacturing, architecture or engineering, our instructors’ top credentials, deep industry knowledge and enthusiasm will help you work better and smarter. With our experienced trainers, we can provide on-site training (in colleges and organizations), or you can use one of our fully equipped training classrooms. The advantages of training with CADFolks are: 
We have industry experts as instructors 
Small classes and personalized attention 
Free technical help upto one year after training (for the same software) 
Flexible time schedule 
Free industry standard course workbook, sample files, and exercises 
Valuable Tips & Tricks

 AutoCAD



SEARCH MORE ANSYS



SEARCH MORE AUTODESK INVENTOR



SEARCH MORE REVIT ARCHITECTURE



SEARCH MORE CATIA



SEARCH MORE CREO



SEARCH MORE Unigraphics NX2



SEARCH MORE SOLID WORK TRAINING



SEARCH MORE STAAD PRO TRAINING



SEARCH MORE SOLID EDGE_2



SEARCH MORELOAD MORE 


CONTACT US 


Map Data
Map DataTerms of UseReport a map error
Map
OMAXE GURGAON MALL, BEHIND SRS VALUE BAZAAR, SEC 49, SOHNA ROAD, Gurgaon - 122018 ( Haryana ) CADFolks Private Limited
OMAXE GURGAON MALL, BEHIND SRS VALUE BAZAAR, SEC 49, SOHNA ROAD , Gurgaon - 122018 ( Haryana )
 +91-9289894040, 0124 400-1616
www.cadfolks.com
 
 
 
 
SEND 


OUR PARTNERS 


Unitech BooksGo4WebTechInnovisionconsultants CloseBESbewy', N'', CAST(N'2015-10-23 07:10:36.000' AS DateTime), CAST(110 AS Numeric(18, 0)))
INSERT [dbo].[ScraperPageTextData] ([AWNO], [webURL], [web1URL], [web2URL], [isURLsimilar], [scrapDateTime], [pageContentText], [SearchContentText], [SearchDateTime], [AnalyzeNo]) VALUES (N'5         ', N'http://www.cadfolks.com', N'n/a', N'n/a', N'false     ', CAST(N'2015-10-22 00:00:00.000' AS DateTime), N'System.Windows.Controls.TextBox: +91 92-8989-4040 / 0124 400-1616 cadfolks@gmail.com / training@cadfolks.com Toggle navigation   HOME
 
SERVICES
 
TUTORIALS
 
COURSES
 
BOOKS 
NEW REGISTRATION 
CONTACT US
 
PARTNERS
 

 WELCOME TO CADFOLKS
CADFolks provides training on CAD/CAM/CAE Softwares such as AutoCAD, CATIA, SolidWorks, Autodesk Inventor, Solid Edge, Pro-Engineer/Creo, and Unigraphics/NX. It also provides consulting services in CAD/CAM/CAE domains. Our consulting services include CAD design, CAD drafting, CAD drawing conversion, assembly to detail drawings, and solid modeling.
We have our office in Gurgaon, Near New Delhi from where we can cater to the Engineering Design requirements of our global customers. Learn from Experts
Learn from our well experienced professionals who use CAD/CAM/CAE software’s daily. Free Support upto One year
Get free technical help upto 1 year on any topic related to your course. Free Course Workbook
Get a free course workbook designed by our experts. Valuable Tips and Tricks
Get valuable tips and tricks to save time and improve your productivity. 
Welcome to CADFolks Pvt. Ltd. 
Help You Design Better


SERVICES 


 WORKSHOPS 
New Batch Starts From 1st May 2015 onwards
We also provide short term course 
We Provide six months Industrial Training also

 UPCOMING EVENTS 
Summer Internship Programme - 2015
Two Hours Free WorkShop On AutoCad, Catia, SolidWorks and other CAD Softwares in Weekends.
We have published AutoCad, Catia, NX books. Other books we will publish very soon. 
We launch our new IT- web portal 

 PROJECT CONSULTANCY 
We are Providing Project Consultancy Services to our different clients from past few years 
Our Clients : Civil, Mechanical, Architectural, Electrical

 CONSULTANCY SERVICES Innovision consultants 
a leading recruitment firm 




VIDEO TUTORIALS 


  MECHANICAL CAD BASIC DRAWING TOOLS 1 IN AUTOCAD 
BASIC DRAWING TOOLS 2 IN AUTOCAD 
DIMENSIONING IN AUTOCAD
MODIFYING TOOLS IN AUTOCAD 
Working on Layers 
2D LAYOUT CREATING 3D OBJECTS 
SOLIDEDITING IN AUTOCAD 
Working on UCS 
SOLID EDITING SLICE AND SHELL 
  ELECTRICAL CAD 
REPORT GENERATION 
SOURCE ARROW 
COPY A COMPONENT 
CREATING 3 PHASE CIRCUIT 
DELETING COMPONENTS 
CREATING PANEL 
PLACING CONNECTORS 
RETAGGING COMPONENTS 
ARRANGMENT OF COMPONENTS 
PLACING MULTIPLE COMPONENTS 
MULTUPLE COMPONENT 
SAVING CIRCUIT TO ICON MENU 
MOVING AND ALIGNING COMPONENTS 
Placing wires on different angles 
PLC DESIGN SWAP A COMPONENT 
creating parent child relationship 
creating new project in autocad electrical
  CIVIL / ARCHITECTURE CAD 
BASIC DRAWING TOOLS 2 IN AUTOCAD
DIMENSIONING IN AUTOCAD
BASIC DRAWING TOOLS 2 IN AUTOCAD
DIMENSIONING IN AUTOCAD
AREA LEGEND (REVIT ARCHITECTURE)
CREATING FLAT ROOF (REVIT ARCHITECTURE)
CREATING LEVELS (REVIT ARCHITECTURE)
CREATING ROOF (REVIT ARCHITECTURE)
CREATING STAIRS (REVIT ARCHITECTURE)
CREATING WALLS (REVIT ARCHITECTURE)
DIMENSIONING (REVIT ARCHITECTURE)
DROMER OPENING (REVIT ARCHITECTURE)
EMBEDDED WALLS (REVIT ARCHITECTURE)
PLACING FLOOR (REVIT ARCHITECTURE)
PLACING TEXT IN REVIT ARCHITECTURE (REVIT ARCHITECTURE)
ROOM LEGEND (REVIT ARCHITECTURE)
WALL OPENING AND EDIDTING (REVIT ARCHITECTURE)
  STAAD PRO 
MODEL USING SNAP GRID 
SELECTION OF ELEMENTS 
DESIGN OF RCC STRUCTURE 
WIND LOAD ANALYSIS 
ASSIGNING DEAD AND LIVE LOADS 
CREATING LOAD COMBINATIONS 
IMPORTING AutoCAD FILE IN STAAD 
MODELING USING STRUCTURE WIZARD 
ANALYSIS OF A SIMPLE BEAM 
ASSIGINING MOVING LOADS 



TRAININGS & OUR COURSES 

Proper training is one of the most important factors in determining your success. With qualified trainers, we provide training for a variety of applications. Not only do our trainers have industry experience, but they continue to use the software we support in real-world applications. Whether manufacturing, architecture or engineering, our instructors’ top credentials, deep industry knowledge and enthusiasm will help you work better and smarter. With our experienced trainers, we can provide on-site training (in colleges and organizations), or you can use one of our fully equipped training classrooms. The advantages of training with CADFolks are: 
We have industry experts as instructors 
Small classes and personalized attention 
Free technical help upto one year after training (for the same software) 
Flexible time schedule 
Free industry standard course workbook, sample files, and exercises 
Valuable Tips & Tricks

 AutoCAD



SEARCH MORE ANSYS



SEARCH MORE AUTODESK INVENTOR



SEARCH MORE REVIT ARCHITECTURE



SEARCH MORE CATIA



SEARCH MORE CREO



SEARCH MORE Unigraphics NX2



SEARCH MORE SOLID WORK TRAINING



SEARCH MORE STAAD PRO TRAINING



SEARCH MORE SOLID EDGE_2



SEARCH MORELOAD MORE 


CONTACT US 



OMAXE GURGAON MALL, BEHIND SRS VALUE BAZAAR, SEC 49, SOHNA ROAD, Gurgaon - 122018 ( Haryana ) CADFolks Private Limited
OMAXE GURGAON MALL, BEHIND SRS VALUE BAZAAR, SEC 49, SOHNA ROAD , Gurgaon - 122018 ( Haryana )
 +91-9289894040, 0124 400-1616
www.cadfolks.com
 
 
 
 
SEND 


OUR PARTNERS 


Unitech BooksGo4WebTechInnovisionconsultants Close', N'', CAST(N'2015-10-22 11:45:23.000' AS DateTime), CAST(105 AS Numeric(18, 0)))
INSERT [dbo].[ScraperPageTextData] ([AWNO], [webURL], [web1URL], [web2URL], [isURLsimilar], [scrapDateTime], [pageContentText], [SearchContentText], [SearchDateTime], [AnalyzeNo]) VALUES (N'6         ', N'n/a', N'http://www.cadfolks.com', N'http://www.cadfolks.com', N'true      ', CAST(N'2015-10-22 00:00:00.000' AS DateTime), N'System.Windows.Controls.TextBox: +91 92-8989-4040 / 0124 400-1616 cadfolks@gmail.com / training@cadfolks.com Toggle navigation   HOME
 
SERVICES
 
TUTORIALS
 
COURSES
 
BOOKS 
NEW REGISTRATION 
CONTACT US
 
PARTNERS
 

 WELCOME TO CADFOLKS
CADFolks provides training on CAD/CAM/CAE Softwares such as AutoCAD, CATIA, SolidWorks, Autodesk Inventor, Solid Edge, Pro-Engineer/Creo, and Unigraphics/NX. It also provides consulting services in CAD/CAM/CAE domains. Our consulting services include CAD design, CAD drafting, CAD drawing conversion, assembly to detail drawings, and solid modeling.
We have our office in Gurgaon, Near New Delhi from where we can cater to the Engineering Design requirements of our global customers. Learn from Experts
Learn from our well experienced professionals who use CAD/CAM/CAE software’s daily. Free Support upto One year
Get free technical help upto 1 year on any topic related to your course. Free Course Workbook
Get a free course workbook designed by our experts. Valuable Tips and Tricks
Get valuable tips and tricks to save time and improve your productivity. 
Welcome to CADFolks Pvt. Ltd. 
Help You Design Better


SERVICES 


 WORKSHOPS 
New Batch Starts From 1st May 2015 onwards
We also provide short term course 
We Provide six months Industrial Training also

 UPCOMING EVENTS 
Summer Internship Programme - 2015
Two Hours Free WorkShop On AutoCad, Catia, SolidWorks and other CAD Softwares in Weekends.
We have published AutoCad, Catia, NX books. Other books we will publish very soon. 
We launch our new IT- web portal 

 PROJECT CONSULTANCY 
We are Providing Project Consultancy Services to our different clients from past few years 
Our Clients : Civil, Mechanical, Architectural, Electrical

 CONSULTANCY SERVICES Innovision consultants 
a leading recruitment firm 




VIDEO TUTORIALS 


  MECHANICAL CAD BASIC DRAWING TOOLS 1 IN AUTOCAD 
BASIC DRAWING TOOLS 2 IN AUTOCAD 
DIMENSIONING IN AUTOCAD
MODIFYING TOOLS IN AUTOCAD 
Working on Layers 
2D LAYOUT CREATING 3D OBJECTS 
SOLIDEDITING IN AUTOCAD 
Working on UCS 
SOLID EDITING SLICE AND SHELL 
  ELECTRICAL CAD 
REPORT GENERATION 
SOURCE ARROW 
COPY A COMPONENT 
CREATING 3 PHASE CIRCUIT 
DELETING COMPONENTS 
CREATING PANEL 
PLACING CONNECTORS 
RETAGGING COMPONENTS 
ARRANGMENT OF COMPONENTS 
PLACING MULTIPLE COMPONENTS 
MULTUPLE COMPONENT 
SAVING CIRCUIT TO ICON MENU 
MOVING AND ALIGNING COMPONENTS 
Placing wires on different angles 
PLC DESIGN SWAP A COMPONENT 
creating parent child relationship 
creating new project in autocad electrical
  CIVIL / ARCHITECTURE CAD 
BASIC DRAWING TOOLS 2 IN AUTOCAD
DIMENSIONING IN AUTOCAD
BASIC DRAWING TOOLS 2 IN AUTOCAD
DIMENSIONING IN AUTOCAD
AREA LEGEND (REVIT ARCHITECTURE)
CREATING FLAT ROOF (REVIT ARCHITECTURE)
CREATING LEVELS (REVIT ARCHITECTURE)
CREATING ROOF (REVIT ARCHITECTURE)
CREATING STAIRS (REVIT ARCHITECTURE)
CREATING WALLS (REVIT ARCHITECTURE)
DIMENSIONING (REVIT ARCHITECTURE)
DROMER OPENING (REVIT ARCHITECTURE)
EMBEDDED WALLS (REVIT ARCHITECTURE)
PLACING FLOOR (REVIT ARCHITECTURE)
PLACING TEXT IN REVIT ARCHITECTURE (REVIT ARCHITECTURE)
ROOM LEGEND (REVIT ARCHITECTURE)
WALL OPENING AND EDIDTING (REVIT ARCHITECTURE)
  STAAD PRO 
MODEL USING SNAP GRID 
SELECTION OF ELEMENTS 
DESIGN OF RCC STRUCTURE 
WIND LOAD ANALYSIS 
ASSIGNING DEAD AND LIVE LOADS 
CREATING LOAD COMBINATIONS 
IMPORTING AutoCAD FILE IN STAAD 
MODELING USING STRUCTURE WIZARD 
ANALYSIS OF A SIMPLE BEAM 
ASSIGINING MOVING LOADS 



TRAININGS & OUR COURSES 

Proper training is one of the most important factors in determining your success. With qualified trainers, we provide training for a variety of applications. Not only do our trainers have industry experience, but they continue to use the software we support in real-world applications. Whether manufacturing, architecture or engineering, our instructors’ top credentials, deep industry knowledge and enthusiasm will help you work better and smarter. With our experienced trainers, we can provide on-site training (in colleges and organizations), or you can use one of our fully equipped training classrooms. The advantages of training with CADFolks are: 
We have industry experts as instructors 
Small classes and personalized attention 
Free technical help upto one year after training (for the same software) 
Flexible time schedule 
Free industry standard course workbook, sample files, and exercises 
Valuable Tips & Tricks

 AutoCAD



SEARCH MORE ANSYS



SEARCH MORE AUTODESK INVENTOR



SEARCH MORE REVIT ARCHITECTURE



SEARCH MORE CATIA



SEARCH MORE CREO



SEARCH MORE Unigraphics NX2



SEARCH MORE SOLID WORK TRAINING



SEARCH MORE STAAD PRO TRAINING



SEARCH MORE SOLID EDGE_2



SEARCH MORELOAD MORE 


CONTACT US 



OMAXE GURGAON MALL, BEHIND SRS VALUE BAZAAR, SEC 49, SOHNA ROAD, Gurgaon - 122018 ( Haryana ) CADFolks Private Limited
OMAXE GURGAON MALL, BEHIND SRS VALUE BAZAAR, SEC 49, SOHNA ROAD , Gurgaon - 122018 ( Haryana )
 +91-9289894040, 0124 400-1616
www.cadfolks.com
 
 
 
 
SEND 


OUR PARTNERS 


Unitech BooksGo4WebTechInnovisionconsultants Close', N'', CAST(N'2015-10-22 11:50:28.000' AS DateTime), CAST(106 AS Numeric(18, 0)))
INSERT [dbo].[ScraperPageTextData] ([AWNO], [webURL], [web1URL], [web2URL], [isURLsimilar], [scrapDateTime], [pageContentText], [SearchContentText], [SearchDateTime], [AnalyzeNo]) VALUES (N'8         ', N'n/a', N'http://www.cadfolks.com', N'http://www.cadfolks.com', N'true      ', CAST(N'2015-10-22 00:00:00.000' AS DateTime), N'System.Windows.Controls.TextBox: +91 92-8989-4040 / 0124 400-1616 cadfolks@gmail.com / training@cadfolks.com Toggle navigation   HOME
 
SERVICES
 
TUTORIALS
 
COURSES
 
BOOKS 
NEW REGISTRATION 
CONTACT US
 
PARTNERS
 

 WELCOME TO CADFOLKS
CADFolks provides training on CAD/CAM/CAE Softwares such as AutoCAD, CATIA, SolidWorks, Autodesk Inventor, Solid Edge, Pro-Engineer/Creo, and Unigraphics/NX. It also provides consulting services in CAD/CAM/CAE domains. Our consulting services include CAD design, CAD drafting, CAD drawing conversion, assembly to detail drawings, and solid modeling.
We have our office in Gurgaon, Near New Delhi from where we can cater to the Engineering Design requirements of our global customers. Learn from Experts
Learn from our well experienced professionals who use CAD/CAM/CAE software’s daily. Free Support upto One year
Get free technical help upto 1 year on any topic related to your course. Free Course Workbook
Get a free course workbook designed by our experts. Valuable Tips and Tricks
Get valuable tips and tricks to save time and improve your productivity. 
Welcome to CADFolks Pvt. Ltd. 
Help You Design Better


SERVICES 


 WORKSHOPS 
New Batch Starts From 1st May 2015 onwards
We also provide short term course 
We Provide six months Industrial Training also

 UPCOMING EVENTS 
Summer Internship Programme - 2015
Two Hours Free WorkShop On AutoCad, Catia, SolidWorks and other CAD Softwares in Weekends.
We have published AutoCad, Catia, NX books. Other books we will publish very soon. 
We launch our new IT- web portal 

 PROJECT CONSULTANCY 
We are Providing Project Consultancy Services to our different clients from past few years 
Our Clients : Civil, Mechanical, Architectural, Electrical

 CONSULTANCY SERVICES Innovision consultants 
a leading recruitment firm 




VIDEO TUTORIALS 


  MECHANICAL CAD BASIC DRAWING TOOLS 1 IN AUTOCAD 
BASIC DRAWING TOOLS 2 IN AUTOCAD 
DIMENSIONING IN AUTOCAD
MODIFYING TOOLS IN AUTOCAD 
Working on Layers 
2D LAYOUT CREATING 3D OBJECTS 
SOLIDEDITING IN AUTOCAD 
Working on UCS 
SOLID EDITING SLICE AND SHELL 
  ELECTRICAL CAD 
REPORT GENERATION 
SOURCE ARROW 
COPY A COMPONENT 
CREATING 3 PHASE CIRCUIT 
DELETING COMPONENTS 
CREATING PANEL 
PLACING CONNECTORS 
RETAGGING COMPONENTS 
ARRANGMENT OF COMPONENTS 
PLACING MULTIPLE COMPONENTS 
MULTUPLE COMPONENT 
SAVING CIRCUIT TO ICON MENU 
MOVING AND ALIGNING COMPONENTS 
Placing wires on different angles 
PLC DESIGN SWAP A COMPONENT 
creating parent child relationship 
creating new project in autocad electrical
  CIVIL / ARCHITECTURE CAD 
BASIC DRAWING TOOLS 2 IN AUTOCAD
DIMENSIONING IN AUTOCAD
BASIC DRAWING TOOLS 2 IN AUTOCAD
DIMENSIONING IN AUTOCAD
AREA LEGEND (REVIT ARCHITECTURE)
CREATING FLAT ROOF (REVIT ARCHITECTURE)
CREATING LEVELS (REVIT ARCHITECTURE)
CREATING ROOF (REVIT ARCHITECTURE)
CREATING STAIRS (REVIT ARCHITECTURE)
CREATING WALLS (REVIT ARCHITECTURE)
DIMENSIONING (REVIT ARCHITECTURE)
DROMER OPENING (REVIT ARCHITECTURE)
EMBEDDED WALLS (REVIT ARCHITECTURE)
PLACING FLOOR (REVIT ARCHITECTURE)
PLACING TEXT IN REVIT ARCHITECTURE (REVIT ARCHITECTURE)
ROOM LEGEND (REVIT ARCHITECTURE)
WALL OPENING AND EDIDTING (REVIT ARCHITECTURE)
  STAAD PRO 
MODEL USING SNAP GRID 
SELECTION OF ELEMENTS 
DESIGN OF RCC STRUCTURE 
WIND LOAD ANALYSIS 
ASSIGNING DEAD AND LIVE LOADS 
CREATING LOAD COMBINATIONS 
IMPORTING AutoCAD FILE IN STAAD 
MODELING USING STRUCTURE WIZARD 
ANALYSIS OF A SIMPLE BEAM 
ASSIGINING MOVING LOADS 



TRAININGS & OUR COURSES 

Proper training is one of the most important factors in determining your success. With qualified trainers, we provide training for a variety of applications. Not only do our trainers have industry experience, but they continue to use the software we support in real-world applications. Whether manufacturing, architecture or engineering, our instructors’ top credentials, deep industry knowledge and enthusiasm will help you work better and smarter. With our experienced trainers, we can provide on-site training (in colleges and organizations), or you can use one of our fully equipped training classrooms. The advantages of training with CADFolks are: 
We have industry experts as instructors 
Small classes and personalized attention 
Free technical help upto one year after training (for the same software) 
Flexible time schedule 
Free industry standard course workbook, sample files, and exercises 
Valuable Tips & Tricks

 AutoCAD



SEARCH MORE ANSYS



SEARCH MORE AUTODESK INVENTOR



SEARCH MORE REVIT ARCHITECTURE



SEARCH MORE CATIA



SEARCH MORE CREO



SEARCH MORE Unigraphics NX2



SEARCH MORE SOLID WORK TRAINING



SEARCH MORE STAAD PRO TRAINING



SEARCH MORE SOLID EDGE_2



SEARCH MORELOAD MORE 


CONTACT US 



OMAXE GURGAON MALL, BEHIND SRS VALUE BAZAAR, SEC 49, SOHNA ROAD, Gurgaon - 122018 ( Haryana ) CADFolks Private Limited
OMAXE GURGAON MALL, BEHIND SRS VALUE BAZAAR, SEC 49, SOHNA ROAD , Gurgaon - 122018 ( Haryana )
 +91-9289894040, 0124 400-1616
www.cadfolks.com
 
 
 
 
SEND 


OUR PARTNERS 


Unitech BooksGo4WebTechInnovisionconsultants Close', N'', CAST(N'2015-10-22 14:43:27.000' AS DateTime), CAST(108 AS Numeric(18, 0)))
INSERT [dbo].[ScraperPageTextData] ([AWNO], [webURL], [web1URL], [web2URL], [isURLsimilar], [scrapDateTime], [pageContentText], [SearchContentText], [SearchDateTime], [AnalyzeNo]) VALUES (N'9         ', N'http://www.cadfolks.com', N'n/a', N'n/a', N'false     ', CAST(N'2015-10-22 00:00:00.000' AS DateTime), N'System.Windows.Controls.TextBox: +91 92-8989-4040 / 0124 400-1616 cadfolks@gmail.com / training@cadfolks.com Toggle navigation   HOME
 
SERVICES
 
TUTORIALS
 
COURSES
 
BOOKS 
NEW REGISTRATION 
CONTACT US
 
PARTNERS
 

 WELCOME TO CADFOLKS
CADFolks provides training on CAD/CAM/CAE Softwares such as AutoCAD, CATIA, SolidWorks, Autodesk Inventor, Solid Edge, Pro-Engineer/Creo, and Unigraphics/NX. It also provides consulting services in CAD/CAM/CAE domains. Our consulting services include CAD design, CAD drafting, CAD drawing conversion, assembly to detail drawings, and solid modeling.
We have our office in Gurgaon, Near New Delhi from where we can cater to the Engineering Design requirements of our global customers. Learn from Experts
Learn from our well experienced professionals who use CAD/CAM/CAE software’s daily. Free Support upto One year
Get free technical help upto 1 year on any topic related to your course. Free Course Workbook
Get a free course workbook designed by our experts. Valuable Tips and Tricks
Get valuable tips and tricks to save time and improve your productivity. 
Welcome to CADFolks Pvt. Ltd. 
Help You Design Better


SERVICES 


 WORKSHOPS 
New Batch Starts From 1st May 2015 onwards
We also provide short term course 
We Provide six months Industrial Training also

 UPCOMING EVENTS 
Summer Internship Programme - 2015
Two Hours Free WorkShop On AutoCad, Catia, SolidWorks and other CAD Softwares in Weekends.
We have published AutoCad, Catia, NX books. Other books we will publish very soon. 
We launch our new IT- web portal 

 PROJECT CONSULTANCY 
We are Providing Project Consultancy Services to our different clients from past few years 
Our Clients : Civil, Mechanical, Architectural, Electrical

 CONSULTANCY SERVICES Innovision consultants 
a leading recruitment firm 




VIDEO TUTORIALS 


  MECHANICAL CAD BASIC DRAWING TOOLS 1 IN AUTOCAD 
BASIC DRAWING TOOLS 2 IN AUTOCAD 
DIMENSIONING IN AUTOCAD
MODIFYING TOOLS IN AUTOCAD 
Working on Layers 
2D LAYOUT CREATING 3D OBJECTS 
SOLIDEDITING IN AUTOCAD 
Working on UCS 
SOLID EDITING SLICE AND SHELL 
  ELECTRICAL CAD 
REPORT GENERATION 
SOURCE ARROW 
COPY A COMPONENT 
CREATING 3 PHASE CIRCUIT 
DELETING COMPONENTS 
CREATING PANEL 
PLACING CONNECTORS 
RETAGGING COMPONENTS 
ARRANGMENT OF COMPONENTS 
PLACING MULTIPLE COMPONENTS 
MULTUPLE COMPONENT 
SAVING CIRCUIT TO ICON MENU 
MOVING AND ALIGNING COMPONENTS 
Placing wires on different angles 
PLC DESIGN SWAP A COMPONENT 
creating parent child relationship 
creating new project in autocad electrical
  CIVIL / ARCHITECTURE CAD 
BASIC DRAWING TOOLS 2 IN AUTOCAD
DIMENSIONING IN AUTOCAD
BASIC DRAWING TOOLS 2 IN AUTOCAD
DIMENSIONING IN AUTOCAD
AREA LEGEND (REVIT ARCHITECTURE)
CREATING FLAT ROOF (REVIT ARCHITECTURE)
CREATING LEVELS (REVIT ARCHITECTURE)
CREATING ROOF (REVIT ARCHITECTURE)
CREATING STAIRS (REVIT ARCHITECTURE)
CREATING WALLS (REVIT ARCHITECTURE)
DIMENSIONING (REVIT ARCHITECTURE)
DROMER OPENING (REVIT ARCHITECTURE)
EMBEDDED WALLS (REVIT ARCHITECTURE)
PLACING FLOOR (REVIT ARCHITECTURE)
PLACING TEXT IN REVIT ARCHITECTURE (REVIT ARCHITECTURE)
ROOM LEGEND (REVIT ARCHITECTURE)
WALL OPENING AND EDIDTING (REVIT ARCHITECTURE)
  STAAD PRO 
MODEL USING SNAP GRID 
SELECTION OF ELEMENTS 
DESIGN OF RCC STRUCTURE 
WIND LOAD ANALYSIS 
ASSIGNING DEAD AND LIVE LOADS 
CREATING LOAD COMBINATIONS 
IMPORTING AutoCAD FILE IN STAAD 
MODELING USING STRUCTURE WIZARD 
ANALYSIS OF A SIMPLE BEAM 
ASSIGINING MOVING LOADS 



TRAININGS & OUR COURSES 

Proper training is one of the most important factors in determining your success. With qualified trainers, we provide training for a variety of applications. Not only do our trainers have industry experience, but they continue to use the software we support in real-world applications. Whether manufacturing, architecture or engineering, our instructors’ top credentials, deep industry knowledge and enthusiasm will help you work better and smarter. With our experienced trainers, we can provide on-site training (in colleges and organizations), or you can use one of our fully equipped training classrooms. The advantages of training with CADFolks are: 
We have industry experts as instructors 
Small classes and personalized attention 
Free technical help upto one year after training (for the same software) 
Flexible time schedule 
Free industry standard course workbook, sample files, and exercises 
Valuable Tips & Tricks

 AutoCAD



SEARCH MORE ANSYS



SEARCH MORE AUTODESK INVENTOR



SEARCH MORE REVIT ARCHITECTURE



SEARCH MORE CATIA



SEARCH MORE CREO



SEARCH MORE Unigraphics NX2



SEARCH MORE SOLID WORK TRAINING



SEARCH MORE STAAD PRO TRAINING



SEARCH MORE SOLID EDGE_2



SEARCH MORELOAD MORE 


CONTACT US 



OMAXE GURGAON MALL, BEHIND SRS VALUE BAZAAR, SEC 49, SOHNA ROAD, Gurgaon - 122018 ( Haryana ) CADFolks Private Limited
OMAXE GURGAON MALL, BEHIND SRS VALUE BAZAAR, SEC 49, SOHNA ROAD , Gurgaon - 122018 ( Haryana )
 +91-9289894040, 0124 400-1616
www.cadfolks.com
 
 
 
 
SEND 


OUR PARTNERS 


Unitech BooksGo4WebTechInnovisionconsultants Close', N'', CAST(N'2015-10-22 15:28:05.000' AS DateTime), CAST(109 AS Numeric(18, 0)))
INSERT [dbo].[ScraperRecordMain] ([AWNO], [webURL], [web1URL], [web2URL], [scrapDateTime], [AnalyzeNo]) VALUES (N'1         ', N'http://www.cadfolks.com', N'n/a', N'n/a', CAST(N'2015-10-22 00:00:00.000' AS DateTime), CAST(101 AS Numeric(18, 0)))
INSERT [dbo].[ScraperRecordMain] ([AWNO], [webURL], [web1URL], [web2URL], [scrapDateTime], [AnalyzeNo]) VALUES (N'10        ', N'http://www.cadfolks.com', N'n/a', N'n/a', CAST(N'2015-10-23 00:00:00.000' AS DateTime), CAST(110 AS Numeric(18, 0)))
INSERT [dbo].[ScraperRecordMain] ([AWNO], [webURL], [web1URL], [web2URL], [scrapDateTime], [AnalyzeNo]) VALUES (N'2         ', N'http://www.cadfolks.com', N'n/a', N'n/a', CAST(N'2015-10-22 00:00:00.000' AS DateTime), CAST(102 AS Numeric(18, 0)))
INSERT [dbo].[ScraperRecordMain] ([AWNO], [webURL], [web1URL], [web2URL], [scrapDateTime], [AnalyzeNo]) VALUES (N'3         ', N'http://www.cadfolks.com', N'n/a', N'n/a', CAST(N'2015-10-22 00:00:00.000' AS DateTime), CAST(103 AS Numeric(18, 0)))
INSERT [dbo].[ScraperRecordMain] ([AWNO], [webURL], [web1URL], [web2URL], [scrapDateTime], [AnalyzeNo]) VALUES (N'4         ', N'http://www.cadfolks.com', N'n/a', N'n/a', CAST(N'2015-10-22 00:00:00.000' AS DateTime), CAST(104 AS Numeric(18, 0)))
INSERT [dbo].[ScraperRecordMain] ([AWNO], [webURL], [web1URL], [web2URL], [scrapDateTime], [AnalyzeNo]) VALUES (N'5         ', N'http://www.cadfolks.com', N'n/a', N'n/a', CAST(N'2015-10-22 00:00:00.000' AS DateTime), CAST(105 AS Numeric(18, 0)))
INSERT [dbo].[ScraperRecordMain] ([AWNO], [webURL], [web1URL], [web2URL], [scrapDateTime], [AnalyzeNo]) VALUES (N'6         ', N'n/a', N'http://www.cadfolks.com', N'http://www.cadfolks.com', CAST(N'2015-10-22 00:00:00.000' AS DateTime), CAST(106 AS Numeric(18, 0)))
INSERT [dbo].[ScraperRecordMain] ([AWNO], [webURL], [web1URL], [web2URL], [scrapDateTime], [AnalyzeNo]) VALUES (N'7         ', N'n/a', N'http://www.swyomsoft.com', N'http://www.cadfolks.com', CAST(N'2015-10-22 00:00:00.000' AS DateTime), CAST(107 AS Numeric(18, 0)))
INSERT [dbo].[ScraperRecordMain] ([AWNO], [webURL], [web1URL], [web2URL], [scrapDateTime], [AnalyzeNo]) VALUES (N'8         ', N'n/a', N'http://www.cadfolks.com', N'http://www.cadfolks.com', CAST(N'2015-10-22 00:00:00.000' AS DateTime), CAST(108 AS Numeric(18, 0)))
INSERT [dbo].[ScraperRecordMain] ([AWNO], [webURL], [web1URL], [web2URL], [scrapDateTime], [AnalyzeNo]) VALUES (N'9         ', N'http://www.cadfolks.com', N'n/a', N'n/a', CAST(N'2015-10-22 00:00:00.000' AS DateTime), CAST(109 AS Numeric(18, 0)))
/****** Object:  Index [UK_ScraperRecordMain_ScraperPageTextData]    Script Date: 23/10/2015 15:09:44 ******/
ALTER TABLE [dbo].[ScraperRecordMain] ADD  CONSTRAINT [UK_ScraperRecordMain_ScraperPageTextData] UNIQUE NONCLUSTERED 
(
	[AnalyzeNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ScrapperRecords]    Script Date: 23/10/2015 15:09:44 ******/
ALTER TABLE [dbo].[ScrapperRecordsPreviousOnly] ADD  CONSTRAINT [IX_ScrapperRecords] UNIQUE NONCLUSTERED 
(
	[AnalyzeNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ScraperPageTextData]  WITH CHECK ADD  CONSTRAINT [webURL] FOREIGN KEY([AWNO])
REFERENCES [dbo].[ScraperPageTextData] ([AWNO])
GO
ALTER TABLE [dbo].[ScraperPageTextData] CHECK CONSTRAINT [webURL]
GO
USE [master]
GO
ALTER DATABASE [WebScraperDemo] SET  READ_WRITE 
GO
