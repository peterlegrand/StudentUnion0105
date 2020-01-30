CREATE PROCEDURE ClassificationPageSectionLanguageDeletePost (@Id int)
AS
DELETE FROM dbClassificationPageSectionLanguage 
WHERE dbClassificationPageSectionLanguage.Id = @Id;
