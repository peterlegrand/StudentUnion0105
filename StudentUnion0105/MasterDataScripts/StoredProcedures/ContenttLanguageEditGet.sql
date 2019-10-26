CREATE PROCEDURE ContenttLanguageEditGet (@Id int)
AS
SELECT
	dbContentType.Id 
	, Creator.UserName Creator
	, dbContentTypeLanguage.CreatedDate
	, Modifier.UserName Modifier
	, dbContentTypeLanguage.ModifiedDate
	, dbContentTypeLanguage.Id LId
	, dbContentTypeLanguage.Name
	, dbContentTypeLanguage.Description
	, dbContentTypeLanguage.MouseOver
	, dbContentTypeLanguage.MenuName
FROM dbContentTypeLanguage
JOIN dbContentType
	ON dbContentType.Id = dbContentTypeLanguage.ContentTypeId
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbContentType.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbContentType.ModifierId) = Modifier.Id
WHERE dbContentTypeLanguage.Id=@Id

