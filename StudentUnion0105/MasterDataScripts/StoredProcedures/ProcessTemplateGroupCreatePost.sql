CREATE PROCEDURE ProcessTemplateGroupCreatePost (
	 @LanguageId int
	, @ModifierId nvarchar(450)
	, @Name nvarchar(50)
	, @Description nvarchar(max)
	, @MouseOver nvarchar(50)
	, @MenuName nvarchar(50)
	)
AS
BEGIN TRANSACTION

INSERT INTO dbProcessTemplateGroup (
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

DECLARE @NewProcessTemplateGroupId int	= scope_identity();

INSERT INTO dbProcessTemplateGroupLanguage (
	ProcessTemplateGroupId
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
	@NewProcessTemplateGroupId
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


