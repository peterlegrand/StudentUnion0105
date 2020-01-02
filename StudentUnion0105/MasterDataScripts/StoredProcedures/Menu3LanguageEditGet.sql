CREATE PROCEDURE Menu3LanguageEditGet (@LId int)
AS
SELECT
	dbMenu3.Id OId
	, Creator.UserName Creator
	, dbMenu3Language.CreatedDate
	, Modifier.UserName Modifier
	, dbMenu3Language.ModifiedDate
	, dbMenu3Language.Id LId
	, ISNULL(dbMenu3Language.MenuName,'') MenuName
	, ISNULL(dbMenu3Language.MouseOver,'') MouseOver
	, ISNULL(dbLanguage.LanguageName,'') Language
	, 0 PId
FROM dbMenu3Language
JOIN dbMenu3
	ON dbMenu3.Id = dbMenu3Language.Menu3Id
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbMenu3.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbMenu3.ModifierId) = Modifier.Id
JOIN dbLanguage
	ON dbLanguage.Id = dbMenu3Language.LanguageId
WHERE dbMenu3Language.Id=@LId

