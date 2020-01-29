CREATE PROCEDURE ContentTypeLanguageCreateGetLanguageList (@Id int)
AS
SELECT cast( Id as varchar) Value, LanguageName Text FROM DbLanguage WHERE Id NOT IN (
SELECT LanguageId FROM DbContentTypeLanguage WHERE DbContentTypeLanguage.ContentTypeId = @Id) ORDER BY LanguageName