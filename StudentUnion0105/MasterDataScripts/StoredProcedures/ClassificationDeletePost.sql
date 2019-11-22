CREATE PROCEDURE ClassificationDeletePost (@OId int)
AS
BEGIN TRANSACTION
DELETE FROM dbClassificationLanguage 
WHERE dbClassificationLanguage.ClassificationId = @OId;

DELETE FROM dbClassification
WHERE dbClassification.Id = @OId
COMMIT TRANSACTION