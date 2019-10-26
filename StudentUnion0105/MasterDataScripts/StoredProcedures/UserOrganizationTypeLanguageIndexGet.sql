CREATE PROCEDURE UserOrganizationTypeLanguageIndexGet (@Id int)
AS
SELECT 
dbLanguage.LanguageName
	, dbUserOrganizationTypeLanguage.Id
	, dbUserOrganizationTypeLanguage.Name
	, dbUserOrganizationTypeLanguage.Description
	, dbUserOrganizationTypeLanguage.MouseOver
	, dbUserOrganizationTypeLanguage.MenuName
FROM dbUserOrganizationTypeLanguage
JOIN dbLanguage 
	ON dbUserOrganizationTypeLanguage.LanguageId = dbLanguage.Id
WHERE dbUserOrganizationTypeLanguage.TypeId = @Id
ORDER BY dbLanguage.LanguageName
