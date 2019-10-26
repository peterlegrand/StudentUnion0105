CREATE PROCEDURE ContentTypeLanguageDeletePost (@Id int)
AS
DELETE FROM dbContentTypeLanguage 
WHERE dbContentTypeLanguage.Id = @Id;
