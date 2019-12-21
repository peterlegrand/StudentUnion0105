CREATE PROCEDURE PageSectionEditGet (@LanguageId int, @Id int)
AS
SELECT
	dbPageSection.Id OId
	, dbPageSection.ContentTypeId
	, dbPageSection.HasPaging
	, dbPageSection.MaxContent
	, dbPageSection.OneTwoColumns
	, dbPageSection.PageSectionTypeId
	, dbPageSection.Sequence
	, dbPageSection.ShowContentTypeTitle
	, dbPageSection.ShowContentTypeDescription
	, dbPageSection.ShowSectionTitleName
	, dbPageSection.ShowSectionTitleDescription
	, dbPageSection.SortById
	, Creator.UserName Creator
	, dbPage.CreatedDate
	, Modifier.UserName Modifier
	, dbPage.ModifiedDate
	, dbPageSectionLanguage.Id LId
	, dbPageSectionLanguage.Name
	, dbPageSectionLanguage.Description
	, dbPageSectionLanguage.MouseOver
	, dbPageSectionLanguage.MenuName
	, dbPageSectionLanguage.TitleName
	, dbPageSectionLanguage.TitleDescription
FROM dbPageSectionLanguage
JOIN dbPageSection 
	ON dbPageSectionLanguage.PageSectionId = dbPageSection.Id
JOIN dbPage 
	ON dbPage.Id = dbPageSection.PageId
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbPage.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbPage.ModifierId) = Modifier.Id
WHERE dbPageSectionLanguage.LanguageId = @LanguageId
	AND dbPageSection.Id = @Id

