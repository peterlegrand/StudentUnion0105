CREATE PROCEDURE OrganizationTypeIndexGet (@LanguageId int)
AS
SELECT 
	dbOrganizationTypeLanguage.Id
	, ISNULL(dbOrganizationTypeLanguage.Name,'') Name
	, ISNULL(dbOrganizationTypeLanguage.Description,'') Description
	, ISNULL(dbOrganizationTypeLanguage.MouseOver,'') MouseOver
	, ISNULL(dbOrganizationTypeLanguage.MenuName,'') MenuName
FROM dbOrganizationTypeLanguage
WHERE dbOrganizationTypeLanguage.LanguageId = @LanguageId
ORDER BY dbOrganizationTypeLanguage.Name