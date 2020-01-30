CREATE PROCEDURE ProcessTemplateFieldTypeLanguageCreateGetLanguageList (@Id int)
AS
SELECT cast( Id as varchar) Value, LanguageName Text FROM DbLanguage WHERE Id NOT IN (
SELECT LanguageId FROM DbProcessTemplateFieldTypeLanguage WHERE DbProcessTemplateFieldTypeLanguage.FieldTypeId = @Id) 
AND DbLanguage.Active = 1
ORDER BY LanguageName