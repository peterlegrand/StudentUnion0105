CREATE PROCEDURE PageSectionDeletePost (@Id int)
AS
BEGIN TRANSACTION
DELETE FROM dbPageSectionLanguage 
WHERE dbPageSectionLanguage.PageSectionId = @Id;

DELETE FROM dbPageSection
WHERE dbPageSection.Id = @Id
COMMIT TRANSACTION