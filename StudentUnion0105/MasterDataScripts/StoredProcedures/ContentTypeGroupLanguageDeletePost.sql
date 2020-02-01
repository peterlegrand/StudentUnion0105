CREATE PROCEDURE ContentTypeGroupLanguageDeletePost (@Id int)
AS
DELETE FROM dbContentTypeGroupLanguage 
WHERE dbContentTypeGroupLanguage.Id = @Id;
