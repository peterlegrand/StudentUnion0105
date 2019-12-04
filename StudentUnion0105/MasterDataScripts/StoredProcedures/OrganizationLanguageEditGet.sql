CREATE PROCEDURE OrganizationLanguageEditGet (@LId int)
AS
SELECT
	dbOrganization.Id  OId
	, Creator.UserName Creator
	, dbOrganizationLanguage.CreatedDate
	, Modifier.UserName Modifier
	, dbOrganizationLanguage.ModifiedDate
	, dbOrganizationLanguage.Id LId
	, ISNULL(dbOrganizationLanguage.Name,'') Name
	, ISNULL(dbOrganizationLanguage.Description,'') Description
	, ISNULL(dbOrganizationLanguage.MouseOver,'') MouseOver
	, ISNULL(dbOrganizationLanguage.MenuName,'') MenuName
	, ISNULL(dbLanguage.LanguageName,'') Language
	, dbOrganization.ParentOrganizationId PId
FROM dbOrganizationLanguage
JOIN dbOrganization
	ON dbOrganization.Id = dbOrganizationLanguage.OrganizationId
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbOrganization.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbOrganization.ModifierId) = Modifier.Id
JOIN dbLanguage
	ON dbLanguage.Id = dbOrganizationLanguage.LanguageId
WHERE dbOrganizationLanguage.Id=@LId

