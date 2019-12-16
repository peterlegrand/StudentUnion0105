CREATE PROCEDURE ClassificationPageSectionDeletePost (@OId int)
AS
BEGIN TRANSACTION
DELETE FROM dbClassificationPageSectionLanguage 
WHERE dbClassificationPageSectionLanguage.PageSectionId = @OId;

DELETE FROM dbClassificationPageSection
WHERE dbClassificationPageSection.Id = @OId
COMMIT TRANSACTION