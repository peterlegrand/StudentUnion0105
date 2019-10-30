CREATE PROCEDURE ClassificationCreatePost (
	@Id int
	, @LanguageId int
	, @ClassificationStatusId int
	, @DefaultClassificationPageId int
	, @HasDropDown bit
	, @DropDownSequence int
	, @ModifierId nvarchar(450)
	, @Name nvarchar(50)
	, @Description nvarchar(max)
	, @MouseOver nvarchar(50)
	, @MenuName nvarchar(50)
	)
AS
BEGIN TRANSACTION

INSERT INTO dbClassification (
	ClassificationStatusId 
	, DefaultClassificationPageId 
	, HasDropDown 
	, DropDownSequence 
	, CreatorId
	, CreatedDate
	, ModifierId 
	, ModifiedDate
	)
VALUES (
	@ClassificationStatusId
	, @DefaultClassificationPageId
	, @HasDropDown
	, @DropDownSequence
	, @ModifierId
	, getdate()
	, @ModifierId
	, getdate()
	);

DECLARE @NewClassificationId int	= scope_identity();

INSERT INTO dbClassificationLanguage (
	ClassificationId
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
	@NewClassificationId
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


