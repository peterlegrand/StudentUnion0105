CREATE PROCEDURE ProcessTemplateFlowLanguageEditGet (@LId int)
AS
SELECT
	dbProcessTemplateFlow.Id OId
	, Creator.UserName Creator
	, dbProcessTemplateFlowLanguage.CreatedDate
	, Modifier.UserName Modifier
	, dbProcessTemplateFlowLanguage.ModifiedDate
	, dbProcessTemplateFlowLanguage.Id LId
	, ISNULL(dbProcessTemplateFlowLanguage.Name,'') Name
	, ISNULL(dbProcessTemplateFlowLanguage.Description,'') Description
	, ISNULL(dbProcessTemplateFlowLanguage.MouseOver,'') MouseOver
	, ISNULL(dbProcessTemplateFlowLanguage.MenuName,'') MenuName
	, ISNULL(dbLanguage.LanguageName,'') Language
	, dbProcessTemplateFlow.ProcessTemplateId PId
FROM dbProcessTemplateFlowLanguage
JOIN dbProcessTemplateFlow
	ON dbProcessTemplateFlow.Id = dbProcessTemplateFlowLanguage.FlowId
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbProcessTemplateFlowLanguage.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbProcessTemplateFlowLanguage.ModifierId) = Modifier.Id
JOIN dbLanguage
	ON dbLanguage.Id = dbClassificationLanguage.LanguageId
WHERE dbProcessTemplateFlowLanguage.Id=@LId

