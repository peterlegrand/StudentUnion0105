CREATE PROCEDURE PageSectionTypeSelectAllForLanguage (@LanguageId Int) 
AS  
SELECT  
dbPageSectionTypeLanguage.PageSectionTypeId Id 
, ISNULL(dbPageSectionTypeLanguage.Name,'') Name 
FROM dbPageSectionType 
JOIN dbPageSectionTypeLanguage 
ON dbPageSectionType.Id = dbPageSectionTypeLanguage.PageSectionTypeId
WHERE dbPageSectionTypeLanguage.LanguageId = @LanguageId 
ORDER BY dbPageSectionTypeLanguage.Name 

