CREATE PROCEDURE ClassificationEditPost (
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
UPDATE dbClassification 
SET
	ClassificationStatusId = @ClassificationStatusId
	, DefaultClassificationPageId = @DefaultClassificationPageId
	, HasDropDown = @HasDropDown
	, DropDownSequence = @DropDownSequence
	, ModifierId = @ModifierId
	, ModifiedDate = getdate()
WHERE Id = @Id;
UPDATE dbClassificationLanguage
SET
	 Name = @Name
	, Description = @Description
	, MouseOver = @MouseOver
	, MenuName = @MenuName
	, ModifierId = @ModifierId
	, ModifiedDate = getdate()
WHERE ClassificationId = @Id
	AND LanguageId = @LanguageId
COMMIT TRANSACTION


