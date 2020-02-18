CREATE PROCEDURE ContentTypeEditPost (
	@OId int
	, @LId int
	, @Name nvarchar(255)
	, @Description nvarchar(max)
	, @MouseOver nvarchar(255)
	, @MenuName nvarchar(255)
	, @ModifierID  nvarchar(255)
	, @SecurityLevel int
	, @ProcessTemplateId int)
AS
BEGIN TRANSACTION

UPDATE dbContentTypeLanguage SET 
	Name = @Name
	, Description = @Description
	, MouseOver = @MouseOver
	, MenuName = @MenuName 
	
WHERE Id = @LId
UPDATE dbContentType SET 
	ModifierId= @ModifierId
	, ModifiedDate = getdate()
	, SecurityLevel = @SecurityLevel 
	, ProcessTemplateId = @ProcessTemplateId
WHERE Id = @OId
COMMIT TRANSACTION