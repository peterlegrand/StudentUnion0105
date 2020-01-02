CREATE PROCEDURE Menu2LanguageEditGet (@LId int)
AS
SELECT
	dbMenu2.Id OId
	, Creator.UserName Creator
	, dbMenu2Language.CreatedDate
	, Modifier.UserName Modifier
	, dbMenu2Language.ModifiedDate
	, dbMenu2Language.Id LId
	, ISNULL(dbMenu2Language.MenuName,'') MenuName
	, ISNULL(dbMenu2Language.MouseOver,'') MouseOver
	, ISNULL(dbLanguage.LanguageName,'') Language
	, 0 PId
FROM dbMenu2Language
JOIN dbMenu2
	ON dbMenu2.Id = dbMenu2Language.Menu2Id
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbMenu2.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbMenu2.ModifierId) = Modifier.Id
JOIN dbLanguage
	ON dbLanguage.Id = dbMenu2Language.LanguageId
WHERE dbMenu2Language.Id=@LId

