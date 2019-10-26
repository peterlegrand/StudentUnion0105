CREATE PROCEDURE OrganizationTypeDeleteGet (@LanguageId int, @Id int)
AS
SELECT
	dbOrganizationType.Id 
	, Creator.UserName Creator
	, dbOrganizationType.CreatedDate
	, Modifier.UserName Modifier
	, dbOrganizationType.ModifiedDate
	, dbOrganizationTypeLanguage.Id LId
	, dbOrganizationTypeLanguage.Name
	, dbOrganizationTypeLanguage.Description
	, dbOrganizationTypeLanguage.MouseOver
	, dbOrganizationTypeLanguage.MenuName
FROM dbOrganizationTypeLanguage
JOIN dbOrganizationType 
	ON dbOrganizationTypeLanguage.OrganizationTypeId = dbOrganizationType.Id
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbOrganizationType.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbOrganizationType.ModifierId) = Modifier.Id
WHERE dbOrganizationTypeLanguage.LanguageId = @LanguageId
	AND dbOrganizationType.Id = @Id

