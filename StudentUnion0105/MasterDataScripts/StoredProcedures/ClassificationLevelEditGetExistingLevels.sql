CREATE PROCEDURE ClassificationLevelEditGetExistingLevels (@LanguageId int, @Id int)
AS 
SELECT 
	dbClassificationLevel.Sequence Id
	, dbClassificationLevelLanguage.Name
FROM dbClassificationLevel 
JOIN dbClassificationLevelLanguage
	ON dbClassificationLevel.Id = dbClassificationLevelLanguage.ClassificationLevelId
WHERE dbClassificationLevelLanguage.LanguageId = @LanguageId
	AND dbClassificationLevel.ClassificationId = (SELECT ClassificationId FROM dbClassificationLevel WHERE Id = @Id)
ORDER BY dbClassificationLevel.Sequence