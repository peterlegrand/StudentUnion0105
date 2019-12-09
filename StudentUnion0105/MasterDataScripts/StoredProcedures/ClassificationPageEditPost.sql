CREATE PROCEDURE ClassificationPageEditPost (
	@OId int
	, @LanguageId int
	, @StatusId int
	, @ShowClassificationPageTitleName bit
	, @ShowClassificationPageTitleDescription bit
	, @ModifierId nvarchar(450)
	, @Name nvarchar(50)
	, @Description nvarchar(max)
	, @MouseOver nvarchar(50)
	, @MenuName nvarchar(50)
	, @TitleName nvarchar(50)
	, @TitleDescription nvarchar(max)
	)
AS
BEGIN TRANSACTION
UPDATE dbClassificationPage 
SET
	ClassificationPageStatusId = @StatusId
	, ShowClassificationPageTitleName = @ShowClassificationPageTitleName
	, ShowClassificationPageTitleDescription= @ShowClassificationPageTitleDescription 
	, ModifierId = @ModifierId
	, ModifiedDate = getdate()
WHERE Id = @OId;
UPDATE dbClassificationPageLanguage
SET
	 Name = @Name
	, Description = @Description
	, MouseOver = @MouseOver
	, MenuName = @MenuName
	, TitleName = @TitleName
	, TitleDescription = @TitleDescription
	, ModifierId = @ModifierId
	, ModifiedDate = getdate()
WHERE ClassificationPageId = @OId
	AND LanguageId = @LanguageId
COMMIT TRANSACTION


