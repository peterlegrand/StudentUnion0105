CREATE PROCEDURE ClassificationLanguageIndexGet (@Id int)
AS
SELECT 
	dbLanguage.LanguageName
	, dbClassificationLanguage.Id
	, dbClassificationLanguage.Name
	, dbClassificationLanguage.Description
	, dbClassificationLanguage.MouseOver
	, dbClassificationLanguage.MenuName
FROM dbClassificationLanguage
JOIN dbLanguage 
	ON dbClassificationLanguage.LanguageId = dbLanguage.Id
WHERE dbClassificationLanguage.ClassificationId = @Id
ORDER BY dbLanguage.LanguageName
