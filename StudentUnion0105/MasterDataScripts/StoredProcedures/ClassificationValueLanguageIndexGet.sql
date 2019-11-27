CREATE PROCEDURE ClassificationValueLanguageIndexGet (@OId int)
AS
SELECT 
dbLanguage.LanguageName Language
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
WHERE dbClassificationValueLanguage.ClassificationValueId = @OId
ORDER BY dbLanguage.LanguageName
