CREATE PROCEDURE ClassificationPageSectionLanguageEditGet (@LId int)
AS
SELECT
	dbClassificationPageSection.Id OId
	, Creator.UserName Creator
	, dbClassificationPageSectionLanguage.CreatedDate
	, Modifier.UserName Modifier
	, dbClassificationPageSectionLanguage.ModifiedDate
	, dbClassificationPageSectionLanguage.Id LId
	, ISNULL(dbClassificationPageSectionLanguage.Name,'') Name
	, ISNULL(dbClassificationPageSectionLanguage.Description,'') Description
	, ISNULL(dbClassificationPageSectionLanguage.MouseOver,'') MouseOver
	, ISNULL(dbClassificationPageSectionLanguage.MenuName,'') MenuName
	, ISNULL(dbClassificationPageSectionLanguage.TitleName,'') TitleName
	, ISNULL(dbClassificationPageSectionLanguage.TitleDescription,'') TitleDescription
	, ISNULL(dbLanguage.LanguageName,'') Language
	, dbClassificationPageSection.ClassificationPageId PId
FROM dbClassificationPageSectionLanguage
JOIN dbClassificationPageSection
	ON dbClassificationPageSection.Id = dbClassificationPageSectionLanguage.PageSectionId
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), DbClassificationPageSectionLanguage.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), DbClassificationPageSectionLanguage.ModifierId) = Modifier.Id
JOIN dbLanguage
	ON dbLanguage.Id = dbClassificationPageSectionLanguage.LanguageId
WHERE dbClassificationPageSectionLanguage.Id=@LId

