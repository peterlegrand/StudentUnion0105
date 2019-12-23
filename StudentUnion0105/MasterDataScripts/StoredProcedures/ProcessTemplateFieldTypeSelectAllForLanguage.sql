CREATE PROCEDURE ProcessTemplateFieldTypeSelectAllForLanguage (@LanguageId Int) 
AS  
SELECT  
dbProcessTemplateFieldTypeLanguage.FieldTypeId Id 
, ISNULL(dbProcessTemplateFieldTypeLanguage.Name,'') Name 
FROM dbProcessTemplateFieldType 
JOIN dbProcessTemplateFieldTypeLanguage 
ON dbProcessTemplateFieldType.Id = dbProcessTemplateFieldTypeLanguage.FieldTypeId 
WHERE dbProcessTemplateFieldTypeLanguage.LanguageId = @LanguageId 
ORDER BY dbProcessTemplateFieldTypeLanguage.Name 
