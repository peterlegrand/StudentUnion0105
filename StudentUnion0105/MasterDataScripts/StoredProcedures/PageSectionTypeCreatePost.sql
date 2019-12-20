CREATE PROCEDURE PageSectionTypeCreatePost (
	@IndexSection bit
	, @LanguageId int
	, @ModifierId nvarchar(450)
	, @Name nvarchar(50)
	, @Description nvarchar(max)
	, @MouseOver nvarchar(50)
	, @MenuName nvarchar(50)
	)
AS
BEGIN TRANSACTION

INSERT INTO dbPageSectionType (
	IndexSection
	, CreatorId
	, CreatedDate
	, ModifierId 
	, ModifiedDate
	)
VALUES (
	@IndexSection
	, @ModifierId
	, getdate()
	, @ModifierId
	, getdate()
	);

DECLARE @NewId int	= scope_identity();

INSERT INTO dbPageSectionTypeLanguage (
	PageSectionTypeId	
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


