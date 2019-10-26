CREATE PROCEDURE OrganizationTypeLanguageEditGet (@Id int)
AS
SELECT
	dbOrganizationType.Id 
	, Creator.UserName Creator
	, dbOrganizationTypeLanguage.CreatedDate
	, Modifier.UserName Modifier
	, dbOrganizationTypeLanguage.ModifiedDate
	, dbOrganizationTypeLanguage.Id LId
	, dbOrganizationTypeLanguage.Name
	, dbOrganizationTypeLanguage.Description
	, dbOrganizationTypeLanguage.MouseOver
	, dbOrganizationTypeLanguage.MenuName
FROM dbOrganizationTypeLanguage
JOIN dbOrganizationType
	ON dbOrganizationType.Id = dbOrganizationTypeLanguage.OrganizationTypeId
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbOrganizationType.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbOrganizationType.ModifierId) = Modifier.Id
WHERE dbOrganizationTypeLanguage.Id=@Id

