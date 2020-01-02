CREATE PROCEDURE Menu2EditGet (@LanguageId int, @Id int)
AS
SELECT
	dbMenu2.Id 
	, dbMenu2.Sequence
	, dbMenu2.ClassificationId
	, dbMenu2.FeatureId
	, dbMenu2.Controller
	, dbMenu2.Action
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
WHERE dbMenu2Language.LanguageId = @LanguageId
	AND dbMenu2.Id = @Id


