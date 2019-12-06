CREATE PROCEDURE PageSectionLanguageEditGet (@LId int)
AS
SELECT
	dbPageSection.Id OId
	, Creator.UserName Creator
	, dbPageSectionLanguage.CreatedDate
	, Modifier.UserName Modifier
	, dbPageSectionLanguage.ModifiedDate
	, dbPageSectionLanguage.Id LId
	, ISNULL(dbPageSectionLanguage.Name,'') Name
	, ISNULL(dbPageSectionLanguage.Description,'') Description
	, ISNULL(dbPageSectionLanguage.MouseOver,'') MouseOver
	, ISNULL(dbPageSectionLanguage.MenuName,'') MenuName
	, ISNULL(dbLanguage.LanguageName,'') Language
	, dbPageSection.PageId PId
FROM dbPageSectionLanguage
JOIN dbPageSection
	ON dbPageSection.Id = dbPageSectionLanguage.PageSectionId
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbPageSectionLanguage.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbPageSectionLanguage.ModifierId) = Modifier.Id
JOIN dbLanguage
	ON dbLanguage.Id = dbPageSectionLanguage.LanguageId
WHERE dbPageSectionLanguage.Id=@LId

