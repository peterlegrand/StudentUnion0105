CREATE PROCEDURE OrganizationEditGet (@LanguageId int, @Id int)
AS
SELECT
	dbOrganization.Id OId
	, dbOrganization.OrganizationStatusId
	, dbOrganization.OrganizationTypeId
	, Creator.UserName Creator
	, dbOrganization.CreatedDate
	, Modifier.UserName Modifier
	, dbOrganization.ModifiedDate
	, dbOrganizationLanguage.Id LId
	, dbOrganizationLanguage.Name
	, dbOrganizationLanguage.Description
	, dbOrganizationLanguage.MouseOver
	, dbOrganizationLanguage.MenuName
FROM dbOrganizationLanguage
JOIN dbOrganization 
	ON dbOrganizationLanguage.OrganizationId = dbOrganization.Id
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbOrganization.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbOrganization.ModifierId) = Modifier.Id
WHERE dbOrganizationLanguage.LanguageId = @LanguageId
	AND dbOrganization.Id = @Id


