IF EXISTS(SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[GetAllDvds]') AND OBJECTPROPERTY(id,
N'IsProcedure') = 1)

BEGIN
DROP PROCEDURE dbo.GetAllDvds
END

USE DvdLibraryDatabase
GO

CREATE PROCEDURE GetAllDvds
AS 

BEGIN

SELECT * FROM dbo.DvdList

END
GO

---------------------------------------------------------------------------
IF EXISTS(SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[GetDvdById]') AND OBJECTPROPERTY(id,
N'IsProcedure') = 1)

BEGIN
DROP PROCEDURE dbo.GetDvdById
END

USE DvdLibraryDatabase
GO


CREATE PROCEDURE GetDvdById
@dvdId INT 
AS 

BEGIN

SELECT * FROM dbo.DvdList
WHERE dbo.DvdList.dvdId = @dvdId

END
GO

---------------------------------------------------------------------------

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[AddDvd]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
DROP PROCEDURE dbo.AddDvd
END

USE DvdLibraryDatabase
GO
CREATE PROCEDURE AddDvd

@title VARCHAR(50),
@releasedYear INT, 
@director VARCHAR(50),
@rating VARCHAR(50),
@notes VARCHAR(100)

AS
BEGIN
INSERT INTO dbo.DvdList(title, releasedYear, director, rating, notes) VALUES(@title, @releasedYear, @director, @rating, @notes)
END
GO

---------------------------------------------------------------------------
IF EXISTS(SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[EditDvdById]') AND OBJECTPROPERTY(id,
N'IsProcedure') = 1)

BEGIN
DROP PROCEDURE dbo.EditDvdById
END

USE DvdLibraryDatabase
GO

CREATE PROCEDURE EditDvdById
@dvdId INT, 
@title VARCHAR(50),
@releasedYear INT,
@director VARCHAR(50),
@rating VARCHAR(50),
@notes VARCHAR(100)

AS 

BEGIN 

UPDATE dbo.DvdList 
SET title = @title,
    releasedYear = @releasedYear,
    director = @director,
    rating = @rating,
    notes = @notes
WHERE dvdId = @dvdId

END
GO


---------------------------------------------------------------------------
IF EXISTS(SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[DeleteDvdById]') AND OBJECTPROPERTY(id,
N'IsProcedure') = 1)

BEGIN
DROP PROCEDURE dbo.DeleteDvdById
END

USE DvdLibraryDatabase
GO

CREATE PROCEDURE DeleteDvdById
@dvdId INT 
AS 

BEGIN

DELETE FROM dbo.DvdList
WHERE dbo.DvdList.dvdId = @dvdId

END
GO