CREATE PROCEDURE ProcessTemplateLanguageEditGet (@LId int)
AS
SELECT
	dbProcessTemplate.Id OId
	, Creator.UserName Creator
	, dbProcessTemplateLanguage.CreatedDate
	, Modifier.UserName Modifier
	, dbProcessTemplateLanguage.ModifiedDate
	, dbProcessTemplateLanguage.Id LId
	, ISNULL(dbProcessTemplateLanguage.Name,'') Name
	, ISNULL(dbProcessTemplateLanguage.Description,'') Description
	, ISNULL(dbProcessTemplateLanguage.MouseOver,'') MouseOver
	, ISNULL(dbProcessTemplateLanguage.MenuName,'') MenuName
	, ISNULL(dbLanguage.LanguageName,'') Language
	, 0 PId
FROM dbProcessTemplateLanguage
JOIN dbProcessTemplate
	ON dbProcessTemplate.Id = dbProcessTemplateLanguage.ProcessTemplateId
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbProcessTemplateLanguage.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbProcessTemplateLanguage.ModifierId) = Modifier.Id
JOIN dbLanguage
	ON dbLanguage.Id = dbClassificationLanguage.LanguageId
WHERE dbProcessTemplateLanguage.Id=@LId

