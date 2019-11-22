CREATE PROCEDURE OrganizationLanguageIndexGet (@Id int)
AS
SELECT 
dbLanguage.LanguageName
	, dbOrganizationLanguage.Id LId
	, dbOrganizationLanguage.Name
	, dbOrganizationLanguage.Description
	, dbOrganizationLanguage.MouseOver
	, dbOrganizationLanguage.MenuName
	, dbOrganizationLanguage.OrganizationId OId
	, 0 PId
FROM dbOrganizationLanguage
JOIN dbLanguage 
	ON dbOrganizationLanguage.LanguageId = dbLanguage.Id
WHERE dbOrganizationLanguage.OrganizationId = @Id
ORDER BY dbLanguage.LanguageName
