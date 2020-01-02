CREATE PROCEDURE Menu3EditGet (@LanguageId int, @Id int)
AS
SELECT
	dbMenu3.Id 
	, dbMenu3.Sequence
	, dbMenu3.ClassificationId
	, dbMenu3.FeatureId
	, dbMenu3.Controller
	, dbMenu3.Action
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
WHERE dbMenu3Language.LanguageId = @LanguageId
	AND dbMenu3.Id = @Id


