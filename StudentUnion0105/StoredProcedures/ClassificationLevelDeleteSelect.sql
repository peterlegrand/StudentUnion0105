CREATE PROCEDURE ClassificationLevelDeleteSelect (@Id int, @LanguageId int)
AS
SELECT 
	dbClassificationLevel.Id
	, dbClassificationLevelLanguage.LanguageId
	, 0 ParentId
	, dbClassificationLevelLanguage.Name
	, dbClassificationLevelLanguage.Description
	, dbClassificationLevelLanguage.MouseOver
	, dbClassificationLevelLanguage.MenuName
	, '' Status
	, 0 Int1
	, 0 Int2
	, CAST(1 as bit) Bool1
	, CAST(1 as bit) Bool2
	, 0 IntNull1
	, 0 IntNull2
	, Creator.UserName Creator
	, Modifier.UserName Modifier
	, dbclassificationlevel.CreatedDate
	, dbclassificationlevel.ModifiedDate
FROM dbClassificationLevel
JOIN dbClassificationLevelLanguage
	ON dbClassificationLevel.Id = dbClassificationLevelLanguage.ClassificationLevelId
JOIN dbLanguage
	ON dbClassificationLevelLanguage.LanguageId = dbLanguage.Id
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbClassificationLevel.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbClassificationLevel.CreatorId) = Modifier.Id
WHERE dbClassificationLevel.Id = @Id AND dbClassificationLevelLanguage.LanguageId = @LanguageId
GO

