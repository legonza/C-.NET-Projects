USE CarDealership
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='State')
DROP TABLE [State]
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Make')
DROP TABLE Make
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Model')
DROP TABLE Model
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Vehicle')
DROP TABLE Vehicle
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Specials')
DROP TABLE Specials
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Contacts')
DROP TABLE Contacts
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Purchase')
DROP TABLE Purchase
GO

CREATE TABLE [State](
	StateId char(2) NOT NULL PRIMARY KEY,
	StateName nvarchar(100) NOT NULL
)

CREATE TABLE Make(
	MakeId INT NOT NULL PRIMARY KEY IDENTITY (1,1),
	MakeName nvarchar(50) NOT NULL,
	DateAdded DATE NOT NULL,
	UserId nvarchar(128) NOT NULL

)

CREATE TABLE Model(
	ModelId INT NOT NULL PRIMARY KEY IDENTITY (1,1),
	ModelName nvarchar(50) NOT NULL,
	UserId nvarchar(128) NOT NULL,
	AddedDate DATE NOT NULL,
	MakeId INT NOT NULL FOREIGN KEY REFERENCES Make(MakeId)
)

CREATE TABLE Vehicle(
	VehicleId INT NOT NULL PRIMARY KEY IDENTITY (1,1),
	[Type] nvarchar(10) NOT NULL,
	BodyStyle nvarchar(50) NOT NULL,
	[Year] nvarchar(5) NOT NULL,
	Transmission nvarchar(20) NOT NULL,
	Color nvarchar(20) NOT NULL,
	Interior nvarchar(10) NOT NULL,
	Miles nvarchar(10) NOT NULL,
	Vin nvarchar(15) NOT NULL,
	Price decimal(18, 2) NOT NULL,
	Msrp decimal(18, 2) NOT NULL,
	[Description] nvarchar(100) NOT NULL,
	Featured BIT NOT NULL,
	IsSold BIT NOT NULL,
	ImageFileName nvarchar(50) NULL,
	MakeId INT NOT NULL FOREIGN KEY REFERENCES Make(MakeId),
	ModelId INT NOT NULL FOREIGN KEY REFERENCES Model(ModelId)
)

CREATE TABLE Specials(
	SpecialsId INT NOT NULL PRIMARY KEY IDENTITY (1,1),
	Title nvarchar(50) NOT NULL,
	[Description] nvarchar(800) NOT NULL,
	SpecialsImage nvarchar(50) NULL
)

CREATE TABLE Contacts(
	ContactId INT NOT NULL PRIMARY KEY IDENTITY (1,1),
	[Name] nvarchar(50) NOT NULL,
	[Email] nvarchar(100) NOT NULL,
	Phone nvarchar(15) NOT NULL,
	[Message] nvarchar(200) NOT NULL
)

CREATE TABLE Purchase(
	PurchaseId INT NOT NULL PRIMARY KEY IDENTITY (1,1),
	[Name] nvarchar(50) NOT NULL,
	[Email] nvarchar(100) NOT NULL,
	Phone nvarchar(15) NOT NULL,
	StreetOne nvarchar(50) NOT NULL,
	StreetTwo nvarchar(50) NOT NULL,
	City nvarchar(50) NOT NULL,
	Zipcode nvarchar(10) NOT NULL,
	PaymentOption nvarchar(20) NOT NULL,
	PurchasePrice DECIMAL NOT NULL,
	StateId char(2) NOT NULL FOREIGN KEY REFERENCES [State](StateId),
	VehicleId INT NOT NULL FOREIGN KEY REFERENCES Vehicle(VehicleId)
)