CREATE PROCEDURE 
[dbo].[ShowPageSection] 
@Id int
, @LanguageId int
AS
SELECT 
	dbPageSection.Id
	, dbPageSection.PageId
	, dbPageSection.ShowSectionTitle
	, dbPageSection.ShowSectionTitleDescription
	, dbPageSection.ShowContentTypeTitle
	, dbPageSection.ShowContentTypeDescription
	, dbPageSection.OneTwoColumns
	, dbPageSection.ContentTypeId
	, dbPageSection.SortById
	, dbPageSection.MaxContent
	, dbPageSection.HasPaging
	, dbPageSectionLanguage.PageSectionTitle
	, dbPageSectionLanguage.PageSectionDescription
	, dbPageSectionType.IndexSection
FROM dbPageSection 
JOIN dbPageSectionLanguage
	ON dbPageSection.Id = dbPageSectionLanguage.PageSectionId
JOIN dbPageSectionType
	ON dbPageSection.PageSectionTypeId = dbPageSectionType.Id
WHERE dbPageSection.PageId = @Id
	AND dbPageSectionLanguage.LanguageId = @LanguageId
ORDER BY dbPageSection.Sequence
