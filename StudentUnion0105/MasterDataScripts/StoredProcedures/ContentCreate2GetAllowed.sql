CREATE PROCEDURE ContentCreate2GetAllowed (@CurrentUser nvarchar(50), @Id int)
AS
DECLARE @SecurityLevel int;
DECLARE @LanguageId int;
SELECT @LanguageId = AspNetUsers.DefaultLanguageId , @SecurityLevel = SecurityLevel FROM AspNetUsers WHERE Id = @CurrentUser;

SELECT CASE WHEN COUNT(1) > 0 THEN 1 ELSE 0 END AS [intValue] FROM 
(
SELECT DbContentType.* 
FROM dbContentType
WHERE DbContentType.SecurityLevel <= @SecurityLevel
	AND DbContentType.Id = @Id
	AND DbContentType.ProcessTemplateId = 0

UNION ALL

SELECT 
	DbContentType.*
FROM DbContentType
JOIN dbProcessTemplateFlow
	ON DbContentType.ProcessTemplateId = dbProcessTemplateFlow.ProcessTemplateId
JOIN DbProcessTemplateFlowCondition
	ON DbProcessTemplateFlow.Id = DbProcessTemplateFlowCondition.ProcessTemplateFlowId
WHERE dbProcessTemplateFlow.ProcessTemplateFromStepId = 0
	AND DbProcessTemplateFlowCondition.ProcessTemplateConditionTypeId = 15
	AND DbProcessTemplateFlowCondition.ProcessTemplateFlowConditionInt <= @SecurityLevel
	AND DbContentType.Id = @Id
	AND DbContentType.SecurityLevel <= @SecurityLevel
	AND DbContentType.ProcessTemplateId <> 0

UNION ALL

SELECT 
	DbContentType.*
FROM DbContentType
JOIN dbProcessTemplateFlow
	ON DbContentType.ProcessTemplateId = dbProcessTemplateFlow.ProcessTemplateId
WHERE dbProcessTemplateFlow.ProcessTemplateFromStepId = 0
	AND DbContentType.Id = @Id
	AND DbContentType.SecurityLevel <= @SecurityLevel
	AND DbContentType.ProcessTemplateId <> 0
	AND DbProcessTemplateFlow.Id NOT IN (
		select DbProcessTemplateFlowCondition.ProcessTemplateFlowId from DbProcessTemplateFlowCondition WHERE DbProcessTemplateFlowCondition.ProcessTemplateConditionTypeId = 15)
	) Allresults