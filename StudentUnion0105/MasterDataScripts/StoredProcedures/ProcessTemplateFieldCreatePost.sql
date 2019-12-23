CREATE PROCEDURE ProcessTemplateFieldCreatePost (
	@PId int
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

INSERT INTO dbProcessTemplateField (
	ProcessTemplateFieldTypeId 
	, ProcessTemplateId
	)
VALUES (
	@ProcessTemplateFieldTypeId
	, @PId
	);

DECLARE @NewProcessTemplateFieldId int	= scope_identity();

INSERT INTO dbProcessTemplateFieldLanguage (
	ProcessTemplateFieldId
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
	@NewProcessTemplateFieldId
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


