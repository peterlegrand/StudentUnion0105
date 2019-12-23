CREATE PROCEDURE ProcessTemplateFieldEditPost (
	@Id int
	, @LanguageId int
	, @ProcessTemplateFieldTypeId int
	, @ModifierId nvarchar(450)
	, @Name nvarchar(50)
	, @Description nvarchar(max)
	, @MouseOver nvarchar(50)
	, @MenuName nvarchar(50)
	)
AS
BEGIN TRANSACTION
UPDATE dbProcessTemplateField 
SET
 	ProcessTemplateFieldTypeId = @ProcessTemplateFieldTypeId
WHERE Id = @Id;
UPDATE dbProcessTemplateFieldLanguage
SET
	 Name = @Name
	, Description = @Description
	, MouseOver = @MouseOver
	, MenuName = @MenuName
	, ModifierId = @ModifierId
	, ModifiedDate = getdate()
WHERE ProcessTemplateFieldId = @Id
	AND LanguageId = @LanguageId
COMMIT TRANSACTION


