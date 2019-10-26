CREATE PROCEDURE ProcessTemplateFlowLanguageEditGet (@Id int)
AS
SELECT
	dbProcessTemplateFlow.Id 
	, Creator.UserName Creator
	, dbProcessTemplateFlowLanguage.CreatedDate
	, Modifier.UserName Modifier
	, dbProcessTemplateFlowLanguage.ModifiedDate
	, dbProcessTemplateFlowLanguage.Id LId
	, dbProcessTemplateFlowLanguage.Name
	, dbProcessTemplateFlowLanguage.Description
	, dbProcessTemplateFlowLanguage.MouseOver
	, dbProcessTemplateFlowLanguage.MenuName
FROM dbProcessTemplateFlowLanguage
JOIN dbProcessTemplateFlow
	ON dbProcessTemplateFlow.Id = dbProcessTemplateFlowLanguage.FlowId
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbProcessTemplateFlowLanguage.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbProcessTemplateFlowLanguage.ModifierId) = Modifier.Id
WHERE dbProcessTemplateFlowLanguage.Id=@Id

