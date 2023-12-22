/*==================================================================
		Get record when user sign in.
==================================================================*/
CREATE OR ALTER PROCEDURE [dbo].[PR_MST_USER_REGISTRATION_SELECT_BY_USERNAME_PASSWORD]
@Username	NVARCHAR(MAX),
@Password	NVARCHAR(MAX)

AS
SELECT
	 [dbo].[MST_User_Registration].[UserID]
	,[dbo].[MST_User_Registration].[Username]
    ,[dbo].[MST_User_Registration].[Email]
	,[dbo].[MST_User_Registration].[IsAdmin]
	,[dbo].[MST_User_Registration].[IsActive]

FROM [dbo].[MST_User_Registration]
WHERE [dbo].[MST_User_Registration].[Username] = @Username
AND	[dbo].[MST_User_Registration].[Password] = @Password
ORDER BY [dbo].[MST_User_Registration].[Username]


/*==================================================================
		Insert record when user sign up.
==================================================================*/
CREATE OR ALTER PROCEDURE [dbo].[PR_MST_USER_REGISTRATION_INSERT_RECORD]
@Username	NVARCHAR(MAX),
@Email		NVARCHAR(MAX),
@Password	NVARCHAR(MAX),
@IsAdmin	BIT = 0,
@IsActive	BIT = 0

AS
INSERT INTO [dbo].[MST_User_Registration]
(
	 [dbo].[MST_User_Registration].[Username]
    ,[dbo].[MST_User_Registration].[Email]
	,[dbo].[MST_User_Registration].[Password]
	,[dbo].[MST_User_Registration].[IsAdmin]
	,[dbo].[MST_User_Registration].[IsActive]
	,[dbo].[MST_User_Registration].[CreatedDate]
	,[dbo].[MST_User_Registration].[ModifiedDate]
)
VALUES
(
	 @Username
    ,@Email
	,@Password
	,@IsAdmin
	,@IsActive
	,GETDATE()
	,GETDATE()
)


/*==================================================================
		Update record.
==================================================================*/
CREATE OR ALTER PROCEDURE [dbo].[PR_MST_USER_REGISTRATION_UPDATE_RECORD]
@UserID		INT,
@Username	NVARCHAR(MAX),
@Email		NVARCHAR(MAX),
@Password	NVARCHAR(MAX),
@IsActive	BIT = 0

AS
UPDATE [dbo].[MST_User_Registration]
SET 
	 [dbo].[MST_User_Registration].[Username] = @Username
    ,[dbo].[MST_User_Registration].[Email] = @Email
	,[dbo].[MST_User_Registration].[Password] = @Password
	,[dbo].[MST_User_Registration].[IsActive] = @IsActive
	,[dbo].[MST_User_Registration].[ModifiedDate] = GETDATE()
WHERE [dbo].[MST_User_Registration].[UserID] = @UserID


/*==================================================================
		Delete record.
==================================================================*/
CREATE OR ALTER PROCEDURE [dbo].[PR_MST_USER_REGISTRATION_DELETE_RECORD]
@UserID		INT
AS
DELETE FROM [dbo].[MST_User_Registration]
WHERE [dbo].[MST_User_Registration].[UserID] = @UserID