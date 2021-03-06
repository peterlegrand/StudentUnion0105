CREATE PROCEDURE [GetProcessTemplateGroup] (@LanguageId Int) 
AS  
SELECT  
dbProcessTemplateGroupLanguage.ProcessTemplateGroupId Id 
, ISNULL(dbProcessTemplateGroupLanguage.Name,'') Name 
FROM dbProcessTemplateGroup 
JOIN dbProcessTemplateGroupLanguage 
ON dbProcessTemplateGroup.Id = dbProcessTemplateGroupLanguage.ProcessTemplateGroupId
WHERE dbProcessTemplateGroupLanguage.LanguageId = @LanguageId 
ORDER BY dbProcessTemplateGroupLanguage.Name
