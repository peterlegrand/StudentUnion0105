CREATE PROCEDURE PageSectionLanguageCreatePost (
	@OId int
	, @LanguageId int
	, @Name nvarchar(50)
	, @Description nvarchar(max)
	, @MouseOver nvarchar(50)
	, @DropDownName nvarchar(50)
	, @PageName nvarchar(50)
	, @PageDescription nvarchar(max)
	, @HeaderName nvarchar(50)
	, @HeaderDescription nvarchar(max)
	, @TopicName nvarchar(50)
	, @ModifierId nvarchar(450)
	)
AS
INSERT INTO dbPageSectionLanguage (
	ClassificationId
	, LanguageId
	, Name 
	, Description 
	, MouseOver 
	, MenuName 
	, DropDownName 
	, PageName 
	, PageDescription 
	, HeaderName 
	, HeaderDescription 
	, TopicName 
	, CreatorId
	, CreatedDate
	, ModifierId 
	, ModifiedDate
	)
VALUES (
	@OId
	, @LanguageId
	, @Name
	, @Description
	, @MouseOver
	, @MenuName
	, @DropDownName 
	, @PageName 
	, @PageDescription 
	, @HeaderName 
	, @HeaderDescription 
	, @TopicName 
	, @ModifierId
	, getdate()
	, @ModifierId
	, getdate()
	);
