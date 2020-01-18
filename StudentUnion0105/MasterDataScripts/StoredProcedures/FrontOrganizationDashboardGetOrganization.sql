CREATE PROCEDURE FrontOrganizationDashboardGetOrganization (@OrganizationId int, @LanguageId int)
AS
SELECT dbOrganization.Id
	, DbOrganizationLanguage.Name OrganizationName
	, DbOrganizationStatus.Name StatusName
	, DbOrganizationTypeLanguage.Name TypeName
	, DbOrganizationLanguage.Description OrganizationDescription
	, DbOrganization.CreatedDate
	, Creator.UserName Creator
	, DbOrganization.ModifiedDate
	, Modifier.UserName Modifier
	, ISNULL(Parent.Name,'No parent') ParentName 
FROM dbOrganization
LEFT JOIN (SELECT DbOrganizationLanguage.OrganizationId, DbOrganizationLanguage.Name FROM DbOrganizationLanguage WHERE LanguageId = @LanguageId) Parent
	ON dbOrganization.ParentOrganizationId = Parent.OrganizationId
JOIN DbOrganizationLanguage
	ON DbOrganization.Id = DbOrganizationLanguage.OrganizationId
JOIN DbOrganizationStatus
	ON DbOrganization.OrganizationStatusId = DbOrganizationStatus.Id
JOIN DbOrganizationTypeLanguage
	ON DbOrganization.OrganizationTypeId = DbOrganizationTypeLanguage.OrganizationTypeId
JOIN AspNetUsers Creator
	ON DbOrganization.CreatorId = Creator.Id
JOIN AspNetUsers Modifier
	ON DbOrganization.ModifierId = Modifier.Id
WHERE DbOrganizationLanguage.LanguageId = @LanguageId
	AND DbOrganizationTypeLanguage.LanguageId = @LanguageId
	AND dborganization.Id = @OrganizationId