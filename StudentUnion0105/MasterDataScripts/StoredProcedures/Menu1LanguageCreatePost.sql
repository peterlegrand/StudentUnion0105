CREATE PROCEDURE Menu1LanguageCreatePost (
	@OId int
	, @LanguageId int
	, @MenuName nvarchar(50)
	, @MouseOver nvarchar(50)
	, @ModifierId nvarchar(450)
	)
AS
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
	@OId
	, @LanguageId
	, @MenuName
	, @MouseOver
	, @ModifierId
	, getdate()
	, @ModifierId
	, getdate()
	);
