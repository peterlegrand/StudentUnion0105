CREATE PROCEDURE UserOrganizationTypeLanguageEditGet (@LId int)
AS
SELECT
	dbUserOrganizationType.Id OId
	, Creator.UserName Creator
	, dbUserOrganizationTypeLanguage.CreatedDate
	, Modifier.UserName Modifier
	, dbUserOrganizationTypeLanguage.ModifiedDate
	, dbUserOrganizationTypeLanguage.Id LId
	, ISNULL(dbUserOrganizationTypeLanguage.Name,'') Name
	, ISNULL(dbUserOrganizationTypeLanguage.Description,'') Description
	, ISNULL(dbUserOrganizationTypeLanguage.MouseOver,'') MouseOver
	, ISNULL(dbUserOrganizationTypeLanguage.MenuName,'') MenuName
	, ISNULL(dbLanguage.LanguageName,'') Language
	, 0 PId
FROM dbUserOrganizationTypeLanguage
JOIN dbUserOrganizationType
	ON dbUserOrganizationType.Id = dbUserOrganizationTypeLanguage.TypeId
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbUserOrganizationTypeLanguage.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbUserOrganizationTypeLanguage.ModifierId) = Modifier.Id
JOIN dbLanguage
	ON dbLanguage.Id = dbUserOrganizationTypeLanguage.LanguageId
WHERE dbUserOrganizationTypeLanguage.Id=@LId

