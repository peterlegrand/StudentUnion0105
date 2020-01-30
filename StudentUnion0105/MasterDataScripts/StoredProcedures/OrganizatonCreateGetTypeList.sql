CREATE PROCEDURE OrganizatonCreateGetTypeList (@LanguageId int)
AS
SELECT Id, Name Text 
FROM DbOrganizationTypeLanguage
WHERE DbOrganizationTypeLanguage.LanguageId = @LanguageId
ORDER BY Name