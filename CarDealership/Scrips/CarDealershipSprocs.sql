IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES
WHERE ROUTINE_NAME = 'StateSelectAll')
DROP PROCEDURE StateSelectAll
GO

CREATE PROCEDURE StateSelectAll AS 
BEGIN
	SELECT StateId, StateName
	FROM [State]
END
----------------------------------------------------------------------------
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES
WHERE ROUTINE_NAME = 'MakeSelectAll')
DROP PROCEDURE MakeSelectAll
GO

CREATE PROCEDURE MakeSelectAll AS 
BEGIN
	SELECT MakeId, MakeName, DateAdded, UserId, Email
	FROM Make
	INNER JOIN AspNetUsers ON Make.UserId = AspNetUsers.Id
	ORDER BY MakeName DESC;
END

----------------------------------------------------------------------------
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES
WHERE ROUTINE_NAME = 'ModelSelectAll')
DROP PROCEDURE ModelSelectAll
GO

CREATE PROCEDURE ModelSelectAll AS 
BEGIN
	SELECT ModelName, AddedDate, ModelId, Email, MakeName
	FROM Model
	INNER JOIN Make ON Model.MakeId = Make.MakeId
	INNER JOIN AspNetUsers ON Model.UserId = AspNetUsers.Id
	ORDER BY ModelName DESC;
END

----------------------------------------------------------------------------
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES
WHERE ROUTINE_NAME = 'VehicleInsert')
DROP PROCEDURE VehicleInsert
GO

CREATE PROCEDURE VehicleInsert(
	@VehicleId int output,
	@Type nvarchar(10),
	@BodyStyle nvarchar(50),
	@Year nvarchar(5),
	@Transmission nvarchar(20),
	@Color nvarchar(20),
	@Interior nvarchar(10),
	@Miles nvarchar(10),
	@Vin nvarchar(15),
	@Price decimal(18,2),
	@Msrp decimal(18,2),
	@Description nvarchar(100),
	@IsSold bit,
	@Featured bit,
	@ImageFileName nvarchar(50),
	@MakeId int,
	@ModelId int
)AS
BEGIN
	INSERT INTO Vehicle([Type], BodyStyle, [Year], Transmission, Color, Interior, Miles, Vin, Price, Msrp, [Description], IsSold, Featured, ImageFileName, MakeId, ModelId)
	VALUES(@Type, @BodyStyle, @Year, @Transmission, @Color, @Interior, @Miles, @Vin, @Price, @Msrp, @Description, @IsSold, @Featured, @ImageFileName, @MakeId, @ModelId);
	SET @VehicleId = SCOPE_IDENTITY();
END

----------------------------------------------------------------------------
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES
WHERE ROUTINE_NAME = 'VehicleUpdate')
DROP PROCEDURE VehicleUpdate
GO

CREATE PROCEDURE VehicleUpdate(
	@VehicleId int,
	@Type nvarchar(10),
	@BodyStyle nvarchar(50),
	@Year nvarchar(5),
	@Transmission nvarchar(20),
	@Color nvarchar(20),
	@Interior nvarchar(10),
	@Miles nvarchar(10),
	@Vin nvarchar(15),
	@Price decimal(18,2),
	@Msrp decimal(18,2),
	@Description nvarchar(100),
	@Featured bit,
	@ImageFileName nvarchar(50),
	@MakeId int,
	@ModelId int
)AS
BEGIN
	UPDATE Vehicle SET
	[Type] = @Type,
	BodyStyle = @BodyStyle,
	[Year] = @Year,
	Transmission = @Transmission,
	Color = @Color,
	Interior = @Interior,
	Miles = @Miles,
	Vin = @Vin,
	Price = @Price,
	Msrp = @Msrp,
	[Description] = @Description,
	Featured = @Featured,
	ImageFileName = @ImageFileName,
	MakeId = @MakeId,
	ModelId = @ModelId
	WHERE VehicleId = @VehicleId
END

----------------------------------------------------------------------------
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES
WHERE ROUTINE_NAME = 'VehicleDelete')
DROP PROCEDURE VehicleDelete
GO

CREATE PROCEDURE VehicleDelete(
	@VehicleId int
)AS
BEGIN 
	BEGIN TRANSACTION
	DELETE FROM Purchase WHERE VehicleId = @VehicleId;
	DELETE FROM Vehicle WHERE VehicleId = @VehicleId;
	COMMIT TRANSACTION
END

----------------------------------------------------------------------------
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES
WHERE ROUTINE_NAME = 'VehicleSelect')
DROP PROCEDURE VehicleSelect
GO

CREATE PROCEDURE VehicleSelect(
	@VehicleId int
)AS
BEGIN 
	SELECT VehicleId, [Type], BodyStyle, [Year], Transmission, Color, Interior, Miles, Vin, Price, Msrp, [Description], Featured, ImageFileName, MakeId, ModelId
	FROM Vehicle
	WHERE VehicleId = @VehicleId
END

----------------------------------------------------------------------------
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES
WHERE ROUTINE_NAME = 'VehicleSelectFeatured')
DROP PROCEDURE VehicleSelectFeatured
GO

CREATE PROCEDURE VehicleSelectFeatured AS 
BEGIN
	SELECT TOP 8 VehicleId, [Year], m.MakeName, ModelName, Price, ImageFileName
	FROM Vehicle v
	INNER JOIN Make m ON v.MakeId = m.MakeId
	INNER JOIN Model  ON v.ModelId = Model.ModelId
END

----------------------------------------------------------------------------
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES
WHERE ROUTINE_NAME = 'VehicleSelectDetails')
DROP PROCEDURE VehicleSelectDetails
GO

CREATE PROCEDURE VehicleSelectDetails(
	@VehicleId INT
)AS
BEGIN
	SELECT VehicleId, [Type], BodyStyle, [Year], Transmission, Color, Interior, Miles, Vin, Price, Msrp, [Description],
	Featured, ImageFileName, m.MakeName, ModelName
	FROM Vehicle v
	INNER JOIN Make m ON v.MakeId = m.MakeId
	INNER JOIN Model ON v.ModelId = Model.ModelId
	WHERE VehicleId = @VehicleId
END

----------------------------------------------------------------------------
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES
WHERE ROUTINE_NAME = 'SpecialsSelect')
DROP PROCEDURE SpecialsSelect
GO
CREATE PROCEDURE SpecialsSelect AS
BEGIN
	SELECT *
	FROM Specials
END

----------------------------------------------------------------------------
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES
WHERE ROUTINE_NAME = 'SelectAllVehicles')
DROP PROCEDURE SelectAllVehicles
GO
CREATE PROCEDURE SelectAllVehicles AS
BEGIN
	SELECT VehicleId, [Type], BodyStyle, [Year], Transmission, Color, Interior, Miles, Vin, Price, Msrp, [Description], ImageFileName, MakeName, ModelName
	FROM Vehicle
	INNER JOIN Make ON Vehicle.MakeId = Make.MakeId
	INNER JOIN Model ON Vehicle.ModelId = Model.ModelId
END

----------------------------------------------------------------------------
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES
WHERE ROUTINE_NAME = 'UserSelect')
DROP PROCEDURE UserSelect
GO

CREATE PROCEDURE UserSelect AS 
BEGIN
	SELECT  UserId, RoleId, Email, UserName
	FROM AspNetUserRoles 
	INNER JOIN AspNetUsers ON AspNetUserRoles.UserId = AspNetUsers.Id
END

----------------------------------------------------------------------------
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES
WHERE ROUTINE_NAME = 'SpecialDelete')
DROP PROCEDURE SpecialDelete
GO

CREATE PROCEDURE SpecialDelete(
	@SpecialsId int
)AS
BEGIN 
	BEGIN TRANSACTION
	DELETE FROM Specials WHERE SpecialsId = @SpecialsId;
	COMMIT TRANSACTION
END

----------------------------------------------------------------------------
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES
WHERE ROUTINE_NAME = 'SpecialInsert')
DROP PROCEDURE SpecialInsert
GO

CREATE PROCEDURE SpecialInsert(
	@SpecialsId int output,
	@Title nvarchar(50),
	@Description nvarchar(800),
	@SpecialsImage nvarchar(50)
	
)AS
BEGIN
	INSERT INTO Specials(Title, [Description], SpecialsImage)
	VALUES(@Title, @Description, @SpecialsImage);
	SET @SpecialsId = SCOPE_IDENTITY();
END


-----------------------------------------------------------------------------

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES
WHERE ROUTINE_NAME = 'PurchasedVehicles')
DROP PROCEDURE PurchasedVehicles
GO

CREATE PROCEDURE PurchasedVehicles(
	@PurchaseId int output,
	@Name nvarchar(50),
	@Email nvarchar(100),
	@Phone nvarchar(15),
	@StreetOne nvarchar(50),
	@StreetTwo nvarchar(50),
	@City nvarchar(50),
	@Zipcode nvarchar(10),
	@PaymentOption nvarchar(20),
	@PurchasePrice decimal(18,0),
	@StateId char(2),
	@VehicleId int
	
)AS
BEGIN
	INSERT INTO Purchase([Name], Email, Phone, StreetOne, StreetTwo, City, Zipcode, PaymentOption, PurchasePrice, StateId, VehicleId)
	VALUES(@Name, @Email, @Phone, @StreetOne, @StreetTwo, @City, @Zipcode, @PaymentOption, @PurchasePrice, @StateId, @VehicleId);
	SET @PurchaseId = SCOPE_IDENTITY();
END

----------------------------------------------------------------------------
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES
WHERE ROUTINE_NAME = 'ContactsInsert')
DROP PROCEDURE ContactsInsert
GO

CREATE PROCEDURE ContactsInsert(
	@ContactId int output,
	@Name nvarchar(50),
	@Email nvarchar(100),
	@Phone nvarchar(15),
	@Message nvarchar(200)
	
)AS
BEGIN
	INSERT INTO Contacts([Name], Email, Phone, [Message])
	VALUES(@Name, @Email, @Phone, @Message);
	SET @ContactId = SCOPE_IDENTITY();
END

----------------------------------------------------------------------------
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES
WHERE ROUTINE_NAME = 'GetVehiclesReport')
DROP PROCEDURE GetVehiclesReport
GO

CREATE PROCEDURE GetVehiclesReport 
@prm_vehicleType nvarchar(10)
AS
BEGIN 
    SELECT V.[Year], --This will print the actual column name from Vehicle table in the results below because I didn't use the 'AS' keyword to add a custom colun name
           MA.MakeName, --This will print the actual column name from Make table in the results below because I didn't use the 'AS' keyword to add a custom colun name
           MO.ModelName, --This will print the actual column name from Model table in the results below because I didn't use the 'AS' keyword to add a custom colun name
           COUNT(MO.ModelName) AS [Count], --This will count how many vehicles with the same ModelName are in the table and print the word 'Count' for the column in the results below because I used the 'AS' keyword and gave it a custom name
           SUM(V.Price) AS StockValue --This add up all of the prices for a specific year, make, and model and print the word 'StockValue' in the results below because I used the 'AS' keyword and gave it a custom name
        FROM Vehicle AS V
            INNER JOIN Make AS MA 
                ON V.MakeId = MA.MakeId --Connect the Make table to the Vehicle table by MakeId
            INNER JOIN Model AS MO 
                ON V.ModelId = MO.ModelId --Connect the Model table to the Vehicle table by ModelId
    WHERE V.[Type] = @prm_vehicleType --This limits the results to only NEW vehicles.
    GROUP BY V.[Year], MA.MakeName, MO.ModelName --This will group the results together by Year, MakeName, and ModelName in the results 
    ORDER by Year DESC, MA.MakeName, MO.ModelName --This will order the grouped results by Year first (in a descending order - newest year first), then alphabetically by MakeName, then alphabetically by ModelName last.
END