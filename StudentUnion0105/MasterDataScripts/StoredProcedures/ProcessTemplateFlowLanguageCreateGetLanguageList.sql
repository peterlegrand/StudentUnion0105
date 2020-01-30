CREATE PROCEDURE ProcessTemplateFlowLanguageCreateGetLanguageList (@Id int)
AS
SELECT cast( Id as varchar) Value, LanguageName Text FROM DbLanguage WHERE Id NOT IN (
SELECT LanguageId FROM DbProcessTemplateFlowLanguage WHERE DbProcessTemplateFlowLanguage.FlowId = @Id) 
AND DbLanguage.Active = 1
ORDER BY LanguageName