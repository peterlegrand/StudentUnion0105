CREATE PROCEDURE OrganizationTypeLanguageIndexGet (@Id int)
AS
SELECT 
dbLanguage.LanguageName
	, dbOrganizationTypeLanguage.Id
	, dbOrganizationTypeLanguage.Name
	, dbOrganizationTypeLanguage.Description
	, dbOrganizationTypeLanguage.MouseOver
	, dbOrganizationTypeLanguage.MenuName
FROM dbOrganizationTypeLanguage
JOIN dbLanguage 
	ON dbOrganizationTypeLanguage.LanguageId = dbLanguage.Id
WHERE dbOrganizationTypeLanguage.OrganizationTypeId = @Id
ORDER BY dbLanguage.LanguageName
