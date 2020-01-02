CREATE PROCEDURE Menu1LanguageDeletePost (@Id int)
AS
DELETE FROM dbMenu1Language 
WHERE dbMenu1Language.Id = @Id;
