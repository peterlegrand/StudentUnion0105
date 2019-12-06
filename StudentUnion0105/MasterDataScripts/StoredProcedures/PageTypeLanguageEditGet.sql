CREATE PROCEDURE PageTypeLanguageEditGet (@LId int)
AS
SELECT
	dbPageType.Id OId
	, Creator.UserName Creator
	, dbPageTypeLanguage.CreatedDate
	, Modifier.UserName Modifier
	, dbPageTypeLanguage.ModifiedDate
	, dbPageTypeLanguage.Id LId
	, ISNULL(dbPageTypeLanguage.Name,'') Name
	, ISNULL(dbPageTypeLanguage.Description,'') Description
	, ISNULL(dbPageTypeLanguage.MouseOver,'') MouseOver
	, ISNULL(dbPageTypeLanguage.MenuName,'') MenuName
	, ISNULL(dbLanguage.LanguageName,'') Language
	, 0 PId
FROM dbPageTypeLanguage
JOIN dbPageType
	ON dbPageType.Id = dbPageTypeLanguage.PageTypeId
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbPageTypeLanguage.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbPageTypeLanguage.ModifierId) = Modifier.Id
JOIN dbLanguage
	ON dbLanguage.Id = dbPageTypeLanguage.LanguageId
WHERE dbPageTypeLanguage.Id=@LId

