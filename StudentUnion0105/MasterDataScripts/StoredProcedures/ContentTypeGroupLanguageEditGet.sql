CREATE PROCEDURE ContentTypeGroupLanguageEditGet (@LId int)
AS
SELECT
	dbContentTypeGroup.Id OId
	, Creator.UserName Creator
	, dbContentTypeGroupLanguage.CreatedDate
	, Modifier.UserName Modifier
	, dbContentTypeGroupLanguage.ModifiedDate
	, dbContentTypeGroupLanguage.Id LId
	, ISNULL(dbContentTypeGroupLanguage.Name,'') Name
	, ISNULL(dbContentTypeGroupLanguage.Description,'') Description
	, ISNULL(dbContentTypeGroupLanguage.MouseOver,'') MouseOver
	, ISNULL(dbContentTypeGroupLanguage.MenuName,'') MenuName
	, ISNULL(dbLanguage.LanguageName,'') Language
	, 0 PId
FROM dbContentTypeGroupLanguage
JOIN dbContentTypeGroup
	ON dbContentTypeGroup.Id = dbContentTypeGroupLanguage.ContentTypeGroupId
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbContentTypeGroup.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbContentTypeGroup.ModifierId) = Modifier.Id
JOIN dbLanguage
	ON dbLanguage.Id = dbContentTypeGroupLanguage.LanguageId
WHERE dbContentTypeGroupLanguage.Id=@LId

