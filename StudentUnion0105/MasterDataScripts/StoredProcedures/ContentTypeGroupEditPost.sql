CREATE PROCEDURE ContentTypeGroupEditPost (
	@Id int
	, @LanguageId int
	, @ModifierId nvarchar(450)
	, @Name nvarchar(50)
	, @Description nvarchar(max)
	, @MouseOver nvarchar(50)
	, @MenuName nvarchar(50)
	)
AS
BEGIN TRANSACTION
UPDATE dbContentTypeGroup 
SET
	, ModifierId = @ModifierId
	, ModifiedDate = getdate()
WHERE Id = @Id;

UPDATE dbContentTypeGroupLanguage
SET
	 Name = @Name
	, Description = @Description
	, MouseOver = @MouseOver
	, MenuName = @MenuName
	, ModifierId = @ModifierId
	, ModifiedDate = getdate()
WHERE ContentTypeGroupId = @Id
	AND LanguageId = @LanguageId
COMMIT TRANSACTION


