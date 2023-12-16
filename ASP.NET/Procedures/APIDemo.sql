-- 1. SELECT ALL 
CREATE OR ALTER PROCEDURE [dbo].[API_PERSON_SELECT_ALL]
AS
SELECT [dbo].[Person].[PersonID]
	  ,[dbo].[Person].[PersonName]
	  ,[dbo].[Person].[Email]
	  ,[dbo].[Person].[Phone]
FROM [dbo].[Person]
ORDER BY [dbo].[Person].[PersonID]


-- 2. SELECT BY PK
CREATE OR ALTER PROCEDURE [dbo].[API_PERSON_SELECT_BY_PK]
@PersonID	int
AS
SELECT [dbo].[Person].[PersonID]
	  ,[dbo].[Person].[PersonName]
	  ,[dbo].[Person].[Email]
	  ,[dbo].[Person].[Phone]
FROM [dbo].[Person]
WHERE [dbo].[Person].[PersonID] = @PersonID
ORDER BY [dbo].[Person].[PersonName]


-- 3. INSERT RECORD
CREATE OR ALTER PROCEDURE [dbo].[API_PERSON_INSERT_RECORD]
@PersonName		varchar(100),
@Email			varchar(100),
@Phone			varchar(100)
AS
INSERT INTO [dbo].[Person]
(
	 [dbo].[Person].[PersonName]
	,[dbo].[Person].[Email]
	,[dbo].[Person].[Phone]
)
VALUES
(
	@PersonName,
	@Email,
	@Phone
)


-- 4. UPDATE RECORD BY PK
CREATE OR ALTER PROCEDURE [dbo].[API_PERSON_UPDATE_RECORD_BY_PK]
@PersonID		int,
@PersonName		varchar(100),
@Email			varchar(100),
@Phone			varchar(100)
AS
UPDATE [dbo].[Person]
SET	[dbo].[Person].[PersonName] = @PersonName
   ,[dbo].[Person].[Email] = @Email
   ,[dbo].[Person].[Phone] = @Phone
WHERE [dbo].[Person].[PersonID] = @PersonID


-- 4. DELETE RECORD BY PK
CREATE OR ALTER PROCEDURE [dbo].[API_PERSON_DELETE_RECORD_BY_PK]
@PersonID	int
AS
DELETE FROM [dbo].[Person]
WHERE [dbo].[Person].[PersonID] = @PersonID