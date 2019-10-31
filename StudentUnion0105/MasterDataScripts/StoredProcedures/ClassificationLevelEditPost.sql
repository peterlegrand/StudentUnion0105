CREATE PROCEDURE ClassificationLevelEditPost (
	@Id int
	, @LanguageId int
	, @Alphabetically bit
	, @CanLink bit
	, @InDropDown bit
	, @OnTheFly bit 
	, @Sequence int
	, @DateLevel int
	, @ModifierId nvarchar(450)
	, @Name nvarchar(50)
	, @Description nvarchar(max)
	, @MouseOver nvarchar(50)
	, @MenuName nvarchar(50)
	)
AS
BEGIN TRANSACTION
UPDATE dbClassificationLevel 
SET
	Alphabetically = @Alphabetically
	, CanLink = @CanLink
	, InDropDown = @InDropDown
	, OnTheFly = @OnTheFly
	, Sequence = @Sequence
	, DateLevel = @DateLevel
	, ModifierId = @ModifierId
	, ModifiedDate = getdate()
WHERE Id = @Id;
UPDATE dbClassificationLevelLanguage
SET
	 Name = @Name
	, Description = @Description
	, MouseOver = @MouseOver
	, MenuName = @MenuName
	, ModifierId = @ModifierId
	, ModifiedDate = getdate()
WHERE ClassificationLevelId = @Id
	AND LanguageId = @LanguageId
COMMIT TRANSACTION


