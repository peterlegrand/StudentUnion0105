CREATE PROCEDURE [ProcessTemplateFlowCreate]  
  @ProcessTemplateId int 
, @FromStepId int 
, @ToStepId int 
, @LanguageId int 
, @Name nvarchar(max) 
, @Description nvarchar(max) 
, @MouseOver nvarchar(max) 
 
AS 
BEGIN TRANSACTION
INSERT INTO dbProcessTemplateFlow (ProcessTemplateId, ProcessTemplateFromStepId, ProcessTemplateToStepId )
VALUES ( @ProcessTemplateId, @FromStepId ,  @ToStepId);
DECLARE @Id int	= scope_identity();
INSERT INTO dbProcessTemplateFlowLanguage (FlowId, LanguageId, Name, Description, MouseOver, ModifiedDate, CreatedDate)
VALUES (@Id, @LanguageId, @Name, @Description, @MouseOver, getdate(), getdate())

COMMIT TRANSACTION