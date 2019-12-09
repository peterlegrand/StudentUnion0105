CREATE PROCEDURE ClassificationPageDeletePost (@OId int)
AS
BEGIN TRANSACTION
DELETE FROM dbClassificationPageLanguage 
WHERE dbClassificationPageLanguage.ClassificationPageId = @OId;

DELETE FROM dbClassificationPage
WHERE dbClassificationPage.Id = @OId
COMMIT TRANSACTION