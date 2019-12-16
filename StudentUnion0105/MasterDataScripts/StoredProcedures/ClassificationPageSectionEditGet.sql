CREATE PROCEDURE ClassificationPageSectionEditGet (@LanguageId int, @OId int)
AS
SELECT
	dbClassificationPageSection.Id OId
	, dbClassificationPageSection.ClassificationPageId PId
	, dbClassificationPageSection.Sequence
	, dbClassificationPageSection.SectionTypeId
	, dbClassificationPageSection.ShowSectionTitleName
	, dbClassificationPageSection.ShowSectionTitleDescription
	, dbClassificationPageSection.ShowContentTypeTitleName
	, dbClassificationPageSection.ShowContentTypeTitleDescription
	, dbClassificationPageSection.OneTwoColumns
	, ISNULL(dbClassificationPageSection.ContentTypeId,0)ContentTypeId
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
	ON convert(nvarchar(50), DbClassificationPageSectionLanguage.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), DbClassificationPageSectionLanguage.ModifierId) = Modifier.Id
WHERE dbClassificationPageSectionLanguage.LanguageId = @LanguageId
	AND dbClassificationPageSection.Id = @OId

