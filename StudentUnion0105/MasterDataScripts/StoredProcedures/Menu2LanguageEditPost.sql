CREATE PROCEDURE Menu2LanguageEditPost (
	@LId int
	, @ModifierId nvarchar(450)
	, @Description nvarchar(max)
	, @MenuName nvarchar(50)
	, @MouseOver nvarchar(50)
	)
AS
UPDATE dbMenu2Language 
SET 
	MenuName = @MenuName
	, MouseOver = @MouseOver
	, ModifierId = @ModifierId
	, ModifiedDate = getdate()
WHERE Id = @LId;
