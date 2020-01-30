CREATE PROCEDURE OrganizationTypeLanguageCreateGetLanguageList (@Id int)
AS
SELECT cast( Id as varchar) Value, LanguageName Text FROM DbLanguage WHERE Id NOT IN (
SELECT LanguageId FROM DbOrganizationTypeLanguage WHERE DbOrganizationTypeLanguage.OrganizationTypeId = @Id) 
AND DbLanguage.Active = 1
ORDER BY LanguageName