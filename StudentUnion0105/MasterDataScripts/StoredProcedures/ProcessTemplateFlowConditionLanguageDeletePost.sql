CREATE PROCEDURE ProcessTemplateFlowConditionLanguageDeletePost (@Id int)
AS
DELETE FROM dbProcessTemplateFlowConditionLanguage 
WHERE dbProcessTemplateFlowConditionLanguage.Id = @Id;
