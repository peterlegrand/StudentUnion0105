CREATE PROCEDURE ClassificationLevelCreatePost (
	@PId int
	, @LanguageId int
	, @Sequence int
	, @DateLevel int
	, @OnTheFly bit
	, @Alphabetically bit
	, @CanLink bit
	, @InDropDown bit
	, @ModifierId nvarchar(450)
	, @Name nvarchar(50)
	, @Description nvarchar(max)
	, @MouseOver nvarchar(50)
	, @MenuName nvarchar(50)
	)
AS
BEGIN TRANSACTION

UPDATE dbClassificationLevel SET Sequence = Sequence + 1 WHERE Sequence >= @Sequence and ClassificationId = @PId

INSERT INTO dbClassificationLevel (
	ClassificationId 
	, Sequence
	, DateLevel
	, OnTheFly
	, Alphabetically
	, CanLink
	, InDropDown
	, CreatorId
	, CreatedDate
	, ModifierId 
	, ModifiedDate
	)
VALUES (
	@PId
	, @Sequence
	, @DateLevel
	, @OnTheFly
	, @Alphabetically
	, @CanLink
	, @InDropDown
	, @ModifierId
	, getdate()
	, @ModifierId
	, getdate()
	);

DECLARE @NewClassificationLevelId int	= scope_identity();

INSERT INTO dbClassificationLevelLanguage (
	ClassificationLevelId
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
	@NewClassificationLevelId
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


