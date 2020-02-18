CREATE PROCEDURE ContentCreate1GetContentType (@CurrentUser nvarchar(50), @PId int) 
AS
DECLARE @SecurityLevel int;
DECLARE @LanguageId int;
SELECT @LanguageId = AspNetUsers.DefaultLanguageId , @SecurityLevel = SecurityLevel FROM AspNetUsers WHERE Id = @CurrentUser;

SELECT * FROM (
SELECT 
	DbContentType.ContentTypeGroupId PId
	, DbContentType.Id 
	, DbContentTypeLanguage.Name
FROM DbContentType
JOIN DbContentTypeLanguage
	ON DbContentType.Id = DbContentTypeLanguage.ContentTypeId
WHERE LanguageId = @LanguageId
	AND DbContentType.ContentTypeGroupId = @PId
	AND DbContentType.SecurityLevel <= @SecurityLevel
	AND DbContentType.ProcessTemplateId = 0

UNION ALL
SELECT 
	DbContentType.ContentTypeGroupId PId
	, DbContentType.Id 
	, DbContentTypeLanguage.Name
FROM DbContentType
JOIN DbContentTypeLanguage
	ON DbContentType.Id = DbContentTypeLanguage.ContentTypeId
JOIN dbProcessTemplateFlow
	ON DbContentType.ProcessTemplateId = dbProcessTemplateFlow.ProcessTemplateId
JOIN DbProcessTemplateFlowCondition
	ON DbProcessTemplateFlow.Id = DbProcessTemplateFlowCondition.ProcessTemplateFlowId
WHERE dbProcessTemplateFlow.ProcessTemplateFromStepId = 0
	AND DbProcessTemplateFlowCondition.ProcessTemplateConditionTypeId = 15
	AND DbProcessTemplateFlowCondition.ProcessTemplateFlowConditionInt <= @SecurityLevel
	AND LanguageId = @LanguageId
	AND DbContentType.ContentTypeGroupId = @PId
	AND DbContentType.SecurityLevel <= @SecurityLevel
	AND DbContentType.ProcessTemplateId <> 0

UNION ALL

SELECT 
	DbContentType.ContentTypeGroupId PId
	, DbContentType.Id 
	, DbContentTypeLanguage.Name
FROM DbContentType
JOIN DbContentTypeLanguage
	ON DbContentType.Id = DbContentTypeLanguage.ContentTypeId
JOIN dbProcessTemplateFlow
	ON DbContentType.ProcessTemplateId = dbProcessTemplateFlow.ProcessTemplateId
WHERE dbProcessTemplateFlow.ProcessTemplateFromStepId = 0
	AND LanguageId = @LanguageId
	AND DbContentType.ContentTypeGroupId = @PId
	AND DbContentType.SecurityLevel <= @SecurityLevel
	AND DbContentType.ProcessTemplateId <> 0
	AND DbProcessTemplateFlow.Id NOT IN (
		select DbProcessTemplateFlowCondition.ProcessTemplateFlowId from DbProcessTemplateFlowCondition WHERE DbProcessTemplateFlowCondition.ProcessTemplateConditionTypeId = 15
)) AllResults
ORDER BY Name