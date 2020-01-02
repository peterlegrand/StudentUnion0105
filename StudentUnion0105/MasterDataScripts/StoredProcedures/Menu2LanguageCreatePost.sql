CREATE PROCEDURE Menu2LanguageCreatePost (
	@OId int
	, @LanguageId int
	, @MenuName nvarchar(50)
	, @MouseOver nvarchar(50)
	, @ModifierId nvarchar(450)
	)
AS
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
	@OId
	, @LanguageId
	, @MenuName
	, @MouseOver
	, @ModifierId
	, getdate()
	, @ModifierId
	, getdate()
	);
