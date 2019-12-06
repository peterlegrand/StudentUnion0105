CREATE PROCEDURE PageSectionTypeLanguageEditGet (@LId int)
AS
SELECT
	dbPageSectionType.Id OId
	, Creator.UserName Creator
	, dbPageSectionTypeLanguage.CreatedDate
	, Modifier.UserName Modifier
	, dbPageSectionTypeLanguage.ModifiedDate
	, dbPageSectionTypeLanguage.Id LId
	, ISNULL(dbPageSectionTypeLanguage.Name,'') Name
	, ISNULL(dbPageSectionTypeLanguage.Description,'') Description
	, ISNULL(dbPageSectionTypeLanguage.MouseOver,'') MouseOver
	, ISNULL(dbPageSectionTypeLanguage.MenuName,'') MenuName
	, ISNULL(dbLanguage.LanguageName,'') Language
	, 0 PId
FROM dbPageSectionTypeLanguage
JOIN dbPageSectionType
	ON dbPageSectionType.Id = dbPageSectionTypeLanguage.PageSectionTypeId
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbPageSectionTypeLanguage.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbPageSectionTypeLanguage.ModifierId) = Modifier.Id
JOIN dbLanguage
	ON dbLanguage.Id = dbPageSectionTypeLanguage.LanguageId
WHERE dbPageSectionTypeLanguage.Id=@LId

