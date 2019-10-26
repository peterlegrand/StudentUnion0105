CREATE PROCEDURE ClassificationValueLanguageDeletePost (@Id int)
AS
DELETE FROM dbClassificationValueLanguage 
WHERE dbClassificationValueLanguage.Id = @Id;
