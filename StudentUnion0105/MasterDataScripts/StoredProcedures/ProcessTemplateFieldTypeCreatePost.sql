CREATE PROCEDURE ProcessTemplateFieldTypeCreatePost (
	 @LanguageId int
	, @ModifierId nvarchar(450)
	, @Name nvarchar(50)
	, @Description nvarchar(max)
	, @MouseOver nvarchar(50)
	, @MenuName nvarchar(50)
	)
AS
BEGIN TRANSACTION

INSERT INTO dbProcessTemplateFieldType (
	 CreatorId
	, CreatedDate
	, ModifierId 
	, ModifiedDate
	)
VALUES (
	 @ModifierId
	, getdate()
	, @ModifierId
	, getdate()
	);

DECLARE @NewId int	= scope_identity();

INSERT INTO dbProcessTemplateFieldTypeLanguage (
	FieldTypeId
	, LanguageId
	, Name 
	, Description 
	, MouseOver 
	, MenuName 
	, CreatorId
	, CreatedDate
	, ModifierId 
	, ModifiedDate
	)
VALUES (
	@NewId
	, @LanguageId
	, @Name
	, @Description
	, @MouseOver
	, @MenuName
	, @ModifierId
	, getdate()
	, @ModifierId
	, getdate()
	);
COMMIT TRANSACTION


