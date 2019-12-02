CREATE PROCEDURE ClassificationValueLanguageIndexGet (@OId int)
AS
SELECT 
	dbClassificationValueLanguage.Id LId
	, dbClassificationValueLanguage.ClassificationValueId OId
	, dbClassificationValue.ClassificationId PId 
	, ISNULL(dbClassificationValueLanguage.Name,'') Name
	, ISNULL(dbClassificationValueLanguage.Description,'') Description
	, ISNULL(dbClassificationValueLanguage.MouseOver,'') MouseOver
	, ISNULL(dbClassificationValueLanguage.MenuName,'') MenuName
	, dbLanguage.Id LanguageId
	, ISNULL(dbLanguage.LanguageName,'') LanguageName
FROM dbClassificationValueLanguage
JOIN dbLanguage 
	ON dbClassificationValueLanguage.LanguageId = dbLanguage.Id
JOIN dbClassificationValue
	ON dbClassificationValue.Id = dbClassificationValueLanguage.ClassificationValueId
WHERE dbClassificationValueLanguage.ClassificationValueId = @OId
ORDER BY dbLanguage.LanguageName
