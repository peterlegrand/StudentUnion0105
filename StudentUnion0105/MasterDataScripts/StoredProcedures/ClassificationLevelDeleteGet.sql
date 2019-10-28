CREATE PROCEDURE ClassificationLevelDeleteGet (@LanguageId int, @Id int)
AS
SELECT
	dbClassificationLevel.Id 
	, dbClassificationLevel.Alphabetically
	, dbClassificationLevel.CanLink
	, dbClassificationLevel.InDropDown
	, dbClassificationLevel.OnTheFly
	, dbClassificationLevel.Sequence
	, Creator.UserName Creator
	, dbClassificationLevel.CreatedDate
	, Modifier.UserName Modifier
	, dbClassificationLevel.ModifiedDate
	, dbClassificationLevelLanguage.Id LId
	, dbClassificationLevelLanguage.Name
	, dbClassificationLevelLanguage.Description
	, dbClassificationLevelLanguage.MouseOver
	, dbClassificationLevelLanguage.MenuName
FROM dbClassificationLevelLanguage
JOIN dbClassificationLevel 
	ON dbClassificationLevelLanguage.ClassificationLevelId = dbClassificationLevel.Id
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbClassificationLevel.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbClassificationLevel.ModifierId) = Modifier.Id
WHERE dbClassificationLevelLanguage.LanguageId = @LanguageId
	AND dbClassificationLevel.Id = @Id
