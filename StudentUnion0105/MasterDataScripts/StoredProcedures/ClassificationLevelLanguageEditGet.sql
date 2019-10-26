CREATE PROCEDURE ClassificationLevelLanguageEditGet (@Id int)
AS
SELECT
	dbClassificationLevel.Id 
	, Creator.UserName Creator
	, dbClassificationLevelLanguage.CreatedDate
	, Modifier.UserName Modifier
	, dbClassificationLevelLanguage.ModifiedDate
	, dbClassificationLevelLanguage.Id LId
	, dbClassificationLevelLanguage.Name
	, dbClassificationLevelLanguage.Description
	, dbClassificationLevelLanguage.MouseOver
	, dbClassificationLevelLanguage.MenuName
FROM dbClassificationLevelLanguage
JOIN dbClassificationLevel
	ON dbClassificationLevel.Id = dbClassificationLevelLanguage.ClassificationLevelId
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbClassificationLevel.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbClassificationLevel.ModifierId) = Modifier.Id
WHERE dbClassificationLevelLanguage.Id=@Id

