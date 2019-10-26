CREATE PROCEDURE ProcessTemplateFieldLanguageDeletePost (@Id int)
AS
DELETE FROM dbProcessTemplateFieldLanguage 
WHERE dbProcessTemplateFieldLanguage.Id = @Id;
