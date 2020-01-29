CREATE PROCEDURE ProjectLanguageCreateGetLanguageList (@Id int)
AS
SELECT cast( Id as varchar) Value, LanguageName Text FROM DbLanguage WHERE Id NOT IN (
SELECT LanguageId FROM DbProjectLanguage WHERE DbProjectLanguage.ProjectId = @Id) ORDER BY LanguageName