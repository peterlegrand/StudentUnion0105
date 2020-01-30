CREATE PROCEDURE PageLanguageCreateGetLanguageList (@Id int)
AS
SELECT cast( Id as varchar) Value, LanguageName Text FROM DbLanguage WHERE Id NOT IN (
SELECT LanguageId FROM DbPageLanguage WHERE DbPageLanguage.PageId = @Id) 
AND DbLanguage.Active = 1
ORDER BY LanguageName