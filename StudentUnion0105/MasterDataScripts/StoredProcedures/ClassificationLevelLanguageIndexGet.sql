CREATE PROCEDURE ClassificationLevelLanguageIndexGet (@OId int)
AS
SELECT 
	dbClassificationLevelLanguage.Id LId
	, dbClassificationLevelLanguage.ClassificationLevelId OId
	, dbClassificationLevel.ClassificationId PId
	, ISNULL(dbClassificationLevelLanguage.Name,'') Name
	, ISNULL(dbClassificationLevelLanguage.Description,'') Description
	, ISNULL(dbClassificationLevelLanguage.MouseOver,'') MouseOver
	, ISNULL(dbClassificationLevelLanguage.MenuName,'') MenuName
	, dbLanguage.Id LanguageId
	, ISNULL(dbLanguage.LanguageName,'') LanguageName
FROM dbClassificationLevelLanguage
JOIN dbLanguage 
	ON dbClassificationLevelLanguage.LanguageId = dbLanguage.Id
JOIN dbClassificationLevel
	ON dbClassificationLevel.Id = dbClassificationLevelLanguage.ClassificationLevelId 
WHERE dbClassificationLevelLanguage.ClassificationLevelId = @OId
ORDER BY dbLanguage.LanguageName
