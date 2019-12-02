CREATE PROCEDURE ClassificationLanguageIndexGet (@OId int)
AS
SELECT 
	 dbClassificationLanguage.Id LId
	, dbClassificationLanguage.ClassificationId OId
	, 0 PId
	, ISNULL(dbClassificationLanguage.Name,'') Name
	, ISNULL(dbClassificationLanguage.Description,'') Description 
	, ISNULL(dbClassificationLanguage.MouseOver,'') MouseOver
	, ISNULL(dbClassificationLanguage.MenuName,'') MenuName
	, dbLanguage.Id LanguageId
	, ISNULL(dbLanguage.LanguageName,'') LanguageName
FROM dbClassificationLanguage
JOIN dbLanguage 
	ON dbClassificationLanguage.LanguageId = dbLanguage.Id
WHERE dbClassificationLanguage.ClassificationId = @OId
ORDER BY dbLanguage.LanguageName
