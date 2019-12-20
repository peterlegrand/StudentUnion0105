CREATE PROCEDURE ContentTypeCreatePost (
	 @LanguageId int
	, @ModifierId nvarchar(450)
	, @Name nvarchar(50)
	, @Description nvarchar(max)
	, @MouseOver nvarchar(50)
	, @MenuName nvarchar(50)
	, @TitleName nvarchar(50)
	, @TitleDescription nvarchar(Max)
	)
AS
BEGIN TRANSACTION

INSERT INTO dbContentType (
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

INSERT INTO dbContentTypeLanguage (
	ContentTypeId	
	, LanguageId
	, Name 
	, Description 
	, MouseOver 
	, MenuName 
	, TitleName 
	, TitleDescription
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
	, @TitleName
	, @TitleDescription
	, @ModifierId
	, getdate()
	, @ModifierId
	, getdate()
	);
COMMIT TRANSACTION


