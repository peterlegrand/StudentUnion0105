CREATE PROCEDURE ClassificationPageIndexGet (@Id int, @LanguageId int)
AS
SELECT 
	dbClassificationPage.Id
	, dbClassificationPageLanguage.Name
	, dbClassificationPageLanguage.Description
	, dbClassificationPageLanguage.MouseOver
	, dbClassificationPageLanguage.MenuName
FROM dbClassificationPageLanguage
JOIN dbClassificationPage 
	ON dbClassificationPageLanguage.ClassificationPageId = dbClassificationPage.Id
WHERE dbClassificationPageLanguage.LanguageId = @LanguageId
	AND dbClassificationPage.ClassificationId = @Id
ORDER BY DbClassificationPageLanguage.Name
