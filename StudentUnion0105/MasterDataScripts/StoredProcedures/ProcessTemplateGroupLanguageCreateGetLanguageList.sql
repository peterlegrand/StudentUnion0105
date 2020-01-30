CREATE PROCEDURE ProcessTemplateGroupLanguageCreateGetLanguageList (@Id int)
AS
SELECT cast( Id as varchar) Value, LanguageName Text FROM DbLanguage WHERE Id NOT IN (
SELECT LanguageId FROM DbProcessTemplateGroupLanguage WHERE DbProcessTemplateGroupLanguage.ProcessTemplateGroupId = @Id) 
AND DbLanguage.Active = 1
ORDER BY LanguageName