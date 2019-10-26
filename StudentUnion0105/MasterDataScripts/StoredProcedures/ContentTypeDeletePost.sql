CREATE PROCEDURE ContentTypeDeletePost (@Id int)
AS
BEGIN TRANSACTION
DELETE FROM dbContentTypeLanguage 
WHERE dbContentTypeLanguage.ContentTypeId = @Id;

DELETE FROM dbContentType
WHERE dbContentType.Id = @Id
COMMIT TRANSACTION