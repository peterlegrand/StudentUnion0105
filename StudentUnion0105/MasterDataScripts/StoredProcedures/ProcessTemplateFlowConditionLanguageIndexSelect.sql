CREATE PROCEDURE ProcessTemplateFlowConditionLanguageIndexSelect (@Id int)
AS 
SELECT dbProcessTemplateFlowConditionLanguage.Id
	, dbProcessTemplateFlowCondition.Id
	, dbLanguage.LanguageName
	, dbProcessTemplateFlowConditionLanguage.Name
	, dbProcessTemplateFlowConditionLanguage.MouseOver
	, dbProcessTemplateFlowConditionLanguage.MenuName
	, Creator.UserName Creator
	, Modifier.UserName Modifier
	, dbProcessTemplateFlowConditionLanguage.CreatedDate
	, dbProcessTemplateFlowConditionLanguage.ModifiedDate
FROM dbProcessTemplateFlowCondition
JOIN dbProcessTemplateFlowConditionLanguage
	ON dbProcessTemplateFlowCondition.Id = dbProcessTemplateFlowConditionLanguage.FlowConditionId
JOIN dbLanguage
	ON dbLanguage.Id = dbProcessTemplateFlowConditionLanguage.LanguageId
JOIN AspNetUsers Creator
	ON CAST( dbProcessTemplateFlowConditionLanguage.CreatorId as nvarchar(450))= Creator.Id
JOIN AspNetUsers Modifier
	ON CAST( dbProcessTemplateFlowConditionLanguage.CreatorId as nvarchar(450))= Modifier.Id
WHERE dbProcessTemplateFlowConditionLanguage.FlowConditionId = @Id
ORDER BY 
dbProcessTemplateFlowConditionLanguage.Name




