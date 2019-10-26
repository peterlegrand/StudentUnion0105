CREATE PROCEDURE ClassificationLevelDeletePost (@Id int)
AS
BEGIN TRANSACTION
DELETE FROM dbClassificationLevelLanguage 
WHERE dbClassificationLevelLanguage.ClassificationLevelId = @Id;

DELETE FROM dbClassificationLevel
WHERE dbClassificationLevel.Id = @Id
COMMIT TRANSACTION