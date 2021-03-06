CREATE PROCEDURE [dbo].[UserOrganizationSelectAll] (@User varchar(450), @LanguageId int) 
AS  
SELECT  
dbUserOrganization.OrganizationId  Id
, ISNULL(dbOrganizationLanguage.Name,'') Name 
, ISNULL(dbOrganizationLanguage.Description,'') Description 
, ISNULL(dbOrganizationLanguage.MouseOver,'') MouseOver 
, ISNULL(dbOrganizationLanguage.MenuName,'') MenuName 
FROM dbUserOrganization
JOIN dbOrganization
	ON dbUserOrganization.OrganizationId = dbOrganization.Id
JOIN dbOrganizationLanguage
	ON dbOrganization.Id = dbOrganizationLanguage.OrganizationId
WHERE dbUserOrganization.UserId = @User
	AND dbOrganizationLanguage.LanguageId = @LanguageId
ORDER BY dbOrganizationLanguage.Name
