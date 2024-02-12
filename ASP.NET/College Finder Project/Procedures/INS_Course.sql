/*****************************
	Get all records.
*****************************/

CREATE OR ALTER PROCEDURE [dbo].[PR_INS_COURSE_SELECT_RECORDS]
AS
SELECT [dbo].[INS_Course].[CourseID]
	,[dbo].[INS_Course].[CourseLogo]
	,[dbo].[INS_Course].[CourseName]
	,[dbo].[INS_Course].[CourseShortName]
	,[dbo].[INS_Course].[CourseDefinition]
	,[dbo].[INS_Course].[CourseDescription]
	,[dbo].[INS_Course].[CourseDuration]
	,[dbo].[INS_Course].[CourseFees]
	,[dbo].[INS_Course].[IsYearly]
	,[dbo].[INS_Course].[StreamID]
FROM [dbo].[INS_Course]


/*****************************
	Get record by ID.
*****************************/

CREATE OR ALTER PROCEDURE [dbo].[PR_INS_COURSE_SELECT_RECORD_BY_PK]
@CourseID	INT

AS
SELECT [dbo].[INS_Course].[CourseID]
	,[dbo].[INS_Course].[CourseLogo]
	,[dbo].[INS_Course].[CourseName]
	,[dbo].[INS_Course].[CourseShortName]
	,[dbo].[INS_Course].[CourseDefinition]
	,[dbo].[INS_Course].[CourseDescription]
	,[dbo].[INS_Course].[CourseDuration]
	,[dbo].[INS_Course].[CourseFees]
	,[dbo].[INS_Course].[IsYearly]
	,[dbo].[INS_Course].[StreamID]
	,[dbo].[INS_Streams].[StreamName]
FROM [dbo].[INS_Course]
INNER JOIN [dbo].[INS_Streams]
ON [dbo].[INS_Streams].[StreamID] = [dbo].[INS_Course].[StreamID]
WHERE [dbo].[INS_Course].[CourseID] = @CourseID


/*****************************
	Insert record.
*****************************/
CREATE OR ALTER PROCEDURE [dbo].[PR_INS_COURSE_INSERT_RECORD]
@CourseName			NVARCHAR(MAX),
@CourseShortName	NVARCHAR(MAX),
@CourseDefinition	NVARCHAR(MAX),
@CourseDescription	NVARCHAR(MAX),
@CourseDuration		NVARCHAR(MAX),
@CourseFees			NVARCHAR(MAX),
@IsYearly			BIT,
@StreamID			INT

AS
INSERT INTO [dbo].[INS_Course]
(
	[dbo].[INS_Course].[CourseName]
	,[dbo].[INS_Course].[CourseShortName]
	,[dbo].[INS_Course].[CourseDefinition]
	,[dbo].[INS_Course].[CourseDescription]
	,[dbo].[INS_Course].[CourseDuration]
	,[dbo].[INS_Course].[CourseFees]
	,[dbo].[INS_Course].[IsYearly]
	,[dbo].[INS_Course].[StreamID]
	,[dbo].[INS_Course].[CreatedDate]
	,[dbo].[INS_Course].[ModifiedDate]
)
VALUES(
	@CourseName,
	@CourseShortName,
	@CourseDefinition,
	@CourseDescription,
	@CourseDuration	,
	@CourseFees,
	@IsYearly,			
	@StreamID,
	GETDATE(),
	GETDATE()
)


/*****************************
	Update record.
*****************************/
CREATE OR ALTER PROCEDURE [dbo].[PR_INS_COURSE_UPDATE_RECORD]
@CourseID			INT,
@CourseName			NVARCHAR(MAX),
@CourseShortName	NVARCHAR(MAX),
@CourseDefinition	NVARCHAR(MAX),
@CourseDescription	NVARCHAR(MAX),
@CourseDuration		NVARCHAR(MAX),
@CourseFees			NVARCHAR(MAX),
@IsYearly			BIT,
@StreamID			INT

AS
UPDATE [dbo].[INS_Course]
SET	[dbo].[INS_Course].[CourseName] = @CourseName
	,[dbo].[INS_Course].[CourseShortName] = @CourseShortName
	,[dbo].[INS_Course].[CourseDefinition] = @CourseDefinition
	,[dbo].[INS_Course].[CourseDescription] = @CourseDescription
	,[dbo].[INS_Course].[CourseDuration] = @CourseDuration
	,[dbo].[INS_Course].[CourseFees] = @CourseFees
	,[dbo].[INS_Course].[IsYearly] = @IsYearly
	,[dbo].[INS_Course].[StreamID] = @StreamID
	,[dbo].[INS_Course].[ModifiedDate] = GETDATE()
WHERE [dbo].[INS_Course].[CourseID] = @CourseID


/*****************************
	Delete record.
*****************************/
CREATE OR ALTER PROCEDURE [dbo].[PR_INS_COURSE_DELETE_RECORD]
@CourseID	INT
AS
DELETE FROM [dbo].[INS_Course]
WHERE [dbo].[INS_Course].[CourseID] = @CourseID