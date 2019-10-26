CREATE PROCEDURE ProcessTemplateLanguageDeletePost (@Id int)
AS
DELETE FROM dbProcessTemplateLanguage 
WHERE dbProcessTemplateLanguage.Id = @Id;
