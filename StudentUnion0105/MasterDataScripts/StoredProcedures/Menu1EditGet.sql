CREATE PROCEDURE Menu1EditGet (@LanguageId int, @Id int)
AS
SELECT
	dbMenu1.Id 
	, dbMenu1.Sequence
	, dbMenu1.ClassificationId
	, dbMenu1.FeatureId
	, dbMenu1.Controller
	, dbMenu1.Action
	, dbMenu1.DestinationId
	, Creator.UserName Creator
	, dbMenu1.CreatedDate
	, Modifier.UserName Modifier
	, dbMenu1.ModifiedDate
	, dbMenu1Language.Id LId
	, dbMenu1Language.MenuName
	, dbMenu1Language.MouseOver
FROM dbMenu1Language
JOIN dbMenu1 
	ON dbMenu1Language.Menu1Id = dbMenu1.Id
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbMenu1.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbMenu1.ModifierId) = Modifier.Id
WHERE dbMenu1Language.LanguageId = @LanguageId
	AND dbMenu1.Id = @Id


