CREATE PROCEDURE ClassificationValueSectionLanguageCreatePost (
	@OId int
	, @LanguageId int
	, @Name nvarchar(50)
	, @Description nvarchar(max)
	, @MouseOver nvarchar(50)
	, @MenuName nvarchar(50)
	, @TitleName nvarchar(50)
	, @TitleDescription nvarchar(max)
	, @DropDownName
	, @PageName
	, @PageDescription
	, @HeaderName
	, @HeaderDescription
	, @TopicName

	, @ModifierId nvarchar(450)
	)
AS
INSERT INTO dbClassificationPageSectionLanguage (
	PageSectionId
	, LanguageId
	, Name 
	, Description 
	, MouseOver 
	, MenuName 
	, TitleName
	, TitleDescription
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
	, @TitleName
	, @TitleDescription
	, @ModifierId
	, getdate()
	, @ModifierId
	, getdate()
	);