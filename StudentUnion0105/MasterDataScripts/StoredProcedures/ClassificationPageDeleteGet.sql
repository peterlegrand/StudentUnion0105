CREATE PROCEDURE ClassificationPageDeleteGet (@OId int, @LanguageId int)
AS
SELECT
	dbClassificationPage.Id OId 
	, dbClassificationPage.ClassificationId PId 
	, dbPageStatus.Name Status
	, dbClassificationPage.ShowClassificationPageTitleName
	, dbClassificationPage.ShowClassificationPageTitleDescription
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
JOIN dbPageStatus
	ON dbPageStatus.Id = dbclassificationPage.ClassificationPageStatusId
WHERE dbClassificationPageLanguage.LanguageId = @LanguageId
	AND dbClassificationPage.Id = @OId
