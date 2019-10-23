CREATE PROCEDURE ClassificationIndexGet (@LanguageId int)
AS
SELECT 
	dbClassificationLanguage.Id
	, dbClassificationLanguage.Name
	, dbClassificationLanguage.Description
	, dbClassificationLanguage.MouseOver
	, dbClassificationLanguage.MenuName
FROM dbClassificationLanguage
WHERE dbClassificationLanguage.LanguageId = @LanguageId
ORDER BY dbClassificationLanguage.Name