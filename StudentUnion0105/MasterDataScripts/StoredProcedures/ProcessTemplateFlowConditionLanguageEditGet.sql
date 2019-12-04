CREATE PROCEDURE ProcessTemplateFlowConditionLanguageEditGet (@LId int)
AS
SELECT
	dbProcessTemplateFlowCondition.Id OId
	, Creator.UserName Creator
	, dbProcessTemplateFlowConditionLanguage.CreatedDate
	, Modifier.UserName Modifier
	, dbProcessTemplateFlowConditionLanguage.ModifiedDate
	, dbProcessTemplateFlowConditionLanguage.Id LId
	, ISNULL(dbProcessTemplateFlowConditionLanguage.Name,'') Name
	, ISNULL(dbProcessTemplateFlowConditionLanguage.Description,'') Description
	, ISNULL(dbProcessTemplateFlowConditionLanguage.MouseOver,'') MouseOver
	, ISNULL(dbProcessTemplateFlowConditionLanguage.MenuName,'') MenuName
	, ISNULL(dbLanguage.LanguageName,'') Language
	, dbProcessTemplateFlowCondition.FlowId PId
FROM dbProcessTemplateFlowConditionLanguage
JOIN dbProcessTemplateFlowCondition
	ON dbProcessTemplateFlowCondition.Id = dbProcessTemplateFlowConditionLanguage.FlowConditionId
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbProcessTemplateFlowConditionLanguage.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbProcessTemplateFlowConditionLanguage.ModifierId) = Modifier.Id
JOIN dbLanguage
	ON dbLanguage.Id = dbClassificationLanguage.LanguageId
WHERE dbProcessTemplateFlowConditionLanguage.Id=@LId

