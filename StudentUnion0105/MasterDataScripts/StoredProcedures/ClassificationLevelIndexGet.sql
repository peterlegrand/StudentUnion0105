CREATE PROCEDURE ClassificationLevelIndexGet (@Id int, @LanguageId int)
AS
SELECT 
	dbClassificationLevel.Id
	, dbClassificationLevelLanguage.Name
	, dbClassificationLevelLanguage.Description
	, dbClassificationLevelLanguage.MouseOver
	, dbClassificationLevelLanguage.MenuName
FROM dbClassificationLevelLanguage
JOIN dbClassificationLevel 
	ON dbClassificationLevelLanguage.ClassificationLevelId = dbClassificationLevel.Id
WHERE dbClassificationLevelLanguage.LanguageId = @LanguageId
	AND dbClassificationLevel.ClassificationId = @Id
ORDER BY dbClassificationLevel.Sequence
