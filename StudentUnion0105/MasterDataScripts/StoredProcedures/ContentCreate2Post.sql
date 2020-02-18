CREATE PROCEDURE ContentCreate2Post  
 @ContentTypeId int 
, @ContentStatusId int 
, @LanguageId int 
, @Title nvarchar(max) 
, @Description nvarchar(max) 
, @SecurityLevel int 
, @OrganizationId int 
, @ProjectId int 
, @CreatorId nvarchar(255)
, @ProcessTemplateId int
, @new_identity INT = NULL OUTPUT 
AS 
BEGIN TRANSACTION
INSERT dbContent 
(ContentTypeId 
, ContentStatusId 
, LanguageId 
, Title 
, Description 
, SecurityLevel 
, OrganizationId 
, ProjectId 
, CreatorId
, ModifierId
, CreatedDate 
, ModifiedDate) 
VALUES ( 
@ContentTypeId 
, @ContentStatusId 
, @LanguageId 
, @Title 
, @Description 
, @SecurityLevel 
, @OrganizationId 
, iif(@ProjectId=0,null,@ProjectId) 
, @CreatorId
, @CreatorId
, GETDATE() 
, getdate() 
) 
SET @new_identity = SCOPE_IDENTITY()

IF @ProcessTemplateId <> 0
BEGIN
DECLARE @StepId int;
DECLARE @NewProcessId int;
SELECT @StepId = DbProcessTemplateFlow.ProcessTemplateToStepId FROM DbProcessTemplateFlow WHERE DbProcessTemplateFlow.ProcessTemplateFromStepId=0 AND DbProcessTemplateFlow.ProcessTemplateId = @ProcessTemplateId ;

INSERT INTO dbProcess (ProcessTemplateId, StepId, CreatorId, CreatedDate, ModifierId, ModifiedDate, ContentId)
VALUES (@ProcessTemplateId, @StepId, @CreatorId, getdate(), @CreatorId, GETDATE(), @new_identity)

SET @NewProcessId = SCOPE_IDENTITY()

INSERT INTO DbProcessField (ProcessId, ProcessTemplateFieldId) SELECT @NewProcessId, Id FROM DbProcessTemplateField WHERE ProcessTemplateId = @ProcessTemplateId

UPDATE DbProcessField SET IntValue = @ProjectId WHERE ProcessId = 


COMMIT TRANSACTION