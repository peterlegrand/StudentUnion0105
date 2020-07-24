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

INSERT INTO dbProcess (ProcessTemplateId, StepId, CreatorId, CreatedDate, ModifierId, ModifiedDate)
VALUES (@ProcessTemplateId, @StepId, @CreatorId, getdate(), @CreatorId, GETDATE())

SET @NewProcessId = SCOPE_IDENTITY()

INSERT INTO DbProcessField (ProcessId, ProcessTemplateFieldId, DateTimeValue, IntValue) 
SELECT @NewProcessId, Id, '1900-1-1',0 FROM DbProcessTemplateField WHERE ProcessTemplateId = @ProcessTemplateId

--PETER have to think about 
--17 primary classification
--19 primary classification value

UPDATE DbProcessField SET IntValue = @ProjectId WHERE ProcessId IN (SELECT dbprocess.Id FROM DbProcess JOIN DbProcessTemplateField ON DbProcess.ProcessTemplateId = DbProcessTemplateField.ProcessTemplateId
WHERE DbProcessTemplateField.ProcessTemplateFieldTypeId = 15)

UPDATE DbProcessField SET IntValue = @new_identity WHERE ProcessId IN (SELECT dbprocess.Id FROM DbProcess JOIN DbProcessTemplateField ON DbProcess.ProcessTemplateId = DbProcessTemplateField.ProcessTemplateId
WHERE DbProcessTemplateField.ProcessTemplateFieldTypeId = 21)

UPDATE DbProcessField SET IntValue = @OrganizationId WHERE ProcessId IN (SELECT dbprocess.Id FROM DbProcess JOIN DbProcessTemplateField ON DbProcess.ProcessTemplateId = DbProcessTemplateField.ProcessTemplateId
WHERE DbProcessTemplateField.ProcessTemplateFieldTypeId = 13)

END
COMMIT TRANSACTION