CREATE PROCEDURE ClassificationPageEditGet (@LanguageId int, @OId int)
AS
SELECT
	dbClassificationPage.Id OId
	, dbClassificationPage.ClassificationId PId
	, dbClassificationPage.StatusId
	, dbClassificationPage.ShowTitleName
	, dbClassificationPage.ShowTitleDescription
	, Creator.UserName Creator
	, dbClassificationPage.CreatedDate
	, Modifier.UserName Modifier
	, dbClassificationPage.ModifiedDate
	, dbClassificationPageLanguage.Id LId
	, dbClassificationPageLanguage.Name
	, dbClassificationPageLanguage.Description
	, dbClassificationPageLanguage.MouseOver
	, dbClassificationPageLanguage.MenuName
	, dbClassificationPageLanguage.TitleName
	, dbClassificationPageLanguage.TitleDescription
FROM dbClassificationPageLanguage
JOIN dbClassificationPage 
	ON dbClassificationPageLanguage.ClassificationPageId = dbClassificationPage.Id
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbClassificationPage.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbClassificationPage.ModifierId) = Modifier.Id
WHERE dbClassificationPageLanguage.LanguageId = @LanguageId
	AND dbClassificationPage.Id = @OId

