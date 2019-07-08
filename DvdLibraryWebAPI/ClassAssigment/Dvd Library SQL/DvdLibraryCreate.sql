USE [master]
GO

IF EXISTS (SELECT NAME FROM sys.databases WHERE NAME = 'DvdLibraryDatabase')
DROP DATABASE DvdLibraryDatabase

USE DvdLibraryDatabase
GO


IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Dvd' AND TABLE_SCHEMA = 'dbo')
    DROP TABLE dbo.Dvd;

CREATE TABLE DvdList(
	dvdId INT PRIMARY KEY IDENTITY (1, 1),
	title varchar (50) NOT NULL,
	releasedYear INT NOT NULL,
	director varchar (50) NOT NULL,
	rating varchar (50) NOT NULL,
	notes varchar (50) NULL
);