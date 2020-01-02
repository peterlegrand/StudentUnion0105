CREATE PROCEDURE Menu2CreatePost (
	@Menu1Id int
	, @MenuTypeId int
	, @Sequence int
	, @ClassificationId int
	, @FeatureId int
	, @Controller nvarchar(max)
	, @Action nvarchar(max)
	, @DestinationId int
	, @LanguageId int
	, @ModifierId nvarchar(450)
	, @MenuName nvarchar(50)
	, @MouseOver nvarchar(50)
	)
AS
BEGIN TRANSACTION

INSERT INTO dbMenu2 (
	Menu1Id
	, MenuTypeId 
	, Sequence
	, ClassificationId 
	, FeatureId 
	, Controller
	, Action
	, DestinationId
	, CreatorId
	, CreatedDate
	, ModifierId 
	, ModifiedDate
	)
VALUES (
	@Menu1Id
	, @MenuTypeId
	, @Sequence
	, @ClassificationId
	, @FeatureId
	, @Controller
	, @Action
	, @DestinationId
	, @ModifierId
	, getdate()
	, @ModifierId
	, getdate()
	);

DECLARE @NewMenu2Id int	= scope_identity();

INSERT INTO dbMenu2Language (
	Menu2Id
	, LanguageId
	, MenuName 
	, MouseOver 
	, CreatorId
	, CreatedDate
	, ModifierId 
	, ModifiedDate
	)
VALUES (
	@NewMenu2Id
	, @LanguageId
	, @MenuName
	, @MouseOver
	, @ModifierId
	, getdate()
	, @ModifierId
	, getdate()
	);
COMMIT TRANSACTION


