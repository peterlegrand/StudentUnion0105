CREATE PROCEDURE ProcessTemplateFieldLanguageCreateGetLanguageList (@Id int)
AS               
SELECT cast( Id as varchar) Value, LanguageName Text FROM DbLanguage WHERE Id NOT IN (
SELECT LanguageId FROM DbProcessTemplateFieldLanguage WHERE DbProcessTemplateFieldLanguage.ProcessTemplateFieldId = @Id) 
AND DbLanguage.Active = 1
ORDER BY LanguageName


