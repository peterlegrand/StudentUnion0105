CREATE PROCEDURE OrganizationTypeLanguageEditGet (@LId int)
AS
SELECT
	dbOrganizationType.Id  OId
	, Creator.UserName Creator
	, dbOrganizationTypeLanguage.CreatedDate
	, Modifier.UserName Modifier
	, dbOrganizationTypeLanguage.ModifiedDate
	, dbOrganizationTypeLanguage.Id LId
	, ISNULL(dbOrganizationTypeLanguage.Name,'') Name
	, ISNULL(dbOrganizationTypeLanguage.Description,'') Description
	, ISNULL(dbOrganizationTypeLanguage.MouseOver,'') MouseOver
	, ISNULL(dbOrganizationTypeLanguage.MenuName,'') MenuName
	, ISNULL(dbLanguage.LanguageName,'') Language
	, 0 PId
FROM dbOrganizationTypeLanguage
JOIN dbOrganizationType
	ON dbOrganizationType.Id = dbOrganizationTypeLanguage.OrganizationTypeId
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbOrganizationType.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbOrganizationType.ModifierId) = Modifier.Id
JOIN dbLanguage
	ON dbLanguage.Id = dbOrganizationTypeLanguage.LanguageId
WHERE dbOrganizationTypeLanguage.Id=@LId

