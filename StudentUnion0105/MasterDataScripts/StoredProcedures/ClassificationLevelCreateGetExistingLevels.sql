CREATE PROCEDURE ClassificationLevelCreateGetExistingLevels (@LanguageId int, @PId int)
AS 
SELECT 
	dbClassificationLevel.Sequence Id
	, dbClassificationLevelLanguage.Name
FROM dbClassificationLevel 
JOIN dbClassificationLevelLanguage
	ON dbClassificationLevel.Id = dbClassificationLevelLanguage.ClassificationLevelId
WHERE dbClassificationLevelLanguage.LanguageId = @LanguageId
	AND dbClassificationLevel.ClassificationId = @PId
ORDER BY dbClassificationLevel.Sequence