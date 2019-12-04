CREATE PROCEDURE PageSectionLanguageCreatePost (
	@OId int
	, @LanguageId int
	, @Name nvarchar(50)
	, @Description nvarchar(max)
	, @MouseOver nvarchar(50)
	, @TitleName nvarchar(50)
	, @TitleDescription nvarchar(max)
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
