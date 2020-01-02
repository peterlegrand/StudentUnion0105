CREATE PROCEDURE Menu1DeleteGet (@LanguageId int, @Id int)
AS
SELECT
	dbMenu1.Id OId 
	, dbMenuType.Name TypeName
	, ISNULL(DbClassificationLanguage.Name, '') ClassificationName
	, dbMenu1.Controller
	, dbMenu1.Action
	, dbMenu1.FeatureId
	, dbMenu1.DestinationId
	, Creator.UserName Creator
	, dbMenu1.CreatedDate
	, Modifier.UserName Modifier
	, dbMenu1.ModifiedDate
	, dbMenu1Language.Id LId
	, dbMenu1Language.MenuName
	, dbMenu1Language.MouseOver
	, DbLanguage.LanguageName
FROM dbMenu1Language
JOIN dbMenu1 
	ON dbMenu1Language.Menu1Id = dbMenu1.Id
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbMenu1.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbMenu1.ModifierId) = Modifier.Id
JOIN dbMenuType
	ON dbMenuType.Id = dbMenu1.MenuTypeId
LEFT JOIN DbClassificationLanguage
	ON dbMenu1.ClassificationId = DbClassificationLanguage.ClassificationId
JOIN DbLanguage
	ON DbLanguage.Id = dbMenu1Language.LanguageId
WHERE dbMenu1Language.LanguageId = @LanguageId
	AND DbClassificationLanguage.LanguageId = @LanguageId
	AND dbMenu1.Id = @Id


