CREATE PROCEDURE ClassificationLevelDeletePost (@OId int)
AS
BEGIN TRANSACTION
DELETE FROM dbClassificationLevelLanguage 
WHERE dbClassificationLevelLanguage.ClassificationLevelId = @OId;

DELETE FROM dbClassificationLevel
WHERE dbClassificationLevel.Id = @OId
COMMIT TRANSACTION