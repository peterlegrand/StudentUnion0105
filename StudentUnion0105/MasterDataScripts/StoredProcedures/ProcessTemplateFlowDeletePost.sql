CREATE PROCEDURE ProcessTemplateFlowDeletePost (@Id int)
AS
BEGIN TRANSACTION
DELETE FROM dbProcessTemplateFlowLanguage 
WHERE dbProcessTemplateFlowLanguage.FlowId = @Id;

DELETE FROM dbProcessTemplateFlow
WHERE dbProcessTemplateFlow.Id = @Id
COMMIT TRANSACTION