CREATE PROCEDURE ContenttLanguageEditGet (@LId int)
AS
SELECT
	dbContentType.Id  OId
	, Creator.UserName Creator
	, dbContentTypeLanguage.CreatedDate
	, Modifier.UserName Modifier
	, dbContentTypeLanguage.ModifiedDate
	, dbContentTypeLanguage.Id LId
	, ISNULL(dbContentTypeLanguage.Name,'') Name
	, ISNULL(dbContentTypeLanguage.Description,'') Description
	, ISNULL(dbContentTypeLanguage.MouseOver,'') MouseOver
	, ISNULL(dbContentTypeLanguage.MenuName,'') MenuName
	, ISNULL(dbLanguage.LanguageName,'') Language
	, 0 PId
FROM dbContentTypeLanguage
JOIN dbContentType
	ON dbContentType.Id = dbContentTypeLanguage.ContentTypeId
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbContentType.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbContentType.ModifierId) = Modifier.Id
JOIN dbLanguage
	ON dbLanguage.Id = dbContentTypeLanguage.LanguageId
WHERE dbContentTypeLanguage.Id=@LId

