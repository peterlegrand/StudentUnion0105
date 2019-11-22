CREATE PROCEDURE OrganizationTypeLanguageIndexGet (@Id int)
AS
SELECT 
dbLanguage.LanguageName
	, dbOrganizationTypeLanguage.Id LId
	, dbOrganizationTypeLanguage.Name
	, dbOrganizationTypeLanguage.Description
	, dbOrganizationTypeLanguage.MouseOver
	, dbOrganizationTypeLanguage.MenuName
	, dbOrganizationTypeLanguage.OrganizationTypeId OId
	, 0 PId
FROM dbOrganizationTypeLanguage
JOIN dbLanguage 
	ON dbOrganizationTypeLanguage.LanguageId = dbLanguage.Id
WHERE dbOrganizationTypeLanguage.OrganizationTypeId = @Id
ORDER BY dbLanguage.LanguageName
