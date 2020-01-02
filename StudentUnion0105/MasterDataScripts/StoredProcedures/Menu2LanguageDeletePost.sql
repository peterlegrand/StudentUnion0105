CREATE PROCEDURE Menu2LanguageDeletePost (@Id int)
AS
DELETE FROM dbMenu2Language 
WHERE dbMenu2Language.Id = @Id;
