CREATE PROCEDURE ClassificationLevelLanguageIndexGet (@Id int)
AS
SELECT 
dbLanguage.LanguageName
	, dbClassificationLevelLanguage.Id Lid
	, dbClassificationLevelLanguage.Name
	, dbClassificationLevelLanguage.Description
	, dbClassificationLevelLanguage.MouseOver
	, dbClassificationLevelLanguage.MenuName
	, dbClassificationLevelLanguage.ClassificationLevelId Id
	, dbLanguage.LanguageName Language
FROM dbClassificationLevelLanguage
JOIN dbLanguage 
	ON dbClassificationLevelLanguage.LanguageId = dbLanguage.Id
WHERE dbClassificationLevelLanguage.ClassificationLevelId = @Id
ORDER BY dbLanguage.LanguageName
