/*==================================================================
		Get records.
==================================================================*/
CREATE OR ALTER PROCEDURE [dbo].[PR_LOC_COUNTRY_SELECT_RECORDS]
@CountryID	INT = NULL

AS
SELECT
	 [dbo].[LOC_Country].[CountryID]
    ,[dbo].[LOC_Country].[CountryName]
	,[dbo].[LOC_Country].[CountryCode]
	,[dbo].[LOC_Country].[CreatedDate]
	,[dbo].[LOC_Country].[ModifiedDate]

FROM [dbo].[LOC_Country]
WHERE [dbo].[LOC_Country].[CountryID] = CASE
											WHEN @CountryID IS NOT NULL THEN @CountryID
											ELSE CountryID
										END
ORDER BY [dbo].[LOC_Country].[CountryName]


/*==================================================================
		Insert records.
==================================================================*/
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


/*==================================================================
		Update records.
==================================================================*/
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


/*==================================================================
		Delete records.
==================================================================*/
CREATE OR ALTER PROCEDURE [dbo].[PR_LOC_COUNTRY_DELETE_RECORD]
@CountryID		INT

AS
DELETE FROM [dbo].[LOC_Country]
WHERE [dbo].[LOC_Country].[CountryID] = @CountryID