CREATE PROCEDURE [GetProcessTemplateGroup] (@Language Int) 
AS  
SELECT  
dbProcessTemplateGroupLanguage.ProcessTemplateGroupId Id 
, ISNULL(dbProcessTemplateGroupLanguage.ProcessTemplateGroupName,'') Name 
FROM dbProcessTemplateGroup 
JOIN dbProcessTemplateGroupLanguage 
ON dbProcessTemplateGroup.Id = dbProcessTemplateGroupLanguage.ProcessTemplateGroupId
WHERE dbProcessTemplateGroupLanguage.LanguageId = @Language 
ORDER BY dbProcessTemplateGroupLanguage.ProcessTemplateGroupName
