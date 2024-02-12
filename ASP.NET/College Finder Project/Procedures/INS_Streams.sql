/*==================================================================
		Get records.
==================================================================*/
CREATE OR ALTER PROCEDURE [dbo].[PR_INS_STREAMS_SELECT_RECORDS]
@StreamID	INT = NULL

AS
SELECT [dbo].[INS_Streams].[StreamID]
	  ,[dbo].[INS_Streams].[StreamName]
	  ,[dbo].[INS_Streams].[StreamDescription]
	  ,[dbo].[INS_Streams].[CreatedDate]
	  ,[dbo].[INS_Streams].[ModifiedDate]
FROM [dbo].[INS_Streams]
WHERE [dbo].[INS_Streams].[StreamID] = CASE
											WHEN @StreamID IS NOT NULL THEN @StreamID
											ELSE StreamID
										END
ORDER BY [dbo].[INS_Streams].[StreamName]


/*==================================================================
		Insert records.
==================================================================*/
CREATE OR ALTER PROCEDURE [dbo].[PR_INS_STREAMS_INSERT_RECORD]
@StreamName			NVARCHAR(MAX),
@StreamDescription	NVARCHAR(MAX)

AS
INSERT INTO [dbo].[INS_Streams]
(
	[dbo].[INS_Streams].[StreamName]
   ,[dbo].[INS_Streams].[StreamDescription]
   ,[dbo].[INS_Streams].[CreatedDate]
   ,[dbo].[INS_Streams].[ModifiedDate]
)
VALUES
(
	@StreamName
   ,@StreamDescription
   ,GETDATE()
   ,GETDATE()
)


/*==================================================================
		Update records.
==================================================================*/
CREATE OR ALTER PROCEDURE [dbo].[PR_INS_STREAMS_UPDATE_RECORD]
@StreamID			INT,
@StreamName			NVARCHAR(MAX),
@StreamDescription	NVARCHAR(MAX)

AS
UPDATE [dbo].[INS_Streams]
SET	[dbo].[INS_Streams].[StreamName] = @StreamName
   ,[dbo].[INS_Streams].[StreamDescription] = @StreamDescription
   ,[dbo].[INS_Streams].[ModifiedDate] = GETDATE()
WHERE [dbo].[INS_Streams].[StreamID] = @StreamID


/*==================================================================
		Delete records.
==================================================================*/
CREATE OR ALTER PROCEDURE [dbo].[PR_INS_STREAMS_DELETE_RECORD]
@StreamID	INT

AS
DELETE FROM [dbo].[INS_Streams]
WHERE [dbo].[INS_Streams].[StreamID] = @StreamID