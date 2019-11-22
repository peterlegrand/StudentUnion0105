CREATE PROCEDURE UserOrganizationTypeLanguageIndexGet (@Id int)
AS
SELECT 
dbLanguage.LanguageName
	, dbUserOrganizationTypeLanguage.Id LId
	, dbUserOrganizationTypeLanguage.Name
	, dbUserOrganizationTypeLanguage.Description
	, dbUserOrganizationTypeLanguage.MouseOver
	, dbUserOrganizationTypeLanguage.MenuName
	, dbUserOrganizationTypeLanguage.TypeId OId
	, 0 PId
FROM dbUserOrganizationTypeLanguage
JOIN dbLanguage 
	ON dbUserOrganizationTypeLanguage.LanguageId = dbLanguage.Id
WHERE dbUserOrganizationTypeLanguage.TypeId = @Id
ORDER BY dbLanguage.LanguageName
