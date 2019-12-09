CREATE PROCEDURE ClassificationPageLanguageEditGet (@LId int)
AS
SELECT
	dbClassificationPage.Id OId
	, Creator.UserName Creator
	, dbClassificationPageLanguage.CreatedDate
	, Modifier.UserName Modifier
	, dbClassificationPageLanguage.ModifiedDate
	, dbClassificationPageLanguage.Id LId
	, ISNULL(dbClassificationPageLanguage.Name,'') Name
	, ISNULL(dbClassificationPageLanguage.Description,'') Description
	, ISNULL(dbClassificationPageLanguage.MouseOver,'') MouseOver
	, ISNULL(dbClassificationPageLanguage.MenuName,'') MenuName
	, ISNULL(dbClassificationPageLanguage.TitleName,'') TitleName
	, ISNULL(dbClassificationPageLanguage.TitleDescription,'') TitleDescription
	, ISNULL(dbLanguage.LanguageName,'') Language
	, dbClassificationPage.ClassificationId PId
FROM dbClassificationPageLanguage
JOIN dbClassificationPage
	ON dbClassificationPage.Id = dbClassificationPageLanguage.ClassificationPageId
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbClassificationPage.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbClassificationPage.ModifierId) = Modifier.Id
JOIN dbLanguage
	ON dbLanguage.Id = dbClassificationPageLanguage.LanguageId
WHERE dbClassificationPageLanguage.Id=@LId

