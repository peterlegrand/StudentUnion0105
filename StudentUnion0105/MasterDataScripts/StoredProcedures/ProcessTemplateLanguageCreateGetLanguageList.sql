CREATE PROCEDURE ProcessTemplateLanguageCreateGetLanguageList (@Id int)
AS
SELECT cast( Id as varchar) Value, LanguageName Text FROM DbLanguage WHERE Id NOT IN (
SELECT LanguageId FROM DbProcessTemplateLanguage WHERE DbProcessTemplateLanguage.ProcessTemplateId = @Id) 
AND DbLanguage.Active = 1
ORDER BY LanguageName