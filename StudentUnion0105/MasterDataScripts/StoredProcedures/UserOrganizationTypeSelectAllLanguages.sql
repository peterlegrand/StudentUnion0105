CREATE PROCEDURE [dbo].[UserOrganizationTypeSelectAllLanguages] (@Id int)
AS
SELECT dbUserOrganizationTypeLanguage.Id
, dbUserOrganizationTypeLanguage.Name
, dbLanguage.LanguageName Description
FROM dbUserOrganizationTypeLanguage
JOIN dbLanguage
	ON dbUserOrganizationTypeLanguage.LanguageId = dbLanguage.Id
WHERE dbUserOrganizationTypeLanguage.TypeId = @Id
ORDER BY dbLanguage.LanguageName