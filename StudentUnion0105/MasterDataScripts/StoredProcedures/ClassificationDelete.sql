CREATE PROCEDURE ClassificationDelete (@Id int)
AS
BEGIN TRANSACTION 
DELETE FROM dbClassificationLanguage 
WHERE dbClassificationLanguage.ClassificationId = @Id

DELETE FROM dbClassification 
WHERE dbClassification.Id = @Id
COMMIT TRANSACTION