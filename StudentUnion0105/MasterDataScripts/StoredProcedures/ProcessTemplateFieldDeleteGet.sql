CREATE PROCEDURE ProcessTemplateFieldDeleteGet (@LanguageId int, @Id int)
AS
SELECT
	dbProcessTemplateField.Id 
	, Creator.UserName Creator
	, dbProcessTemplate.CreatedDate
	, Modifier.UserName Modifier
	, dbProcessTemplate.ModifiedDate
	, dbProcessTemplateFieldLanguage.Id LId
	, dbProcessTemplateFieldLanguage.Name
	, dbProcessTemplateFieldLanguage.Description
	, dbProcessTemplateFieldLanguage.MouseOver
	, dbProcessTemplateFieldLanguage.MenuName
FROM dbProcessTemplateFieldLanguage
JOIN dbProcessTemplateField
	ON dbProcessTemplateField.Id = dbProcessTemplateFieldLanguage.ProcessTemplateFieldId
JOIN dbProcessTemplate
	ON dbProcessTemplate.Id = dbProcessTemplateField.ProcessTemplateId
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbProcessTemplate.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbProcessTemplate.ModifierId) = Modifier.Id
WHERE dbProcessTemplateFieldLanguage.LanguageId = @LanguageId
	AND dbProcessTemplateField.Id = @Id

