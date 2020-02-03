CREATE PROCEDURE ContentTypeDeleteGet (@LanguageId int, @Id int)
AS
SELECT
	dbContentType.Id 
	, Creator.UserName Creator
	, dbContentType.CreatedDate
	, Modifier.UserName Modifier
	, dbContentType.ModifiedDate
	, dbContentTypeLanguage.Id LId
	, dbContentTypeLanguage.Name
	, dbContentTypeLanguage.Description
	, dbContentTypeLanguage.MouseOver
	, dbContentTypeLanguage.MenuName
	, dbContentType.SecurityLevel
FROM dbContentTypeLanguage
JOIN dbContentType 
	ON dbContentTypeLanguage.ContentTypeId = dbContentType.Id
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbContentType.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbContentType.ModifierId) = Modifier.Id
WHERE dbContentTypeLanguage.LanguageId = @LanguageId
	AND dbContentType.Id = @Id

