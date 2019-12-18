CREATE PROCEDURE ClassificationLevelEditGetExistingLevels (@LanguageId int, @OId int)
AS 
SELECT 
	dbClassificationLevel.Sequence Id
	, dbClassificationLevelLanguage.Name
FROM dbClassificationLevel 
JOIN dbClassificationLevelLanguage
	ON dbClassificationLevel.Id = dbClassificationLevelLanguage.ClassificationLevelId
WHERE dbClassificationLevelLanguage.LanguageId = @LanguageId
	AND dbClassificationLevel.ClassificationId = (SELECT ClassificationId FROM dbClassificationLevel WHERE Id = @OId)
ORDER BY dbClassificationLevel.Sequence