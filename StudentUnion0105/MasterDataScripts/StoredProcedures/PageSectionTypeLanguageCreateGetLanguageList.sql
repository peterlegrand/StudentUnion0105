CREATE PROCEDURE PageSectionTypeLanguageCreateGetLanguageList (@Id int)
AS
SELECT cast( Id as varchar) Value, LanguageName Text FROM DbLanguage WHERE Id NOT IN (
SELECT LanguageId FROM DbPageSectionTypeLanguage WHERE DbPageSectionTypeLanguage.PageSectionTypeId = @Id) 
AND DbLanguage.Active = 1
ORDER BY LanguageName