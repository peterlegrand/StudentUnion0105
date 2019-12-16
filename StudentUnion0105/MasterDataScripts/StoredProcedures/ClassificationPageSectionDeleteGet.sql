CREATE PROCEDURE ClassificationPageSectionDeleteGet (@OId int, @LanguageId int)
AS
SELECT
	dbClassificationPageSection.Id OId 
	, dbClassificationPageSection.ClassificationPageId PId 
	, dbClassificationPageSection.Sequence
	, DbPageSectionTypeLanguage.Name SectionTypeName
	, dbClassificationPageSection.ShowSectionTitleName
	, dbClassificationPageSection.ShowSectionTitleDescription
	, dbClassificationPageSection.ShowContentTypeTitleName
	, dbClassificationPageSection.ShowContentTypeTitleDescription
	, dbClassificationPageSection.OneTwoColumns
	, ISNULL(DbContentTypeLanguage.Name,'') ContentTypeName
	, dbClassificationPageSection.SortById
	, dbClassificationPageSection.MaxContent 
	, dbClassificationPageSection.HasPaging
	, dbClassificationPageSectionLanguage.Id LId
	, dbClassificationPageSectionLanguage.Name
	, dbClassificationPageSectionLanguage.Description
	, dbClassificationPageSectionLanguage.MouseOver
	, dbClassificationPageSectionLanguage.MenuName
	, dbClassificationPageSectionLanguage.TitleName
	, dbClassificationPageSectionLanguage.TitleDescription
	, Creator.UserName Creator
	, DbClassificationPageSectionLanguage.CreatedDate
	, Modifier.UserName Modifier
	, DbClassificationPageSectionLanguage.ModifiedDate
FROM dbClassificationPageSectionLanguage
JOIN dbClassificationPageSection 
	ON dbClassificationPageSectionLanguage.PageSectionId = dbClassificationPageSection.Id
JOIN AspNetUsers Creator
	ON DbClassificationPageSectionLanguage.CreatorId = Creator.Id
JOIN AspNetUsers Modifier
	ON DbClassificationPageSectionLanguage.ModifierId = Modifier.Id
JOIN DbPageSectionTypeLanguage
	ON DbPageSectionTypeLanguage.PageSectionTypeId = dbclassificationPageSection.SectionTypeId
LEFT JOIN DbContentTypeLanguage
	ON DbContentTypeLanguage.ContentTypeId = dbclassificationPageSection.ContentTypeId
WHERE dbClassificationPageSectionLanguage.LanguageId = @LanguageId
	AND dbClassificationPageSection.Id = @OId
	AND DbPageSectionTypeLanguage.LanguageId = @LanguageId