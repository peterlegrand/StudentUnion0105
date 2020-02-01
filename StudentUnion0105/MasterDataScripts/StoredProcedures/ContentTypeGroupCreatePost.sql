CREATE PROCEDURE ContentTypeGroupCreatePost (
	 @LanguageId int
	, @ModifierId nvarchar(450)
	, @Name nvarchar(50)
	, @Description nvarchar(max)
	, @MouseOver nvarchar(50)
	, @MenuName nvarchar(50)
	)
AS
BEGIN TRANSACTION

INSERT INTO dbContentTypeGroup (
	, CreatorId
	, CreatedDate
	, ModifierId 
	, ModifiedDate
	)
VALUES (
	, @ModifierId
	, getdate()
	, @ModifierId
	, getdate()
	);

DECLARE @NewContentTypeGroupId int	= scope_identity();

INSERT INTO dbContentTypeGroupLanguage (
	ContentTypeGroupId
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
	@NewContentTypeGroupId
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


