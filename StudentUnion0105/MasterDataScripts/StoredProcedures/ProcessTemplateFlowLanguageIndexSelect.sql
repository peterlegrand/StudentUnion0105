CREATE PROCEDURE ProcessTemplateFlowLanguageIndexSelect (@Id int)
AS 
SELECT dbProcessTemplateFlowLanguage.Id
	, dbProcessTemplateFlow.Id
	, dbLanguage.LanguageName
	, dbProcessTemplateFlowLanguage.Name
	, dbProcessTemplateFlowLanguage.MouseOver
	, dbProcessTemplateFlowLanguage.MenuName
	, Creator.UserName Creator
	, Modifier.UserName Modifier
	, dbProcessTemplateFlowLanguage.CreatedDate
	, dbProcessTemplateFlowLanguage.ModifiedDate
FROM dbProcessTemplateFlow
JOIN dbProcessTemplateFlowLanguage
	ON dbProcessTemplateFlow.Id = dbProcessTemplateFlowLanguage.FlowId
JOIN dbLanguage
	ON dbLanguage.Id = dbProcessTemplateFlowLanguage.LanguageId
JOIN AspNetUsers Creator
	ON CAST( dbProcessTemplateFlowLanguage.CreatorId as nvarchar(450))= Creator.Id
JOIN AspNetUsers Modifier
	ON CAST( dbProcessTemplateFlowLanguage.CreatorId as nvarchar(450))= Modifier.Id
WHERE dbProcessTemplateFlowLanguage.FlowId = @Id
ORDER BY 
dbProcessTemplateFlowLanguage.Name




