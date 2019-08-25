IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES
WHERE ROUTINE_NAME = 'DbReset')
DROP PROCEDURE DbReset
GO

CREATE PROCEDURE DbReset AS 
BEGIN
	DELETE FROM [State];
	DELETE FROM Vehicle;
	DELETE FROM Model;
	DELETE FROM Make;
	DELETE FROM Specials;
	DELETE FROM Vehicle; 
	DELETE FROM AspNetUsers WHERE id = '00000000-0000-0000-0000-000000000000';
	DELETE FROM AspNetUsers WHERE id = '11111111-1111-1111-1111-111111111111';
	DELETE FROM AspNetRoles;

	DBCC CHECKIDENT ('Vehicle', RESEED, 1)

	INSERT INTO [State] (StateId, StateName) VALUES ('MN', 'Minnesota'),('WA', 'Washington'),('OH', 'Ohio');

	INSERT INTO AspNetRoles(Id, [Name])Values('Admin', 'Admin'), ('Sales', 'Sales');

	INSERT INTO AspNetUserRoles(UserId, RoleId)Values('00000000-0000-0000-0000-000000000000', 'Admin'),('11111111-1111-1111-1111-111111111111', 'Sales')

	INSERT INTO AspNetUsers(Id, EmailConfirmed, PhoneNumberConfirmed, Email, TwoFactorEnabled, LockoutEnabled, AccessFailedCount, UserName)
	VALUES('00000000-0000-0000-0000-000000000000', 0, 0, 'test@test.com', 0, 0, 0, 'test'), ('11111111-1111-1111-1111-111111111111', 0, 0, 'test2@test.com',0, 0, 0, 'test2');
	
	
	SET IDENTITY_INSERT Make ON;
	INSERT INTO Make (MakeId, MakeName, DateAdded, UserId)VALUES(1, 'Jeep', '2019-03-20', '00000000-0000-0000-0000-000000000000'),(2, 'Dodge', '2018-02-01', '00000000-0000-0000-0000-000000000000'),(3, 'Chevrolet','2017-03-01', '00000000-0000-0000-0000-000000000000');
	SET IDENTITY_INSERT Make OFF;

	SET IDENTITY_INSERT Model ON;
	INSERT INTO Model (ModelId, ModelName, UserId, AddedDate, MakeId)VALUES(1, 'Charger', '00000000-0000-0000-0000-000000000000', '2018-02-01', 2),(2, 'Wrangler', '00000000-0000-0000-0000-000000000000', '2019-03-02', 1),(3, 'Tahoe', '00000000-0000-0000-0000-000000000000', '2017-03-01', 3);
	SET IDENTITY_INSERT Model OFF;

	SET IDENTITY_INSERT Specials ON;
	INSERT INTO Specials (SpecialsId, Title, [Description], SpecialsImage)VALUES(1, 'The Dark Sale', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.', 'money.png'),
	(2, 'The Light Sale', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.', 'money.png'),
	(3, 'The Greate White Sale', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.', 'money.png');
	SET IDENTITY_INSERT Specials OFF;
	
	SET IDENTITY_INSERT Vehicle ON;
	INSERT INTO Vehicle(VehicleId, [Type], BodyStyle, [Year], Transmission, Color, Interior, Miles, Vin, Price, Msrp, [Description], Featured, IsSold, ImageFileName, MakeId, ModelId)
	VALUES(1, 'NEW', 'SUV', '2019', 'Automatic', 'Black', 'Leather', '000010', '1A234B67C8', '39000.99', '30000.99', 'OffRoad', 1, 0, 'jeeps.png', 1, 2),
	(2, 'USED', 'SUV', '2020', 'Automatic', 'Black', 'Leather', '000510', '1A234B67C9', '39000.99', '30000.99', 'Racing', 1, 0, 'jeeps.png', 2, 1),
	(3, 'USED', 'Truck', '2018', 'Manuel', 'White', 'Leather', '000210', '1A234B67C7', '40000.99', '30000.99', 'OffRoad', 1, 0, 'jeeps.png', 3, 2),
	(4, 'USED', 'SUV', '2018', 'Automatic', 'Blue', 'Leather', '000110', '1A234B67C6', '41000.99', '30000.99', 'OffRoad', 1, 0, 'jeeps.png', 2, 3);
	SET IDENTITY_INSERT Vehicle OFF;

	
	(6, 'NEW', 'Truck', '2019', 'Automatic', 'White', 'Leather', '000210', '1A234B67C7', '40000.99', '30000.99', 'OffRoad', 1, 0, 'jeeps.png', 3, 1),
	(7, 'NEW', 'Truck', '2020', 'Automatic', 'White', 'Leather', '000210', '1A234B67C11', '40000.99', '30000.99', 'OffRoad', 1, 0, 'jeeps.png', 3, 2),
	(8, 'NEW', 'Truck', '2020', 'Automatic', 'White', 'Leather', '000210', '1A234B67C12', '40000.99', '30000.99', 'OffRoad', 1, 0, 'jeeps.png', 3, 1),
	(9, 'NEW', 'Truck', '2020', 'Automatic', 'White', 'Leather', '000210', '1A234B67C7', '40000.99', '30000.99', 'OffRoad', 1, 0, 'jeeps.png', 3, 2),
	(10, 'NEW', 'Truck', '2020', 'Automatic', 'White', 'Leather', '000210', '1A234B67C7', '40000.99', '30000.99', 'OffRoad', 1, 0, 'jeeps.png', 3, 1),
	(11, 'NEW', 'Truck', '2018', 'Automatic', 'White', 'Leather', '000210', '1A234B67C7', '40000.99', '30000.99', 'OffRoad', 1, 0, 'jeeps.png', 3, 2),
END