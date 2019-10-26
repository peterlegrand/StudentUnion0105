CREATE PROCEDURE PageTypeLanguageDeletePost (@Id int)
AS
DELETE FROM dbPageTypeLanguage 
WHERE dbPageTypeLanguage.Id = @Id;
