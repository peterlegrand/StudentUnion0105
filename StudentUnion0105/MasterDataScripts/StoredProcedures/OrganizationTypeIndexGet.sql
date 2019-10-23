CREATE PROCEDURE OrganizationTypeIndexGet (@LanguageId int)
AS
SELECT 
	dbOrganizationTypeLanguage.Id
	, dbOrganizationTypeLanguage.Name
	, dbOrganizationTypeLanguage.Description
	, dbOrganizationTypeLanguage.MouseOver
	, dbOrganizationTypeLanguage.MenuName
FROM dbOrganizationTypeLanguage
WHERE dbOrganizationTypeLanguage.LanguageId = @LanguageId
ORDER BY dbOrganizationTypeLanguage.Name