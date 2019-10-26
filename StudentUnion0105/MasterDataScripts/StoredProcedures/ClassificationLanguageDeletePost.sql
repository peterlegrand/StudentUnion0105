CREATE PROCEDURE ClassificationLanguageDeletePost (@Id int)
AS
DELETE FROM dbClassificationLanguage 
WHERE dbClassificationLanguage.Id = @Id;
