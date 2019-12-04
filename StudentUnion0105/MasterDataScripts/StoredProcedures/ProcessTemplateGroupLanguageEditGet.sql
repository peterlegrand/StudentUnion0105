CREATE PROCEDURE ProcessTemplateGroupLanguageEditGet (@LId int)
AS
SELECT
	dbProcessTemplateGroup.Id OId
	, Creator.UserName Creator
	, dbProcessTemplateGroupLanguage.CreatedDate
	, Modifier.UserName Modifier
	, dbProcessTemplateGroupLanguage.ModifiedDate
	, dbProcessTemplateGroupLanguage.Id LId
	, ISNULL(dbProcessTemplateGroupLanguage.Name,'') Name
	, ISNULL(dbProcessTemplateGroupLanguage.Description,'') Description
	, ISNULL(dbProcessTemplateGroupLanguage.MouseOver,'') MouseOver
	, ISNULL(dbProcessTemplateGroupLanguage.MenuName,'') MenuName
	, ISNULL(dbLanguage.LanguageName,'') Language
	, 0 PId
FROM dbProcessTemplateGroupLanguage
JOIN dbProcessTemplateGroup
	ON dbProcessTemplateGroup.Id = dbProcessTemplateGroupLanguage.ProcessTemplateGroupId
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbProcessTemplateGroupLanguage.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbProcessTemplateGroupLanguage.ModifierId) = Modifier.Id
JOIN dbLanguage
	ON dbLanguage.Id = dbClassificationLanguage.LanguageId
WHERE dbProcessTemplateGroupLanguage.Id=@LId

