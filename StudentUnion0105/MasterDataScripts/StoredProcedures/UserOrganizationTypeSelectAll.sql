CREATE PROCEDURE [dbo].[UserOrganizationTypeSelectAll] (@LanguageId int) 
AS  
SELECT  
dbUserOrganizationType.Id
, ISNULL(dbUserOrganizationTypeLanguage.Name,dbUserOrganizationType.Name) Name 
FROM dbUserOrganizationType
JOIN dbUserOrganizationTypeLanguage
	ON dbUserOrganizationType.Id = dbUserOrganizationTypeLanguage.TypeId
WHERE  dbUserOrganizationTypeLanguage.LanguageId = @LanguageId
ORDER BY dbUSerOrganizationTypeLanguage.Name
