CREATE PROCEDURE UserOrganizationTypeIndexGet (@LanguageId int)
AS
SELECT 
	dbUserOrganizationTypeLanguage.Id
	, dbUserOrganizationTypeLanguage.Name
	, dbUserOrganizationTypeLanguage.Description
	, dbUserOrganizationTypeLanguage.MouseOver
	, dbUserOrganizationTypeLanguage.MenuName
FROM dbUserOrganizationTypeLanguage
WHERE dbUserOrganizationTypeLanguage.LanguageId = @LanguageId
ORDER BY dbUserOrganizationTypeLanguage.Name
