CREATE PROCEDURE UserRelationTypeLanguageDeletePost (@Id int)
AS
DELETE FROM dbUserRelationTypeLanguage 
WHERE dbUserRelationTypeLanguage.Id = @Id;
