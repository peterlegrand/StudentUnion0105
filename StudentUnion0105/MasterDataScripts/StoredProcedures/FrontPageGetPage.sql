CREATE PROCEDURE FrontPageGetPage (@LanguageId int)
AS
SELECT 
	dbPage.Id OId
	, dbPage.ShowTitleName
	, dbPage.ShowTitleDescription
	, dbPageLanguage.Id LId
	, dbPageLanguage.Name
	, dbPageLanguage.Description
	, dbPageLanguage.MouseOver
	, dbPageLanguage.MenuName
	, dbPageLanguage.TitleName
	, dbPageLanguage.TitleDescription
FROM dbPage
JOIN dbPageLanguage
	ON dbPage.Id = dbPageLanguage.PageId
JOIN dbSetting	
	ON dbsetting.IntValue = dbPage.Id
WHERE dbSetting.Id = 2
	AND dbPageLanguage.LanguageId = @LanguageId
	AND dbPage.PageStatusId = 1
