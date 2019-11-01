CREATE PROCEDURE OrganizationIndexGetOld  (@LanguageId int)
AS
SELECT 
	dbOrganizationLanguage.Id
	, dbOrganizationLanguage.Name
	, dbOrganizationLanguage.Description
	, dbOrganizationLanguage.MouseOver
	, dbOrganizationLanguage.MenuName
FROM dbOrganizationLanguage
WHERE dbOrganizationLanguage.LanguageId = @LanguageId
ORDER BY dbOrganizationLanguage.Name