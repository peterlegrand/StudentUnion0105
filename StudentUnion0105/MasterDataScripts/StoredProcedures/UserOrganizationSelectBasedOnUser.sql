CREATE PROCEDURE [dbo].[UserOrganizationSelectBasedOnUser] (@LanguageId int, @Id int) 
AS  
SELECT  
dbUserOrganization.OrganizationId Id
, ISNULL(dbOrganizationLanguage.Name,'') Name 
FROM dbUserOrganization
JOIN dbOrganization
	ON dbUserOrganization.OrganizationId = dbOrganization.Id
JOIN dbOrganizationLanguage
	ON dbOrganization.Id = dbOrganizationLanguage.OrganizationId
WHERE dbUserOrganization.Id  = @Id
	AND dbOrganizationLanguage.LanguageId = @LanguageId
ORDER BY dbOrganizationLanguage.Name
