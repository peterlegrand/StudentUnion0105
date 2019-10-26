CREATE PROCEDURE OrganizationLanguageIndexGet (@Id int)
AS
SELECT 
dbLanguage.LanguageName
	, dbOrganizationLanguage.Id
	, dbOrganizationLanguage.Name
	, dbOrganizationLanguage.Description
	, dbOrganizationLanguage.MouseOver
	, dbOrganizationLanguage.MenuName
FROM dbOrganizationLanguage
JOIN dbLanguage 
	ON dbOrganizationLanguage.LanguageId = dbLanguage.Id
WHERE dbOrganizationLanguage.OrganizationId = @Id
ORDER BY dbLanguage.LanguageName
