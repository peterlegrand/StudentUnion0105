CREATE PROCEDURE Menu3DeleteGet (@LanguageId int, @Id int)
AS
SELECT
	dbMenu3.Id OId 
	, dbMenuType.Name TypeName
	, ISNULL(DbClassificationLanguage.Name, '') ClassificationName
	, dbMenu3.Controller
	, dbMenu3.Action
	, dbMenu3.FeatureId
	, dbMenu3.DestinationId
	, Creator.UserName Creator
	, dbMenu3.CreatedDate
	, Modifier.UserName Modifier
	, dbMenu3.ModifiedDate
	, dbMenu3Language.Id LId
	, dbMenu3Language.MenuName
	, dbMenu3Language.MouseOver
FROM dbMenu3Language
JOIN dbMenu3 
	ON dbMenu3Language.Menu3Id = dbMenu3.Id
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbMenu3.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbMenu3.ModifierId) = Modifier.Id
JOIN dbMenuType
	ON dbMenuType.Id = dbMenu3.MenuTypeId
LEFT JOIN DbClassificationLanguage
	ON dbMenu3.ClassificationId = DbClassificationLanguage.ClassificationId
WHERE dbMenu3Language.LanguageId = @LanguageId
	AND DbClassificationLanguage.LanguageId = @LanguageId
	AND dbMenu3.Id = @Id


