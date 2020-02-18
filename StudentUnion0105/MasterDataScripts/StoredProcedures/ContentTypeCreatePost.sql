CREATE PROCEDURE ContentTypeCreatePost (
	 @LanguageId int
	, @ModifierId nvarchar(450)
	, @Name nvarchar(50)
	, @Description nvarchar(max)
	, @MouseOver nvarchar(50)
	, @MenuName nvarchar(50)
	, @TitleName nvarchar(50)
	, @TitleDescription nvarchar(Max)
	, @SecurityLevel int
	, @ProcessTemplateId int
	, @ContentTypeGroupId int
	)
AS
BEGIN TRANSACTION

INSERT INTO dbContentType (
	CreatorId
	, CreatedDate
	, ModifierId 
	, ModifiedDate
	, SecurityLevel
	, ProcessTemplateId
	, ContentTypeGroupId
	)
VALUES (
	@ModifierId
	, getdate()
	, @ModifierId
	, getdate()
	, @SecurityLevel
	, @ProcessTemplateId
	, @ContentTypeGroupId
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

INSERT INTO dbContentTypeClassification (
	dbContentTypeClassification.ClassificationId
	, dbContentTypeClassification.ContentTypeId
	, dbContentTypeClassification.StatusId)
SELECT dbclassification.Id
	, @NewId
	, 1 
FROM dbclassification;

COMMIT TRANSACTION


