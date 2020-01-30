CREATE PROCEDURE ProcessTemplateStepLanguageCreateGetLanguageList (@Id int)
AS
SELECT cast( Id as varchar) Value, LanguageName Text FROM DbLanguage WHERE Id NOT IN (
SELECT LanguageId FROM DbProcessTemplateStepLanguage WHERE DbProcessTemplateStepLanguage.StepId = @Id) 
AND DbLanguage.Active = 1
ORDER BY LanguageName