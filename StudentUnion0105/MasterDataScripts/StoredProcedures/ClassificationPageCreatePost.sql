CREATE PROCEDURE ClassificationPageCreatePost (
	@PId int
	, @LanguageId int
	, @StatusId int
	, @ShowTitleName bit
	, @ShowTitleDescription bit
	, @ModifierId nvarchar(450)
	, @Name nvarchar(50)
	, @Description nvarchar(max)
	, @MouseOver nvarchar(50)
	, @MenuName nvarchar(50)
	, @TitleName nvarchar(50)
	, @TitleDescription nvarchar(max)
	)
AS
BEGIN TRANSACTION

INSERT INTO dbClassificationPage (
	ClassificationId 
	, StatusId
	, ShowTitleName
	, ShowTitleDescription 
	, CreatorId
	, CreatedDate
	, ModifierId 
	, ModifiedDate
	)
VALUES (
	@PId
	, @StatusId
	, @ShowTitleName
	, @ShowTitleDescription
	, @ModifierId
	, getdate()
	, @ModifierId
	, getdate()
	);

DECLARE @NewClassificationPageId int	= scope_identity();

INSERT INTO dbClassificationPageLanguage (
	ClassificationPageId
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
	@NewClassificationPageId
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


