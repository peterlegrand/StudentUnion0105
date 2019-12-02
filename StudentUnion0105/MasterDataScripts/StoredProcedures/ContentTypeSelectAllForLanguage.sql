CREATE PROCEDURE [dbo].[ContentTypeSelectAllForLanguage] (@LanguageId Int) 
AS  
SELECT  
dbContentTypeLanguage.ContentTypeId Id 
, ISNULL(dbContentTypeLanguage.Name,'') Name 
FROM dbContentType 
JOIN dbContentTypeLanguage 
ON dbContentType.Id = dbContentTypeLanguage.ContentTypeId 
WHERE dbContentTypeLanguage.LanguageId = @LanguageId 
ORDER BY dbContentTypeLanguage.Name 
