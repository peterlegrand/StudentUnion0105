CREATE PROCEDURE ClassificationLevelLanguageIndexGet (@Id int)
AS
SELECT 
dbLanguage.LanguageName
	, dbClassificationLevelLanguage.Id Lid
	, dbClassificationLevelLanguage.Name
	, dbClassificationLevelLanguage.Description
	, dbClassificationLevelLanguage.MouseOver
	, dbClassificationLevelLanguage.MenuName
	, dbClassificationLevelLanguage.ClassificationLevelId OId
	, dbLanguage.LanguageName Language
	, dbClassificationLevel.ClassificationId PId
FROM dbClassificationLevelLanguage
JOIN dbLanguage 
	ON dbClassificationLevelLanguage.LanguageId = dbLanguage.Id
JOIN dbClassificationLevel
	ON dbClassificationLevel.Id = dbClassificationLevelLanguage.ClassificationLevelId 
WHERE dbClassificationLevelLanguage.ClassificationLevelId = @Id
ORDER BY dbLanguage.LanguageName
