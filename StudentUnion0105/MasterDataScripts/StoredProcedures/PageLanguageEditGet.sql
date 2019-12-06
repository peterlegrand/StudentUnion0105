CREATE PROCEDURE PageLanguageEditGet (@LId int)
AS
SELECT
	dbPage.Id OId
	, Creator.UserName Creator
	, dbPageLanguage.CreatedDate
	, Modifier.UserName Modifier
	, dbPageLanguage.ModifiedDate
	, dbPageLanguage.Id LId
	, ISNULL(dbPageLanguage.Name,'') Name
	, ISNULL(dbPageLanguage.Description,'') Description
	, ISNULL(dbPageLanguage.MouseOver,'') MouseOver
	, ISNULL(dbPageLanguage.MenuName,'') MenuName
	, ISNULL(dbLanguage.LanguageName,'') Language
	, 0 PId
FROM dbPageLanguage
JOIN dbPage
	ON dbPage.Id = dbPageLanguage.PageId
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbPage.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbPage.ModifierId) = Modifier.Id
JOIN dbLanguage
	ON dbLanguage.Id = dbPageLanguage.LanguageId
WHERE dbPageLanguage.Id=@LId

