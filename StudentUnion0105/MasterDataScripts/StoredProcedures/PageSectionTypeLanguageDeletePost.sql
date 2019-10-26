CREATE PROCEDURE PageSectionTypeLanguageDeletePost (@Id int)
AS
DELETE FROM dbPageSectionTypeLanguage 
WHERE dbPageSectionTypeLanguage.Id = @Id;
