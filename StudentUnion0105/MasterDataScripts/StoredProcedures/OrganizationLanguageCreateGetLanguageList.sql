CREATE PROCEDURE OrganizationLanguageCreateGetLanguageList (@Id int)
AS
SELECT cast( Id as varchar) Value, LanguageName Text FROM DbLanguage WHERE Id NOT IN (
SELECT LanguageId FROM DbOrganizationLanguage WHERE DbOrganizationLanguage.OrganizationId = @Id) 
AND DbLanguage.Active = 1
ORDER BY LanguageName