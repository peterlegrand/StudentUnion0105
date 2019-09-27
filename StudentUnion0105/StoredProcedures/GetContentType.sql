CREATE PROCEDURE [dbo].[GetContentType] (@Language Int) 
AS  
SELECT  
dbContentTypeLanguage.ContentTypeId Id 
, ISNULL(dbContentTypeLanguage.Name,'') Name 
FROM dbContentType 
JOIN dbContentTypeLanguage 
ON dbContentType.Id = dbContentTypeLanguage.ContentTypeId 
WHERE dbContentTypeLanguage.LanguageId = @Language 
ORDER BY dbContentTypeLanguage.Name 
