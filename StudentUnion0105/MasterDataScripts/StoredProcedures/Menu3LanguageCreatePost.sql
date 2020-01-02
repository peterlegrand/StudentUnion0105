CREATE PROCEDURE Menu3LanguageCreatePost (
	@OId int
	, @LanguageId int
	, @MenuName nvarchar(50)
	, @MouseOver nvarchar(50)
	, @ModifierId nvarchar(450)
	)
AS
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
	@OId
	, @LanguageId
	, @MenuName
	, @MouseOver
	, @ModifierId
	, getdate()
	, @ModifierId
	, getdate()
	);
