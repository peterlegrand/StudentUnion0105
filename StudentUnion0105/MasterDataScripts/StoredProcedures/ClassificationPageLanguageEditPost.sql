CREATE PROCEDURE ClassificationPageLanguageEditPost (
	@LId int
	, @ModifierId nvarchar(450)
	, @Name nvarchar(50)
	, @Description nvarchar(max)
	, @MouseOver nvarchar(50)
	, @MenuName nvarchar(50)
	, @TitleName nvarchar(50)
	, @TitleDescription nvarchar(max)
	)
AS
UPDATE dbClassificationPageLanguage 
SET Name = @Name
	, Description = @Description
	, MouseOver = @MouseOver
	, MenuName = @MenuName
	, TitleName = @TitleName
	, TitleDescription = @TitleDescription
	, ModifierId = @ModifierId
	, ModifiedDate = getdate()
WHERE Id = @LId;
