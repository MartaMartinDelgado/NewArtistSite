CREATE DATABASE ArtistSiteDB;

GO

USE ArtistSiteDB;

GO


CREATE TABLE Experience
(ExperienceId int NOT NULL IDENTITY(1,1),
ArtistRole varchar(50) NOT NULL,
StartDate datetime NOT NULL,
EndDate datetime NOT NULL,
RoleDescription varchar(200),
Contact varchar(50),
CONSTRAINT PK_Experience PRIMARY KEY(ExperienceId)
)

CREATE TABLE Artist
(
ArtistId int NOT NULL IDENTITY(1,1),
FName varchar(20) NOT NULL,
LName varchar(30) NOT NULL,
UserName varchar(50) NOT NULL,
Bio varchar(1000) NOT NULL,
UpdatedOn datetime NOT NULL,
ExperienceId int NOT NULL,
CONSTRAINT PK_Artist PRIMARY KEY(ArtistId),
CONSTRAINT FK_Artist_Experience FOREIGN KEY(ExperienceId) REFERENCES Experience(ExperienceId)
)

CREATE TABLE Category
(
CategoryId int NOT NULL IDENTITY(1,1),
ContentCategory varchar(30) NOT NULL,
CONSTRAINT PK_Category PRIMARY KEY(CategoryId)
)

CREATE TABLE Content
(
ContentId int NOT NULL IDENTITY(1,1),
ContentName varchar(100) NOT NULL,
DateRecorded datetime NOT NULL,
CategoryId int NOT NULL,
Link varchar(100) NOT NULL,
PrivateContent bit NOT NULL,
-- 1 for Private content, 0 for Public content
CONSTRAINT PK_Content PRIMARY KEY(ContentId),
CONSTRAINT FK_Content_Category FOREIGN KEY(CategoryId) REFERENCES Category(CategoryId)
)
GO
