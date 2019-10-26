CREATE PROCEDURE ProcessTemplateFieldLanguageEditGet (@Id int)
AS
SELECT
	dbProcessTemplateField.Id 
	, Creator.UserName Creator
	, dbProcessTemplateFieldLanguage.CreatedDate
	, Modifier.UserName Modifier
	, dbProcessTemplateFieldLanguage.ModifiedDate
	, dbProcessTemplateFieldLanguage.Id LId
	, dbProcessTemplateFieldLanguage.Name
	, dbProcessTemplateFieldLanguage.Description
	, dbProcessTemplateFieldLanguage.MouseOver
	, dbProcessTemplateFieldLanguage.MenuName
FROM dbProcessTemplateFieldLanguage
JOIN dbProcessTemplateField
	ON dbProcessTemplateField.Id = dbProcessTemplateFieldLanguage.ProcessTemplateFieldId
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbProcessTemplateFieldLanguage.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbProcessTemplateFieldLanguage.ModifierId) = Modifier.Id
WHERE dbProcessTemplateFieldLanguage.Id=@Id

