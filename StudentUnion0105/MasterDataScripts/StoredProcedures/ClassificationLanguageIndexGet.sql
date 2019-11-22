CREATE PROCEDURE ClassificationLanguageIndexGet (@Id int)
AS
SELECT 
	dbLanguage.LanguageName
	, dbClassificationLanguage.Id LId
	, dbClassificationLanguage.Name
	, dbClassificationLanguage.Description
	, dbClassificationLanguage.MouseOver
	, dbClassificationLanguage.MenuName
	, dbClassificationLanguage.ClassificationId OId
	, dbLanguage.LanguageName Language
	, 0 PId
FROM dbClassificationLanguage
JOIN dbLanguage 
	ON dbClassificationLanguage.LanguageId = dbLanguage.Id
WHERE dbClassificationLanguage.ClassificationId = @Id
ORDER BY dbLanguage.LanguageName
