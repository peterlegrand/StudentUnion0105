CREATE PROCEDURE Menu1CreatePost (
	@MenuTypeId int
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

INSERT INTO dbMenu1 (
	MenuTypeId 
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
	@MenuTypeId
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

DECLARE @NewMenu1Id int	= scope_identity();

INSERT INTO dbMenu1Language (
	Menu1Id
	, LanguageId
	, MenuName 
	, MouseOver 
	, CreatorId
	, CreatedDate
	, ModifierId 
	, ModifiedDate
	)
VALUES (
	@NewMenu1Id
	, @LanguageId
	, @MenuName
	, @MouseOver
	, @ModifierId
	, getdate()
	, @ModifierId
	, getdate()
	);
COMMIT TRANSACTION


