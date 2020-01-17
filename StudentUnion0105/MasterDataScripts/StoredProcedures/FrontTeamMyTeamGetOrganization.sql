CREATE PROCEDURE FrontTeamMyTeamGetOrganization (@CurrentUserId nvarchar(50))
AS
SELECT
	DbOrganizationLanguage.OrganizationId Id
	, DbOrganizationLanguage.Name OrganizatioName
	, DbUserOrganizationTypeLanguage.Name UserOrganizationTypeName
FROM dbUserOrganization
JOIN DbOrganizationLanguage
	ON dbUserOrganization.OrganizationId = DbOrganizationLanguage.OrganizationId
JOIN DbUserOrganizationTypeLanguage
	ON DbUserOrganizationTypeLanguage.TypeId = DbUserOrganization.TypeId
JOIN AspNetUsers
	ON AspNetUsers.Id = DbUserOrganization.UserId
	AND AspNetUsers.DefaultLanguageId = DbOrganizationLanguage.LanguageId
	AND AspNetUsers.DefaultLanguageId = DbUserOrganizationTypeLanguage.LanguageId
