CREATE PROCEDURE ProcessTemplateFlowLanguageDeletePost (@Id int)
AS
DELETE FROM dbProcessTemplateFlowLanguage 
WHERE dbProcessTemplateFlowLanguage.Id = @Id;
