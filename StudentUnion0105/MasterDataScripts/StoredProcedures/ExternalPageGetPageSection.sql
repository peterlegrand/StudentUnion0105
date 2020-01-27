CREATE PROCEDURE ExternalPageGetPageSection 
AS
SELECT 
	dbPageSection.Id OId
	, dbPageSection.PageId PId
	, dbPageSection.Sequence
	, dbPageSection.OneTwoColumns
	, dbPageSection.ShowSectionTitleName
	, dbPageSection.ShowSectionTitleDescription
	, dbPageSection.ShowContentTypeTitle
	, dbPageSection.ShowContentTypeDescription
	, ISNULL(ContentType.TitleName,'') ContentTitleName
	, ISNULL(ContentType.TitleDescription,'') ContentTitleDescription
	, dbPageSection.MaxContent
	, dbPageSection.HasPaging
	, dbPageSectionLanguage.Id LId
	, dbPageSectionLanguage.Name
	, dbPageSectionLanguage.Description
	, dbPageSectionLanguage.MouseOver
	, dbPageSectionLanguage.MenuName
	, dbPageSectionLanguage.TitleName
	, dbPageSectionLanguage.TitleDescription
FROM dbPageSection
JOIN dbPageSectionLanguage
	ON dbPageSection.Id = dbPageSectionLanguage.PageSectionId
JOIN dbSetting	PageSetting
	ON PageSetting.IntValue = dbPageSection.PageId
LEFT JOIN (
	SELECT 
		dbContentType.Id
		, dbContentTypeLanguage.TitleName
		, dbContentTypeLanguage.TitleDescription 
	FROM dbContentType 
	JOIN dbContentTypeLanguage 
		ON dbContentType.Id = dbContentTypeLanguage.ContentTypeId 
	JOIN dbSetting	LanguageSetting
	ON LanguageSetting.IntValue = dbContentTypeLanguage.LanguageId

	WHERE LanguageSetting.IntValue = 1) ContentType
	ON ContentType.Id = dbPageSection.ContentTypeId
WHERE PageSetting.Id = 5
