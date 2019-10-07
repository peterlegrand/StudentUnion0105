CREATE PROCEDURE [ProcessTemplateFlowCreate]  
  @ProcessTemplateId int 
, @FromStepId int 
, @ToStepId int 
, @LangaugeId int 
, @Name nvarchar(max) 
, @Description nvarchar(max) 
, @MouseOver nvarchar(max) 
 
AS 
BEGIN TRANSACTION
INSERT INTO dbProcessTemplateFlow (ProcessTemplateFromStepId, ProcessTemplateToStepId )
VALUES ( @FromStepId ,  @ToStepId);
DECLARE @Id int	= scope_identity();
INSERT INTO dbProcessTemplateFlowLanguage (FlowId, Name, Description, MouseOver, ModifiedDate, CreatedDate)
VALUES (@Id, @Name, @Description, @MouseOver, getdate(), getdate())

COMMIT TRANSACTION