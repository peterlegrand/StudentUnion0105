CREATE PROCEDURE PageLanguageDeletePost (@Id int)
AS
DELETE FROM dbPageLanguage 
WHERE dbPageLanguage.Id = @Id;
