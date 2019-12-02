CREATE PROCEDURE UserOrganizationTypeLanguageIndexGet (@OId int)
AS
SELECT 
	dbUserOrganizationTypeLanguage.Id LId
	, dbUserOrganizationTypeLanguage.TypeId OId
	, 0 PId
	, ISNULL(dbUserOrganizationTypeLanguage.Name,'') Name
	, ISNULL(dbUserOrganizationTypeLanguage.Description,'') Description
	, ISNULL(dbUserOrganizationTypeLanguage.MouseOver,'') MouseOver
	, ISNULL(dbUserOrganizationTypeLanguage.MenuName,'') MenuName
	, dbLanguage.Id LanguageId
	, ISNULL(dbLanguage.LanguageName,'') LanguageName
FROM dbUserOrganizationTypeLanguage
JOIN dbLanguage 
	ON dbUserOrganizationTypeLanguage.LanguageId = dbLanguage.Id
WHERE dbUserOrganizationTypeLanguage.TypeId = @OId
ORDER BY dbLanguage.LanguageName
