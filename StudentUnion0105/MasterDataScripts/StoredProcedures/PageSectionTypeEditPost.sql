CREATE PROCEDURE PageSectionTypeEditPost (
	@OId int
	, @IndexSection bit
	, @LId int
	, @Name nvarchar(255)
	, @Description nvarchar(max)
	, @MouseOver nvarchar(255)
	, @MenuName nvarchar(255)
	, @ModifierID  nvarchar(255))
AS
BEGIN TRANSACTION
UPDATE dbPageSectionTypeLanguage 
SET Name = @Name, Description = @Description, MouseOver = @MouseOver, MenuName = @MenuName 
WHERE Id = @LId
UPDATE dbPageSectionType SET ModifierId= @ModifierId, ModifiedDate = getdate(), IndexSection = @IndexSection where Id = @OId
COMMIT TRANSACTION