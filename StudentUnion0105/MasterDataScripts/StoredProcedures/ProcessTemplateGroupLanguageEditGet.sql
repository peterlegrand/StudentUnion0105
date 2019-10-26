CREATE PROCEDURE ProcessTemplateGroupLanguageEditGet (@Id int)
AS
SELECT
	dbProcessTemplateGroup.Id 
	, Creator.UserName Creator
	, dbProcessTemplateGroupLanguage.CreatedDate
	, Modifier.UserName Modifier
	, dbProcessTemplateGroupLanguage.ModifiedDate
	, dbProcessTemplateGroupLanguage.Id LId
	, dbProcessTemplateGroupLanguage.Name
	, dbProcessTemplateGroupLanguage.Description
	, dbProcessTemplateGroupLanguage.MouseOver
	, dbProcessTemplateGroupLanguage.MenuName
FROM dbProcessTemplateGroupLanguage
JOIN dbProcessTemplateGroup
	ON dbProcessTemplateGroup.Id = dbProcessTemplateGroupLanguage.ProcessTemplateGroupId
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbProcessTemplateGroupLanguage.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbProcessTemplateGroupLanguage.ModifierId) = Modifier.Id
WHERE dbProcessTemplateGroupLanguage.Id=@Id

