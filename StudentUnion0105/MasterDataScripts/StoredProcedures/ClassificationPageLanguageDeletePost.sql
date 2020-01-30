CREATE PROCEDURE ClassificationPageLanguageDeletePost (@Id int)
AS
DELETE FROM dbClassificationPageLanguage 
WHERE dbClassificationPageLanguage.Id = @Id;
