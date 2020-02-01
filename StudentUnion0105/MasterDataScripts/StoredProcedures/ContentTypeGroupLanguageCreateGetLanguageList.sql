CREATE PROCEDURE ContentTypeGroupLanguageCreateGetLanguageList (@Id int)
AS
SELECT cast( Id as varchar) Value, LanguageName Text FROM DbLanguage WHERE Id NOT IN (
SELECT LanguageId FROM DbContentTypeGroupLanguage WHERE DbContentTypeGroupLanguage.ContentTypeGroupId = @Id) 
AND DbLanguage.Active = 1
ORDER BY LanguageName