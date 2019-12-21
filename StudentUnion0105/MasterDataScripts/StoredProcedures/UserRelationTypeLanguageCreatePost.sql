CREATE PROCEDURE UserRelationTypeLanguageCreatePost (
	@OId int
	, @LanguageId int
	, @FromIsOfToName nvarchar(50)
	, @ToIsOfFromName nvarchar(50)
	, @FromIsOfToDescription nvarchar(max)
	, @ToIsOfFromDescription nvarchar(max)
	, @FromIsOfToMouseOver nvarchar(50)
	, @ToIsOfFromMouseOver nvarchar(50)
	, @FromIsOfToMenuName nvarchar(50)
	, @ToIsOfFromMenuName nvarchar(50)
	, @ModifierId nvarchar(450)
	)
AS
INSERT INTO dbUserRelationTypeLanguage (
	TypeId
	, LanguageId
	, FromIsOfToName 
	, ToIsOfFromName 
	, FromIsOfToDescription 
	, ToIsOfFromDescription 
	, FromIsOfToMouseOver 
	, ToIsOfFromMouseOver 
	, FromIsOfToMenuName 
	, ToIsOfFromMenuName 
	, CreatorId
	, CreatedDate
	, ModifierId 
	, ModifiedDate
	)
VALUES (
	@OId
	, @LanguageId
	, @FromIsOfToName 
	, @ToIsOfFromName 
	, @FromIsOfToDescription 
	, @ToIsOfFromDescription 
	, @FromIsOfToMouseOver 
	, @ToIsOfFromMouseOver 
	, @FromIsOfToMenuName 
	, @ToIsOfFromMenuName 
	, @ModifierId
	, getdate()
	, @ModifierId
	, getdate()
	);
