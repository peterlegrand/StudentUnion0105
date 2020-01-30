CREATE PROCEDURE PageSectionLanguageCreateGetLanguageList (@Id int)
AS
SELECT cast( Id as varchar) Value, LanguageName Text FROM DbLanguage WHERE Id NOT IN (
SELECT LanguageId FROM DbPageSectionLanguage WHERE DbPageSectionLanguage.PageSectionId = @Id) 
AND DbLanguage.Active = 1
ORDER BY LanguageName