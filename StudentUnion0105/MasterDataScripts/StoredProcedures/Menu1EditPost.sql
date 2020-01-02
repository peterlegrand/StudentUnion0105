CREATE PROCEDURE Menu1EditPost (
	@Id int
	, @LanguageId int
	, @Sequence int
	, @ClassificationId int
	, @FeatureId int
	, @Controller nvarchar(max)
	, @Action nvarchar(max)
	, @DestinationId int
	, @ModifierId nvarchar(450)
	, @MenuName nvarchar(50)
	, @MouseOver nvarchar(50)
	)
AS
BEGIN TRANSACTION
UPDATE dbMenu1 
SET
	Sequence = @Sequence
	, ClassificationId = @ClassificationId
	, FeatureId = @FeatureId
	, Controller = @Controller
	, Action = @Action
	, DestinationId = @DestinationId
	, ModifierId = @ModifierId
	, ModifiedDate = getdate()
WHERE Id = @Id;
UPDATE dbMenu1Language
SET
	MenuName = @MenuName
	, MouseOver = @MouseOver
	, ModifierId = @ModifierId
	, ModifiedDate = getdate()
WHERE Menu1Id = @Id
	AND LanguageId = @LanguageId
COMMIT TRANSACTION


