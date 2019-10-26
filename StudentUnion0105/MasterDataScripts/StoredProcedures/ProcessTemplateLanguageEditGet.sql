CREATE PROCEDURE ProcessTemplateLanguageEditGet (@Id int)
AS
SELECT
	dbProcessTemplate.Id 
	, Creator.UserName Creator
	, dbProcessTemplateLanguage.CreatedDate
	, Modifier.UserName Modifier
	, dbProcessTemplateLanguage.ModifiedDate
	, dbProcessTemplateLanguage.Id LId
	, dbProcessTemplateLanguage.Name
	, dbProcessTemplateLanguage.Description
	, dbProcessTemplateLanguage.MouseOver
	, dbProcessTemplateLanguage.MenuName
FROM dbProcessTemplateLanguage
JOIN dbProcessTemplate
	ON dbProcessTemplate.Id = dbProcessTemplateLanguage.ProcessTemplateId
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbProcessTemplateLanguage.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbProcessTemplateLanguage.ModifierId) = Modifier.Id
WHERE dbProcessTemplateLanguage.Id=@Id

