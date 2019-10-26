CREATE PROCEDURE OrganizationLanguageEditGet (@Id int)
AS
SELECT
	dbOrganization.Id 
	, Creator.UserName Creator
	, dbOrganizationLanguage.CreatedDate
	, Modifier.UserName Modifier
	, dbOrganizationLanguage.ModifiedDate
	, dbOrganizationLanguage.Id LId
	, dbOrganizationLanguage.Name
	, dbOrganizationLanguage.Description
	, dbOrganizationLanguage.MouseOver
	, dbOrganizationLanguage.MenuName
FROM dbOrganizationLanguage
JOIN dbOrganization
	ON dbOrganization.Id = dbOrganizationLanguage.OrganizationId
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbOrganization.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbOrganization.ModifierId) = Modifier.Id
WHERE dbOrganizationLanguage.Id=@Id

