CREATE PROCEDURE ClassificationValueLanguageCreateGetLanguageList (@Id int)
AS
SELECT cast( Id as varchar) Value, LanguageName Text FROM DbLanguage WHERE Id NOT IN (
SELECT LanguageId FROM DbClassificationValueLanguage WHERE DbClassificationValueLanguage.ClassificationValueId = @Id) 
AND DbLanguage.Active = 1
ORDER BY LanguageName