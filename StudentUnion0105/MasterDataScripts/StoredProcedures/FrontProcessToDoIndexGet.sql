CREATE PROCEDURE FrontProcessToDoIndexGet (@DefaultLanguageId int, @CurrentUser nvarchar(200)) AS
SELECT 
	DbProcess.Id
	, DbProcessTemplateLanguage.Name
	, dbprocess.CreatedDate
FROM DbProcess
JOIN DbProcessTemplateFlow
	ON DbProcess.ProcessTemplateId = DbProcessTemplateFlow.ProcessTemplateId
	AND DbProcess.StepId = DbProcessTemplateFlow.ProcessTemplateFromStepId
JOIN DbProcessTemplateFlowCondition
	ON DbProcessTemplateFlow.Id = DbProcessTemplateFlowCondition.ProcessTemplateFlowId
JOIN DbProcessTemplateLanguage
	ON DbProcess.ProcessTemplateId = DbProcessTemplateLanguage.ProcessTemplateId
WHERE StepId <> 0
AND DbProcessTemplateFlowCondition.ProcessTemplateConditionTypeId = 2 --Creator
AND DbProcess.CreatorId = @CurrentUser
AND DbProcessTemplateLanguage.LanguageId = @DefaultLanguageId

UNION ALL
SELECT 
	DbProcess.Id
	, DbProcessTemplateLanguage.Name
	, dbprocess.CreatedDate
FROM DbProcess
JOIN DbProcessTemplateFlow
	ON DbProcess.ProcessTemplateId = DbProcessTemplateFlow.ProcessTemplateId
	AND DbProcess.StepId = DbProcessTemplateFlow.ProcessTemplateFromStepId
JOIN DbProcessTemplateFlowCondition
	ON DbProcessTemplateFlow.Id = DbProcessTemplateFlowCondition.ProcessTemplateFlowId
JOIN DbProcessTemplateField
	ON DbProcessTemplateField.ProcessTemplateId = DbProcessTemplateFlow.ProcessTemplateId
JOIN DbProcessField
	ON DbProcessField.ProcessId = DbProcess.Id
	AND DbProcessField.ProcessTemplateFieldId = DbProcessTemplateField.Id
JOIN DbProcessTemplateLanguage
	ON DbProcess.ProcessTemplateId = DbProcessTemplateLanguage.ProcessTemplateId
JOIN AspNetUsers
	ON AspNetUsers.SecurityLevel >= DbProcessField.IntValue 
WHERE StepId <> 0
	AND DbProcessTemplateField.ProcessTemplateFieldTypeId = 27
--	AND DbProcessField.IntValue <= @CurrentSecurityLevel --Security level
	AND DbProcessTemplateFlowCondition.ProcessTemplateConditionTypeId = 3 
	AND AspNetUsers.Id = @CurrentUser

UNION ALL

SELECT 
	DbProcess.Id
	, DbProcessTemplateLanguage.Name
	, dbprocess.CreatedDate
FROM DbProcess
JOIN DbProcessTemplateFlow
	ON DbProcess.ProcessTemplateId = DbProcessTemplateFlow.ProcessTemplateId
	AND DbProcess.StepId = DbProcessTemplateFlow.ProcessTemplateFromStepId
JOIN DbProcessTemplateFlowCondition
	ON DbProcessTemplateFlow.Id = DbProcessTemplateFlowCondition.ProcessTemplateFlowId
JOIN DbProcessTemplateField
	ON DbProcessTemplateField.ProcessTemplateId = DbProcessTemplateFlow.ProcessTemplateId
JOIN DbProcessField
	ON DbProcessField.ProcessId = DbProcess.Id
	AND DbProcessField.ProcessTemplateFieldId = DbProcessTemplateField.Id
JOIN AspNetUserRoles
	ON AspNetUserRoles.RoleId = DbProcessField.StringValue
JOIN DbProcessTemplateLanguage
	ON DbProcess.ProcessTemplateId = DbProcessTemplateLanguage.ProcessTemplateId
WHERE StepId <> 0
	AND DbProcessTemplateField.ProcessTemplateFieldTypeId = 29 --Role user
	AND AspNetUserRoles.UserId = @CurrentUser
	AND DbProcessTemplateFlowCondition.ProcessTemplateConditionTypeId = 4 

UNION ALL

SELECT 
	DbProcess.Id
	, DbProcessTemplateLanguage.Name
	, dbprocess.CreatedDate
FROM DbProcess
JOIN DbProcessTemplateFlow
	ON DbProcess.ProcessTemplateId = DbProcessTemplateFlow.ProcessTemplateId
	AND DbProcess.StepId = DbProcessTemplateFlow.ProcessTemplateFromStepId
JOIN DbProcessTemplateFlowCondition
	ON DbProcessTemplateFlow.Id = DbProcessTemplateFlowCondition.ProcessTemplateFlowId
JOIN DbProcessTemplateField
	ON DbProcessTemplateField.ProcessTemplateId = DbProcessTemplateFlow.ProcessTemplateId
JOIN DbProcessField
	ON DbProcessField.ProcessId = DbProcess.Id
	AND DbProcessField.ProcessTemplateFieldId = DbProcessTemplateField.Id
JOIN DbUserRelation
	ON DbUserRelation.FromUserId = DbProcessField.StringValue
JOIN DbProcessTemplateLanguage
	ON DbProcess.ProcessTemplateId = DbProcessTemplateLanguage.ProcessTemplateId
WHERE StepId <> 0
	AND DbProcessTemplateField.ProcessTemplateFieldTypeId = 11 --manager
	AND DbUserRelation.TypeId = 1
	AND DbUserRelation.ToUserId = @CurrentUser
	AND DbProcessTemplateFlowCondition.ProcessTemplateConditionTypeId = 5 

UNION ALL

SELECT 
	DbProcess.Id
	, DbProcessTemplateLanguage.Name
	, dbprocess.CreatedDate
FROM DbProcess
JOIN DbProcessTemplateFlow
	ON DbProcess.ProcessTemplateId = DbProcessTemplateFlow.ProcessTemplateId
	AND DbProcess.StepId = DbProcessTemplateFlow.ProcessTemplateFromStepId
JOIN DbProcessTemplateFlowCondition
	ON DbProcessTemplateFlow.Id = DbProcessTemplateFlowCondition.ProcessTemplateFlowId
JOIN DbProcessTemplateField
	ON DbProcessTemplateField.ProcessTemplateId = DbProcessTemplateFlow.ProcessTemplateId
JOIN DbProcessField
	ON DbProcessField.ProcessId = DbProcess.Id
	AND DbProcessField.ProcessTemplateFieldId = DbProcessTemplateField.Id
JOIN DbUserOrganization
	ON DbUserOrganization.OrganizationId = DbProcessField.IntValue
JOIN DbProcessTemplateLanguage
	ON DbProcess.ProcessTemplateId = DbProcessTemplateLanguage.ProcessTemplateId
WHERE StepId <> 0
	AND DbProcessTemplateField.ProcessTemplateFieldTypeId = 13 --Organization
	AND DbUserOrganization.UserId = @CurrentUser
	AND DbProcessTemplateFlowCondition.ProcessTemplateConditionTypeId = 6 


UNION ALL

SELECT 
	DbProcess.Id
	, DbProcessTemplateLanguage.Name
	, dbprocess.CreatedDate
FROM DbProcess
JOIN DbProcessTemplateFlow
	ON DbProcess.ProcessTemplateId = DbProcessTemplateFlow.ProcessTemplateId
	AND DbProcess.StepId = DbProcessTemplateFlow.ProcessTemplateFromStepId
JOIN DbProcessTemplateFlowCondition
	ON DbProcessTemplateFlow.Id = DbProcessTemplateFlowCondition.ProcessTemplateFlowId
JOIN DbUserRelation
	ON DbUserRelation.FromUserId = DbProcess.CreatorId
JOIN DbProcessTemplateLanguage
	ON DbProcess.ProcessTemplateId = DbProcessTemplateLanguage.ProcessTemplateId
WHERE StepId <> 0
	AND DbUserRelation.TypeId = 1
	AND DbUserRelation.ToUserId = @CurrentUser
	AND DbProcessTemplateFlowCondition.ProcessTemplateConditionTypeId = 14
