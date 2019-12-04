CREATE PROCEDURE ProcessTemplateFieldLanguageEditGet (@LId int)
AS
SELECT
	dbProcessTemplateField.Id OId
	, Creator.UserName Creator
	, dbProcessTemplateFieldLanguage.CreatedDate
	, Modifier.UserName Modifier
	, dbProcessTemplateFieldLanguage.ModifiedDate
	, dbProcessTemplateFieldLanguage.Id LId
	, ISNULL(dbProcessTemplateFieldLanguage.Name,'') Name
	, ISNULL(dbProcessTemplateFieldLanguage.Description,'') Description
	, ISNULL(dbProcessTemplateFieldLanguage.MouseOver,'') MouseOver
	, ISNULL(dbProcessTemplateFieldLanguage.MenuName,'') MenuName
	, ISNULL(dbLanguage.LanguageName,'') Language
	, dbProcessTemplateField.ProcessTemplateId PId
FROM dbProcessTemplateFieldLanguage
JOIN dbProcessTemplateField
	ON dbProcessTemplateField.Id = dbProcessTemplateFieldLanguage.ProcessTemplateFieldId
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbProcessTemplateFieldLanguage.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbProcessTemplateFieldLanguage.ModifierId) = Modifier.Id
JOIN dbLanguage
	ON dbLanguage.Id = dbClassificationLanguage.LanguageId
WHERE dbProcessTemplateFieldLanguage.Id=@LId

