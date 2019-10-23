CREATE PROCEDURE ContentTypeLanguageIndexSelect (@Id int)
AS 
SELECT dbContentTypeLanguage.Id
	, dbContentType.Id
	, dbLanguage.LanguageName
	, dbContentTypeLanguage.Name
	, dbContentTypeLanguage.MouseOver
	, dbContentTypeLanguage.MenuName
	, Creator.UserName Creator
	, Modifier.UserName Modifier
	, dbContentType.CreatedDate
	, dbContentType.ModifiedDate
FROM dbContentType
JOIN dbContentTypeLanguage
	ON dbContentType.Id = dbContentTypeLanguage.ContentTypeId
JOIN dbLanguage
	ON dbLanguage.Id = dbContentTypeLanguage.LanguageId
JOIN AspNetUsers Creator
	ON CAST( dbContentType.CreatorId as nvarchar(450))= Creator.Id
JOIN AspNetUsers Modifier
	ON CAST( dbContentType.CreatorId as nvarchar(450))= Modifier.Id
WHERE dbContentTypeLanguage.ContentTypeId = @Id
ORDER BY 
dbContentTypeLanguage.Name




