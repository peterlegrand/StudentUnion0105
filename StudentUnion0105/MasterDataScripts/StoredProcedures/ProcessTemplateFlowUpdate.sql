CREATE PROCEDURE [ProcessTemplateFlowUpdate]  
  @ProcessTemplateFlowLanguageId int
, @FromStepId int 
, @ToStepId int 
, @Name nvarchar(max) 
, @Description nvarchar(max) 
, @MouseOver nvarchar(max) 
 
AS 
BEGIN TRANSACTION
DECLARE @ProcessTemplateFlowID int;

SELECT @ProcessTemplateFlowID = FlowId 
FROM dbProcessTemplateFlowLanguage 
WHERE Id = @ProcessTemplateFlowLanguageID

UPDATE dbProcessTemplateFlow 
SET 
	ProcessTemplateFromStepId = @FromStepId
	, ProcessTemplateToStepId = @ToStepId
WHERE Id = @ProcessTemplateFlowID

UPDATE dbProcessTemplateFlowLanguage
SET
	Name = @Name
	, Description = @Description
	, MouseOver = @MouseOver
	, ModifiedDate = getdate()
Where Id = @ProcessTemplateFlowLanguageId
COMMIT TRANSACTION

