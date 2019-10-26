CREATE PROCEDURE PageTypeDeletePost (@Id int)
AS
BEGIN TRANSACTION
DELETE FROM dbPageTypeLanguage 
WHERE dbPageTypeLanguage.PageTypeId = @Id;

DELETE FROM dbPageType
WHERE dbPageType.Id = @Id
COMMIT TRANSACTION