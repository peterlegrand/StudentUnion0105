CREATE PROCEDURE [dbo].[UserOrganizationNewOrganizationsSelect] (@UserId varchar(450), @LanguageId int) 
AS  
SELECT dbOrganization.Id , dbOrganizationLanguage.Name
FROM dbOrganization 
JOIN dbOrganizationLanguage
	ON dbOrganization.Id = dbOrganizationLanguage.OrganizationId
WHERE dbOrganization.Id NOT IN (SELECT OrganizationId FROM dbUserOrganization WHERE UserId = @UserId)
	AND dbOrganization.OrganizationStatusId = 1
	AND dbOrganizationLanguage.LanguageId = @LanguageId
ORDER BY dbOrganizationLanguage.Name