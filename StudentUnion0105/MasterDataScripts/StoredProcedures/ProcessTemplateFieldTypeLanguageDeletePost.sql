CREATE PROCEDURE ProcessTemplateFieldTypeLanguageDeletePost (@Id int)
AS
DELETE FROM dbProcessTemplateFieldTypeLanguage 
WHERE dbProcessTemplateFieldTypeLanguage.Id = @Id;
