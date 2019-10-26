CREATE PROCEDURE ClassificationValueLanguageIndexGet (@Id int)
AS
SELECT 
dbLanguage.LanguageName
	, dbClassificationValueLanguage.Id
	, dbClassificationValueLanguage.Name
	, dbClassificationValueLanguage.Description
	, dbClassificationValueLanguage.MouseOver
	, dbClassificationValueLanguage.MenuName
FROM dbClassificationValueLanguage
JOIN dbLanguage 
	ON dbClassificationValueLanguage.LanguageId = dbLanguage.Id
WHERE dbClassificationValueLanguage.ClassificationValueId = @Id
ORDER BY dbLanguage.LanguageName
