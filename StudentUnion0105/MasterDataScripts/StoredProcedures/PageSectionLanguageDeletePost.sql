CREATE PROCEDURE PageSectionLanguageDeletePost (@Id int)
AS
DELETE FROM dbPageSectionLanguage 
WHERE dbPageSectionLanguage.Id = @Id;
