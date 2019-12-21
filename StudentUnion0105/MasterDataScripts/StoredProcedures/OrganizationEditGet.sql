CREATE PROCEDURE OrganizationEditGet (@LanguageId int, @Id int)
AS
SELECT
	dbOrganization.Id OId
	, ISNULL(parent.name,'') ParentOrganization
	, dbOrganization.OrganizationStatusId
	, dbOrganization.OrganizationTypeId
	, dbOrganizationLanguage.Id LId
	, dbOrganizationLanguage.LanguageId
	, ISNULL(dbOrganizationLanguage.Name, '') Name
	, ISNULL(dbOrganizationLanguage.Description, '') Description
	, ISNULL(dbOrganizationLanguage.MouseOver, '') MouseOver
	, ISNULL(dbOrganizationLanguage.MenuName, '') MenuName
	, Creator.UserName Creator
	, dbOrganization.CreatedDate
	, Modifier.UserName Modifier
	, dbOrganization.ModifiedDate
FROM dbOrganizationLanguage
JOIN dbOrganization 
	ON dbOrganizationLanguage.OrganizationId = dbOrganization.Id
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbOrganization.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbOrganization.ModifierId) = Modifier.Id
LEFT JOIN (SELECT DbOrganization.Id, DbOrganizationLanguage.Name FROM DbOrganization JOIN DbOrganizationLanguage ON DbOrganization.Id = DbOrganizationLanguage.OrganizationId)  Parent
	ON dbOrganization.ParentOrganizationId = Parent.Id
WHERE dbOrganizationLanguage.LanguageId = @LanguageId
	AND dbOrganization.Id = @Id


