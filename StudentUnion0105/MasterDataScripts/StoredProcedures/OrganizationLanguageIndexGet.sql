CREATE PROCEDURE OrganizationLanguageIndexGet (@OId int)
AS
SELECT 
	dbOrganizationLanguage.Id LId
	, dbOrganizationLanguage.OrganizationId OId
	, 0 PId
	, ISNULL(dbOrganizationLanguage.Name,'') Name
	, ISNULL(dbOrganizationLanguage.Description,'') Description
	, ISNULL(dbOrganizationLanguage.MouseOver,'') MouseOver
	, ISNULL(dbOrganizationLanguage.MenuName,'') MenuName
	, dbLanguage.Id LanguageId
	, ISNULL(dbLanguage.LanguageName,'') LanguageName
FROM dbOrganizationLanguage
JOIN dbLanguage 
	ON dbOrganizationLanguage.LanguageId = dbLanguage.Id
WHERE dbOrganizationLanguage.OrganizationId = @OId
ORDER BY dbLanguage.LanguageName
