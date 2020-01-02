CREATE PROCEDURE Menu3LanguageDeletePost (@Id int)
AS
DELETE FROM dbMenu3Language 
WHERE dbMenu3Language.Id = @Id;
