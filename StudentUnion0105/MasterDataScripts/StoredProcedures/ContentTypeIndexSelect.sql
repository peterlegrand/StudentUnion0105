CREATE PROCEDURE ContentTypeIndexSelect (@LanguageId int)
AS 
SELECT dbContentType.Id
	, dbContentTypeLanguage.LanguageId
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
JOIN AspNetUsers Creator
	ON CAST( dbContentType.CreatorId as nvarchar(450))= Creator.Id
JOIN AspNetUsers Modifier
	ON CAST( dbContentType.CreatorId as nvarchar(450))= Modifier.Id
WHERE dbContentTypeLanguage.LanguageId = @LanguageId
ORDER BY 
dbContentTypeLanguage.Name


