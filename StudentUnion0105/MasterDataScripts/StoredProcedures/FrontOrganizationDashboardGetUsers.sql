CREATE PROCEDURE FrontOrganizationDashboardGetUsers (@OrganizationId int, @LanguageId int)
AS
SELECT 
	DbUserOrganization.Id
	, users.Id UserId
	, users.UserName
	, DbUserOrganizationTypeLanguage.Name TypeName
FROM AspNetUsers Users 
JOIN DbUserOrganization
	ON users.Id = DbUserOrganization.UserId
JOIN DbUserOrganizationTypeLanguage
	ON DbUserOrganizationTypeLanguage.TypeId = DbUserOrganization.TypeId
WHERE DbUserOrganization.OrganizationId = @OrganizationId
	AND DbUserOrganizationTypeLanguage.LanguageId = @LanguageId
