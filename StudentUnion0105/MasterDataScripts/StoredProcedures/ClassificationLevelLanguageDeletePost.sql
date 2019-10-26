CREATE PROCEDURE ClassificationLevelLanguageDeletePost (@Id int)
AS
DELETE FROM dbClassificationLevelLanguage 
WHERE dbClassificationLevelLanguage.Id = @Id;
