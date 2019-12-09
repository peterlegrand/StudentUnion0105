CREATE PROCEDURE ClassificationPageLanguageIndexGet (@OId int)
AS
SELECT 
	dbClassificationPageLanguage.Id LId
	, dbClassificationPageLanguage.ClassificationPageId OId
	, dbClassificationPage.ClassificationId PId
	, ISNULL(dbClassificationPageLanguage.Name,'') Name
	, ISNULL(dbClassificationPageLanguage.Description,'') Description
	, ISNULL(dbClassificationPageLanguage.MouseOver,'') MouseOver
	, ISNULL(dbClassificationPageLanguage.MenuName,'') MenuName
	, ISNULL(dbClassificationPageLanguage.TitleName,'') TitleName
	, ISNULL(dbClassificationPageLanguage.TitleDescription,'') TitleDescription
	, dbLanguage.Id LanguageId
	, ISNULL(dbLanguage.LanguageName,'') LanguageName
FROM dbClassificationPageLanguage
JOIN dbLanguage 
	ON dbClassificationPageLanguage.LanguageId = dbLanguage.Id
JOIN dbClassificationPage
	ON dbClassificationPage.Id = dbClassificationPageLanguage.ClassificationPageId 
WHERE dbClassificationPageLanguage.ClassificationPageId = @OId
ORDER BY dbLanguage.LanguageName
