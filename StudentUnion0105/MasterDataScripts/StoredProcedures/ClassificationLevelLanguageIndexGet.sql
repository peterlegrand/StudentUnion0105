CREATE PROCEDURE ClassificationLevelLanguageIndexGet (@Id int)
AS
SELECT 
dbLanguage.LanguageName
	, dbClassificationLevelLanguage.Id
	, dbClassificationLevelLanguage.Name
	, dbClassificationLevelLanguage.Description
	, dbClassificationLevelLanguage.MouseOver
	, dbClassificationLevelLanguage.MenuName
FROM dbClassificationLevelLanguage
JOIN dbLanguage 
	ON dbClassificationLevelLanguage.LanguageId = dbLanguage.Id
WHERE dbClassificationLevelLanguage.ClassificationLevelId = @Id
ORDER BY dbLanguage.LanguageName
