CREATE PROCEDURE ProcessTemplateFieldTypeLanguageEditPost (
	@LId int
	, @ModifierId nvarchar(450)
	, @Name nvarchar(50)
	, @Description nvarchar(max)
	, @MouseOver nvarchar(50)
	, @MenuName nvarchar(50)
	)
AS
UPDATE dbProcessTemplateFieldTypeLanguage 
SET Name = @Name
	, Description = @Description
	, MouseOver = @MouseOver
	, MenuName = @MenuName
	, ModifierId = @ModifierId
	, ModifiedDate = getdate()
WHERE Id = @LId;
