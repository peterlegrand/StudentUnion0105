CREATE PROCEDURE OrganizationTypeLanguageIndexGet (@OId int)
AS
SELECT 
	dbOrganizationTypeLanguage.Id LId
	, dbOrganizationTypeLanguage.OrganizationTypeId OId
	, 0 PId
	, ISNULL(dbOrganizationTypeLanguage.Name,'') Name
	, ISNULL(dbOrganizationTypeLanguage.Description,'') Description
	, ISNULL(dbOrganizationTypeLanguage.MouseOver,'') MouseOver
	, ISNULL(dbOrganizationTypeLanguage.MenuName,'') MenuName
	, dbLanguage.Id LanguageId
	, ISNULL(dbLanguage.LanguageName,'') LanguageName
FROM dbOrganizationTypeLanguage
JOIN dbLanguage 
	ON dbOrganizationTypeLanguage.LanguageId = dbLanguage.Id
WHERE dbOrganizationTypeLanguage.OrganizationTypeId = @OId
ORDER BY dbLanguage.LanguageName
