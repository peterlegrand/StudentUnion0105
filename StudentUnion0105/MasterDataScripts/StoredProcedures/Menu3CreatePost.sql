CREATE PROCEDURE Menu3CreatePost (
	@Menu2Id int
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

INSERT INTO dbMenu3 (
	Menu2Id
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
	@Menu2Id
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

DECLARE @NewMenu3Id int	= scope_identity();

INSERT INTO dbMenu3Language (
	Menu3Id
	, LanguageId
	, MenuName 
	, MouseOver 
	, CreatorId
	, CreatedDate
	, ModifierId 
	, ModifiedDate
	)
VALUES (
	@NewMenu3Id
	, @LanguageId
	, @MenuName
	, @MouseOver
	, @ModifierId
	, getdate()
	, @ModifierId
	, getdate()
	);
COMMIT TRANSACTION


