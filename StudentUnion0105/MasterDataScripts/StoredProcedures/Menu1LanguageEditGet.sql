CREATE PROCEDURE Menu1LanguageEditGet (@LId int)
AS
SELECT
	dbMenu1.Id OId
	, Creator.UserName Creator
	, dbMenu1Language.CreatedDate
	, Modifier.UserName Modifier
	, dbMenu1Language.ModifiedDate
	, dbMenu1Language.Id LId
	, ISNULL(dbMenu1Language.MenuName,'') MenuName
	, ISNULL(dbMenu1Language.MouseOver,'') MouseOver
	, ISNULL(dbLanguage.LanguageName,'') Language
	, 0 PId
FROM dbMenu1Language
JOIN dbMenu1
	ON dbMenu1.Id = dbMenu1Language.Menu1Id
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbMenu1.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbMenu1.ModifierId) = Modifier.Id
JOIN dbLanguage
	ON dbLanguage.Id = dbMenu1Language.LanguageId
WHERE dbMenu1Language.Id=@LId

