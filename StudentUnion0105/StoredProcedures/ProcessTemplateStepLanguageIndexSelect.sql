CREATE PROCEDURE ProcessTemplateStepLanguageIndexSelect (@Id int)
AS 
SELECT dbProcessTemplateStepLanguage.Id
	, dbProcessTemplateStep.Id
	, dbLanguage.LanguageName
	, dbProcessTemplateStepLanguage.Name
	, dbProcessTemplateStepLanguage.MouseOver
	, dbProcessTemplateStepLanguage.MenuName
	, Creator.UserName Creator
	, Modifier.UserName Modifier
	, dbProcessTemplateStepLanguage.CreatedDate
	, dbProcessTemplateStepLanguage.ModifiedDate
FROM dbProcessTemplateStep
JOIN dbProcessTemplateStepLanguage
	ON dbProcessTemplateStep.Id = dbProcessTemplateStepLanguage.StepId
JOIN dbLanguage
	ON dbLanguage.Id = dbProcessTemplateStepLanguage.LanguageId
JOIN AspNetUsers Creator
	ON CAST( dbProcessTemplateStepLanguage.CreatorId as nvarchar(450))= Creator.Id
JOIN AspNetUsers Modifier
	ON CAST( dbProcessTemplateStepLanguage.CreatorId as nvarchar(450))= Modifier.Id
WHERE dbProcessTemplateStepLanguage.StepId = @Id
ORDER BY 
dbProcessTemplateStepLanguage.Name




