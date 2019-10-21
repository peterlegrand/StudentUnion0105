CREATE PROCEDURE ProcessTemplateFlowIndexSelect (@LanguageId int)
AS 
SELECT dbProcessTemplateFlow.Id
	, dbProcessTemplateFlowLanguage.LanguageId
	, dbProcessTemplateFlow.ProcessTemplateId
	, dbProcessTemplateFlowLanguage.Name
	, dbProcessTemplateFlowLanguage.MouseOver
	, dbProcessTemplateFlowLanguage.MenuName
	, FromField.Name FromName
	, ToField.Name = ToName
FROM dbProcessTemplateFlow
JOIN dbProcessTemplateFlowLanguage
	ON dbProcessTemplateFlow.Id = dbProcessTemplateFlowLanguage.FlowId
JOIN dbProcessTemplateFieldLanguage FromField
	ON FromField.ProcessTemplateFieldId = dbProcessTemplateFlow.ProcessTemplateFromStepId
JOIN dbProcessTemplateFieldLanguage ToField
	ON ToField.ProcessTemplateFieldId = dbProcessTemplateFlow.ProcessTemplateToStepId
WHERE dbProcessTemplateFlowLanguage.LanguageId = @LanguageId
ORDER BY 
dbProcessTemplateFlowLanguage.Name


