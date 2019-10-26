CREATE PROCEDURE PageSectionTypeDeletePost (@Id int)
AS
BEGIN TRANSACTION
DELETE FROM dbPageSectionTypeLanguage 
WHERE dbPageSectionTypeLanguage.PageSectionTypeId = @Id;

DELETE FROM dbPageSectionType
WHERE dbPageSectionType.Id = @Id
COMMIT TRANSACTION