/*--------------------------
	SELECT ALL COLLEGES
--------------------------*/
CREATE OR ALTER PROCEDURE [dbo].[PR_INS_COLLEGE_SELECT_RECORDS]
AS
SELECT [dbo].[INS_College].[CollegeID]
	  ,[dbo].[INS_College].[CollegeLogo]
	  ,[dbo].[INS_College].[CollegeName]
	  ,[dbo].[INS_College].[CollegeShortName]
	  ,[dbo].[INS_College].[CollegeDescription]
	  ,[dbo].[INS_College].[CollegeTypeID]
	  ,[dbo].[INS_CollegeType].[CollegeTypeName]
	  ,[dbo].[INS_College].[ApprovalID]
	  ,[dbo].[MST_Approval].[ApprovalName]
	  ,[dbo].[MST_Approval].[ApprovalShortName]
	  ,[dbo].[INS_College].[AboutCourses]
	  ,[dbo].[INS_College].[AboutPlacement]
	  ,[dbo].[INS_College].[Established]
	  ,[dbo].[INS_College].[IsUniversity]
	  ,[dbo].[INS_College].[CampusType]
	  ,[dbo].[INS_College].[CampusArea]
	  ,[dbo].[INS_College].[Email]
	  ,[dbo].[INS_College].[Phone]
	  ,[dbo].[INS_College].[Website]
	  ,[dbo].[INS_College].[Address]
	  ,[dbo].[INS_College].[CityID]
	  ,[dbo].[LOC_City].[CityName]
	  ,[dbo].[LOC_City].[CityCode]

FROM [dbo].[INS_College]
LEFT OUTER JOIN [dbo].[INS_CollegeType]
ON [dbo].[INS_College].[CollegeTypeID] = [dbo].[INS_CollegeType].[CollegeTypeID]
LEFT OUTER JOIN [dbo].[MST_Approval]
ON [dbo].[INS_College].[ApprovalID] = [dbo].[MST_Approval].[ApprovalID]
LEFT OUTER JOIN [dbo].[LOC_City]
ON [dbo].[INS_College].[CityID] = [dbo].[LOC_City].[CityID]
ORDER BY [dbo].[INS_College].[CollegeName]


/*--------------------------
	SELECT COLLEGE BY ID
--------------------------*/
CREATE OR ALTER PROCEDURE [dbo].[PR_INS_COLLEGE_SELECT_RECORD_BY_PK]
@CollegeID	INT

AS
SELECT [dbo].[INS_College].[CollegeID]
	  ,[dbo].[INS_College].[CollegeLogo]
	  ,[dbo].[INS_College].[CollegeName]
	  ,[dbo].[INS_College].[CollegeShortName]
	  ,[dbo].[INS_College].[CollegeDescription]
	  ,[dbo].[INS_College].[CollegeTypeID]
	  ,[dbo].[INS_CollegeType].[CollegeTypeName]
	  ,[dbo].[INS_College].[ApprovalID]
	  ,[dbo].[MST_Approval].[ApprovalName]
	  ,[dbo].[MST_Approval].[ApprovalShortName]
	  ,[dbo].[INS_College].[AboutCourses]
	  ,[dbo].[INS_College].[AboutPlacement]
	  ,[dbo].[INS_College].[Established]
	  ,[dbo].[INS_College].[IsUniversity]
	  ,[dbo].[INS_College].[CampusType]
	  ,[dbo].[INS_College].[CampusArea]
	  ,[dbo].[INS_College].[Email]
	  ,[dbo].[INS_College].[Phone]
	  ,[dbo].[INS_College].[Website]
	  ,[dbo].[INS_College].[Address]
	  ,[dbo].[INS_College].[CityID]
	  ,[dbo].[LOC_City].[CityName]
	  ,[dbo].[LOC_City].[CityCode]
	  ,[dbo].[LOC_City].[StateID]
	  ,[dbo].[LOC_State].[StateName]
	  ,[dbo].[LOC_State].[StateCode]
      ,[dbo].[LOC_State].[CountryID]
      ,[dbo].[LOC_Country].[CountryName]
      ,[dbo].[LOC_Country].[CountryCode]

FROM [dbo].[INS_College]
LEFT OUTER JOIN [dbo].[INS_CollegeType]
ON [dbo].[INS_College].[CollegeTypeID] = [dbo].[INS_CollegeType].[CollegeTypeID]
LEFT OUTER JOIN [dbo].[MST_Approval]
ON [dbo].[INS_College].[ApprovalID] = [dbo].[MST_Approval].[ApprovalID]
LEFT OUTER JOIN [dbo].[LOC_City]
ON [dbo].[INS_College].[CityID] = [dbo].[LOC_City].[CityID]
LEFT OUTER JOIN [dbo].[LOC_State]
ON [dbo].[LOC_City].[StateID] = [dbo].[LOC_State].[StateID]
LEFT OUTER JOIN [dbo].[LOC_Country]
ON [dbo].[LOC_State].[CountryID] = [dbo].[LOC_Country].[CountryID]
WHERE [dbo].[INS_College].[CollegeID] = @CollegeID
ORDER BY [dbo].[INS_College].[CollegeName]


/*--------------------------
	INSERT COLLEGE RECORD
--------------------------*/
CREATE OR ALTER PROCEDURE [dbo].[PR_INS_COLLEGE_INSERT_RECORD]
@CollegeLogo			NVARCHAR(MAX),
@CollegeName			NVARCHAR(MAX),
@CollegeShortName		NVARCHAR(MAX),
@CollegeDescription		NVARCHAR(MAX),
@CollegeTypeID			INT,
@ApprovalID				INT,
@Established			INT = NULL,
@IsUniversity			BIT,
@CampusType				NVARCHAR(MAX) = NULL,
@CampusArea				NVARCHAR(MAX) = NULL,
@Email					NVARCHAR(MAX),
@Phone					NVARCHAR(MAX),
@Website				NVARCHAR(MAX),
@Address				NVARCHAR(MAX),
@CityID					INT

AS
INSERT INTO [dbo].[INS_College]
(
	 [dbo].[INS_College].[CollegeLogo]
	,[dbo].[INS_College].[CollegeName]
	,[dbo].[INS_College].[CollegeShortName]
	,[dbo].[INS_College].[CollegeDescription]
	,[dbo].[INS_College].[CollegeTypeID]
	,[dbo].[INS_College].[ApprovalID]
	,[dbo].[INS_College].[Established]
	,[dbo].[INS_College].[IsUniversity]
	,[dbo].[INS_College].[CampusType]
	,[dbo].[INS_College].[CampusArea]
	,[dbo].[INS_College].[Email]
	,[dbo].[INS_College].[Phone]
	,[dbo].[INS_College].[Website]
	,[dbo].[INS_College].[Address]
	,[dbo].[INS_College].[CityID]
	,[dbo].[INS_College].[CreatedDate]
	,[dbo].[INS_College].[ModifiedDate]
)
VALUES
(
	@CollegeLogo,
	@CollegeName,
	@CollegeShortName,
	@CollegeDescription,
	@CollegeTypeID,
	@ApprovalID,
	@Established,
	@IsUniversity,
	@CampusType,
	@CampusArea,
	@Email,
	@Phone,
	@Website,
	@Address,
	@CityID,
	GETDATE(),
	GETDATE()
)


/*--------------------------
	UPDATE COLLEGE RECORD
--------------------------*/
CREATE OR ALTER PROCEDURE [dbo].[PR_INS_COLLEGE_UPDATE_RECORD]
@CollegeID				INT,
@CollegeLogo			NVARCHAR(MAX),
@CollegeName			NVARCHAR(MAX),
@CollegeShortName		NVARCHAR(MAX),
@CollegeDescription		NVARCHAR(MAX),
@CollegeTypeID			INT,
@ApprovalID				INT,
@Established			INT = NULL,
@IsUniversity			BIT,
@CampusType				NVARCHAR(MAX) = NULL,
@CampusArea				NVARCHAR(MAX) = NULL,
@Email					NVARCHAR(MAX),
@Phone					NVARCHAR(MAX),
@Website				NVARCHAR(MAX),
@Address				NVARCHAR(MAX),
@CityID					INT

AS
UPDATE [dbo].[INS_College]
SET  [dbo].[INS_College].[CollegeLogo] = @CollegeLogo
	,[dbo].[INS_College].[CollegeName] = @CollegeName
	,[dbo].[INS_College].[CollegeShortName] = @CollegeShortName
	,[dbo].[INS_College].[CollegeDescription] = @CollegeDescription
	,[dbo].[INS_College].[CollegeTypeID] = @CollegeTypeID
	,[dbo].[INS_College].[ApprovalID] = @ApprovalID
	,[dbo].[INS_College].[Established] = @Established
	,[dbo].[INS_College].[IsUniversity] = @IsUniversity
	,[dbo].[INS_College].[CampusType] = @CampusType
	,[dbo].[INS_College].[CampusArea] = @CampusArea
	,[dbo].[INS_College].[Email] = @Email
	,[dbo].[INS_College].[Phone] = @Phone
	,[dbo].[INS_College].[Website] = @Website
	,[dbo].[INS_College].[Address] = @Address
	,[dbo].[INS_College].[CityID] = @CityID
	,[dbo].[INS_College].[ModifiedDate] = GETDATE()
WHERE [dbo].[INS_College].[CollegeID] = @CollegeID


/*--------------------------
	DELETE COLLEGE RECORD
--------------------------*/
CREATE OR ALTER PROCEDURE [dbo].[PR_INS_COLLEGE_DELETE_RECORD]
@CollegeID	INT

AS
DELETE FROM [dbo].[INS_College]
WHERE [dbo].[INS_College].[CollegeID] = @CollegeID