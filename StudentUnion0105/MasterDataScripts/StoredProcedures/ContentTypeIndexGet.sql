CREATE PROCEDURE ContentTypeIndexGet (@LanguageId int)
AS
SELECT 
	dbContentType.Id
	, ISNULL(Name, '') Name
	, ISNULL(Description,'') Description
	, ISNULL(MouseOver,'') MouseOver
	, ISNULL(MenuName,'') MenuName
FROM dbContentType 
JOIN dbContentTypeLanguage 
	ON dbContentType.Id = dbContentTypeLanguage.ContentTypeId
WHERE dbContentTypeLanguage.LanguageId = @LanguageId
ORDER BY Name