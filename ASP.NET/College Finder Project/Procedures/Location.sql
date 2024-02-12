/* ========================= Country ========================= */

/*-------------------------
	Get records.
-------------------------*/
CREATE OR ALTER PROCEDURE [dbo].[PR_LOC_COUNTRY_SELECT_RECORDS]
AS
SELECT
	 [dbo].[LOC_Country].[CountryID]
    ,[dbo].[LOC_Country].[CountryName]
	,[dbo].[LOC_Country].[CountryCode]
	,[dbo].[LOC_Country].[CreatedDate]
	,[dbo].[LOC_Country].[ModifiedDate]

FROM [dbo].[LOC_Country]
ORDER BY [dbo].[LOC_Country].[CountryName]


/*-------------------------
	Get records by PK.
-------------------------*/
CREATE OR ALTER PROCEDURE [dbo].[PR_LOC_COUNTRY_SELECT_RECORD_BY_PK]
@CountryID		INT
AS
SELECT
	 [dbo].[LOC_Country].[CountryID]
    ,[dbo].[LOC_Country].[CountryName]
	,[dbo].[LOC_Country].[CountryCode]
	,[dbo].[LOC_Country].[CreatedDate]
	,[dbo].[LOC_Country].[ModifiedDate]

FROM [dbo].[LOC_Country]
WHERE [dbo].[LOC_Country].[CountryID] = @CountryID
ORDER BY [dbo].[LOC_Country].[CountryName]


/*-------------------------
	Insert records.
-------------------------*/
CREATE OR ALTER PROCEDURE [dbo].[PR_LOC_COUNTRY_INSERT_RECORD]
@CountryName	NVARCHAR(MAX),
@CountryCode	NVARCHAR(MAX) = NULL

AS
INSERT INTO [dbo].[LOC_Country]
(
	 [dbo].[LOC_Country].[CountryName]
	,[dbo].[LOC_Country].[CountryCode]
	,[dbo].[LOC_Country].[CreatedDate]
	,[dbo].[LOC_Country].[ModifiedDate]
)
VALUES
(
	 @CountryName
    ,@CountryCode
	,GETDATE()
	,GETDATE()
)


/*-------------------------
	Update records.
-------------------------*/
CREATE OR ALTER PROCEDURE [dbo].[PR_LOC_COUNTRY_UPDATE_RECORD]
@CountryID		INT,
@CountryName	NVARCHAR(MAX),
@CountryCode	NVARCHAR(MAX) = NULL

AS
UPDATE [dbo].[LOC_Country]
SET
	 [dbo].[LOC_Country].[CountryName] = @CountryName
	,[dbo].[LOC_Country].[CountryCode] = @CountryCode
	,[dbo].[LOC_Country].[ModifiedDate] = GETDATE()
WHERE [dbo].[LOC_Country].[CountryID] = @CountryID


/*-------------------------
	Delete records.
-------------------------*/
CREATE OR ALTER PROCEDURE [dbo].[PR_LOC_COUNTRY_DELETE_RECORD]
@CountryID		INT

AS
DELETE FROM [dbo].[LOC_Country]
WHERE [dbo].[LOC_Country].[CountryID] = @CountryID










/* ========================= State ========================= */

/*-------------------------
	Get records.
-------------------------*/
CREATE OR ALTER PROCEDURE [dbo].[PR_LOC_STATE_SELECT_RECORDS]
AS
SELECT  
	[dbo].[LOC_State].[StateID]
   ,[dbo].[LOC_State].[StateName]
   ,[dbo].[LOC_State].[StateCode]
   ,[dbo].[LOC_State].[CountryID]
   ,[dbo].[LOC_Country].[CountryName]
   ,[dbo].[LOC_Country].[CountryCode]
   ,[dbo].[LOC_State].[CreatedDate]
   ,[dbo].[LOC_State].[ModifiedDate]

FROM [dbo].[LOC_State]
LEFT OUTER JOIN [dbo].[LOC_Country]
ON [dbo].[LOC_State].[CountryID] = [dbo].[LOC_Country].[CountryID]
ORDER BY 
	 [dbo].[LOC_Country].[CountryName]
	,[dbo].[LOC_State].[StateName]


/*-------------------------
	Get record by PK.
-------------------------*/
CREATE OR ALTER PROCEDURE [dbo].[PR_LOC_STATE_SELECT_RECORD_BY_PK_FK]
@StateID	INT = NULL,
@CountryID	INT = NULL

AS
SELECT  
	[dbo].[LOC_State].[StateID]
   ,[dbo].[LOC_State].[StateName]
   ,[dbo].[LOC_State].[StateCode]
   ,[dbo].[LOC_State].[CountryID]
   ,[dbo].[LOC_Country].[CountryName]
   ,[dbo].[LOC_Country].[CountryCode]
   ,[dbo].[LOC_State].[CreatedDate]
   ,[dbo].[LOC_State].[ModifiedDate]

FROM [dbo].[LOC_State]
LEFT OUTER JOIN [dbo].[LOC_Country]
ON [dbo].[LOC_State].[CountryID] = [dbo].[LOC_Country].[CountryID]
WHERE [dbo].[LOC_State].[StateID] = @StateID
OR [dbo].[LOC_State].[CountryID] = @CountryID
ORDER BY 
	 [dbo].[LOC_Country].[CountryName]
	,[dbo].[LOC_State].[StateName]


/*-------------------------
	Insert records.
-------------------------*/

CREATE OR ALTER PROCEDURE [dbo].[PR_LOC_STATE_INSERT_RECORD]
@StateName	NVARCHAR(MAX),
@StateCode	NVARCHAR(MAX) = NULL,
@CountryID	INT

AS
INSERT INTO [dbo].[LOC_State]
(
	 [dbo].[LOC_State].[StateName]
	,[dbo].[LOC_State].[StateCode]
	,[dbo].[LOC_State].[CountryID]
	,[dbo].[LOC_State].[CreatedDate]
	,[dbo].[LOC_State].[ModifiedDate]
)
VALUES
(
	 @StateName
	,@StateCode
	,@CountryID
	,GETDATE()
	,GETDATE()
)


/*-------------------------
	Update records.
-------------------------*/

CREATE OR ALTER PROCEDURE [dbo].[PR_LOC_STATE_UPDATE_RECORD]
@StateID	INT,
@StateName	NVARCHAR(MAX),
@StateCode	NVARCHAR(MAX),
@CountryID	INT

AS
UPDATE [dbo].[LOC_State]
SET  [dbo].[LOC_State].[StateName] = @StateName
	,[dbo].[LOC_State].[StateCode] = @StateCode
	,[dbo].[LOC_State].[CountryID] = @CountryID
	,[dbo].[LOC_State].[ModifiedDate] = GETDATE()
WHERE [dbo].[LOC_State].[StateID] = @StateID


/*-------------------------
	Delete records.
-------------------------*/

CREATE OR ALTER PROCEDURE [dbo].[PR_LOC_STATE_DELETE_RECORD]
@StateID	INT

AS
DELETE FROM [dbo].[LOC_State]
WHERE [dbo].[LOC_State].[StateID] = @StateID












/* ========================= City ========================= */

/*-------------------------
	Get records.
-------------------------*/

CREATE OR ALTER PROCEDURE [dbo].[PR_LOC_CITY_SELECT_RECORDS]
AS
SELECT 
	[dbo].[LOC_City].[CityID]
   ,[dbo].[LOC_City].[CityName]
   ,[dbo].[LOC_City].[CityCode]
   ,[dbo].[LOC_City].[StateID]
   ,[dbo].[LOC_State].[StateName]
   ,[dbo].[LOC_State].[StateCode]
   ,[dbo].[LOC_State].[CountryID]
   ,[dbo].[LOC_Country].[CountryName]
   ,[dbo].[LOC_Country].[CountryCode]
   ,[dbo].[LOC_City].[CreatedDate]
   ,[dbo].[LOC_City].[ModifiedDate]

FROM [dbo].[LOC_City]
LEFT OUTER JOIN [dbo].[LOC_State]
ON [dbo].[LOC_City].[StateID] = [dbo].[LOC_State].[StateID]
LEFT OUTER JOIN [dbo].[LOC_Country]
ON [dbo].[LOC_State].[CountryID] = [dbo].[LOC_Country].[CountryID]
ORDER BY 
	[dbo].[LOC_Country].[CountryName]
   ,[dbo].[LOC_State].[StateName]
   ,[dbo].[LOC_City].[CityName]


/*-------------------------
	Get record by PK.
-------------------------*/

CREATE OR ALTER PROCEDURE [dbo].[PR_LOC_CITY_SELECT_RECORD_BY_PK]
@CityID		INT

AS
SELECT 
	[dbo].[LOC_City].[CityID]
   ,[dbo].[LOC_City].[CityName]
   ,[dbo].[LOC_City].[CityCode]
   ,[dbo].[LOC_City].[StateID]
   ,[dbo].[LOC_State].[StateName]
   ,[dbo].[LOC_State].[StateCode]
   ,[dbo].[LOC_State].[CountryID]
   ,[dbo].[LOC_Country].[CountryName]
   ,[dbo].[LOC_Country].[CountryCode]
   ,[dbo].[LOC_City].[CreatedDate]
   ,[dbo].[LOC_City].[ModifiedDate]

FROM [dbo].[LOC_City]
LEFT OUTER JOIN [dbo].[LOC_State]
ON [dbo].[LOC_City].[StateID] = [dbo].[LOC_State].[StateID]
LEFT OUTER JOIN [dbo].[LOC_Country]
ON [dbo].[LOC_State].[CountryID] = [dbo].[LOC_Country].[CountryID]
WHERE [dbo].[LOC_City].[CityID] = @CityID
ORDER BY 
	[dbo].[LOC_Country].[CountryName]
   ,[dbo].[LOC_State].[StateName]
   ,[dbo].[LOC_City].[CityName]


/*-------------------------
	Insert records.
-------------------------*/

CREATE OR ALTER PROCEDURE [dbo].[PR_LOC_CITY_INSERT_RECORD]
@CityName	NVARCHAR(MAX),
@CityCode	NVARCHAR(MAX) = NULL,
@StateID	INT

AS
INSERT INTO [dbo].[LOC_City]
(
	 [dbo].[LOC_City].[CityName]
	,[dbo].[LOC_City].[CityCode]
	,[dbo].[LOC_City].[StateID]
	,[dbo].[LOC_City].[CreatedDate]
	,[dbo].[LOC_City].[ModifiedDate]
)
VALUES
(
	 @CityName
	,@CityCode
	,@StateID
	,GETDATE()
	,GETDATE()
)


/*-------------------------
	Update records.
-------------------------*/

CREATE OR ALTER PROCEDURE [dbo].[PR_LOC_CITY_UPDATE_RECORD]
@CityID		INT,
@CityName	NVARCHAR(MAX),
@CityCode	NVARCHAR(MAX) = NULL,
@StateID	INT

AS
UPDATE [dbo].[LOC_City]
SET  [dbo].[LOC_City].[CityName] = @CityName
	,[dbo].[LOC_City].[CityCode] = @CityCode
	,[dbo].[LOC_City].[StateID] = @StateID
	,[dbo].[LOC_City].[ModifiedDate] = GETDATE()
WHERE [dbo].[LOC_City].[CityID] = @CityID


/*-------------------------
	Delete records.
-------------------------*/

CREATE OR ALTER PROCEDURE [dbo].[PR_LOC_CITY_DELETE_RECORD]
@CityID		INT

AS
DELETE FROM [dbo].[LOC_City]
WHERE [dbo].[LOC_City].[CityID] = @CityID