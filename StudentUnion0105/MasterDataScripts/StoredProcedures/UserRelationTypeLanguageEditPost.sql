CREATE PROCEDURE UserRelationTypeLanguageEditPost (
@LId int
, @FromIsOfToName nvarchar(50)
, @ToIsOfFromName nvarchar(50)
, @FromIsOfToDescription nvarchar(max)
, @ToIsOfFromDescription nvarchar(max)
, @FromIsOfToMouseOver nvarchar(50)
, @ToIsOfFromMouseOver nvarchar(50)
, @FromIsOfToMenuName nvarchar(50)
, @ToIsOfFromMenuName nvarchar(50)
, @Modifier varchar(450))
AS
UPDATE dbUserRelationTypeLanguage 
SET FromIsOfToName = @FromIsOfToName
, ToIsOfFromName = @ToIsOfFromName
, FromIsOfToDescription = @FromIsOfToDescription
, ToIsOfFromDescription = @ToIsOfFromDescription
, FromIsOfToMouseOver = @FromIsOfToMouseOver
, ToIsOfFromMouseOver = @ToIsOfFromMouseOver
, FromIsOfToMenuName = @FromIsOfToMenuName
, ToIsOfFromMenuName = @ToIsOfFromMenuName
, ModifierId = @Modifier
, ModifiedDate = getdate()
WHERE Id = @LId
