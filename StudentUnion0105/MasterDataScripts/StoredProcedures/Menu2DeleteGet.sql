CREATE PROCEDURE Menu2DeleteGet (@LanguageId int, @Id int)
AS
SELECT
	dbMenu2.Id OId 
	, dbMenuType.Name TypeName
	, ISNULL(DbClassificationLanguage.Name, '') ClassificationName
	, dbMenu2.Controller
	, dbMenu2.Action
	, dbMenu2.FeatureId
	, dbMenu2.DestinationId
	, Creator.UserName Creator
	, dbMenu2.CreatedDate
	, Modifier.UserName Modifier
	, dbMenu2.ModifiedDate
	, dbMenu2Language.Id LId
	, dbMenu2Language.MenuName
	, dbMenu2Language.MouseOver
FROM dbMenu2Language
JOIN dbMenu2 
	ON dbMenu2Language.Menu2Id = dbMenu2.Id
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbMenu2.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbMenu2.ModifierId) = Modifier.Id
JOIN dbMenuType
	ON dbMenuType.Id = dbMenu2.MenuTypeId
LEFT JOIN DbClassificationLanguage
	ON dbMenu2.ClassificationId = DbClassificationLanguage.ClassificationId
WHERE dbMenu2Language.LanguageId = @LanguageId
	AND DbClassificationLanguage.LanguageId = @LanguageId
	AND dbMenu2.Id = @Id


