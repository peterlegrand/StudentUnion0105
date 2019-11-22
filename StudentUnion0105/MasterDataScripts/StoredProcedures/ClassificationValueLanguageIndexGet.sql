CREATE PROCEDURE ClassificationValueLanguageIndexGet (@Id int)
AS
SELECT 
dbLanguage.LanguageName
	, dbClassificationValueLanguage.Id LId
	, dbClassificationValueLanguage.Name
	, dbClassificationValueLanguage.Description
	, dbClassificationValueLanguage.MouseOver
	, dbClassificationValueLanguage.MenuName
	, dbClassificationValueLanguage.ClassificationValueId OId
	, dbClassificationValue.ClassificationId PId 
FROM dbClassificationValueLanguage
JOIN dbLanguage 
	ON dbClassificationValueLanguage.LanguageId = dbLanguage.Id
JOIN dbClassificationValue
	ON dbClassificationValue.Id = dbClassificationValueLanguage.ClassificationValueId
WHERE dbClassificationValueLanguage.ClassificationValueId = @Id
ORDER BY dbLanguage.LanguageName
